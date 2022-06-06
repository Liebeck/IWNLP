using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.FlexParser.VerbTemplates.schwachUntrennbar
{
    public class VerbSchwachUntrennbarParser : VerbConjugationParserBase
    {
        public Dictionary<string, string> ParseParameters(string[] input, string word)
        {
            string[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch Verb schwach untrennbar|");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            for (int i = 0; i < inputSplitted.Length; i++)
            {
                if (inputSplitted[i].Contains("="))
                {
                    inputSplitted[i] = base.CleanLine(inputSplitted[i]);
                    string[] keyValuePair = inputSplitted[i].Split(new char[] { '=' });
                    string key = keyValuePair[0].Trim();
                    string value = keyValuePair[1].Trim();
                    parameters[key] = value;
                }
                else
                {
                    if (string.IsNullOrEmpty(inputSplitted[i]))
                    {
                        Common.PrintError(word, string.Format("VerbSchwachUntrennbarParser: {0} parsing arguments, possible empty parameter", word));
                        break;
                    }
                    parameters["1"] = inputSplitted[i++];
                    parameters["2"] = inputSplitted[i++];
                    parameters["3"] = inputSplitted[i++];
                    parameters["4"] = inputSplitted[i++];
                    parameters["5"] = inputSplitted[i++];
                    parameters[ParameterSchwachUntrennbar.PartizipII] = inputSplitted[i];
                    if (parameters[ParameterSchwachUntrennbar.PartizipII].StartsWith("6=")) // Special case for "Flexion:brauchen"
                    {
                        parameters[ParameterSchwachUntrennbar.PartizipII] = parameters[ParameterSchwachUntrennbar.PartizipII].Substring(2);
                    }
                }
            }
            if (parameters.Any(x => x.Value.Contains("=")))
            {
                Common.PrintError(word, string.Format("VerbSchwachUntrennbarParser: {0} contains '='", word));
            }
            return parameters;
        }

        public VerbConjugation Parse(string word, string[] input)
        {
            return this.Parse(word, this.ParseParameters(input, word));
        }

        public VerbConjugation Parse(string word, Dictionary<string, string> parameters)
        {
            VerbConjugation verb = new VerbConjugation();
            verb.PartizipII = parameters[ParameterSchwachUntrennbar.PartizipII];
            if (parameters.ContainsKey(ParameterSchwachUntrennbar.PartizipPlus))
            {
                verb.PartizipIIAlternativ = parameters[ParameterSchwachUntrennbar.PartizipPlus];
            }
            List<string> condition = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "p", "s", "t", "v", "w", "x", "z", "ß" };
            List<string> condition2 = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "m", "p", "s", "t", "v", "w", "x", "z", "ß" };
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

            #region Präsens Konjunktiv Singular 1 Person
            verb.PräsensAktivKonjunktiv_Singular1Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters["1. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "e");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4]);
                        break;
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 2 Person
            verb.PräsensAktivKonjunktiv_Singular2Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "2. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters["2. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "est");
                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter4] + "est");
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "est");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "est");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "est");
                        break;
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 3 Person
            verb.PräsensAktivKonjunktiv_Singular3Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "3. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters["3. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "e");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "e");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "e");
                        break;
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 1 Person
            verb.PräsensAktivKonjunktiv_Plural1Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "1. Plural Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters["1. Plural Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "en");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "en");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "n");
                        break;
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 2 Person
            verb.PräsensAktivKonjunktiv_Plural2Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "2. Plural Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters["2. Plural Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "e":
                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "et");
                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter4] + "et");
                        break;
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "et");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "et");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "et");
                        break;
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 3 Person
            verb.PräsensAktivKonjunktiv_Plural3Person = new List<string>();
            if (base.ContainsNonEmpty(parameters, "3. Plural Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters["3. Plural Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                switch (parameters[ParameterSchwachUntrennbar.Parameter3])
                {
                    case "r":
                        if (parameters[ParameterSchwachUntrennbar.Parameter4] == "l")
                        {
                            verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "en");
                        }
                        else
                        {
                            verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + "en");
                        }
                        break;
                    default:
                        verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterSchwachUntrennbar.Parameter1] + parameters[ParameterSchwachUntrennbar.Parameter2] + parameters[ParameterSchwachUntrennbar.Parameter3] + parameters[ParameterSchwachUntrennbar.Parameter4] + "n");
                        break;
                }
            }
            #endregion


            #region Präteritum Konjunktiv Singular 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person = new List<string>();
                string key = "1. Singular Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Singular1Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >ich", ",</br >", "<br />" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Singular1Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person = verb.PräteritumAktivIndikativ_Singular1Person;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Singular Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person = new List<string>();
                string key = "2. Singular Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >du", ",</br >","</br >" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Singular2Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person = verb.PräteritumAktivIndikativ_Singular2Person;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Singular Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person = new List<string>();
                string key = "3. Singular Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Singular3Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >{{small|er/sie/es}}", ",</br >", "</br >" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Singular3Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person = verb.PräteritumAktivIndikativ_Singular3Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person = new List<string>();
                string key = "1. Plural Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Plural1Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >wir", ",</br >", "</br >" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Plural1Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person = verb.PräteritumAktivIndikativ_Plural1Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person = new List<string>();
                string key = "2. Plural Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >ihr", ",</br >", "</br >" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Plural2Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person = verb.PräteritumAktivIndikativ_Plural2Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person = new List<string>();
                string key = "3. Plural Konjunktiv Präteritum Aktiv";
                if (!parameters[key].Contains("</br >"))
                {
                    verb.PräteritumAktivKonjunktiv_Plural3Person.Add(parameters[key]);
                }
                else // example: "Flexion:brauchen"
                {
                    string[] multipleValues = parameters[key].Split(new string[] { ",</br >sie", ",</br >", "</br >" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräteritumAktivKonjunktiv_Plural3Person.Add(multipleValues[i].Trim());
                    }
                }
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person = verb.PräteritumAktivIndikativ_Plural3Person;
            }
            #endregion

            return verb;
        }

    }
}
