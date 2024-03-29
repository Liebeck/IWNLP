﻿using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class VerbParser : ParserBase
    {
        //{{Deutsch Verb Übersicht
        public bool OutputWrongInflectionForms { get; set; }

        public Word Parse(string word, string[] text, string wortArtLine)
        {
            Verb verb = new Verb();
            verb.Text = word;
            verb.POS = POS.Verb;
            if (!(text.Select((content, index) => new { Content = content.Trim(), Index = index }).Any(x => x.Content.Contains("{{Deutsch Verb Übersicht"))))
            {
                if (base.OutputDefinitionBlockMissing)
                {
                    Common.PrintError(word, string.Format("Verb Parser: No definition block: {0}", word));
                }
                verb.ConjugationBlockMissing = true;
                Stats.Instance.VerbsTotal++;
                return verb;
            }
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Verb Übersicht") || x.Content.Contains("{{ Deutsch Verb Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart + 1 && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart + 1, flexionSubstantivEnd - 1);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "NounParser");
            for (int i = 0; i < cleanedLines.Count; i++)
            {
                string line = cleanedLines[i];
                if (line.Contains("<ref name"))
                {
                    Common.PrintError(word, string.Format("Verb contains '<ref name': {0}", word));
                }
                string[] forms = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
                if (forms.Length == 1 || (forms.Length == 2 && (noValue.Contains(forms[1]))))  // No value given
                {
                    continue;
                }
                forms[1] = forms[1].Replace("&nbsp;", " ");
                forms[0] = forms[0].Trim(); // remove spaces
                if (forms[0].StartsWith("Präsens_ich"))
                {
                    if (verb.Präsens_Ich == null) { verb.Präsens_Ich = new List<string>(); }
                    verb.Präsens_Ich.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Präsens_du"))
                {
                    if (verb.Präsens_Du == null) { verb.Präsens_Du = new List<string>(); }
                    verb.Präsens_Du.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Präsens_er"))
                {
                    if (verb.Präsens_ErSieEs == null) { verb.Präsens_ErSieEs = new List<string>(); }
                    verb.Präsens_ErSieEs.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Präteritum_ich"))
                {
                    if (verb.Präteritum_ich == null) { verb.Präteritum_ich = new List<string>(); }
                    verb.Präteritum_ich.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Konjunktiv II_ich"))
                {
                    if (verb.KonjunktivII_Ich == null) { verb.KonjunktivII_Ich = new List<string>(); }
                    verb.KonjunktivII_Ich.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Imperativ Singular"))
                {
                    List<string> extractedForms = this.GetForms(forms[1], verb);
                    for (int j = 0; j < extractedForms.Count; j++)
                    {
                        if (!extractedForms[j].EndsWith("!"))
                        {
                            extractedForms[j] = extractedForms[j] + "!";
                        }
                    }
                    if (verb.ImperativSingular == null) { verb.ImperativSingular = new List<string>(); }
                    verb.ImperativSingular.AddRange(extractedForms);
                }
                else if (forms[0].StartsWith("Imperativ Plural"))
                {
                    List<string> extractedForms = this.GetForms(forms[1], verb);
                    for (int j = 0; j < extractedForms.Count; j++)
                    {
                        if (!extractedForms[j].EndsWith("!"))
                        {
                            extractedForms[j] = extractedForms[j] + "!";
                        }
                    }
                    if (verb.ImperativPlural == null) { verb.ImperativPlural = new List<string>(); }
                    verb.ImperativPlural.AddRange(extractedForms);
                }
                else if (forms[0].StartsWith("Partizip II"))
                {
                    if (verb.PartizipII == null) { verb.PartizipII = new List<string>(); }
                    verb.PartizipII.AddRange(this.GetForms(forms[1], verb));
                }
                else if (forms[0].StartsWith("Hilfsverb"))
                {
                    if (verb.Hilfsverb == null) { verb.Hilfsverb = new List<string>(); }
                    verb.Hilfsverb.AddRange(this.GetForms(forms[1].Replace(":", string.Empty), verb)); // special case for certain verbs, where the auxiliary verb depends on the meaning of the verb. See [[wandeln]]
                }
                else if (forms[0].StartsWith("Weitere_Konjugationen2"))
                {
                    verb.WeitereKonjugationen2 = forms[1];
                }
                else if (forms[0].StartsWith("Weitere_Konjugationen"))
                {
                    verb.WeitereKonjugationen = forms[1];
                }
                else if (forms[0].StartsWith("unpersönlich"))
                {
                    verb.Unpersönlich = true;
                }
                else if (forms[0].StartsWith("Befehl_du") ||
                    forms[0].StartsWith("Befehl_ihr") ||
                    forms[0].StartsWith("Gegenwart_ihr") ||
                    forms[0].StartsWith("Gegenwart_wir") ||
                    forms[0].StartsWith("Gegenwart_sie") ||
                    forms[0].StartsWith("1.Vergangenheit_du") ||
                    forms[0].StartsWith("1.Vergangenheit_er, sie, es") ||
                    forms[0].StartsWith("1.Vergangenheit_wir") ||
                    forms[0].StartsWith("1.Vergangenheit_ihr") ||
                    forms[0].StartsWith("1.Vergangenheit_sie") ||
                    forms[0].StartsWith("Konjunktiv II_du") ||
                    forms[0].StartsWith("Konjunktiv I_ich") ||
                    forms[0].StartsWith("Partizip I_ich") ||
                    forms[0].StartsWith("Partizip I") ||
                    forms[0].StartsWith("Indikativ II_ich") ||
                    forms[0].StartsWith("Passiv"))
                {
                    if (OutputWrongInflectionForms)
                    {
                        Common.PrintError(word, string.Format("VerbParser: Wrong inflection form: {0}=={1}", word, line));
                    }
                }
                else if (forms[0].StartsWith("Weitere Konjugationen")) { }
                else if (forms[0].StartsWith("Flexion")) { }
                else
                {
                    Common.PrintError(word, string.Format("word {0}=={1}", word, line));
                }
            }
            Stats.Instance.VerbsTotal++;
            return verb;
        }

        protected List<string> GetForms(string input, Word word)
        {
            input = input.Trim();
            input = input.Replace("[[", string.Empty).Replace("]]", string.Empty).Trim(); // remove braces for internal links with the same name
            input = RemoveBetween(input, "[", "]").Trim();
            input = input.Replace("„", string.Empty);
            input = input.Replace("“", string.Empty).Trim();
            string[] declensions = input.Split(new string[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>", "<br >", "," }, StringSplitOptions.RemoveEmptyEntries);
            List<string> allForms = new List<string>();
            foreach (string declension in declensions)
            {
                string cleaned = declension.Trim();
                // special case for "fragen"
                if (cleaned.StartsWith("''"))
                {
                    cleaned = cleaned.Substring(2);
                }
                if (cleaned.EndsWith("''"))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 2);
                }
                if (cleaned.Contains("(selten)"))  // example gelten
                {
                    cleaned = cleaned.Replace("(selten)", string.Empty);
                }
                List<string> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains(":") || cleaned.Contains("''"))
                {
                    word.ParserError = true;
                    Common.PrintError(word.Text, string.Format("VerbParser error (contains parenthesis): {0}", word.Text));
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
                        Common.PrintError(word.Text, string.Format("{0}: braces to not match", word.Text));
                        return allForms;
                    }
                    if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                    {
                        allForms.Add(cleaned.Substring(1, cleaned.Length - 2).Trim());
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Common.PrintError(word.Text, string.Format("{0}: contains more than 2 braces. at the moment, the parser doesn't support more than 2 braces.", word.Text));
                    }
                    else
                    {
                        allForms.AddRange(this.CreateAllFormsFromBraces(cleaned));
                    }
                }

            }
            if (allForms.Count == 0)
            {
                Common.PrintError(word.Text, string.Format("VerbParser: zero forms extracted: {0}| {1}", word.Text, input));
            } // Example: "reinpfeifen", Example "verheeren"
            return allForms;
        }
    }
}
