using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class DeutschNameUebersichtParser: ParserBase
    {
        public Word Parse(String word, String[] text)
        {
            try
            {
                List<String> cleanedTemplateBlock = this.GetCleanedTemplateBlock(word, text);
                Dictionary<String, String> parameters = this.ParseParameters(cleanedTemplateBlock, word);
                return this.Parse(word, parameters);
            }
            catch (Exception ex)
            {
                Common.PrintError(word, String.Format("DeutschAdjektivischUebersichtParser: Errors while parsing the parameters: {0}", word));
                return null;
            }
        }

        public Noun Parse(String word, Dictionary<String, String> parameters) 
        {
            return null;
        }

        public List<String> GetCleanedTemplateBlock(String word, String[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Name Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            String[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<String> cleanedLines = base.GetCleanedMultilineDefintionBlock(definition, word, "DeutschNameUebersichtParser");
            cleanedLines = cleanedLines.Where(x => !x.Equals("{{Deutsch Name Übersicht")).ToList();
            if (cleanedLines[0].StartsWith("{{Deutsch Name Übersicht|")) 
            {
                cleanedLines[0] = cleanedLines[0].Replace("{{Deutsch Name Übersicht|", String.Empty);
            }
            return cleanedLines;
        }

        public Dictionary<String, String> ParseParameters(List<String> input, String word)
        {
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            foreach (String line in input)
            {
                String[] keyValuePair = line.Split(new char[] { '=' });
                String key = keyValuePair[0].Trim();
                String value = keyValuePair[1].Trim();
                parameters[key] = value;
            }
            return parameters;
        }
    }
}
