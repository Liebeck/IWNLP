using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class PronounParser : ParserBase
    {

        List<String> blacklist = new List<string>() 
        {
            "einige",
        };

        public Word Parse(String word, String[] text, String wortArtLine)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            Pronoun pronoun = new Pronoun();
            pronoun.Text = word;

            if (wortArtLine.Contains("{{Wortart|Artikel|Deutsch}}") && !wortArtLine.Contains("{{Wortart|Demonstrativpronomen|Deutsch}}"))
            {
                pronoun.POS = POS.DET;
            }
            else
            {
                pronoun.POS = POS.Pronoun;
            }
            if (text.Any(x => x.Contains("{{Pronomina-Tabelle")))
            {


                int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Pronomina-Tabelle")).Select(x => x.Index).First();
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
                        text[i] = "|" + text[i];
                    }



                    String line = text[i].Substring(1).Trim(); // Skip leading "|"
                    if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line
                    line = base.CleanLine(line);


                    String[] forms = line.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    List<String> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
                    if (forms.Length == 1 || (forms.Length == 2 && (noValue.Contains(forms[1].Trim()))))  // No value given
                    {
                        continue;
                    }
                    forms[1] = forms[1].Replace("&nbsp;", " ");
                    forms[0] = forms[0].Trim(); // remove spaces

                    if (forms[0].StartsWith("Wer oder was? (Einzahl m)") || forms[0].StartsWith("Nominativ Singular m"))
                    {
                        if (pronoun.WerEinzahlM == null) { pronoun.WerEinzahlM = new List<string>(); }
                        pronoun.WerEinzahlM.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wer oder was? (Einzahl f)") || forms[0].StartsWith("Nominativ Singular f"))
                    {
                        if (pronoun.WerEinzahlF == null) { pronoun.WerEinzahlF = new List<string>(); }
                        pronoun.WerEinzahlF.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wer oder was? (Einzahl n)") || forms[0].StartsWith("Nominativ Singular n"))
                    {
                        if (pronoun.WerEinzahlN == null) { pronoun.WerEinzahlN = new List<string>(); }
                        pronoun.WerEinzahlN.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wer oder was? (Mehrzahl)") || forms[0].StartsWith("Nominativ Plural"))
                    {
                        if (pronoun.WerEinzahlMehrzahl == null) { pronoun.WerEinzahlMehrzahl = new List<string>(); }
                        pronoun.WerEinzahlMehrzahl.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wessen? (Einzahl m)") || forms[0].StartsWith("Genitiv Singular m"))
                    {
                        if (pronoun.WessenEinzahlM == null) { pronoun.WessenEinzahlM = new List<string>(); }
                        pronoun.WessenEinzahlM.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wessen? (Einzahl f)") || forms[0].StartsWith("Genitiv Singular f"))
                    {
                        if (pronoun.WessenEinzahlF == null) { pronoun.WessenEinzahlF = new List<string>(); }
                        pronoun.WessenEinzahlF.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wessen? (Einzahl n)") || forms[0].StartsWith("Genitiv Singular n"))
                    {
                        if (pronoun.WessenEinzahlN == null) { pronoun.WessenEinzahlN = new List<string>(); }
                        pronoun.WessenEinzahlN.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wessen? (Mehrzahl)") || forms[0].StartsWith("Genitiv Plural"))
                    {
                        if (pronoun.WessenEinzahlMehrzahl == null) { pronoun.WessenEinzahlMehrzahl = new List<string>(); }
                        pronoun.WessenEinzahlMehrzahl.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wem? (Einzahl m)") || forms[0].StartsWith("Dativ Singular m"))
                    {
                        if (pronoun.WemEinzahlM == null) { pronoun.WemEinzahlM = new List<string>(); }
                        pronoun.WemEinzahlM.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wem? (Einzahl f)") || forms[0].StartsWith("Dativ Singular f"))
                    {
                        if (pronoun.WemEinzahlF == null) { pronoun.WemEinzahlF = new List<string>(); }
                        pronoun.WemEinzahlF.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wem? (Einzahl n)") || forms[0].StartsWith("Dativ Singular n"))
                    {
                        if (pronoun.WemEinzahlN == null) { pronoun.WemEinzahlN = new List<string>(); }
                        pronoun.WemEinzahlN.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wem? (Mehrzahl)") || forms[0].StartsWith("Dativ Plural"))
                    {
                        if (pronoun.WemEinzahlMehrzahl == null) { pronoun.WemEinzahlMehrzahl = new List<string>(); }
                        pronoun.WemEinzahlMehrzahl.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wen? (Einzahl m)") || forms[0].StartsWith("Akkusativ Singular m"))
                    {
                        if (pronoun.WenEinzahlM == null) { pronoun.WenEinzahlM = new List<string>(); }
                        pronoun.WenEinzahlM.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wen? (Einzahl f)") || forms[0].StartsWith("Akkusativ Singular f"))
                    {
                        if (pronoun.WenEinzahlF == null) { pronoun.WenEinzahlF = new List<string>(); }
                        pronoun.WenEinzahlF.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wen? (Einzahl n)") || forms[0].StartsWith("Akkusativ Singular n"))
                    {
                        if (pronoun.WenEinzahlN == null) { pronoun.WenEinzahlN = new List<string>(); }
                        pronoun.WenEinzahlN.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Wen? (Mehrzahl)") || forms[0].StartsWith("Akkusativ Plural"))
                    {
                        if (pronoun.WenEinzahlMehrzahl == null) { pronoun.WenEinzahlMehrzahl = new List<string>(); }
                        pronoun.WenEinzahlMehrzahl.AddRange(this.GetForms(forms[1], pronoun));
                    }
                    else if (forms[0].StartsWith("Weitere Formen"))
                    {
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            else
            {
                if (text.Any(x => x.Contains("{{Deutsch Personalpronomen 3}}")))
                {
                    this.AddTemplateDeutschPersonalpronomen3(pronoun);
                }
            }

            return pronoun;
        }

        protected void AddTemplateDeutschPersonalpronomen3(Pronoun pronoun)
        {
            pronoun.WerEinzahlM = new List<string>() { "er" };
            pronoun.WerEinzahlF = new List<string>() { "sie" };
            pronoun.WerEinzahlN = new List<string>() { "es" };
            pronoun.WerEinzahlMehrzahl = new List<string>() { "sie" };
            pronoun.WessenEinzahlM = new List<string>() { "seiner" };
            pronoun.WessenEinzahlF = new List<string>() { "ihrer" };
            pronoun.WessenEinzahlN = new List<string>() { "seiner" };
            pronoun.WessenEinzahlMehrzahl = new List<string>() { "ihrer" };
            pronoun.WemEinzahlM = new List<string>() { "ihm" };
            pronoun.WemEinzahlF = new List<string>() { "ihr" };
            pronoun.WemEinzahlN = new List<string>() { "ihm" };
            pronoun.WemEinzahlMehrzahl = new List<string>() { "ihnen" };
            pronoun.WenEinzahlM = new List<string>() { "ihn" };
            pronoun.WenEinzahlF = new List<string>() { "sie" };
            pronoun.WenEinzahlN = new List<string>() { "es" };
            pronoun.WenEinzahlMehrzahl = new List<string>() { "sie" };
        }

        protected List<String> GetForms(String input, Word word)
        {
            input = input.Trim();
            String[] declensions = input.Split(new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>", "," }, StringSplitOptions.RemoveEmptyEntries);
            List<String> allForms = new List<String>();
            foreach (String declension in declensions)
            {
                String cleaned = declension.Replace("[[", String.Empty).Replace("]]", String.Empty); // remove braces for internal links with the same name
                cleaned = RemoveBetween(declension, "[", "]").Trim();
                if (cleaned.StartsWith("'''")) // example "das"
                {
                    cleaned = cleaned.Substring(3);
                }
                if (cleaned.EndsWith("'''"))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 3);
                }

                if (cleaned.StartsWith("''")) // example "welcher"
                {
                    cleaned = cleaned.Substring(2);
                }
                if (cleaned.EndsWith("''"))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 2);
                }


                int countOpeningBraces = cleaned.Count(x => x == '(');
                if (countOpeningBraces == 1 && cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                {
                    cleaned = cleaned.Substring(1, cleaned.Length - 2).Trim();
                }


                List<String> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains("''") || cleaned.Contains("(") || cleaned.Contains(")"))
                {
                    word.ParserError = true;
                    Console.WriteLine("Pronoun parser error (contains parenthesis): " + word.Text);
                    return allForms;

                }

                allForms.Add(cleaned);


            }
            return allForms;
        }

    }
}
