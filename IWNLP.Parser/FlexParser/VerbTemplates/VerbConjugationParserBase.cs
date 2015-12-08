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


 

        protected String GetWithSpaceOrEmpty(Dictionary<String, String> dictionary, String key)
        {
            if (dictionary.ContainsKey(key) && !String.IsNullOrEmpty(dictionary[key]))
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
