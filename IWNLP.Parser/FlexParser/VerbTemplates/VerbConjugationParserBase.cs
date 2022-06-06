using IWNLP.Parser.POSParser;
using System.Collections.Generic;

namespace IWNLP.Parser.FlexParser.VerbTemplates
{
    public class VerbConjugationParserBase : ParserBase
    {
        protected string GetNextUnnamedParameter(Dictionary<string, string> dict)
        {
            int i = 1;
            while (dict.ContainsKey(i.ToString()))
            {
                i++;
            }
            return i.ToString();
        }


 

        protected string GetWithSpaceOrEmpty(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.ContainsKey(key) && !string.IsNullOrEmpty(dictionary[key]))
            {
                return " " + dictionary[key];
            }
            return string.Empty;
        }

        protected string GetOrEmpty(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return string.Empty;
        }

    }
}
