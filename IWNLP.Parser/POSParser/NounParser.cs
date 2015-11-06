using IWNLP.Models;
using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class NounParser : ParserBase
    {

        List<String> blacklist = new List<string>() 
        {
        "Oachkatzlschwoaf"
        };



        public Word Parse(String word, String[] text, String wortArtLine)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            if (wortArtLine.Contains("ohne feste Deklination") || wortArtLine.Contains("{{Wortart|Nachname|Deutsch}}") || wortArtLine.Contains("{{Wortart|Vorname|Deutsch}}") || wortArtLine.Contains("{{Wortart|Toponym|Deutsch}}") || wortArtLine.Contains("{{Wortart|Buchstabe|Deutsch}}"))
            {
                return null;
            }
            if (!text.Any(x => x.Contains("{{Deutsch Substantiv Übersicht")) || text.Any(x => x.Contains("{{Wortart|Eigenname|Deutsch}}")))
            {
                return null;
            }
            Noun noun = new Noun();
            noun.POS = POS.Noun;
            noun.Text = word;
            noun.Genus = new List<Genus>();

            Dictionary<int, Genus> genusFlexboxMapping = new Dictionary<int, Genus>();

            if (wortArtLine.Contains("{{m}}")) { noun.Genus.Add(Genus.Maskulinum); }
            if (wortArtLine.Contains("{{f}}")) { noun.Genus.Add(Genus.Femininum); }
            if (wortArtLine.Contains("{{n}}")) { noun.Genus.Add(Genus.Neutrum); }
            if (wortArtLine.Contains("{{nm}}")) { noun.Genus = noun.Genus.Union(new List<Genus>() { Genus.Neutrum, Genus.Maskulinum }).ToList(); }
            else if (wortArtLine.Contains("{{mf}}") || wortArtLine.Contains("{{fm}}")) { noun.Genus = noun.Genus.Union(new List<Genus>() { Genus.Maskulinum, Genus.Femininum }).ToList(); }
            else if (wortArtLine.Contains("{{nf}}") || wortArtLine.Contains("{{fn}}")) { noun.Genus = noun.Genus.Union(new List<Genus>() { Genus.Neutrum, Genus.Femininum }).ToList(); }





            noun.NominativSingular = new List<Inflection>();
            noun.NominativPlural = new List<Inflection>();
            noun.GenitivSingular = new List<Inflection>();
            noun.GenitivPlural = new List<Inflection>();
            noun.DativSingular = new List<Inflection>();
            noun.DativPlural = new List<Inflection>();
            noun.AkkusativSingular = new List<Inflection>();
            noun.AkkusativPlural = new List<Inflection>();


            //// Silbentrennung Yoursmile
            //if (text.Any(x => x.Contains("{{Worttrennung}}")))
            //{
            //    var aa = text.First(x => x.Contains("{{Worttrennung}}"));
            //    int indexSilbentrennungStart = text
            //        .Select((content, index) => new { Content = content.Trim(), Index = index })
            //        .First(x => x.Content.Contains("{{Worttrennung}}")).Index;
            //    int nextLine = indexSilbentrennungStart + 1;
            //    if (text[nextLine].Contains("{{Pl.}}"))
            //    {
            //        String pluralText = "{{Pl.}}";
            //        String plural = text[nextLine].Substring(text[nextLine].IndexOf(pluralText) + pluralText.Length);
            //        if (plural.Contains("tio·nen"))
            //        {
            //            //if (!(superlativ.Contains("alte Rechtschreibung") || superlativ.Contains("Alte Rechtschreibung")))
            //            //{
            //            //    //Console.WriteLine(String.Format("*** [[{0}]]: {1}", word, superlativ));
            //            //}
            //            //else
            //            //{
            //                Console.WriteLine(String.Format("* [[{0}]]: {1}", word, plural));
            //            //}

            //        }
            //        //
            //    }

            //}

            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Substantiv Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart + 1 && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            for (int i = flexionSubstantivStart + 1; i < flexionSubstantivEnd; i++)
            {
                text[i] = text[i].Trim();
                if (text[i].StartsWith("<!--")) { continue; } // skip comments
                if (!text[i].StartsWith("|"))
                {
                    Console.WriteLine("Error in: " + word + " || " + text[i]);
                }

                String line = text[i].Substring(1).Trim(); // Skip leading "|"
                if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line

                if (line.StartsWith("Bild"))
                {
                    continue; // Skip "Bild"-line
                }
                line = base.CleanLine(line);


                String[] forms = line.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<String> noPluralForms = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };

                if (forms.Length == 1) // no Plural
                {
                    continue;
                }
                else
                {
                    forms[1] = forms[1].Trim();
                    if (forms.Length == 2 && (noPluralForms.Contains(forms[1])))  // No Plural
                    {
                        continue;
                    }
                }

                forms[1] = forms[1].Replace("&nbsp;", " ");

                // retrieve the number from the key, for instance from "|Nominativ Singular 1"
                
                Char formNumberRaw = forms[0].Replace("*", String.Empty).Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries).Last()[0];
                int formNumber = 0;
                if(Char.IsDigit(formNumberRaw))
                {
                    formNumber = int.Parse(formNumberRaw.ToString());
                }
                
                


                forms[0] = forms[0].Trim(); // remove spaces
                if (forms[0].EndsWith("1") || forms[0].EndsWith("2") || forms[0].EndsWith("3") || forms[0].EndsWith("4"))
                {
                    forms[0] = forms[0].Substring(0, forms[0].Length - 2);
                }

                if (forms[0].StartsWith("Genus")) 
                {
                    int genusKey = 0;
                    if (forms[0].EndsWith("1")) { genusKey = 1; }
                    else if (forms[0].EndsWith("2")) { genusKey = 2; }
                    else if (forms[0].EndsWith("3")) { genusKey = 3; }

                    Genus genus = Genus.Neutrum;
                    if(forms[1] == "n"){genus = Genus.Neutrum;}
                    else if(forms[1] == "f"){genus = Genus.Femininum;}
                    else if(forms[1] == "m"){genus = Genus.Maskulinum;}
                    else 
                    {
                        Console.WriteLine(word + ": error while parsing genus: " + forms[1]);
                    }
                    if (!noun.Genus.Contains(genus))
                    {
                        noun.Genus.Add(genus);
                    }
                    if (genusKey != 0) 
                    {
                        genusFlexboxMapping.Add(genusKey, genus);
                    }
                }
                else if (forms[0].StartsWith("Nominativ"))
                {
                    List<Inflection> inflections = this.GetInflections(forms[1], noun, Case.Nominative, formNumber, genusFlexboxMapping);
                    if (forms[0].Contains("Singular")) { noun.NominativSingular.AddRange(inflections); }
                    else if (forms[0].Contains("Plural")) { noun.NominativPlural.AddRange(inflections); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Genitiv"))
                {
                    List<Inflection> inflections = this.GetInflections(forms[1], noun, Case.Genitive, formNumber, genusFlexboxMapping);
                    if (forms[0].Contains("Singular")) { noun.GenitivSingular.AddRange(inflections); }
                    else if (forms[0].Contains("Plural")) { noun.GenitivPlural.AddRange(inflections); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Dativ"))
                {
                    List<Inflection> inflections = this.GetInflections(forms[1], noun, Case.Dative, formNumber, genusFlexboxMapping);
                    if (forms[0].Contains("Singular")) { noun.DativSingular.AddRange(inflections); }
                    else if (forms[0].Contains("Plural")) { noun.DativPlural.AddRange(inflections); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Akkusativ"))
                {
                    List<Inflection> inflections = this.GetInflections(forms[1], noun, Case.Accusative, formNumber, genusFlexboxMapping);
                    if (forms[0].Contains("Singular")) { noun.AkkusativSingular.AddRange(inflections); }
                    else if (forms[0].Contains("Plural")) { noun.AkkusativPlural.AddRange(inflections); }
                    else { throw new ArgumentException(); }
                }
                else if(forms[0] == "Artikel"){}
                else
                {
                    Console.WriteLine("Nounparser: forms[0] invalid in " + word + ": " + forms[0]);
                   // throw new ArgumentException();
                }
            }
            return noun;
        }


        protected List<Inflection> GetInflections(String input, Word word, Case wordCase, int formNumber, Dictionary<int, Genus> genusDictionary)
        {
            input = input.Trim();
            String[] declensions = input.Split(new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" }, StringSplitOptions.RemoveEmptyEntries);
            List<Inflection> inflections = new List<Inflection>();
            foreach (String declension in declensions)
            {
                String cleaned = RemoveBetween(declension, "[", "]").Trim();
                cleaned = cleaned.Replace("/", String.Empty); // fix for missplaced '/' of "<br">
                if (cleaned.EndsWith(","))  // sometimes a comma is also used to separate forms, but it might also be inside on an inflection. therefore it's not possible to split by a comma as well.
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 1);
                }
                List<String> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains(":") || cleaned.Contains("…") || cleaned.Contains("...") || cleaned.Contains(" ,") || cleaned.Contains(", ") || cleaned.Contains("''"))
                {
                    Console.WriteLine("NounParser error (contains parenthesis): " + word.Text);
                    word.ParserError = true;
                    return inflections;

                }
                if (!cleaned.Contains("("))
                {

                    combinations.Add(cleaned);
                }
                else
                {
                    int countOpeningBraces = cleaned.Count(x => x == '(');
                    int countClosingBraces = cleaned.Count(x => x == ')');
                    if (countOpeningBraces != countClosingBraces)
                    {

                        word.ParserError = true;
                        Console.WriteLine(word.Text + ": braces do not match");
                        return inflections;
                    }
                    if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                    {
                        combinations.Add(cleaned.Substring(1, cleaned.Length - 2));
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Console.WriteLine(word.Text + ": containts more than 2 braces. at the moment, the parser doesn't support more than 2 braces.");
                    }
                    else
                    {
                        combinations.AddRange(this.CreateAllFormsFromBraces(cleaned));
                    }
                }
                foreach (String finalCombination in combinations)
                {

                    // TODO: add articles based on genus
                    if (finalCombination.Contains(" "))  // check for article
                    {
                        List<String> articles = new List<string>() { "der", "die", "das", "den", "dem", "des" };

                        String firstWord = finalCombination.Substring(0, finalCombination.IndexOf(" "));

                        if (articles.Contains(firstWord))
                        {
                            String rest = finalCombination.Substring(finalCombination.IndexOf(" ") + 1).Trim();
                            inflections.Add(new Inflection()
                            {
                                Article = firstWord,
                                InflectedWord = rest
                            });
                        }
                        else
                        {
                            inflections.Add(new Inflection()
                            {
                                InflectedWord = finalCombination,
                            });
                        }
                    }
                    else
                    {
                        inflections.Add(new Inflection()
                        {
                            InflectedWord = finalCombination,
                        });
                    }
                }
            }
            return inflections;
        }
    }
}
