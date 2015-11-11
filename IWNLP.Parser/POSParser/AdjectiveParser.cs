using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class AdjectiveParser: ParserBase
    {
        public Word Parse(String word, String[] text, String wortArtLine) 
        {

            // https://de.wiktionary.org/wiki/Vorlage:Deklinationsseite_Adjektiv

            Adjective adjective = new Adjective();
            adjective.Text = word;
            adjective.POS = POS.Adjective;

            if(!(text.Select((content, index) => new { Content = content.Trim(), Index = index }).Any(x => x.Content.Contains("{{Deutsch Adjektiv Übersicht"))))
            {
                if (base.OutputDefinitionBlockMissing) 
                {
                    Console.WriteLine("Adjective Parser: No definition block: " + word);
                }
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


                String[] forms = line.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<String> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
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
                else
                {
                    throw new ArgumentException();
                }
            }

            return adjective;
        }

        protected List<String> GetForms(String input, Word word)
        {
            input = input.Trim();
            String[] declensions = input.Split(new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" }, StringSplitOptions.RemoveEmptyEntries);
            List<String> allForms = new List<String>();
            foreach (String declension in declensions)
            {
                String cleaned = declension.Replace("[[", String.Empty).Replace("]]", String.Empty); // remove braces for internal links with the same name
                cleaned = RemoveBetween(declension, "[", "]").Trim();
                cleaned = cleaned.Replace("/", String.Empty); // fix for missplaced '/' of "<br">

                List<String> combinations = new List<string>();
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains("''"))
                {
                    word.ParserError = true;
                    Console.WriteLine("AdjeciveParser error (contains parenthesis): " + word.Text);
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
                        allForms.Add(cleaned.Substring(1, cleaned.Length - 2));
                    }
                    else if (countOpeningBraces > 2)
                    {
                        word.ParserError = true;
                        Console.WriteLine(word.Text + ": containts more than 2 braces. at the moment, the parser doesn't support more than 2 braces.");
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
