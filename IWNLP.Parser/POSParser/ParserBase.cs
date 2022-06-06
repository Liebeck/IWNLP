using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        protected string[] SplitTemplateInput(string[] input, string templateStart)
        {
            bool multiline = input.Length > 1;
            string firstLine = input[0];
            if (firstLine.Contains("{{small|er/sie/es}}")) { firstLine = firstLine.Replace("{{small|er/sie/es}}", string.Empty); } // Example: "Flexion:schwären"
            if (firstLine.EndsWith("\r\n")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            if (firstLine.EndsWith("\n\r")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            if (firstLine.EndsWith("\n")) { firstLine = firstLine.Substring(0, firstLine.Length - 1); }
            if (firstLine.EndsWith("\r")) { firstLine = firstLine.Substring(0, firstLine.Length - 1); }
            if (firstLine.StartsWith(templateStart)) { firstLine = firstLine.Substring(templateStart.Length); }
            if (firstLine.EndsWith("}}")) { firstLine = firstLine.Substring(0, firstLine.Length - 2); }
            // Cite: https://en.wikipedia.org/wiki/Help:Template
            //Whitespace characters (spaces, tabs, returns) are stripped from the beginnings and ends of named parameter names and values, but not from the middle: thus {{ ... | myparam = this is a test }} has the same effect as {{ ... |myparam=this is a test}}. This does not apply to unnamed parameters, where the whitespace characters are preserved.
            List<string> inputLines = firstLine.Split(new char[] { '|' }).Select(x => x).ToList();
            if (multiline)
            {
                for (int i = 1; i < input.Length; i++)
                {
                    string line = input[i].Trim();
                    if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line
                    if (line.StartsWith("|"))
                    {
                        line = line.Substring(1);   // Skip leading "|"
                    }
                    line = this.CleanLine(line).Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        inputLines.Add(line);
                    }
                }
            }
            return inputLines.ToArray();
        }

        public static string RemoveBetween(string input, string startText, string endText)
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

        protected List<string> GetCleanedMultilineDefinitionBlock(string[] lines, string word, string parserName) 
        {
            List<string> cleanedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++) 
            {
                string line = lines[i].Trim();
                if (line.StartsWith("<!--")) { continue; } // skip comments
                if (line == "}}") { continue; }
                if (!line.StartsWith("|") && !line.StartsWith("{{"))
                {
                    Common.PrintError(word, string.Format("{0}: Error in {1} || {2}", parserName, word, line));
                }
                if (line.EndsWith("}}")) { line = line.Substring(0, line.Length - 2); } // remove end of block, if it is in the same line
                if (string.IsNullOrEmpty(line))
                {
                    Common.PrintError(word, string.Format("{0}: Empty line in {1}", parserName, word));
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

        protected string CleanLine(string input)
        {
            input = input.Replace("<ref name=\"ug\"/>", string.Empty).Trim(); // Example: "abbröckeln"
            input = input.Replace("<ref name=\"owb\"/>", string.Empty).Trim(); // Example: "Flexion:rauschen"
            input = input.Replace("<ref name=owb/>", string.Empty).Trim(); // Example: "Flexion:rauschen"
            input = RemoveBetween(input, "<ref", "</ref>").Trim(); // Example: "Deichgraf", "abbröckeln"
            input = RemoveBetween(input, "<!--", "-->").Trim();
            input = input.Replace("<small>", string.Empty);
            input = input.Replace("</small>", string.Empty);
            input = input.Replace("<center>", string.Empty);
            input = input.Replace("</center>", string.Empty);
            input = input.Replace("[[ungebr.]]", string.Empty); // Example: "abblättern"
            input = input.Replace("<sup>", string.Empty);
            input = input.Replace("</sup>", string.Empty);
            input = input.Replace("(''veraltet'')", string.Empty).Trim(); // Example: "küren"
            input = input.Replace("''(veraltet)''", string.Empty).Trim(); // Example: "werden"
            input = input.Replace("''veraltet:''", string.Empty).Trim();
            input = input.Replace("{{va.|:}}", string.Empty).Trim(); // Example: Teppich
            input = input.Replace("''veraltend auch:''", string.Empty).Trim(); // Example: "scheren"
            input = input.Replace("''(selten)''", string.Empty).Trim(); // Example: "erkälten"
            input = input.Replace("''selten:''", string.Empty).Trim(); // Example: "Fetus"
            input = input.Replace("selten:", string.Empty).Trim(); // Example: "Fötus"
            input = input.Replace("''(selten gebraucht)''", string.Empty).Trim(); // Example: "menstruieren"
            input = input.Replace("''mundartlich:''", string.Empty).Trim(); // Example: "Herz"
            input = input.Replace("dichterisch:", string.Empty).Trim(); // Example: "März"
            input = input.Replace("''poetisch:''", string.Empty).Trim(); // Example: "scheuen"
            input = input.Replace("''dialektal auch:''", string.Empty).Trim(); // Example: "fladern"
            input = input.Replace("''regional:''", string.Empty).Trim(); // Example: "doll"
            input = input.Replace("''nur umgangsspachlich:''", string.Empty).Trim(); // Example: "einzig"
            input = input.Replace("''auch:''", string.Empty).Trim(); // Example: "Mahr"
            input = input.Replace("''militärisch:''", string.Empty).Trim(); // Example: "wegtreten"
            input = input.Replace("''auch einfach:''", string.Empty).Trim(); // Example: "hereinkommen"
            input = input.Replace("[[Hilfe:Dativ-e|''Variante:'']]", string.Empty).Trim(); // Example: "Siebenschläfertag"
            input = input.Replace("Nebensatz:", string.Empty).Trim(); // Example: "aussortieren"
            // replace braces for internal links with the same name
            if (input.Contains("[[") && input.Contains("]]") && input.Contains("|"))
            {
                string firstPart = input.Substring(0, input.IndexOf("[["));
                input = input.Substring(input.IndexOf("|") + 1);
                input = input.Replace("]]", string.Empty);
                input = firstPart + input;
            }
            else
            {
                input = input.Replace("[[", string.Empty).Replace("]]", string.Empty);
            }
            return input;
        }

        public List<string> CreateAllFormsFromBraces(string input)
        {
            List<string> allForms = new List<string>();
            List<string> removedOptionals = new List<string>();
            string startText = "(";
            string endText = ")";
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
                string removed = input.Substring(beginStartText + startText.Length, endStartText - beginStartText - endText.Length).Trim();
                removedOptionals.Add(removed);
                stringBuilder.Append("{" + (braceCounter++) + "}");
                index = endStartText + ")".Length;
            }
            string formatString = stringBuilder.ToString();
            if (removedOptionals.Count == 1)
            {
                allForms.Add(string.Format(formatString, string.Empty).Trim());
                allForms.Add(string.Format(formatString, removedOptionals[0]).Trim());
            }
            else if (removedOptionals.Count == 2)
            {
                allForms.Add(string.Format(formatString, string.Empty, string.Empty).Trim());
                allForms.Add(string.Format(formatString, string.Empty, removedOptionals[1]).Trim());
                allForms.Add(string.Format(formatString, removedOptionals[0], string.Empty).Trim());
                allForms.Add(string.Format(formatString, removedOptionals[0], removedOptionals[1]).Trim());
            }
            else
            {
                throw new NotImplementedException();
            }
            if (allForms.Contains("!")) // special case for "angrenzen", fixed at 20.4.2015. can be removed after next dump
            {
                allForms.Remove("!");
                Common.PrintError(string.Format("ParserBase error with '!': {0}", input));
            }
            return allForms;
        }

        protected string StrRightC(string input, int length)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
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

        protected string StrCrop(string input, int length)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
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

        public string StrSubrev(string input, int offsetFromRight, int length)
        {
            if (length == 0)
            {
                length = 1;
            }
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (offsetFromRight < length)
            {
                return string.Empty;
            }
            if (offsetFromRight - length > input.Length)
            {
                return string.Empty;
            }
            if (length > input.Length)
            {
                return string.Empty;
            }
            return input.Substring(input.Length - offsetFromRight, length);
        }

        public string RemoveNBSPandTrim(string value)
        {
            return value.Replace("&nbsp;", " ").Trim();
        }

        public void RemoveNBSPandTrim(List<string> values, string word)
        {
            if (values == null)
            {
                return;
            }
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Contains(",") || values[i].Contains("<") || values[i].Contains(">") || values[i].Contains("''"))
                {
                    Common.PrintError(string.Format("Error Verb Flexparser: {0}, {1}", word, values[i]));
                }
                if (values[i].Contains("&nbsp;"))
                {
                    values[i] = RemoveNBSPandTrim(values[i]);
                }
            }
        }

        public bool ContainsNonEmpty(Dictionary<string, string> dictionary, string key)
        {
            return dictionary.ContainsKey(key) && !string.IsNullOrEmpty(dictionary[key]);
        }

        public string StrSub(string text, int index, int length)
        {
            if (index < 0) { return string.Empty; }
            if (length <= text.Length)
            {
                return text.Substring(index, length);
            }
            else
            {
                if (index == 0)
                {
                    string output = string.Empty;
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
