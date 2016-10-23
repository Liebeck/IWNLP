using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWNLP.Models.Nouns;

namespace IWNLP.Parser.POSParser
{
    public class DeutschAdjektivischUebersichtParser : ParserBase
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
                Common.PrintError(word, "Errors while parsing the parameters");
                return null;
            }
        }

        public AdjectivalDeclension Parse(String word, Dictionary<String, String> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension();
            if (!parameters.ContainsKey(ParameterAdjektivischUebersichtParser.KeinSingular))
            {
                item.NominativSingular = new List<String>();
                item.GenitivSingular = new List<String>();
                item.DativSingular = new List<String>();
                item.AkkusativSingular = new List<String>();
                item.NominativSingularSchwach = new List<String>();
                item.GenitivSingularSchwach = new List<String>();
                item.DativSingularSchwach = new List<String>();
                item.AkkusativSingularSchwach = new List<String>();
                item.NominativSingularGemischt = new List<String>();
                item.GenitivSingularGemischt = new List<String>();
                item.DativSingularGemischt = new List<String>();
                item.AkkusativSingularGemischt = new List<String>();
                item.NominativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.NominativSingularStark, parameters, new List<String>(){"r", String.Empty, "s"}));
                item.GenitivSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.GenitivSingularStark, parameters, new List<String>() { "n", "r", "n"}));
                item.DativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.DativSingularStark, parameters, new List<String>() { "m", "r", "m" }));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.DativSingularStarkStern)) 
                {
                    item.DativSingular.Add(parameters[ParameterAdjektivischUebersichtParser.DativSingularStarkStern]);
                }
                item.AkkusativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularStark, parameters, new List<String>() { "n", String.Empty, "s" }));
                // Schwach
                item.NominativSingularSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.NominativSingularSchwach, parameters, String.Empty));
                item.GenitivSingularSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.GenitivSingularSchwach, parameters, "n"));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.GenitivSingularSchwachStern))
                {
                    item.GenitivSingularSchwach.Add(parameters[ParameterAdjektivischUebersichtParser.GenitivSingularSchwachStern]);
                }
                item.DativSingularSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.DativSingularSchwach, parameters, "n"));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.DativSingularSchwachStern))
                {
                    item.DativSingularSchwach.Add(parameters[ParameterAdjektivischUebersichtParser.DativSingularSchwachStern]);
                }
                item.AkkusativSingularSchwach.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularSchwach, parameters, new List<String>() { "n", String.Empty, String.Empty }));
                // Gemischt
                item.NominativSingularGemischt.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.NominativSingularGemischt, parameters, new List<String>() { "r", String.Empty, "s"}));
                item.GenitivSingularGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.GenitivSingularGemischt, parameters, "n"));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.GenitivSingularSchwachStern))
                {
                    item.GenitivSingularGemischt.Add(parameters[ParameterAdjektivischUebersichtParser.GenitivSingularSchwachStern]);
                }
                item.DativSingularGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.DativSingularGemischt, parameters, "n"));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.DativSingularSchwachStern))
                {
                    item.DativSingularGemischt.Add(parameters[ParameterAdjektivischUebersichtParser.DativSingularSchwachStern]);
                }
                item.AkkusativSingularGemischt.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularGemischt, parameters, new List<String>() { "n", String.Empty, "s" }));
            }
            if (!parameters.ContainsKey(ParameterAdjektivischUebersichtParser.KeinPlural))
            {
                item.NominativPlural = new List<String>();
                item.GenitivPlural = new List<String>();
                item.DativPlural = new List<String>();
                item.AkkusativPlural = new List<String>();
                item.NominativPluralSchwach = new List<String>();
                item.GenitivPluralSchwach = new List<String>();
                item.DativPluralSchwach = new List<String>();
                item.AkkusativPluralSchwach = new List<String>();
                item.NominativPluralGemischt = new List<String>();
                item.GenitivPluralGemischt = new List<String>();
                item.DativPluralGemischt = new List<String>();
                item.AkkusativPluralGemischt = new List<String>();
                item.NominativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.NominativPluralStark, parameters, new List<String>() { String.Empty, String.Empty, String.Empty }));
                item.GenitivPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.GenitivPluralStark, parameters, new List<String>() { "r", "r", "r" }));
                item.DativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.DativPluralStark, parameters, new List<String>() { "n", "n", "n" }));
                item.AkkusativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativPluralStark, parameters, new List<String>() { String.Empty, String.Empty, String.Empty }));
                // Schwach
                item.NominativPluralSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.NominativPluralSchwach, parameters, "n"));
                item.GenitivPluralSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.GenitivPluralSchwach, parameters, "n"));
                item.DativPluralSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.DativPluralSchwach, parameters, "n"));
                item.AkkusativPluralSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.AkkusativPluralSchwach, parameters, "n"));
                // Gemischt
                item.NominativPluralGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.NominativPluralGemischt, parameters, "n"));
                item.GenitivPluralGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.GenitivPluralGemischt, parameters, "n"));
                item.DativPluralGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.DativPluralGemischt, parameters, "n"));
                item.AkkusativPluralGemischt.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.AkkusativPluralGemischt, parameters, "n"));
            }
            return item;
        }



        protected String GetEntryStark(String key, Dictionary<String, String> parameters, List<String> suffixes)
        {
            if (parameters.ContainsKey(key))
            {
                return parameters[key];
            }
            else
            {
                return this.GetFormStark(parameters[ParameterAdjektivischUebersichtParser.Genus],
                                        parameters[ParameterAdjektivischUebersichtParser.Stamm],
                                        suffixes);
            }
        }

        protected String GetFormSchwach(String key, Dictionary<String, String> parameters, String suffix) 
        {
            if (parameters.ContainsKey(key))
            {
                return parameters[key];
            }
            else 
            {
                return String.Format("{0}{1}", parameters[ParameterAdjektivischUebersichtParser.Stamm], suffix);
            }
        }

        protected String GetFormStark(String genus, String stamm, List<String> suffixes)
        {
            switch (genus)
            {
                case "m": return String.Format("{0}{1}", stamm, suffixes[0]);
                case "f": return String.Format("{0}{1}", stamm, suffixes[1]);
                case "n": return String.Format("{0}{1}", stamm, suffixes[2]);
                default:
                    throw new ArgumentException();
            }
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

            public const String NominativSingularGemischt = "Nominativ Singular gemischt";
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
