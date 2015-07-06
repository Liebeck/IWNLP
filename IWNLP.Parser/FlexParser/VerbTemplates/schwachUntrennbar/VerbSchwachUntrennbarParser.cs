using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser.VerbTemplates.schwachUntrennbar
{
    public class VerbSchwachUntrennbarParser : VerbConjugationParserBase
    {

        List<String> blacklist = new List<string>() {
        };

        public Dictionary<String, String> ParseParameters(String[] input, String word)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            String[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch Verb schwach untrennbar|");
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
                    parameters["1"] = inputSplitted[i++];
                    parameters["2"] = inputSplitted[i++];
                    parameters["3"] = inputSplitted[i++];
                    parameters["4"] = inputSplitted[i++];
                    parameters["5"] = inputSplitted[i++];
                    parameters[ParameterSchwachUntrennbar.PartizipII] = inputSplitted[i];
                }
            }
            return parameters;
        }

        public VerbConjugation Parse(String word, String[] input)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            return this.Parse(word, this.ParseParameters(input, word));
        }

        public VerbConjugation Parse(String word, Dictionary<String, String> parameters)
        {
            VerbConjugation verb = new VerbConjugation();
            verb.PartizipII = parameters[ParameterSchwachUntrennbar.PartizipII];
            if (parameters.ContainsKey(ParameterSchwachUntrennbar.PartizipPlus))
            {
                verb.PartizipIIAlternativ = parameters[ParameterSchwachUntrennbar.PartizipPlus];
            }
            List<String> condition = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "p", "s", "t", "v", "w", "x", "z", "ß" };
            List<String> condition2 = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "m", "p", "s", "t", "v", "w", "x", "z", "ß" };
            #region Präsens Indikativ Singular 1 Person
            verb.PräsensAktivIndikativ_Singular1Person = new List<string>();
            if (parameters.ContainsKey("1. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters["1. Singular Indikativ Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]
                                + "e");
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]
                                + "e");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]
                                + "e");
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter4]
                                + "e");
                        }
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "e");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "e");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "e");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "e");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "e");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "e");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "e");
                        break;
                    default:
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "e")
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "e");
                        }
                        break;
                }
            }
            #endregion

            #region Präsens Indikativ Singular 2 Person
            verb.PräsensAktivIndikativ_Singular2Person = new List<string>();
            if (parameters.ContainsKey("2. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters["2. Singular Indikativ Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "st");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "est");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "st");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "est");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "st");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "st");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "st");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "st");
                        break;
                    case "s":
                    case "ß":
                    case "c":
                    case "x":
                    case "z":
                        verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "t");
                        break;
                    default:
                        verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "st");

                        break;
                }
            }
            #endregion

            #region Präsens Indikativ Singular 3 Person
            verb.PräsensAktivIndikativ_Singular3Person = new List<string>();
            if (parameters.ContainsKey("3. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters["3. Singular Indikativ Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "t");

                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "et");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "et");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "t");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "t");
                        break;
                    default:
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "e")
                        {
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                }
            }
            #endregion

            #region Präsens Indikativ Plural 1 Person
            verb.PräsensAktivIndikativ_Plural1Person = new List<string>();
            if (parameters.ContainsKey("1. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural1Person.Add(parameters["1. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {

                verb.PräsensAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                    + parameters[ParameterSchwachUntrennbar.Parameter3]
                    + parameters[ParameterSchwachUntrennbar.Parameter4]
                    + "n");
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person
            verb.PräsensAktivIndikativ_Plural2Person = new List<string>();
            if (parameters.ContainsKey("2. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters["2. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "t");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "et");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "et");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "t");
                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "t");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "t");
                        break;
                    default:
                        verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "t");

                        break;
                }
            }
            #endregion

            #region Präsens Indikativ Plural 3 Person
            verb.PräsensAktivIndikativ_Plural3Person = new List<string>();
            if (parameters.ContainsKey("3. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural3Person.Add(parameters["3. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {

                verb.PräsensAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                    + parameters[ParameterSchwachUntrennbar.Parameter3]
                    + parameters[ParameterSchwachUntrennbar.Parameter4]
                    + "n");
            }
            #endregion

            #region Präteritum Indikativ Singular 1 Person
            verb.PräteritumAktivIndikativ_Singular1Person = new List<string>();
            if (parameters.ContainsKey("1. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters["1. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "te");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "ete");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ete");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "te");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "te");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "te");

                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person
            verb.PräteritumAktivIndikativ_Singular2Person = new List<string>();
            if (parameters.ContainsKey("2. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters["2. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "test");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "etest");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "test");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "etest");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "test");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "test");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "test");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "test");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "test");

                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 3 Person
            verb.PräteritumAktivIndikativ_Singular3Person = new List<string>();
            if (parameters.ContainsKey("3. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters["3. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "te");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "ete");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ete");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "te");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "te");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "te");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "te");

                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 1 Person
            verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
            if (parameters.ContainsKey("1. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters["1. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "ten");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "eten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "eten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "ten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "ten");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "ten");

                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person
            verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
            if (parameters.ContainsKey("2. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters["2. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "tet");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "etet");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "tet");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "etet");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "tet");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "tet");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "tet");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "tet");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "tet");

                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 3 Person
            verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
            if (parameters.ContainsKey("3. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters["3. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":

                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "ten");
                        break;
                    case "m":
                        if (condition.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "eten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "n":
                        if (condition2.Contains(parameters[ParameterSchwachUntrennbar.Parameter2]))
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "eten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                              + parameters[ParameterSchwachUntrennbar.Parameter3]
                              + parameters[ParameterSchwachUntrennbar.Parameter4]
                              + "ten");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                                + parameters[ParameterSchwachUntrennbar.Parameter3]
                                + "ten");
                        }
                        break;
                    case "d":
                    case "t":
                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + parameters[ParameterSchwachUntrennbar.Parameter4]
                            + "ten");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2]
                            + parameters[ParameterSchwachUntrennbar.Parameter3]
                            + "ten");

                        break;
                }
            }
            #endregion
            return verb;
        }

    }
}
