﻿using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class AdjectiveParser : ParserBase
    {
        public Word Parse(string word, string[] text, string wortArtLine)
        {
            // https://de.wiktionary.org/wiki/Vorlage:Deklinationsseite_Adjektiv
            Adjective adjective = new Adjective();
            adjective.Text = word;
            adjective.POS = POS.Adjective;
            if (!(text.Select((content, index) => new { Content = content.Trim(), Index = index }).Any(x => x.Content.Contains("{{Deutsch Adjektiv Übersicht"))))
            {
                if (base.OutputDefinitionBlockMissing)
                {
                    Common.PrintError(word, string.Format("AdjectiveParser: No definition block: {0}", word));
                }
                Stats.Instance.AdjectivesTotal++;
                return adjective;
            }
            // Silbentrennung Yoursmile
            //if(text.Any(x => x.Contains("{{Worttrennung}}")))
            //{
            //    var aa = text.First(x => x.Contains("{{Worttrennung}}"));
            //    int indexSilbentrennungStart = text
            //        .Select((content, index) => new { Content = content.Trim(), Index = index })
            //        .First(x => x.Content.Contains("{{Worttrennung}}")).Index;
            //    int nextLine = indexSilbentrennungStart + 1;
            //    if(text[nextLine].Contains("{{Sup.}}"))
            //    {
            //        String supText = "{{Sup.}}";
            //        String superlativ = text[nextLine].Substring(text[nextLine].IndexOf(supText) + supText.Length);
            //        if (superlativ.Contains("·st")) 
            //        {
            //            if (!(superlativ.Contains("alte Rechtschreibung") || superlativ.Contains("Alte Rechtschreibung")))
            //            {
            //                //Console.WriteLine(String.Format("*** [[{0}]]: {1}", word, superlativ));
            //            }
            //            else 
            //            {
            //                Console.WriteLine(String.Format("* [[{0}]]: {1}", word, superlativ));
            //            }

            //        }
            //        //
            //    }

            //}


            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Adjektiv Übersicht") || x.Content.Contains("{{ Deutsch Adjektiv Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart + 1 && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart + 1, flexionSubstantivEnd - 1);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "NounParser");
            for (int i = 0; i < cleanedLines.Count; i++)
            {
                string line = cleanedLines[i];
                string[] forms = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
                if (forms.Length == 1 || (forms.Length == 2 && (noValue.Contains(forms[1].Trim()))))  // No value given
                {
                    continue;
                }
                forms[1] = forms[1].Replace("&nbsp;", " ");
                forms[0] = forms[0].Trim(); // remove spaces
                if (forms[0].StartsWith("Positiv"))
                {
                    adjective.Positiv = this.GetForms(forms[1], adjective);
                }
                else if (forms[0].StartsWith("Komparativ"))
                {
                    if (adjective.Komparativ == null)
                    {
                        adjective.Komparativ = new List<string>();
                    }
                    adjective.Komparativ.AddRange(this.GetForms(forms[1], adjective));
                }
                else if (forms[0].StartsWith("Superlativ"))
                {
                    if (adjective.Superlativ == null)
                    {
                        adjective.Superlativ = new List<string>();
                    }
                    adjective.Superlativ.AddRange(this.GetForms(forms[1], adjective));
                }
                else if (forms[0].StartsWith("keine weiteren Formen"))
                {
                    adjective.KeineWeiterenFormen = true;
                }
                else if (forms[0] == "am" && (forms[1] == "nein" || forms[1] == "0")) { }
                else
                {
                    throw new ArgumentException();
                }
            }
            // Error handling
            if (adjective.Superlativ != null && adjective.Superlativ.Any(x => x.StartsWith("am ")))
            {
                Common.PrintError(word, string.Format("AdjectiveParser: contains a superlative with 'am' {0}", word));
            }
            if (adjective.Superlativ != null && adjective.Superlativ.Any(x => x.Contains("<")))
            {
                Common.PrintError(word, string.Format("AdjectiveParser: contains a '<' {0}", word));
            }
            if (adjective.Komparativ != null && adjective.Komparativ.Any(x => x.Contains("<")))
            {
                Common.PrintError(word, string.Format("AdjectiveParser: contains a '<' {0}", word));
            }
            Stats.Instance.AdjectivesTotal++;
            return adjective;
        }

        protected List<string> GetForms(string input, Word word)
        {
            input = input.Trim();
            string[] declensions = input.Split(new string[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> allForms = new List<string>();
            foreach (string declension in declensions)
            {
                string cleaned = declension.Replace("[[", string.Empty).Replace("]]", string.Empty); // remove braces for internal links with the same name
                cleaned = RemoveBetween(declension, "[", "]").Trim();
                cleaned = cleaned.Replace("/", string.Empty); // fix for missplaced '/' of "<br">
                List<string> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains("''"))
                {
                    word.ParserError = true;
                    Common.PrintError(word.Text, string.Format("AdjectiveParser: contains parenthesis: {0}", word.Text));
                    return allForms;
                }
                if (!cleaned.Contains("("))
                {
                    allForms.Add(cleaned);
                }
                else
                {
                    int countOpeningBraces = cleaned.Count(x => x == '(');
                    int countClosingBraces = cleaned.Count(x => x == ')');
                    if (countOpeningBraces != countClosingBraces)
                    {
                        word.ParserError = true;
                        Common.PrintError(word.Text, string.Format("AdjectiveParser: braces do not match: {0}", word.Text));
                        return allForms;
                    }
                    if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                    {
                        allForms.Add(cleaned.Substring(1, cleaned.Length - 2));
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Common.PrintError(word.Text, string.Format("AdjectiveParser: contains more than 2 braces. at the moment, the parser doesn't support more than 2 braces.: {0}", word.Text));
                    }
                    else
                    {
                        allForms.AddRange(this.CreateAllFormsFromBraces(cleaned));
                    }
                }
            }
            return allForms;
        }
    }
}
