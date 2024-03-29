﻿using IWNLP.Models;
using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class NounParser : ParserBase
    {
        public Word Parse(string word, string[] text, string wortArtLine)
        {
            if (wortArtLine.Contains("ohne feste Deklination") || wortArtLine.Contains("{{Wortart|Nachname|Deutsch}}") || wortArtLine.Contains("{{Wortart|Vorname|Deutsch}}") || wortArtLine.Contains("{{Wortart|Toponym|Deutsch}}") || wortArtLine.Contains("{{Wortart|Buchstabe|Deutsch}}"))
            {
                return null;
            }
            if (text.Any(x => x.Contains("{{Deutsch adjektivische Deklination")))
            {
                Common.PrintError(word, "Obsolete template '{{Deutsch adjektivische Deklination' is being used.");
            }
            if (text.Any(x => x.Contains("{{Deutsch adjektivisch Übersicht")))
            {
                DeutschAdjektivischUebersichtParser adjektivischUebersichtParser = new DeutschAdjektivischUebersichtParser();
                return adjektivischUebersichtParser.Parse(word, text);
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
            bool wortArtLineGenusIgnored = false; // ignore the specified genus if a line also starts with |Genus
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
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart + 1, flexionSubstantivEnd - 1);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "NounParser");
            for (int i = 0; i < cleanedLines.Count; i++)
            {
                string line = cleanedLines[i];
                if (string.IsNullOrEmpty(line))
                {
                    Console.WriteLine("Empty line in " + word);
                    continue;
                }
                string[] forms = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> noPluralForms = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
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
                int formNumber = 0;
                if (forms[0] != ("Genus"))
                {
                    char formNumberRaw = forms[0].Replace("*", string.Empty).Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Last()[0];
                    if (char.IsDigit(formNumberRaw))
                    {
                        formNumber = int.Parse(formNumberRaw.ToString());
                    }
                }
                forms[0] = forms[0].Trim(); // remove spaces
                if (!forms[0].Contains("Genus") && (forms[0].EndsWith("1") || forms[0].EndsWith("2") || forms[0].EndsWith("3") || forms[0].EndsWith("4")))
                {
                    forms[0] = forms[0].Substring(0, forms[0].Length - 2);
                }
                if (forms[0].StartsWith("Genus"))
                {
                    if (!wortArtLineGenusIgnored)
                    {
                        noun.Genus = new List<Genus>();
                        wortArtLineGenusIgnored = true;
                    }
                    int genusKey = 0;
                    if (forms[0].EndsWith("1")) { genusKey = 1; }
                    else if (forms[0].EndsWith("2")) { genusKey = 2; }
                    else if (forms[0].EndsWith("3")) { genusKey = 3; }
                    else if (forms[0].EndsWith("4")) { genusKey = 4; }
                    Genus genus = Genus.Neutrum;
                    if (forms[1] == "n") { genus = Genus.Neutrum; }
                    else if (forms[1] == "f") { genus = Genus.Femininum; }
                    else if (forms[1] == "m") { genus = Genus.Maskulinum; }
                    else if (forms[1] == "0") { genus = Genus.Pluralwort; }
                    else
                    {
                        Common.PrintError(word, string.Format("NounParser: error while parsing genus in {0}: {1}", word, forms[1]));
                    }
                    if (!noun.Genus.Contains(genus))
                    {
                        noun.Genus.Add(genus);
                    }
                    genusFlexboxMapping.Add(genusKey, genus);
                }
                else if (forms[0].StartsWith("Nominativ"))
                {
                    if (forms[0].Contains("Singular")) { noun.NominativSingular.AddRange(this.GetInflections(forms[1], noun, Case.Nominative, formNumber, genusFlexboxMapping, false)); }
                    else if (forms[0].Contains("Plural")) { noun.NominativPlural.AddRange(this.GetInflections(forms[1], noun, Case.Nominative, formNumber, genusFlexboxMapping, true)); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Genitiv"))
                {
                    if (forms[0].Contains("Singular")) { noun.GenitivSingular.AddRange(this.GetInflections(forms[1], noun, Case.Genitive, formNumber, genusFlexboxMapping, false)); }
                    else if (forms[0].Contains("Plural")) { noun.GenitivPlural.AddRange(this.GetInflections(forms[1], noun, Case.Genitive, formNumber, genusFlexboxMapping, true)); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Dativ"))
                {
                    if (forms[0].Contains("Singular")) { noun.DativSingular.AddRange(this.GetInflections(forms[1], noun, Case.Dative, formNumber, genusFlexboxMapping, false)); }
                    else if (forms[0].Contains("Plural")) { noun.DativPlural.AddRange(this.GetInflections(forms[1], noun, Case.Dative, formNumber, genusFlexboxMapping, true)); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0].StartsWith("Akkusativ"))
                {
                    if (forms[0].Contains("Singular")) { noun.AkkusativSingular.AddRange(this.GetInflections(forms[1], noun, Case.Accusative, formNumber, genusFlexboxMapping, false)); }
                    else if (forms[0].Contains("Plural")) { noun.AkkusativPlural.AddRange(this.GetInflections(forms[1], noun, Case.Accusative, formNumber, genusFlexboxMapping, true)); }
                    else { throw new ArgumentException(); }
                }
                else if (forms[0] == "Artikel") { }
                else
                {
                    Common.PrintError(word, string.Format("NounParser: forms[0] invalid in {0}: {1}", word, forms[0]));
                }
            }
            Stats.Instance.Nouns++;
            return noun;
        }

        protected List<Inflection> GetInflections(string input, Word word, Case wordCase, int formNumber, Dictionary<int, Genus> genusDictionary, bool plural)
        {
            input = input.Trim();
            string[] declensions = input.Split(new string[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" }, StringSplitOptions.RemoveEmptyEntries);
            List<Inflection> inflections = new List<Inflection>();
            foreach (string declension in declensions)
            {
                string cleaned = RemoveBetween(declension, "[", "]").Trim();
                cleaned = cleaned.Replace("/", string.Empty); // fix for missplaced '/' of "<br">
                if (cleaned.EndsWith(","))  // sometimes a comma is also used to separate forms, but it might also be inside on an inflection. therefore it's not possible to split by a comma as well.
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 1);
                }
                List<string> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains(":") || cleaned.Contains("…") || cleaned.Contains("...") || cleaned.Contains(" ,") || cleaned.Contains(", ") || cleaned.Contains("''"))
                {
                    Common.PrintError(word.Text, string.Format("NounParser: contains parenthesis: {0}", word.Text));
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
                        Common.PrintError(word.Text, string.Format("NounParser: braces do not match: {0}", word.Text));
                        return inflections;
                    }
                    if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                    {
                        combinations.Add(cleaned.Substring(1, cleaned.Length - 2));
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Common.PrintError(word.Text, string.Format("NounParser: contains more than 2 braces. at the moment, the parser doesn't support more than 2 braces.: {0}", word.Text));
                    }
                    else
                    {
                        combinations.AddRange(this.CreateAllFormsFromBraces(cleaned));
                    }
                }
                foreach (string finalCombination in combinations)
                {
                    List<string> articles = new List<string>() { "der", "die", "das", "den", "dem", "des" };
                    if (genusDictionary.Count > 0) // the case is specified in the template
                    {
                        string article = string.Empty;
                        if (plural)
                        {
                            switch (wordCase)
                            {
                                case Case.Nominative:
                                case Case.Accusative: article = "die"; break;
                                case Case.Genitive: article = "der"; break;
                                case Case.Dative: article = "den"; break;
                            }
                        }
                        else
                        {
                            // map 1 to 0, if only one form is present
                            if (genusDictionary.Count == 1 && formNumber == 1 && genusDictionary.ContainsKey(0))
                            {
                                formNumber = 0;
                            }
                            Genus genus = genusDictionary[formNumber];
                            switch (genus)
                            {
                                case Genus.Maskulinum:
                                    switch (wordCase)
                                    {
                                        case Case.Nominative: article = "der"; break;
                                        case Case.Genitive: article = "des"; break;
                                        case Case.Dative: article = "dem"; break;
                                        case Case.Accusative: article = "den"; break;
                                    }
                                    break;
                                case Genus.Femininum:
                                    switch (wordCase)
                                    {
                                        case Case.Nominative:
                                        case Case.Accusative: article = "die"; break;
                                        case Case.Genitive:
                                        case Case.Dative: article = "der"; break;
                                    }
                                    break;
                                case Genus.Neutrum:
                                    switch (wordCase)
                                    {
                                        case Case.Nominative:
                                        case Case.Accusative: article = "das"; break;
                                        case Case.Genitive: article = "des"; break;
                                        case Case.Dative: article = "dem"; break;
                                    }
                                    break;
                            }
                        }
                        inflections.Add(new Inflection()
                        {
                            Article = article,
                            InflectedWord = finalCombination
                        });
                    }
                    else
                    {
                        if (finalCombination.Contains(" "))  // check for article
                        {
                            string firstWord = finalCombination.Substring(0, finalCombination.IndexOf(" "));
                            if (articles.Contains(firstWord))
                            {
                                string rest = finalCombination.Substring(finalCombination.IndexOf(" ") + 1).Trim();
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
            }
            return inflections;
        }
    }
}
