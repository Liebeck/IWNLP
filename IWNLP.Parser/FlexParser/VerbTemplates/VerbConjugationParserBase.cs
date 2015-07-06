using IWNLP.Parser.POSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser.VerbTemplates
{
    public class VerbConjugationParserBase : ParserBase
    {
        protected String GetNextUnnamedParameter(Dictionary<String, String> dict)
        {
            int i = 1;
            while (dict.ContainsKey(i.ToString()))
            {
                i++;
            }
            return i.ToString();
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
                    line = base.CleanLine(line).Trim();
                    if (!String.IsNullOrEmpty(line)) 
                    {
                        inputLines.Add(line);
                    }
                }
            }
            return inputLines.ToArray();
        }

        protected String GetWithSpaceOrEmpty(Dictionary<String, String> dictionary, String key)
        {
            if (dictionary.ContainsKey(key))
            {
                return " " + dictionary[key];
            }
            return String.Empty;
        }

        protected String GetOrEmpty(Dictionary<String, String> dictionary, String key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return String.Empty;
        }

    }
}
