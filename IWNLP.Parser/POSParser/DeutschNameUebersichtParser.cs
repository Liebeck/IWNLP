using IWNLP.Models;
using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class DeutschNameUebersichtParser : ParserBase
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

        public Noun Parse(string word, Dictionary<string, string> parameters)
        {
            Noun noun = new Noun()
            {
                POS = POS.Noun,
                Genus = new List<Genus>()
            };
            switch (parameters[ParameterNameUebersichtParser.Genus])
            {
                case "m":
                    noun.Genus.Add(Genus.Maskulinum);
                    break;
                case "f":
                    noun.Genus.Add(Genus.Femininum);
                    break;
                case "n":
                    noun.Genus.Add(Genus.Neutrum);
                    break;
                default:
                    throw new ArgumentException("Genus not supported");
            }


            noun.NominativSingular = new List<Inflection>() 
            { 
                new Inflection() {
                   Article = this.GetGenus(parameters[ParameterNameUebersichtParser.Genus], Case.Nominative),
                   InflectedWord = GetGrundformOrPagename(parameters, word)
                },
                new Inflection() {
                    InflectedWord = GetGrundformOrPagename(parameters, word)
                },
            };
            noun.NominativPlural = this.GetPlural(new List<string>() { ParameterNameUebersichtParser.NominativPlural, ParameterNameUebersichtParser.NominativPlural1 },
                                                  new List<string>() { ParameterNameUebersichtParser.NominativPlural2, ParameterNameUebersichtParser.NominativPlural2Stern },
                                                  new List<string>() { ParameterNameUebersichtParser.NominativPlural3, ParameterNameUebersichtParser.NominativPlural3Stern },
                                                  parameters,
                                                  new List<string>() { "die", "die", "die" });
            noun.GenitivSingular = new List<Inflection>();
            noun.GenitivSingular.Add(new Inflection()
            {
                Article = this.GetGenus(parameters[ParameterNameUebersichtParser.Genus], Case.Genitive),
                InflectedWord = GetGrundformOrPagename(parameters, word)
            });
            switch (parameters[ParameterNameUebersichtParser.Genus])
            {
                case "m":
                    if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.Genitiv))
                    {
                        noun.GenitivSingular.Add(new Inflection()
                        {
                            InflectedWord = parameters[ParameterNameUebersichtParser.Genitiv]
                        });
                    }
                    else
                    {
                        if (StrRightC(word, 1) == "s") { noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}’", word) }); }
                        else { noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}s", word) }); }
                    }
                    break;
                case "f":
                    if (!base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.KeinS))
                    {
                        if (StrRightC(word, 1) == "s") { noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}’", word) }); }
                        else { noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}s", word) }); }
                    }
                    if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.GenitivSingular))
                    {
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.GenitivSingular] });
                    }
                    else if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.Genitiv))
                    {
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.Genitiv] });
                    }
                    break;
                case "n":
                    if (StrRightC(word, 1) == "s")
                    {
                        noun.GenitivSingular.Add(new Inflection() { Article = "des", InflectedWord = string.Format("{0}’", word) });
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}’", word) });
                    }
                    else
                    {
                        noun.GenitivSingular.Add(new Inflection() { Article = "des", InflectedWord = string.Format("{0}s", word) });
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = string.Format("{0}s", word) });
                    }
                    break;
                default:
                    throw new ArgumentException("Genus not supported");

            }
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.GenitivStern))
            {
                noun.GenitivSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.GenitivStern] });
            }
            noun.GenitivPlural = this.GetPlural(new List<string>() { ParameterNameUebersichtParser.GenitivPlural, ParameterNameUebersichtParser.GenitivPlural1 },
                                                new List<string>() { ParameterNameUebersichtParser.GenitivPlural2, ParameterNameUebersichtParser.GenitivPlural2Stern },
                                                new List<string>() { ParameterNameUebersichtParser.GenitivPlural3, ParameterNameUebersichtParser.GenitivPlural3Stern },
                                                parameters,
                                                new List<string>() { "der", "die", "die" });
            noun.DativSingular = new List<Inflection>() 
            {
                new Inflection() {
                    Article = this.GetGenus(parameters[ParameterNameUebersichtParser.Genus], Case.Dative),
                    InflectedWord = GetCaseOrPagename(parameters, ParameterNameUebersichtParser.Dativ, word)
                },
                new Inflection() {
                    InflectedWord = GetCaseOrPagename(parameters, ParameterNameUebersichtParser.Dativ, word)
                } 
            };
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.DativStern))
            {
                Console.WriteLine(string.Format("DeutschAdjektivischUebersichtParser: Add unit test: {0}", word));
                noun.DativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.DativStern] });
            }
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.DativSingularStern))
            {
                noun.DativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.DativSingularStern] });
            }
            noun.DativPlural = this.GetPlural(new List<string>() { ParameterNameUebersichtParser.DativPlural, ParameterNameUebersichtParser.DativPlural1 },
                                                  new List<string>() { ParameterNameUebersichtParser.DativPlural2, ParameterNameUebersichtParser.DativPlural2Stern },
                                                  new List<string>() { ParameterNameUebersichtParser.DativPlural3, ParameterNameUebersichtParser.DativPlural3Stern },
                                                  parameters,
                                                  new List<string>() { "den", "die", "die" });
            noun.AkkusativSingular = new List<Inflection>()
            {
                new Inflection() 
                {
                    Article = this.GetGenus(parameters[ParameterNameUebersichtParser.Genus], Case.Accusative),
                    InflectedWord = GetCaseOrPagename(parameters, ParameterNameUebersichtParser.Akkusativ, word)
                } ,
                new Inflection() 
                {
                    InflectedWord = GetCaseOrPagename(parameters, ParameterNameUebersichtParser.Akkusativ, word)
                } 
            };
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.AkkusativStern))
            {
                Console.WriteLine(string.Format("DeutschAdjektivischUebersichtParser: Add unit test 4: {0}", word));
                noun.AkkusativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.AkkusativStern] });
            }
            noun.AkkusativPlural = this.GetPlural(new List<string>() { ParameterNameUebersichtParser.AkkusativPlural, ParameterNameUebersichtParser.AkkusativPlural1 },
                                                  new List<string>() { ParameterNameUebersichtParser.AkkusativPlural2, ParameterNameUebersichtParser.AkkusativPlural2Stern },
                                                  new List<string>() { ParameterNameUebersichtParser.AkkusativPlural3, ParameterNameUebersichtParser.AkkusativPlural3Stern },
                                                  parameters,
                                                  new List<string>() { "die", "die", "die" });
            Stats.Instance.NounsDeutschNameUebersichtTotal++;
            return noun;
        }

        protected string GetGrundformOrPagename(Dictionary<string, string> parameters, string word)
        {
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.Grundform))
            {
                return parameters[ParameterNameUebersichtParser.Grundform];
            }
            else
            {
                return word;
            }
        }

        protected string GetCaseOrPagename(Dictionary<string, string> parameters, string caseName, string word)
        {
            if (base.ContainsNonEmpty(parameters, caseName))
            {
                return parameters[caseName];
            }
            else
            {
                return word;
            }
        }

        protected List<Inflection> GetPlural(List<string> keys1, List<string> keys2, List<string> keys3, Dictionary<string, string> parameters, List<string> genus)
        {
            List<Inflection> inflection = new List<Inflection>();
            if (base.ContainsNonEmpty(parameters, keys1[0]))
            {
                inflection.Add(new Inflection() { Article = genus[0], InflectedWord = parameters[keys1[0]] });
            }
            else if (base.ContainsNonEmpty(parameters, keys1[1]))
            {
                inflection.Add(new Inflection() { Article = genus[0], InflectedWord = parameters[keys1[1]] });
            }
            if (base.ContainsNonEmpty(parameters, keys2[0]))
            {
                inflection.Add(new Inflection() { Article = genus[1], InflectedWord = parameters[keys2[0]] });
                if (base.ContainsNonEmpty(parameters, keys2[1]))
                {
                    inflection.Add(new Inflection() { InflectedWord = parameters[keys2[1]] });
                }
            }
            if (base.ContainsNonEmpty(parameters, keys3[0]))
            {
                inflection.Add(new Inflection() { Article = genus[2], InflectedWord = parameters[keys3[0]] });
                if (base.ContainsNonEmpty(parameters, keys3[1]))
                {
                    inflection.Add(new Inflection() { InflectedWord = parameters[keys3[1]] });
                }
            }

            return inflection;
        }

        protected string GetGenus(string genus, Case caseNoun)
        {
            switch (caseNoun)
            {
                case Case.Nominative:
                    switch (genus)
                    {
                        case "m": return "der";
                        case "f": return "die";
                        case "n": return "das";
                        default: throw new ArgumentException("Genus not supported");
                    }
                case Case.Genitive:
                    switch (genus)
                    {
                        case "m": return "des";
                        case "f": return "der";
                        case "n": return "des";
                        default: throw new ArgumentException("Genus not supported");
                    }
                case Case.Dative:
                    switch (genus)
                    {
                        case "m": return "dem";
                        case "f": return "der";
                        case "n": return "dem";
                        default: throw new ArgumentException("Genus not supported");
                    }
                case Case.Accusative:
                    switch (genus)
                    {
                        case "m": return "den";
                        case "f": return "die";
                        case "n": return "das";
                        default: throw new ArgumentException("Genus not supported");
                    }
                default: throw new ArgumentException("Genus not supported");
            }
        }

        public List<string> GetCleanedTemplateBlock(string word, string[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Name Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "DeutschNameUebersichtParser");
            cleanedLines = cleanedLines.Where(x => !x.Equals("{{Deutsch Name Übersicht")).ToList();
            if (cleanedLines[0].StartsWith("{{Deutsch Name Übersicht|"))
            {
                cleanedLines[0] = cleanedLines[0].Replace("{{Deutsch Name Übersicht|", string.Empty);
            }
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



        public class ParameterNameUebersichtParser
        {
            public const string Grundform = "Grundform";
            public const string Plural = "Plural";
            public const string Stamm = "Stamm";
            public const string Genus = "Genus";
            public const string NominativPlural = "Nominativ Plural";
            public const string NominativPlural1 = "Nominativ Plural 1";
            public const string NominativPlural2 = "Nominativ Plural 2";
            public const string NominativPlural2Stern = "Nominativ Plural 2*";
            public const string NominativPlural3 = "Nominativ Plural 3";
            public const string NominativPlural3Stern = "Nominativ Plural 3*";
            public const string Genitiv = "Genitiv";
            public const string KeinS = "kein-s";
            public const string GenitivSingular = "Genitiv Singular";
            public const string GenitivStern = "Genitiv*";
            public const string GenitivPlural = "Genitiv Plural";
            public const string GenitivPlural1 = "Genitiv Plural 1";
            public const string GenitivPlural2 = "Genitiv Plural 2";
            public const string GenitivPlural2Stern = "Genitiv Plural 2*";
            public const string GenitivPlural3 = "Genitiv Plural 3";
            public const string GenitivPlural3Stern = "Genitiv Plural 3*";
            public const string Dativ = "Dativ";
            public const string DativStern = "Dativ*";
            public const string DativSingularStern = "Dativ Singular*";
            public const string DativPlural = "Dativ Plural";
            public const string DativPlural1 = "Dativ Plural 1";
            public const string DativPlural2 = "Dativ Plural 2";
            public const string DativPlural2Stern = "Dativ Plural 2*";
            public const string DativPlural3 = "Dativ Plural 3";
            public const string DativPlural3Stern = "Dativ Plural 3*";
            public const string Akkusativ = "Akkusativ";
            public const string AkkusativStern = "Akkusativ*";
            public const string AkkusativSingularStern = "Akkusativ Singular*";
            public const string AkkusativPlural = "Akkusativ Plural";
            public const string AkkusativPlural1 = "Akkusativ Plural 1";
            public const string AkkusativPlural2 = "Akkusativ Plural 2";
            public const string AkkusativPlural2Stern = "Akkusativ Plural 2*";
            public const string AkkusativPlural3 = "Akkusativ Plural 3";
            public const string AkkusativPlural3Stern = "Akkusativ Plural 3*";
        }
    }
}
