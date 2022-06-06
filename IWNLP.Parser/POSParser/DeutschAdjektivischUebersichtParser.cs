using IWNLP.Models;
using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class DeutschAdjektivischUebersichtParser : ParserBase
    {
        public Word Parse(string word, string[] text)
        {
            try
            {
                List<string> cleanedTemplateBlock = this.GetCleanedTemplateBlock(word, text);
                Dictionary<string, string> parameters = this.ParseParameters(cleanedTemplateBlock, word);
                return this.Parse(word, parameters);
            }
            catch (Exception ex)
            {
                Common.PrintError(word, string.Format("DeutschAdjektivischUebersichtParser: Errors while parsing the parameters: {0}", word));
                return null;
            }
        }

        public AdjectivalDeclension Parse(string word, Dictionary<string, string> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension();
            if (!parameters.ContainsKey(ParameterAdjektivischUebersichtParser.KeinSingular))
            {
                item.NominativSingular = new List<string>();
                item.GenitivSingular = new List<string>();
                item.DativSingular = new List<string>();
                item.AkkusativSingular = new List<string>();
                item.NominativSingularSchwach = new List<string>();
                item.GenitivSingularSchwach = new List<string>();
                item.DativSingularSchwach = new List<string>();
                item.AkkusativSingularSchwach = new List<string>();
                item.NominativSingularGemischt = new List<string>();
                item.GenitivSingularGemischt = new List<string>();
                item.DativSingularGemischt = new List<string>();
                item.AkkusativSingularGemischt = new List<string>();
                item.NominativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.NominativSingularStark, parameters, new List<string>(){"r", string.Empty, "s"}));
                item.GenitivSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.GenitivSingularStark, parameters, new List<string>() { "n", "r", "n"}));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.GenitivSingularStarkStern))
                {
                    item.GenitivSingular.Add(parameters[ParameterAdjektivischUebersichtParser.GenitivSingularStarkStern]);
                }
                item.DativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.DativSingularStark, parameters, new List<string>() { "m", "r", "m" }));
                if (parameters.ContainsKey(ParameterAdjektivischUebersichtParser.DativSingularStarkStern)) 
                {
                    item.DativSingular.Add(parameters[ParameterAdjektivischUebersichtParser.DativSingularStarkStern]);
                }
                item.AkkusativSingular.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularStark, parameters, new List<string>() { "n", string.Empty, "s" }));
                // Schwach
                item.NominativSingularSchwach.Add(this.GetFormSchwach(ParameterAdjektivischUebersichtParser.NominativSingularSchwach, parameters, string.Empty));
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
                item.AkkusativSingularSchwach.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularSchwach, parameters, new List<string>() { "n", string.Empty, string.Empty }));
                // Gemischt
                item.NominativSingularGemischt.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.NominativSingularGemischt, parameters, new List<string>() { "r", string.Empty, "s"}));
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
                item.AkkusativSingularGemischt.Add(GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativSingularGemischt, parameters, new List<string>() { "n", string.Empty, "s" }));
            }
            if (!parameters.ContainsKey(ParameterAdjektivischUebersichtParser.KeinPlural))
            {
                item.NominativPlural = new List<string>();
                item.GenitivPlural = new List<string>();
                item.DativPlural = new List<string>();
                item.AkkusativPlural = new List<string>();
                item.NominativPluralSchwach = new List<string>();
                item.GenitivPluralSchwach = new List<string>();
                item.DativPluralSchwach = new List<string>();
                item.AkkusativPluralSchwach = new List<string>();
                item.NominativPluralGemischt = new List<string>();
                item.GenitivPluralGemischt = new List<string>();
                item.DativPluralGemischt = new List<string>();
                item.AkkusativPluralGemischt = new List<string>();
                item.NominativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.NominativPluralStark, parameters, new List<string>() { string.Empty, string.Empty, string.Empty }));
                item.GenitivPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.GenitivPluralStark, parameters, new List<string>() { "r", "r", "r" }));
                item.DativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.DativPluralStark, parameters, new List<string>() { "n", "n", "n" }));
                item.AkkusativPlural.Add(this.GetEntryStark(ParameterAdjektivischUebersichtParser.AkkusativPluralStark, parameters, new List<string>() { string.Empty, string.Empty, string.Empty }));
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
            Stats.Instance.AdjectivalDeclensionDeutschAdjektivischUebersichtTotal++;
            return item;
        }



        protected string GetEntryStark(string key, Dictionary<string, string> parameters, List<string> suffixes)
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

        protected string GetFormSchwach(string key, Dictionary<string, string> parameters, string suffix) 
        {
            if (parameters.ContainsKey(key))
            {
                return parameters[key];
            }
            else 
            {
                return string.Format("{0}{1}", parameters[ParameterAdjektivischUebersichtParser.Stamm], suffix);
            }
        }

        protected string GetFormStark(string genus, string stamm, List<string> suffixes)
        {
            switch (genus)
            {
                case "m": return string.Format("{0}{1}", stamm, suffixes[0]);
                case "f": return string.Format("{0}{1}", stamm, suffixes[1]);
                case "n": return string.Format("{0}{1}", stamm, suffixes[2]);
                default:
                    throw new ArgumentException();
            }
        }

        public List<string> GetCleanedTemplateBlock(string word, string[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch adjektivisch Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "DeutschAdjektivischUebersichtParser");
            cleanedLines = cleanedLines.Where(x => !x.Equals("{{Deutsch adjektivisch Übersicht")).ToList();
            return cleanedLines;
        }

        public Dictionary<string, string> ParseParameters(List<string> input, string word)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (string line in input)
            {
                string[] keyValuePair = line.Split(new char[] { '=' });
                string key = keyValuePair[0].Trim();
                string value = keyValuePair[1].Trim();
                parameters[key] = value;
            }
            return parameters;
        }

        public class ParameterAdjektivischUebersichtParser
        {
            public const string KeinSingular = "kein Singular";
            public const string KeinPlural = "kein Plural";
            public const string Stamm = "Stamm";
            public const string Genus = "Genus";
            public const string NominativSingularStark = "Nominativ Singular stark";
            public const string NominativPluralStark = "Nominativ Plural stark";
            public const string GenitivSingularStark = "Genitiv Singular stark";
            public const string GenitivSingularStarkStern = "Genitiv Singular stark*";
            public const string GenitivPluralStark = "Genitiv Plural stark";
            public const string DativSingularStark = "Dativ Singular stark";
            public const string DativSingularStarkStern = "Dativ Singular stark*";
            public const string DativPluralStark = "Dativ Plural stark";
            public const string AkkusativSingularStark = "Akkusativ Singular stark";
            public const string AkkusativPluralStark = "Akkusativ Plural stark";

            public const string NominativSingularSchwach = "Nominativ Singular schwach";
            public const string NominativPluralSchwach = "Nominativ Plural schwach";
            public const string GenitivSingularSchwach = "Genitiv Singular schwach";
            public const string GenitivSingularSchwachStern = "Genitiv Singular schwach*";
            public const string GenitivPluralSchwach = "Genitiv Plural schwach";
            public const string DativSingularSchwach = "Dativ Singular schwach";
            public const string DativSingularSchwachStern = "Dativ Singular schwach*";
            public const string DativPluralSchwach = "Dativ Plural schwach";
            public const string AkkusativSingularSchwach = "Akkusativ Singular schwach";
            public const string AkkusativPluralSchwach = "Akkusativ Plural schwach";

            public const string NominativSingularGemischt = "Nominativ Singular gemischt";
            public const string NominativPluralGemischt = "Nominativ Plural gemischt";
            public const string GenitivSingularGemischt = "Genitiv Singular gemischt";
            public const string GenitivSingularGemischtStern = "Genitiv Singular gemischt*";
            public const string GenitivPluralGemischt = "Genitiv Plural gemischt";
            public const string DativSingularGemischt = "Dativ Singular gemischt";
            public const string DativSingularGemischtStern = "Dativ Singular gemischt*";
            public const string DativPluralGemischt = "Dativ Plural gemischt";
            public const string AkkusativSingularGemischt = "Akkusativ Singular gemischt";
            public const string AkkusativPluralGemischt = "Akkusativ Plural gemischt";
        }
    }
}
