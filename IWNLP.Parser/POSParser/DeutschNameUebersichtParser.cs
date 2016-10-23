using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWNLP.Models.Nouns;

namespace IWNLP.Parser.POSParser
{
    public class DeutschNameUebersichtParser : ParserBase
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
            noun.NominativPlural = this.GetPlural(new List<String>() { ParameterNameUebersichtParser.NominativPlural, ParameterNameUebersichtParser.NominativPlural1 },
                                                  new List<String>() { ParameterNameUebersichtParser.NominativPlural2, ParameterNameUebersichtParser.NominativPlural2Stern },
                                                  new List<String>() { ParameterNameUebersichtParser.NominativPlural3, ParameterNameUebersichtParser.NominativPlural3Stern },
                                                  parameters,
                                                  new List<String>() { "die", "die", "die" });
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
                        if (StrRightC(word, 1) == "s") { noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}’", word) }); }
                        else { noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}s", word) }); }
                    }
                    break;
                case "f":
                    if (!base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.KeinS))
                    {
                        if (StrRightC(word, 1) == "s") { noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}’", word) }); }
                        else { noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}s", word) }); }
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
                        noun.GenitivSingular.Add(new Inflection() { Article = "des", InflectedWord = String.Format("{0}’", word) });
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}’", word) });
                    }
                    else
                    {
                        noun.GenitivSingular.Add(new Inflection() { Article = "des", InflectedWord = String.Format("{0}s", word) });
                        noun.GenitivSingular.Add(new Inflection() { InflectedWord = String.Format("{0}s", word) });
                    }
                    break;
                default:
                    throw new ArgumentException("Genus not supported");

            }
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.GenitivStern))
            {
                noun.GenitivSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.GenitivStern] });
            }
            noun.GenitivPlural = this.GetPlural(new List<String>() { ParameterNameUebersichtParser.GenitivPlural, ParameterNameUebersichtParser.GenitivPlural1 },
                                                new List<String>() { ParameterNameUebersichtParser.GenitivPlural2, ParameterNameUebersichtParser.GenitivPlural2Stern },
                                                new List<String>() { ParameterNameUebersichtParser.GenitivPlural3, ParameterNameUebersichtParser.GenitivPlural3Stern },
                                                parameters,
                                                new List<String>() { "der", "die", "die" });
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
                Console.WriteLine(String.Format("DeutschAdjektivischUebersichtParser: Add unit test: {0}", word));
                noun.DativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.DativStern] });
            }
            if (base.ContainsNonEmpty(parameters, ParameterNameUebersichtParser.DativSingularStern))
            {
                noun.DativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.DativSingularStern] });
            }
            noun.DativPlural = this.GetPlural(new List<String>() { ParameterNameUebersichtParser.DativPlural, ParameterNameUebersichtParser.DativPlural1 },
                                                  new List<String>() { ParameterNameUebersichtParser.DativPlural2, ParameterNameUebersichtParser.DativPlural2Stern },
                                                  new List<String>() { ParameterNameUebersichtParser.DativPlural3, ParameterNameUebersichtParser.DativPlural3Stern },
                                                  parameters,
                                                  new List<String>() { "den", "die", "die" });
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
                Console.WriteLine(String.Format("DeutschAdjektivischUebersichtParser: Add unit test 4: {0}", word));
                noun.AkkusativSingular.Add(new Inflection() { InflectedWord = parameters[ParameterNameUebersichtParser.AkkusativStern] });
            }
            noun.AkkusativPlural = this.GetPlural(new List<String>() { ParameterNameUebersichtParser.AkkusativPlural, ParameterNameUebersichtParser.AkkusativPlural1 },
                                                  new List<String>() { ParameterNameUebersichtParser.AkkusativPlural2, ParameterNameUebersichtParser.AkkusativPlural2Stern },
                                                  new List<String>() { ParameterNameUebersichtParser.AkkusativPlural3, ParameterNameUebersichtParser.AkkusativPlural3Stern },
                                                  parameters,
                                                  new List<String>() { "die", "die", "die" }); ;
            return noun;
        }

        protected String GetGrundformOrPagename(Dictionary<String, String> parameters, String word)
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

        protected String GetCaseOrPagename(Dictionary<String, String> parameters, String caseName, String word)
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

        protected List<Inflection> GetPlural(List<String> keys1, List<String> keys2, List<String> keys3, Dictionary<String, String> parameters, List<String> genus)
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

        protected String GetGenus(String genus, Case caseNoun)
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

        public List<String> GetCleanedTemplateBlock(String word, String[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Name Übersicht")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            String[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<String> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "DeutschNameUebersichtParser");
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



        public class ParameterNameUebersichtParser
        {
            public const String Grundform = "Grundform";
            public const String Plural = "Plural";
            public const String Stamm = "Stamm";
            public const String Genus = "Genus";
            public const String NominativPlural = "Nominativ Plural";
            public const String NominativPlural1 = "Nominativ Plural 1";
            public const String NominativPlural2 = "Nominativ Plural 2";
            public const String NominativPlural2Stern = "Nominativ Plural 2*";
            public const String NominativPlural3 = "Nominativ Plural 3";
            public const String NominativPlural3Stern = "Nominativ Plural 3*";
            public const String Genitiv = "Genitiv";
            public const String KeinS = "kein-s";
            public const String GenitivSingular = "Genitiv Singular";
            public const String GenitivStern = "Genitiv*";
            public const String GenitivPlural = "Genitiv Plural";
            public const String GenitivPlural1 = "Genitiv Plural 1";
            public const String GenitivPlural2 = "Genitiv Plural 2";
            public const String GenitivPlural2Stern = "Genitiv Plural 2*";
            public const String GenitivPlural3 = "Genitiv Plural 3";
            public const String GenitivPlural3Stern = "Genitiv Plural 3*";
            public const String Dativ = "Dativ";
            public const String DativStern = "Dativ*";
            public const String DativSingularStern = "Dativ Singular*";
            public const String DativPlural = "Dativ Plural";
            public const String DativPlural1 = "Dativ Plural 1";
            public const String DativPlural2 = "Dativ Plural 2";
            public const String DativPlural2Stern = "Dativ Plural 2*";
            public const String DativPlural3 = "Dativ Plural 3";
            public const String DativPlural3Stern = "Dativ Plural 3*";
            public const String Akkusativ = "Akkusativ";
            public const String AkkusativStern = "Akkusativ*";
            public const String AkkusativSingularStern = "Akkusativ Singular*";
            public const String AkkusativPlural = "Akkusativ Plural";
            public const String AkkusativPlural1 = "Akkusativ Plural 1";
            public const String AkkusativPlural2 = "Akkusativ Plural 2";
            public const String AkkusativPlural2Stern = "Akkusativ Plural 2*";
            public const String AkkusativPlural3 = "Akkusativ Plural 3";
            public const String AkkusativPlural3Stern = "Akkusativ Plural 3*";
        }
    }
}
