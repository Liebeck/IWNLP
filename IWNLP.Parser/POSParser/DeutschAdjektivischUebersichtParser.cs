using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class DeutschAdjektivischUebersichtParser : ParserBase
    {
        public Word Parse(String word, String[] text)
        {
            List<String> cleanedTemplateBlock = this.GetCleanedTemplateBlock(word, text);
            Dictionary<String, String> parameters = this.ParseParameters(cleanedTemplateBlock, word);
            return null;
        }

        public List<String> GetCleanedTemplateBlock(String word, String[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch adjektivisch Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            String[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<String> cleanedLines = base.GetCleanedMultilineDefintionBlock(definition, word, "DeutschAdjektivischUebersichtParser");
            cleanedLines = cleanedLines.Where(x => !x.Equals("{{Deutsch adjektivisch Übersicht")).ToList();
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

        public class ParameterAdjektivischUebersichtParser 
        {
            public const String KeinSingular = "kein Singular";
            public const String KeinPlural = "kein Plural";
            public const String Stamm = "Stamm";
            public const String Genus = "Genus";
            public const String NominativSingularStark = "Nominativ Singular stark";
            public const String NominativPluralStark = "Nominativ Plural stark";
            public const String GenitivSingularStark = "Genitiv Singular stark";
            public const String GenitivPluralStark = "Genitiv Plural stark";
            public const String DativSingularStark = "Dativ Singular stark";
            public const String DativSingularStarkStern = "Dativ Singular stark*";
            public const String DativPluralStark = "Dativ Plural stark";
            public const String AkkusativSingularStark = "Akkusativ Singular stark";
            public const String AkkusativPluralStark = "Akkusativ Plural stark";

            public const String NominativSingularSchwach = "Nominativ Singular schwach";
            public const String NominativPluralSchwach = "Nominativ Plural schwach";
            public const String GenitivSingularSchwach = "Genitiv Singular schwach";
            public const String GenitivSingularSchwachStern = "Genitiv Singular schwach*";
            public const String GenitivPluralSchwach = "Genitiv Plural schwach";
            public const String DativSingularSchwach = "Dativ Singular schwach";
            public const String DativSingularSchwachStern = "Dativ Singular schwach*";
            public const String DativPluralSchwach = "Dativ Plural schwach";
            public const String AkkusativSingularSchwach = "Akkusativ Singular schwach";
            public const String AkkusativPluralSchwach = "Akkusativ Plural schwach";

            public const String NominativSingularGemischt = "NominativSingularGemischt";
            public const String NominativPluralGemischt = "Nominativ Plural gemischt";
            public const String GenitivSingularGemischt = "Genitiv Singular gemischt";
            public const String GenitivSingularGemischtStern = "Genitiv Singular gemischt*";
            public const String GenitivPluralGemischt = "Genitiv Plural gemischt";
            public const String DativSingularGemischt = "Dativ Singular gemischt";
            public const String DativSingularGemischtStern = "Dativ Singular gemischt*";
            public const String DativPluralGemischt = "Dativ Plural gemischt";
            public const String AkkusativSingularGemischt = "Akkusativ Singular gemischt";
            public const String AkkusativPluralGemischt = "Akkusativ Plural gemischt";
        }
    }
}
