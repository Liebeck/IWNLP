using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class VerbParser : ParserBase
    {
        //{{Deutsch Verb Übersicht
        public bool OutputWrongInflectionForms { get; set; }


        List<String> blacklist = new List<string>() 
        {
        "reinpfeifen",
        "vorstellen"
        };

        public Word Parse(String word, String[] text, String wortArtLine)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            // https://de.wiktionary.org/wiki/Vorlage:Deklinationsseite_Adjektiv

            Verb verb = new Verb();
            verb.Text = word;
            verb.POS = POS.Verb;

            if (!(text.Select((content, index) => new { Content = content.Trim(), Index = index }).Any(x => x.Content.Contains("{{Deutsch Verb Übersicht"))))
            {
                if (base.OutputDefinitionBlockMissing)
                {
                    Console.WriteLine("Verb Parser: No definition block: " + word);
                }
                verb.ConjugationBlockMissing = true;
                return verb;
            }

            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Verb Übersicht") || x.Content.Contains("{{ Deutsch Verb Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart + 1 && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            for (int i = flexionSubstantivStart + 1; i < flexionSubstantivEnd; i++)
            {
                text[i] = text[i].Trim();
                if (text[i].StartsWith("<!--"))
                {
                    continue; // skip comments
                }
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
                if (String.IsNullOrEmpty(line.Trim()))
                {
                    continue;
                }

                if (line.Contains("<ref name"))
                {
                    Console.WriteLine("Verb contains '<ref name':" + word);
                }
                String[] forms = line.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<String> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
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
                    List<String> extractedForms = this.GetForms(forms[1], verb);
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
                    List<String> extractedForms = this.GetForms(forms[1], verb);
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
                //else if (forms[0].StartsWith("Hilfsverb2"))
                //{
                //    verb.Hilfsverb2 = forms[1];
                //}
                else if (forms[0].StartsWith("Hilfsverb"))
                {
                    if (verb.Hilfsverb == null) { verb.Hilfsverb = new List<string>(); }
                    verb.Hilfsverb.AddRange(this.GetForms(forms[1], verb));
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
                        Console.WriteLine("word " + word + "== " + line);
                    }
                }
                else if (forms[0].StartsWith("Weitere Konjugationen"))
                {

                }
                else
                {
                    //throw new ArgumentException();
                    Console.WriteLine("word " + word + "== " + line);
                }
            }

            return verb;
        }

        protected List<String> GetForms(String input, Word word)
        {
            input = input.Trim();
            input = input.Replace("[[", String.Empty).Replace("]]", String.Empty).Trim(); // remove braces for internal links with the same name
            input = RemoveBetween(input, "[", "]").Trim();
            input = input.Replace("„", string.Empty);
            input = input.Replace("“", string.Empty).Trim();

            String[] declensions = input.Split(new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>", "<br >", "," }, StringSplitOptions.RemoveEmptyEntries);
            List<String> allForms = new List<String>();
            foreach (String declension in declensions)
            {
                String cleaned = declension.Trim();
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
                    cleaned = cleaned.Replace("(selten)", String.Empty);
                }
                List<String> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains(":") || cleaned.Contains("''"))
                {
                    word.ParserError = true;
                    Console.WriteLine("VerbParser error (contains parenthesis): " + word.Text);
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
                        Console.WriteLine(word.Text + ": braces do not match");
                        return allForms;
                    }
                    if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                    {
                        allForms.Add(cleaned.Substring(1, cleaned.Length - 2).Trim());
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Console.WriteLine(word.Text + ": contains more than 2 braces. at the moment, the parser doesn't support more than 2 braces.");
                    }
                    else
                    {
                        allForms.AddRange(this.CreateAllFormsFromBraces(cleaned));
                    }
                }

            }
            if (allForms.Count == 0)
            {
                Console.WriteLine("VerbParser: zero forms extracted: " + word.Text + "| " + input);
                //return null; 

            } // Example: "reinpfeifen", Example "verheeren"
            return allForms;
        }
    }
}
