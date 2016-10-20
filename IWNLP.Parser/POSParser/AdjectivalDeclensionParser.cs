using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class AdjectivalDeclensionParser : ParserBase
    {
        public Dictionary<String, String> ParseParameters(String[] input, String word)
        {
            String truncatedWord = word.Replace("Flexion:", String.Empty);
            String[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch adjektivische Deklination");
            if (inputSplitted[0] == String.Empty)
            {
                inputSplitted = inputSplitted.ToList().Skip(1).ToArray();
            }
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            for (int i = 0; i < inputSplitted.Length; i++)
            {
                if (inputSplitted[i].Contains("="))
                {
                    String[] keyValuePair = inputSplitted[i].Split(new char[] { '=' });
                    String key = keyValuePair[0].Trim();
                    String value = keyValuePair[1].Trim();
                    parameters[key] = value;
                }
                else
                {
                    if (input[0].StartsWith("{{Deutsch adjektivische Deklination m") || input[0].StartsWith("{{Deutsch adjektivische Deklination f") || input[0].StartsWith("{{Deutsch adjektivische Deklination n"))
                    {
                        parameters["0"] = inputSplitted[i++];
                        parameters["1"] = inputSplitted[i++];
                    }
                    else
                    {
                        parameters["1"] = inputSplitted[i++];
                    }
                }
            }
            return parameters;
        }

        public AdjectivalDeclension Parse(String word, String[] input)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            List<int> conjugationBlockBeginIndices = input.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.StartsWith("{{Deutsch adjektivische Deklination")).Select(x => x.Index).ToList();
            for (int i = 0; i < conjugationBlockBeginIndices.Count; i++)
            {
                int conjugationBlockBeginIndex = conjugationBlockBeginIndices[i];
                int conjugationBlockEndIndex = input.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= conjugationBlockBeginIndex && x.Content.EndsWith("}}")).Select(x => x.Index).First();
                String[] subArrayDefinitionBlock = Common.GetSubArray(input, conjugationBlockBeginIndex, conjugationBlockEndIndex);
                if (subArrayDefinitionBlock[0].StartsWith("{{Deutsch adjektivische Deklination m"))
                {
                    Stats.Instance.AdjectivalDeclensionM++;
                    return this.ParseM(word, this.ParseParameters(subArrayDefinitionBlock, word));
                }
                else if (subArrayDefinitionBlock[0].StartsWith("{{Deutsch adjektivische Deklination f"))
                {
                    Stats.Instance.AdjectivalDeclensionF++;
                    return this.ParseF(word, this.ParseParameters(subArrayDefinitionBlock, word));
                }
                else if (subArrayDefinitionBlock[0].StartsWith("{{Deutsch adjektivische Deklination n"))
                {
                    Stats.Instance.AdjectivalDeclensionN++;
                    return this.ParseN(word, this.ParseParameters(subArrayDefinitionBlock, word));
                }
                else
                {
                    Stats.Instance.AdjectivalDeclension++;
                    return this.Parse(word, this.ParseParameters(subArrayDefinitionBlock, word));
                }
            }
            return null;
        }

        public AdjectivalDeclension Parse(String word, Dictionary<String, String> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension();
            if (!parameters.ContainsKey(ParameterAdjectivalDeclension.KeinSingular))
            {
                item.NominativSingular = this.GetFormsStark(parameters["Nominativ Singular stark"]);
                item.GenitivSingular = this.GetFormsStark(parameters["Genitiv Singular stark"]);
                item.DativSingular = this.GetFormsStark(parameters["Dativ Singular stark"]);
                item.AkkusativSingular = this.GetFormsStark(parameters["Akkusativ Singular stark"]);
                item.NominativSingularSchwach = this.GetFormsSchwach(parameters["Nominativ Singular schwach"], word);
                item.GenitivSingularSchwach = this.GetFormsSchwach(parameters["Genitiv Singular schwach"], word);
                item.DativSingularSchwach = this.GetFormsSchwach(parameters["Dativ Singular schwach"], word);
                item.AkkusativSingularSchwach = this.GetFormsSchwach(parameters["Akkusativ Singular schwach"], word);
            }
            if (!parameters.ContainsKey(ParameterAdjectivalDeclension.KeinPlural))
            {
                item.NominativPlural = this.GetFormsStark(parameters["Nominativ Plural stark"]);
                item.GenitivPlural = this.GetFormsStark(parameters["Genitiv Plural stark"]);
                item.DativPlural = this.GetFormsStark(parameters["Dativ Plural stark"]);
                item.AkkusativPlural = this.GetFormsStark(parameters["Akkusativ Plural stark"]);
                item.NominativPluralSchwach = this.GetFormsSchwach(parameters["Nominativ Plural schwach"], word);
                item.GenitivPluralSchwach = this.GetFormsSchwach(parameters["Genitiv Plural schwach"], word);
                item.DativPluralSchwach = this.GetFormsSchwach(parameters["Dativ Plural schwach"], word);
                item.AkkusativPluralSchwach = this.GetFormsSchwach(parameters["Akkusativ Plural schwach"], word);
            }
            return item;
        }

        protected List<String> GetFormsStark(String input)
        {
            if (input == "—" || input == "-" || input == "–") { return null; }
            String[] splitSeparator = new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" };
            List<String> result = input.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < result.Count; i++) // special case for "Geistlicher Rat"
            {
                if (result[i].StartsWith("(") && result[i].EndsWith(")"))
                {
                    result[i] = result[i].Substring(0, result[i].Length - 1);
                    result[i] = result[i].Substring(1);
                }
            }
            if (result.Any(x => x.Contains("{{") || x.Contains("}}") || x.Contains("<") || x.Contains(">") || x.Contains("|") || x.Contains(":") || x.Contains("…") || x.Contains("...") || x.Contains(" ,") || x.Contains(", ") || x.Contains("''") || x.Contains("(") || x.Contains(")")))
            {
                Common.PrintError(String.Format("AdjectivalDeclensionParser: error (contains parenthesis): {0}", input));
            }
            return result;
        }

        protected List<Inflection> GetFormsSchwach(String input, String word)
        {
            input = input.Trim();
            if (input == "—" || input == "-" || input == "–") { return null; }
            String[] splitSeparator = new String[] { "&lt;br /&gt;", "<br>", "<br />", "<br/>", "</br>" };
            String[] splits = input.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
            List<Inflection> forms = new List<Inflection>();
            foreach (String item in splits)
            {
                if (item.Contains("[")) { System.Diagnostics.Debugger.Break(); }
                String cleaned = item.Trim();
                if (cleaned.StartsWith("(") && cleaned.EndsWith(")"))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - 1);
                    cleaned = cleaned.Substring(1);
                }
                if (cleaned.Contains("{{") || cleaned.Contains("}}") || cleaned.Contains("<") || cleaned.Contains(">") || cleaned.Contains("|") || cleaned.Contains(":") || cleaned.Contains("…") || cleaned.Contains("...") || cleaned.Contains(" ,") || cleaned.Contains(", ") || cleaned.Contains("''") || cleaned.Contains("(") || cleaned.Contains(")"))
                {
                    Common.PrintError(word, String.Format("AdjectivalDeclensionParser error (contains parenthesis): {0}", word));
                }
                forms.Add(ParseInflectionWithArticle(cleaned, word));
            }
            return forms;
        }

        protected Inflection ParseInflectionWithArticle(String input, String word)
        {
            if (input == "—" || input == "-" || input == "–") { return null; }
            String firstWord = input.Substring(0, input.IndexOf(" "));
            List<String> articles = new List<string>() { "der", "die", "das", "den", "dem", "des" };
            if (articles.Contains(firstWord))
            {
                String rest = input.Substring(input.IndexOf(" ") + 1).Trim();
                return new Inflection()
                {
                    Article = firstWord,
                    InflectedWord = rest
                };
            }
            else
            {
                Common.PrintError(word, String.Format("AdjectivalDeclensionParser: {0} article not found", word));
                return null;
            }
        }

        public AdjectivalDeclension ParseM(String word, Dictionary<String, String> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension()
            {
                NominativSingular = new List<String>() { parameters["1"] + "r" },
                GenitivSingular = new List<String>() { parameters["1"] + "n" },
                DativSingular = new List<String>() { parameters["1"] + "m" },
                AkkusativSingular = new List<String>() { parameters["1"] + "n" },
                NominativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] } },
                GenitivSingularSchwach = new List<Inflection>() { new Inflection() { Article = "des", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "dem", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "den", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                NominativPlural = new List<String>() { parameters["1"] },
                GenitivPlural = new List<String>() { parameters["1"] + "r" },
                DativPlural = new List<String>() { parameters["1"] + "n" },
                AkkusativPlural = new List<String>() { parameters["1"] },
                NominativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                GenitivPluralSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "den", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
            };
            return item;
        }

        public AdjectivalDeclension ParseF(String word, Dictionary<String, String> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension()
            {
                NominativSingular = new List<String>() { parameters["1"] },
                GenitivSingular = new List<String>() { parameters["1"] + "r" },
                DativSingular = new List<String>() { parameters["1"] + "r" },
                AkkusativSingular = new List<String>() { parameters["1"] },
                NominativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] } },
                GenitivSingularSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] } },
                NominativPlural = new List<String>() { parameters["1"] },
                GenitivPlural = new List<String>() { parameters["1"] + "r" },
                DativPlural = new List<String>() { parameters["1"] + "n" },
                AkkusativPlural = new List<String>() { parameters["1"] },
                NominativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                GenitivPluralSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "den", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
            };
            return item;
        }

        public AdjectivalDeclension ParseN(String word, Dictionary<String, String> parameters)
        {
            AdjectivalDeclension item = new AdjectivalDeclension()
            {
                NominativSingular = new List<String>() { parameters["1"] + "s" },
                GenitivSingular = new List<String>() { parameters["1"] + "n" },
                DativSingular = new List<String>() { parameters["1"] + "m" },
                AkkusativSingular = new List<String>() { parameters["1"] + "s" },
                NominativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "das", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] } },
                GenitivSingularSchwach = new List<Inflection>() { new Inflection() { Article = "des", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "dem", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativSingularSchwach = new List<Inflection>() { new Inflection() { Article = "das", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] } },
                NominativPlural = new List<String>() { parameters["1"] },
                GenitivPlural = new List<String>() { parameters["1"] + "r" },
                DativPlural = new List<String>() { parameters["1"] + "n" },
                AkkusativPlural = new List<String>() { parameters["1"] },
                NominativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                GenitivPluralSchwach = new List<Inflection>() { new Inflection() { Article = "der", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                DativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "den", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
                AkkusativPluralSchwach = new List<Inflection>() { new Inflection() { Article = "die", InflectedWord = parameters[ParameterAdjectivalDeclension.Parameter1] + "n" } },
            };
            return item;
        }
    }
}
