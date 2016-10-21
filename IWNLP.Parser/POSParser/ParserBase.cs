using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class ParserBase
    {

        private bool outputDefinitionBlockMissing = false;
        public bool OutputDefinitionBlockMissing
        {
            get { return outputDefinitionBlockMissing; }
            set { outputDefinitionBlockMissing = value; }
        }

        protected String[] SplitTemplateInput(String[] input, String templateStart)
        {
            bool multiline = input.Length > 1;
            String firstLine = input[0];
            if (firstLine.EndsWith("\r\n")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            if (firstLine.EndsWith("\n\r")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            if (firstLine.EndsWith("\n")) { firstLine = firstLine.Substring(0, firstLine.Length - 1); }
            if (firstLine.EndsWith("\r")) { firstLine = firstLine.Substring(0, firstLine.Length - 1); }
            if (firstLine.StartsWith(templateStart)) { firstLine = firstLine.Substring(templateStart.Length); }
            if (firstLine.EndsWith("}}")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            // Cite: https://en.wikipedia.org/wiki/Help:Template
            //Whitespace characters (spaces, tabs, returns) are stripped from the beginnings and ends of named parameter names and values, but not from the middle: thus {{ ... | myparam = this is a test }} has the same effect as {{ ... |myparam=this is a test}}. This does not apply to unnamed parameters, where the whitespace characters are preserved.
            List<String> inputLines = firstLine.Split(new char[] { '|' }).Select(x => x).ToList();
            if (multiline)
            {
                for (int i = 1; i < input.Length; i++)
                {
                    String line = input[i].Trim();
                    if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line
                    if (line.StartsWith("|"))
                    {
                        line = line.Substring(1);   // Skip leading "|"
                    }
                    line = this.CleanLine(line).Trim();
                    if (!String.IsNullOrEmpty(line))
                    {
                        inputLines.Add(line);
                    }
                }
            }
            return inputLines.ToArray();
        }

        public static String RemoveBetween(String input, String startText, String endText)
        {
            if (!input.Contains(startText))
            {
                return input;
            }
            if (input.Contains(startText) && !input.Contains(endText))
            {
                return input;
            }
            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            while (index < input.Length)
            {
                int beginStartText = input.IndexOf(startText, index);
                if (beginStartText < 0) // startText is not present in input anymore
                {
                    stringBuilder.Append(input.Substring(index));
                    return stringBuilder.ToString();
                }
                stringBuilder.Append(input.Substring(index, beginStartText - index));
                int endStartText = input.IndexOf(endText, beginStartText);
                index = endStartText + endText.Length;
            }
            if (index == input.Length)
            {
                return stringBuilder.ToString();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        protected List<String> GetCleanedMultilineDefintionBlock(String[] lines, String word, String parserName) 
        {
            List<String> cleanedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++) 
            {
                String line = lines[i].Trim();
                if (line.StartsWith("<!--")) { continue; } // skip comments
                if (line == "}}") { continue; }
                if (!line.StartsWith("|") && !line.StartsWith("{{"))
                {
                    Common.PrintError(word, String.Format("{0}: Error in {1} || {2}", parserName, word, line));
                }
                if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line
                if (String.IsNullOrEmpty(line))
                {
                    Common.PrintError(word, String.Format("{0}: Empty line in {1}", parserName, word));
                    continue;
                }
                if (!line.StartsWith("{{")) // special case for 'Vorlage:Deutsch Substantiv Übersicht -sch'
                {
                    line = line.Substring(1).Trim(); // Skip leading "|"
                }
                if (line.StartsWith("Bild"))
                {
                    continue; // Skip "Bild"-line
                }
                line = this.CleanLine(line);
                cleanedLines.Add(line);
            }
            return cleanedLines;
        }

        protected String CleanLine(String input)
        {
            input = input.Replace("<ref name=\"ug\"/>", String.Empty).Trim(); // Example: "abbröckeln"
            input = input.Replace("<ref name=\"owb\"/>", String.Empty).Trim(); // Example: "Flexion:rauschen"
            input = input.Replace("<ref name=owb/>", String.Empty).Trim(); // Example: "Flexion:rauschen"
            input = RemoveBetween(input, "<ref", "</ref>").Trim(); // Example: "Deichgraf", "abbröckeln"
            input = RemoveBetween(input, "<!--", "-->").Trim();
            input = input.Replace("<small>", String.Empty);
            input = input.Replace("</small>", String.Empty);
            input = input.Replace("<center>", String.Empty);
            input = input.Replace("</center>", String.Empty);
            input = input.Replace("[[ungebr.]]", String.Empty); // Example: "abblättern"
            input = input.Replace("<sup>", String.Empty);
            input = input.Replace("</sup>", String.Empty);
            input = input.Replace("(''veraltet'')", String.Empty).Trim(); // Example: "küren"
            input = input.Replace("''(veraltet)''", String.Empty).Trim(); // Example: "werden"
            input = input.Replace("''veraltet:''", String.Empty).Trim();
            input = input.Replace("{{va.|:}}", String.Empty).Trim(); // Example: Teppich
            input = input.Replace("''veraltend auch:''", String.Empty).Trim(); // Example: "scheren"
            input = input.Replace("''(selten)''", String.Empty).Trim(); // Example: "erkälten"
            input = input.Replace("''selten:''", String.Empty).Trim(); // Example: "Fetus"
            input = input.Replace("selten:", String.Empty).Trim(); // Example: "Fötus"
            input = input.Replace("''(selten gebraucht)''", String.Empty).Trim(); // Example: "menstruieren"
            input = input.Replace("''mundartlich:''", String.Empty).Trim(); // Example: "Herz"
            input = input.Replace("dichterisch:", String.Empty).Trim(); // Example: "März"
            input = input.Replace("''poetisch:''", String.Empty).Trim(); // Example: "scheuen"
            input = input.Replace("''dialektal auch:''", String.Empty).Trim(); // Example: "fladern"
            input = input.Replace("''regional:''", String.Empty).Trim(); // Example: "doll"
            input = input.Replace("''nur umgangsspachlich:''", String.Empty).Trim(); // Example: "einzig"
            input = input.Replace("''auch:''", String.Empty).Trim(); // Example: "Mahr"
            input = input.Replace("''militärisch:''", String.Empty).Trim(); // Example: "wegtreten"
            input = input.Replace("''auch einfach:''", String.Empty).Trim(); // Example: "hereinkommen"
            input = input.Replace("[[Hilfe:Dativ-e|''Variante:'']]", String.Empty).Trim(); // Example: "Siebenschläfertag"
            input = input.Replace("Nebensatz:", String.Empty).Trim(); // Example: "aussortieren"
            // replace braces for internal links with the same name
            if (input.Contains("[[") && input.Contains("]]") && input.Contains("|"))
            {
                String firstPart = input.Substring(0, input.IndexOf("[["));
                input = input.Substring(input.IndexOf("|") + 1);
                input = input.Replace("]]", String.Empty);
                input = firstPart + input;
            }
            else
            {
                input = input.Replace("[[", String.Empty).Replace("]]", String.Empty);
            }
            return input;
        }

        public List<String> CreateAllFormsFromBraces(String input)
        {
            List<String> allForms = new List<string>();
            List<String> removedOptionals = new List<string>();
            String startText = "(";
            String endText = ")";
            int braceCounter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            while (index < input.Length)
            {
                int beginStartText = input.IndexOf(startText, index);
                if (beginStartText < 0) // startText is not present in input anymore
                {
                    stringBuilder.Append(input.Substring(index));
                    break;
                }
                stringBuilder.Append(input.Substring(index, beginStartText - index));
                int endStartText = input.IndexOf(")", beginStartText);
                String removed = input.Substring(beginStartText + startText.Length, endStartText - beginStartText - endText.Length).Trim();
                removedOptionals.Add(removed);
                stringBuilder.Append("{" + (braceCounter++) + "}");
                index = endStartText + ")".Length;
            }
            String formatString = stringBuilder.ToString();
            if (removedOptionals.Count == 1)
            {
                allForms.Add(String.Format(formatString, String.Empty).Trim());
                allForms.Add(String.Format(formatString, removedOptionals[0]).Trim());
            }
            else if (removedOptionals.Count == 2)
            {
                allForms.Add(String.Format(formatString, String.Empty, String.Empty).Trim());
                allForms.Add(String.Format(formatString, String.Empty, removedOptionals[1]).Trim());
                allForms.Add(String.Format(formatString, removedOptionals[0], String.Empty).Trim());
                allForms.Add(String.Format(formatString, removedOptionals[0], removedOptionals[1]).Trim());
            }
            else
            {
                throw new NotImplementedException();
            }
            if (allForms.Contains("!")) // special case for "angrenzen", fixed at 20.4.2015. can be removed after next dump
            {
                allForms.Remove("!");
                Common.PrintError(String.Format("ParserBase error with '!': {0}", input));
            }
            return allForms;
        }

        protected String StrRightC(String input, int length)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }
            if (input.Length >= length)
            {
                return input.Substring(input.Length - length);
            }
            else
            {
                return input;
            }
        }

        protected String StrCrop(String input, int length)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }
            if (input.Length >= length)
            {
                return input.Substring(0, input.Length - length);
            }
            else
            {
                return StrCrop(input, length % input.Length); // Example "{{Str crop |Lorem ipsum dolor sit amet |35}}" => "Lorem ipsum dolor si"
            }
        }

        public String StrSubrev(String input, int offsetFromRight, int length)
        {
            if (length == 0)
            {
                length = 1;
            }
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }
            if (offsetFromRight < length)
            {
                return String.Empty;
            }
            if (offsetFromRight - length > input.Length)
            {
                return String.Empty;
            }
            if (length > input.Length)
            {
                return String.Empty;
            }
            return input.Substring(input.Length - offsetFromRight, length);
        }

        public String RemoveNBSPandTrim(String value)
        {
            return value.Replace("&nbsp;", " ").Trim();
        }

        public void RemoveNBSPandTrim(List<String> values)
        {
            if (values == null)
            {
                return;
            }
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Contains(",") || values[i].Contains("<") || values[i].Contains(">") || values[i].Contains("''"))
                {
                    Common.PrintError(String.Format("Error Verb Flexparser: {0}", values[i]));
                }
                if (values[i].Contains("&nbsp;"))
                {
                    values[i] = RemoveNBSPandTrim(values[i]);
                }
            }
        }

        public bool ContainsNonEmpty(Dictionary<String, String> dictionary, String key)
        {
            return dictionary.ContainsKey(key) && !String.IsNullOrEmpty(dictionary[key]);
        }

        public String StrSub(String text, int index, int length)
        {
            if (index < 0) { return String.Empty; }
            if (length <= text.Length)
            {
                return text.Substring(index, length);
            }
            else
            {
                if (index == 0)
                {
                    String output = String.Empty;
                    int repeatCount = length / text.Length;
                    for (int i = 0; i < repeatCount; i++)
                    {
                        output += text;
                    }
                    int truncatedLength = length % text.Length;
                    output += text.Substring(0, truncatedLength);
                    return output;
                }
                else
                {
                    throw new ArgumentException();
                }

            }
        }
    }
}
