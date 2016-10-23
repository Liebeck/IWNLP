using IWNLP.Models;
using IWNLP.Parser.FlexParser;
using IWNLP.Parser.POSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IWNLP.Parser
{
    public class WiktionaryParser
    {
        NounParser nounParser;
        AdjectiveParser adjectiveParser;
        VerbParser verbParser;
        AdjectiveFlexParser adjectiveFlexParser;
        VerbFlexParser verbFlexParser;
        PronounParser pronounParser;
        DeutschSubstantivUebersichtSchParser deutschSubstantivUebersicht;
        List<WikiPOSTag> pronounWikiPosTags = new List<WikiPOSTag>() 
        {
            WikiPOSTag.Demonstrativpronomen,
            WikiPOSTag.Indefinitpronomen,
            WikiPOSTag.Interrogativpronomen,
            WikiPOSTag.Personalpronomen,
            WikiPOSTag.Possessivpronomen,
            WikiPOSTag.Reflexivpronomen,
            WikiPOSTag.Relativpronomen,
            WikiPOSTag.Reziprokpronomen
        };

        public WiktionaryParser()
        {
            nounParser = new NounParser();
            adjectiveParser = new AdjectiveParser();
            verbParser = new VerbParser();
            adjectiveFlexParser = new AdjectiveFlexParser();
            verbFlexParser = new VerbFlexParser();
            pronounParser = new PronounParser();
            deutschSubstantivUebersicht = new DeutschSubstantivUebersichtSchParser();
        }

        public List<Entry> ParseText(String word, String textInput, int wikiID)
        {
            if (GlobalBlacklist.Blacklist.Contains(word))
            {
                return null;
            }
            textInput = ParserBase.RemoveBetween(textInput, "<!--", "-->");
            String[] text = textInput.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (text.Any(x => x.Contains("{{Neuer Eintrag}}")))
            {
                return null;
            }
            List<Entry> words = new List<Entry>();
            // Find all "==" blocks and process them separately
            List<int> languageBlockBegin = text.Select((content, index) => new { Content = content.Trim(), Index = index })
                .Where(x => x.Content.StartsWith("==") && !x.Content.StartsWith("===") && x.Content.EndsWith("==") && !x.Content.EndsWith("==="))
                .Select(x => x.Index).ToList();
            int startIndexLanguageBlock = 0;
            for (int i = 0; i < languageBlockBegin.Count; i++)
            {
                int lastLineLanguageBlock = ((i < languageBlockBegin.Count - 1) ? (languageBlockBegin[i + 1]) : (text.Length)) - 1;
                String[] subArrayLanguageBlock = Common.GetSubArray(text, startIndexLanguageBlock, lastLineLanguageBlock);
                // only parse German text blocks
                if (subArrayLanguageBlock.Any(x => x.Contains("({{Sprache|Deutsch}})")))
                {
                    List<Word> parsedLanguageBlock = ParseLanguageBlock(word, subArrayLanguageBlock);
                    if (parsedLanguageBlock != null) // e.g. the block does not contain German content
                    {
                        words.AddRange(parsedLanguageBlock);
                    }
                }
                else if (subArrayLanguageBlock.Any(x => x.Contains("({{Adjektivdeklination|Deutsch}})")))
                {
                    try
                    {
                        words.Add(adjectiveFlexParser.Parse(word, subArrayLanguageBlock));
                    }
                    catch (InvalidOperationException invalid)
                    {
                        Common.PrintError(word, String.Format("WiktionaryParser: single-line adcjective declination: {0}", word));
                    }
                    catch
                    {
                        Common.PrintError(word, String.Format("WiktionaryParser: Adjective declination error: {0}", word));
                    }
                }
                else if (subArrayLanguageBlock.Any(x => x.Contains("({{Verbkonjugation|Deutsch}})")))
                {
                    List<Models.Flections.VerbConjugation> verbConjugations = verbFlexParser.Parse(word, subArrayLanguageBlock);
                    if (verbConjugations != null)
                    {
                        words.AddRange(verbConjugations);
                    }
                }
                if ((i + 1) < languageBlockBegin.Count)
                {
                    startIndexLanguageBlock = languageBlockBegin[i + 1];
                }
            }
            foreach (Entry wordEntry in words)
            {
                if (wordEntry != null)
                {
                    wordEntry.WiktionaryID = wikiID;
                    wordEntry.Text = word;
                }
            }
            return words;
        }

        /// <summary>
        /// parser for a "=="-block
        /// </summary>
        /// <param name="word"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected List<Word> ParseLanguageBlock(String word, String[] text)
        {
            List<Word> words = new List<Word>();
            // Find all "===" blocks and process them separately
            List<int> wortdefinitionBlockIndices = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.StartsWith("===") && x.Content.EndsWith("===") && !x.Content.StartsWith("====") && !x.Content.EndsWith("====")).Select(x => x.Index).ToList(); // Auf einer Seite kann mehr als ein Wort stehen, z.B. bei "Fremde"
            int startIndexDefinitionBlock = 0;
            for (int i = 0; i < wortdefinitionBlockIndices.Count; i++)
            {
                int lastLineFromDefinitionBlock = ((i < wortdefinitionBlockIndices.Count - 1) ? (wortdefinitionBlockIndices[i + 1]) : (text.Length - 1)) - 1;
                String[] subArrayDefinitionBlock = Common.GetSubArray(text, startIndexDefinitionBlock, lastLineFromDefinitionBlock);
                Word parsedWord = ParseDefinitionTextBlock(word, subArrayDefinitionBlock);
                if (parsedWord != null)
                {
                    words.Add(parsedWord);
                }
                startIndexDefinitionBlock = lastLineFromDefinitionBlock;
            }
            return words;
        }

        /// <summary>
        /// parser for a "==="-block
        /// </summary>
        /// <param name="word"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected Word ParseDefinitionTextBlock(String word, String[] text)
        {
            Word wordObject = null;
            bool deutschesWort = !text.Any(x => x.StartsWith("{{Schweizer und Liechtensteiner Schreibweise"));
            deutschesWort &= !text.Any(x => x.StartsWith("{{Alte Schreibweise"));
            if (text.Any(x => x.Contains("{{Wortart|Deklinierte Form|Deutsch}}")))
            {
                deutschesWort &= text.Any(x => x.Contains("{{Wortart|Artikel|Deutsch}}")); // special case for 'das'
            }
            deutschesWort &= !text.Any(x => x.Contains("{{Wortart|Konjugierte Form|Deutsch}}"));
            deutschesWort &= !text.Any(x => x.Contains("{{Wortart|Sprichwort|Deutsch}}"));
            deutschesWort &= !text.Any(x => x.Contains("{{Wortart|Partizip II|Deutsch}}"));
            deutschesWort &= !text.Any(x => x.Contains("{{Wortart|Redewendung|Deutsch}}"));
            deutschesWort &= !text.Any(x => x.Contains("{{Wortart|Merkspruch|Deutsch}}"));
            deutschesWort &= text.Any(x => x.Contains("{{Wortart|"));
            if (!deutschesWort)
            {
                return null;
            }
            String posTagLine = text.Single(x => x.Contains("{{Wortart|"));
            List<WikiPOSTag> wikiPosTags = this.GetWikiPosTags(posTagLine);
            if (wikiPosTags.Contains(WikiPOSTag.Substantiv))
            {
                if (text.Any(x => x.Contains("{{Deutsch Substantiv Übersicht -sch")))
                {
                    return deutschSubstantivUebersicht.Parse(word, text);
                }
                else
                {
                    return nounParser.Parse(word, text, posTagLine);
                }

            }
            else if (wikiPosTags.Contains(WikiPOSTag.Adjektiv))
            {
                try
                {
                    return adjectiveParser.Parse(word, text, posTagLine);
                }
                catch
                {
                    Common.PrintError(word, String.Format("WiktionaryParser: adjectiveparser error: {0}", word));
                    return null;
                }
            }
            else if (wikiPosTags.Contains(WikiPOSTag.Verb) || wikiPosTags.Contains(WikiPOSTag.Hilfsverb))
            {
                try
                {
                    return verbParser.Parse(word, text, posTagLine);
                }
                catch
                {
                    Common.PrintError(word, String.Format("WiktionaryParser: verbparser error: {0}", word));
                    return null;
                }
            }
            else if (pronounWikiPosTags.Intersect(wikiPosTags).Count() > 0 || wikiPosTags.Contains(WikiPOSTag.Artikel))
            {
                try
                {
                    return pronounParser.Parse(word, text, posTagLine);
                }
                catch
                {
                    Common.PrintError(word, String.Format("WiktionaryParser: pronoun parser error: {0}", word));
                    return null;
                }
            }
            else
            {
                wordObject = new Word();
                switch (wikiPosTags.First())
                {
                    case WikiPOSTag.Substantiv: wordObject.POS = POS.Noun; break;
                    case WikiPOSTag.Adjektiv: wordObject.POS = POS.Adjective; break;
                    case WikiPOSTag.Verb: wordObject.POS = POS.Verb; break;
                    case WikiPOSTag.Toponym: wordObject.POS = POS.Noun; break;
                    case WikiPOSTag.PartizipII: wordObject.POS = POS.Verb; break;
                    case WikiPOSTag.Adverb: wordObject.POS = POS.Adverb; break;
                    case WikiPOSTag.Interjektion: wordObject.POS = POS.X; break;
                    case WikiPOSTag.Präposition: wordObject.POS = POS.ADP; break;
                    case WikiPOSTag.Komparativ: wordObject.POS = POS.Adjective; break;
                    case WikiPOSTag.Indefinitpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Personalpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Demonstrativpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Relativpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Possessivpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Interrogativadverb: wordObject.POS = POS.Adverb; break;
                    case WikiPOSTag.Reziprokpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Negationspartikel: wordObject.POS = POS.PRT; break;
                    case WikiPOSTag.Klitikon: wordObject.POS = POS.X; break;
                    case WikiPOSTag.Numerale: wordObject.POS = POS.NUM; break;
                    case WikiPOSTag.Konjunktion: wordObject.POS = POS.CONJ; break;
                    case WikiPOSTag.Superlativ: wordObject.POS = POS.Adjective; break;
                    case WikiPOSTag.Partikel: wordObject.POS = POS.PRT; break;
                    case WikiPOSTag.Artikel: wordObject.POS = POS.DET; break;
                    case WikiPOSTag.Lokaladverb: wordObject.POS = POS.Adverb; break;
                    case WikiPOSTag.Pronominaladverb: wordObject.POS = POS.Adverb; break;
                    case WikiPOSTag.Pronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Gradpartikel: wordObject.POS = POS.PRT; break;
                    case WikiPOSTag.Antwortpartikel: wordObject.POS = POS.PRT; break;
                    case WikiPOSTag.Postposition: wordObject.POS = POS.ADP; break;
                    case WikiPOSTag.Modalpartikel: wordObject.POS = POS.PRT; break;
                    case WikiPOSTag.Interrogativpronomen: wordObject.POS = POS.Pronoun; break;
                    case WikiPOSTag.Hilfsverb: wordObject.POS = POS.Verb; break;
                    case WikiPOSTag.Temporaladverb: wordObject.POS = POS.Adverb; break;
                    case WikiPOSTag.Reflexivpronomen: wordObject.POS = POS.Pronoun; break;

                    // TODO: enhance mapping
                    //case WikiPOSTag.DeklinierteForm: wordObject.POS = POS.; break;
                    //case WikiPOSTag.KonjugierteForm: wordObject.POS = POS; break;
                    //case WikiPOSTag.SubstantivierterInfinitiv: wordObject.POS = POS; break;
                    //case WikiPOSTag.Abkürzung: wordObject.POS = POS; break;
                    //case WikiPOSTag.Wortverbindung: wordObject.POS = POS; break;
                    //case WikiPOSTag.ErweiterterInfinitiv: wordObject.POS = POS; break;
                    //case WikiPOSTag.Redewendung: wordObject.POS = POS; break;
                    //case WikiPOSTag.Vorname: wordObject.POS = POS; break;
                    //case WikiPOSTag.PartizipI: wordObject.POS = POS; break;
                    //case WikiPOSTag.Nachname: wordObject.POS = POS; break;
                    //case WikiPOSTag.Eigenname: wordObject.POS = POS; break;
                    //case WikiPOSTag.GebundenesLexem: wordObject.POS = POS; break;
                    //case WikiPOSTag.Präfix: wordObject.POS = POS; break;
                    //case WikiPOSTag.Sprichwort: wordObject.POS = POS; break;
                    //case WikiPOSTag.Suffix: wordObject.POS = POS; break;
                    //case WikiPOSTag.Ortsnamengrundwort: wordObject.POS = POS; break;
                    //case WikiPOSTag.Affix: wordObject.POS = POS; break;
                    //case WikiPOSTag.Buchstabe: wordObject.POS = POS; break;
                    //case WikiPOSTag.Kontraktion: wordObject.POS = POS; break;
                    //case WikiPOSTag.Grußformel: wordObject.POS = POS; break;
                    //case WikiPOSTag.Subjunktion: wordObject.POS = POS; break;
                    //case WikiPOSTag.GeflügeltesWort: wordObject.POS = POS; break;
                    //case WikiPOSTag.Onomatopoetikum: wordObject.POS = POS; break;
                    //case WikiPOSTag.Zahlzeichen: wordObject.POS = POS; break;
                    //case WikiPOSTag.Konjunktionaladverb: wordObject.POS = POS; break;
                    //case WikiPOSTag.Zahlklassifikator: wordObject.POS = POS; break;
                    //case WikiPOSTag.Merkspruch: wordObject.POS = POS; break;
                    //case WikiPOSTag.neoklassischesFormativ: wordObject.POS = POS; break;
                    //case WikiPOSTag.Fokuspartikel: wordObject.POS = POS; break;
                    //case WikiPOSTag.Präfixoid: wordObject.POS = POS; break;
                    //case WikiPOSTag.Enklitikon: wordObject.POS = POS; break;
                    //case WikiPOSTag.Vergleichspartikel: wordObject.POS = POS; break;
                    //case WikiPOSTag.Zusammenbildung: wordObject.POS = POS; break;
                    //case WikiPOSTag.abtrennbareVerbpartikel: wordObject.POS = POS; break;
                    //case WikiPOSTag.Formativ: wordObject.POS = POS; break;
                    //case WikiPOSTag.Suffixoid: wordObject.POS = POS; break;
                    //case WikiPOSTag.Mehrwortbenennung: wordObject.POS = POS; break;
                    //case WikiPOSTag.Symbol: wordObject.POS = POS; break;
                    //default: throw new ArgumentException(); break;//return WikiPOSTag.Other; break;
                    default: wordObject.POS = POS.X; break;
                }
                //wordObject.POS = POS.X;
            }

            return wordObject;
        }

        public List<WikiPOSTag> GetWikiPosTags(String input)
        {
            List<WikiPOSTag> wikiPosTags = new List<WikiPOSTag>();
            int startIndex = input.IndexOf("|");
            while (startIndex > 0)
            {
                int endIndex = input.IndexOf("|", startIndex + 1);
                if (endIndex >= 0)
                {
                    wikiPosTags.Add(WikiPOSTagParser.ParsePOSTag(input.Substring(startIndex + 1, endIndex - startIndex - 1)));
                    startIndex = input.IndexOf("|", endIndex + 1);
                }
                else
                {
                    if (input.Substring(startIndex + 1) == "Abkürzung (Deutsch)}} ===")
                    {
                        wikiPosTags.Add(WikiPOSTag.Abkürzung);
                    }
                    break;
                }
            }
            return wikiPosTags;
        }

        public static String GetTextFromPage(String dumpPath, int wiktionaryID)
        {
            using (XmlReader myReader = XmlReader.Create(dumpPath))
            {
                while (myReader.Read())
                {
                    if (myReader.NodeType == XmlNodeType.Element && myReader.Name == "page" && myReader.IsStartElement())
                    {
                        myReader.ReadToFollowing("title");
                        myReader.ReadToFollowing("id");
                        int id = myReader.ReadElementContentAsInt();
                        if (id == wiktionaryID)
                        {
                            myReader.ReadToFollowing("revision");
                            myReader.ReadToFollowing("text");
                            String text = myReader.ReadElementContentAsString();
                            return text;
                        }
                    }
                    var value = myReader.Value;
                }
                throw new ArgumentException("Wiktionary ID not found");
            }
        }
    }
}
