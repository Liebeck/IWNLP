using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser.VerbTemplates.unregelmaessig
{
    public class VerbUnregelmaessigParser : VerbConjugationParserBase
    {
        List<String> blacklist = new List<string>() { }; // currently empty

        public Dictionary<String, String> ParseParameters(String[] input, String word)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            String[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch Verb unregelmäßig|");
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
                else // also keep empty values
                {
                    // find next unnamed parameter
                    parameters[base.GetNextUnnamedParameter(parameters)] = inputSplitted[i];
                }
            }
            if (parameters.Count == 0)
            {
                System.Diagnostics.Debugger.Break();
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
            List<String> condition = new List<string>() { "dürfen", "können", "mögen", "müssen", "sollen", "wissen", "wollen" };
            List<String> condition2 = new List<string>() { "behält", "beläd", "berät", "brät", "enthält", "entläd", "enträt", "erhält", "errät", "gerät", "hält", "läd", "missrät", "rät", "überbrät", "überhält", "überläd", "unterhält", "verbrät", "verhält", "verläd", "verrät", "widerrät", "wir" };

            verb.PartizipII = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter5];
            if (parameters.ContainsKey(ParameterUnregelmaessig.PartizipPlus))
            {
                verb.PartizipIIAlternativ = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.PartizipPlus];
            }
            #region Präsens Indikativ Singular 1 Person
            verb.PräsensAktivIndikativ_Singular1Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (ich)"))
            {
                if (!parameters["Indikativ Präsens (ich)"].Contains("<br />ich"))
                {
                    verb.PräsensAktivIndikativ_Singular1Person.Add(parameters["Indikativ Präsens (ich)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else // example: "Flexion:tun"
                {
                    String[] multipleValues = parameters["Indikativ Präsens (ich)"].Split(new String[] { "<br />ich" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräsensAktivIndikativ_Singular1Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }

                }

            }
            else
            {

                String indicative = String.Empty;
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                {
                    if (condition.Contains(parameters[ParameterUnregelmaessig.Parameter10]))
                    {
                        if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                        {
                            indicative = parameters[ParameterUnregelmaessig.Parameter6] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                        }
                        else
                        {
                            indicative = parameters[ParameterUnregelmaessig.Parameter2];
                        }
                    }
                    else
                    {
                        if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                        {
                            indicative = parameters[ParameterUnregelmaessig.Parameter6];
                        }
                        else
                        {
                            indicative = parameters[ParameterUnregelmaessig.Parameter2] + "e";
                        }
                    }

                }
                else
                {
                    indicative = parameters[ParameterUnregelmaessig.Parameter2] + "e";
                }
                verb.PräsensAktivIndikativ_Singular1Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));




            }
            #endregion
            #region Präsens Indikativ Singular 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (ich)"))
                {

                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (ich)"]);

                }
                else
                {
                    String indicativeNebensatz = parameters[ParameterUnregelmaessig.Parameter1];
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            indicativeNebensatz += GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "e";
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6)))
                            {
                                indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter6];
                            }
                            else
                            {
                                indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter2];
                            }
                        }
                    }
                    else
                    {
                        indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter2] + "e";
                    }
                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(indicativeNebensatz);
                }

            }
            #endregion

            #region Präsens Indikativ Singular 2 Person
            verb.PräsensAktivIndikativ_Singular2Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (du)"))
            {
                parameters["Indikativ Präsens (du)"] = CleanLine(parameters["Indikativ Präsens (du)"]);
                List<String> multilineFormats = new List<string>() { "<br>du" };

                if (!multilineFormats.Any(x => parameters["Indikativ Präsens (du)"].Contains(x)))
                {
                    verb.PräsensAktivIndikativ_Singular2Person.Add(parameters["Indikativ Präsens (du)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else // example: "Flexion:bieten"
                {
                    parameters["Indikativ Präsens (du)"] = parameters["Indikativ Präsens (du)"].Replace(",", String.Empty);
                    String[] multipleValues = parameters["Indikativ Präsens (du)"].Split(multilineFormats.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräsensAktivIndikativ_Singular2Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                }
            }
            else
            {
                String indicative = String.Empty;
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                {
                    indicative += parameters[ParameterUnregelmaessig.Parameter6];
                }
                else
                {
                    indicative += parameters[ParameterUnregelmaessig.Parameter2];
                }
                if (condition2.Contains(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6)))
                {
                    indicative += "st";
                }
                else
                {
                    if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) == "i")
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            case "-s": indicative += "t"; break;
                            case "e2": break;
                            default: indicative += "st"; break;
                        }
                    }
                    else
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            case "e":
                            case "e-":
                                indicative += "est"; break;
                            case "-s": indicative += "t"; break;
                            case "e2": break;
                            default: indicative += "st"; break;
                        }
                    }
                }
                verb.PräsensAktivIndikativ_Singular2Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion
            #region Präsens Indikativ Singular 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (du)"))
                {
                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (du)"]);
                }
                else
                {
                    String indicativeNebensatz = parameters[ParameterUnregelmaessig.Parameter1];
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                    {
                        indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter6];
                    }
                    else
                    {
                        indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter2];
                    }

                    if (condition2.Contains(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6)))
                    {
                        indicativeNebensatz += "st";
                    }
                    else
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) == "i")
                        {
                            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                            {
                                case "-s": indicativeNebensatz += "t"; break;
                                case "e2": break;
                                default: indicativeNebensatz += "st"; break;
                            }
                        }
                        else
                        {
                            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                            {
                                case "e":
                                case "e-":
                                    indicativeNebensatz += "est"; break;
                                case "-s": indicativeNebensatz += "t"; break;
                                case "e2": break;
                                default: indicativeNebensatz += "st"; break;
                            }
                        }
                    }
                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(indicativeNebensatz);
                }

            }
            #endregion

            #region Präsens Indikativ Singular 3 Person
            verb.PräsensAktivIndikativ_Singular3Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (man)"))
            {
                parameters["Indikativ Präsens (man)"] = CleanLine(parameters["Indikativ Präsens (man)"]);
                List<String> multilineFormats = new List<string>() { "<br />er/sie/es", "<br>er/sie/es" };

                if (!multilineFormats.Any(x => parameters["Indikativ Präsens (man)"].Contains(x)))
                {
                    verb.PräsensAktivIndikativ_Singular3Person.Add(parameters["Indikativ Präsens (man)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else // example: "Flexion:gebieten"
                {
                    parameters["Indikativ Präsens (man)"] = parameters["Indikativ Präsens (man)"].Replace(",", String.Empty);
                    String[] multipleValues = parameters["Indikativ Präsens (man)"].Split(multilineFormats.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräsensAktivIndikativ_Singular3Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                }
            }
            else
            {
                String indicative = String.Empty;
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                {
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                    {
                        indicative = parameters[ParameterUnregelmaessig.Parameter6] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                    }
                    else
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            indicative = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "t";
                        }
                        else
                        {
                            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                            {
                                indicative = parameters[ParameterUnregelmaessig.Parameter6] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                            }
                            else
                            {
                                indicative = parameters[ParameterUnregelmaessig.Parameter2];
                            }
                        }
                    }
                }
                else
                {
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                    {
                        indicative = parameters[ParameterUnregelmaessig.Parameter6];
                    }
                    else
                    {
                        indicative = parameters[ParameterUnregelmaessig.Parameter2];
                    }
                    // APPEND
                    if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) == "i")
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            case "e":
                            case "e-":
                            case "e2":
                                break;
                            default: indicative += "t";
                                break;
                        }
                    }
                    else
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6))
                        {
                            case "behält":
                            case "berät":
                            case "brät":
                            case "enthält":
                            case "enträt":
                            case "erhält":
                            case "errät":
                            case "gerät":
                            case "hält":
                            case "missrät":
                            case "rät":
                            case "überbrät":
                            case "überhält":
                            case "unterhält":
                            case "verbrät":
                            case "verhält":
                            case "verrät":
                            case "widerrät":
                                break;
                            case "wir":
                                indicative += "d";
                                break;
                            case "beläd":
                            case "entläd":
                            case "läd":
                            case "überläd":
                            case "verläd":
                                indicative += "t";
                                break;
                            default:
                                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                {
                                    case "e":
                                    case "e-":
                                        indicative += "et";
                                        break;
                                    default:
                                        indicative += "t";
                                        break;
                                }
                                break;
                        }
                    }
                }
                verb.PräsensAktivIndikativ_Singular3Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion


            #region Präsens Indikativ Singular 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (man)"))
                {
                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (man)"]);
                }
                else
                {
                    String indicativeNebensatz = parameters[ParameterUnregelmaessig.Parameter1];
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            indicativeNebensatz += GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "t";
                        }
                        else
                        {
                            indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter6];
                        }
                    }
                    else
                    {
                        if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                        {
                            indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter6];
                        }
                        else
                        {
                            indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter2];
                        }
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6))
                        {
                            case "behält":
                            case "berät":
                            case "brät":
                            case "enthält":
                            case "enträt":
                            case "erhält":
                            case "errät":
                            case "ficht":
                            case "gerät":
                            case "hält":
                            case "missrät":
                            case "rät":
                            case "tritt":
                            case "überbrät":
                            case "überhält":
                            case "unterhält":
                            case "verbrät":
                            case "verhält":
                            case "verrät":
                            case "widerrät":
                                break;
                            case "wir":
                                indicativeNebensatz += "d";
                                break;
                            case "beläd":
                            case "entläd":
                            case "läd":
                            case "überläd":
                            case "verläd":
                                indicativeNebensatz += "t";
                                break;
                            default:
                                if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) == "i")
                                {
                                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                    {
                                        case "e2":
                                            break;
                                        default:
                                            indicativeNebensatz += "t";
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                    {
                                        case "e":
                                        case "e-":
                                            indicativeNebensatz += "et";
                                            break;
                                        default:
                                            indicativeNebensatz += "t";
                                            break;
                                    }
                                }
                                break;
                        }

                    }
                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(indicativeNebensatz);
                }

            }
            #endregion

            #region Präsens Indikativ Plural 1 Person
            verb.PräsensAktivIndikativ_Plural1Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (wir)"))
            {
                verb.PräsensAktivIndikativ_Plural1Person.Add(parameters["Indikativ Präsens (wir)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            else
            {
                String indicative = String.Empty;
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                {
                    indicative = parameters[ParameterUnregelmaessig.Parameter10];
                }
                else
                {
                    indicative = parameters[ParameterUnregelmaessig.Parameter2] + "en";
                }
                verb.PräsensAktivIndikativ_Plural1Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präsens Indikativ Plural 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (wir)"))
                {
                    verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters["Indikativ Präsens (wir)"]);
                }
                else
                {
                    verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                }
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person
            verb.PräsensAktivIndikativ_Plural2Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (ihr)"))
            {
                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters["Indikativ Präsens (ihr)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            else
            {
                String indicative = parameters[ParameterUnregelmaessig.Parameter2];
                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                {
                    case "e":
                    case "e-":
                    case "e2":
                        indicative += "et";
                        break;
                    default:
                        indicative += "t";
                        break;

                }
                verb.PräsensAktivIndikativ_Plural2Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (ihr)"))
                {
                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters["Indikativ Präsens (ihr)"]);
                }
                else
                {
                    String indicativeNebensatz = parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter2];
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                    {
                        case "e":
                        case "e-":
                        case "e2":
                            indicativeNebensatz += "et";
                            break;
                        default:
                            indicativeNebensatz += "t";
                            break;
                    }
                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(indicativeNebensatz);
                }

            }
            #endregion

            #region Präsens Indikativ Plural 3 Plural
            verb.PräsensAktivIndikativ_Plural3Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (sie)"))
            {
                verb.PräsensAktivIndikativ_Plural3Person.Add(parameters["Indikativ Präsens (sie)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            else
            {
                String indicative = String.Empty;
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                {
                    switch (parameters[ParameterUnregelmaessig.Parameter10])
                    {
                        case "tun":
                            indicative = "tun";
                            break;
                        default:
                            indicative = parameters[ParameterUnregelmaessig.Parameter10];
                            break;
                    }
                }
                else
                {
                    indicative = parameters[ParameterUnregelmaessig.Parameter2] + "en";
                }
                verb.PräsensAktivIndikativ_Plural3Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präsens Indikativ Plural 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (sie)"))
                {
                    verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters["Indikativ Präsens (sie)"]);
                }
                else
                {
                    verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                }

            }
            #endregion

            #region Präteritum Indikativ Singular 1 Person
            verb.PräteritumAktivIndikativ_Singular1Person = new List<string>();
            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            #endregion

            #region Präteritum Indikativ Singular 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3]);
            }

            #endregion

            #region Präteritum Indikativ Singular 2 Person
            verb.PräteritumAktivIndikativ_Singular2Person = new List<string>();
            switch (StrSubrev(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3), 5, 5))
            {
                case "hielt":
                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    break;
                default:
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                    {
                        case "n":
                        case "in":
                        case "ni":
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                            break;
                        default:
                            if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7) == "-s")
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3))
                                {
                                    case "erkor":
                                    case "kor":
                                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                        break;
                                    default:
                                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "t" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                        break;

                                }
                            }
                            else
                            {
                                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3))
                                {
                                    case "briet":
                                    case "hielt":
                                    case "lud":
                                    case "riet":
                                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                        break;
                                    default:
                                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                        {
                                            case "e":
                                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                                break;
                                            case "e-":
                                            case "em":
                                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                                break;
                                            case "e2":
                                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                                break;
                                            default:
                                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                                break;
                                        }
                                        break;
                                }
                            }
                            break;
                    }
                    if (parameters.ContainsKey("Indikativ Präteritum Aktiv Alternativform (du)"))
                    {
                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (du)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                    break;
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                switch (StrSubrev(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3), 5, 5))
                {
                    case "hielt":
                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "est");
                        break;
                    default:
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                        {
                            case "n":
                            case "in":
                            case "ni":
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                break;
                            default:
                                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                {
                                    case "e":
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "est");
                                        break;
                                    case "e2":
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3]);
                                        break;
                                    case "-s":
                                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3))
                                        {
                                            case "erkor":
                                            case "kor":
                                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                                break;
                                            default:
                                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                                                break;
                                        }
                                        break;
                                    default:
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                        break;
                                }
                                break;
                        }
                        if (parameters.ContainsKey("Indikativ Präteritum Aktiv Alternativform (du)"))
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (du)"]);
                        }
                        break;
                }
            }

            #endregion


            #region Präteritum Indikativ Singular 3 Person
            verb.PräteritumAktivIndikativ_Singular3Person = new List<string>();
            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            #endregion

            #region Präteritum Indikativ Singular 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3]);
            }

            #endregion

            #region Präteritum Indikativ Plural 1 Person
            verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
            {
                case "n":
                case "in":
                case "ni":
                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "n" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    break;
                default:
                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "en" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    break;
            }

            #endregion

            #region Präteritum Indikativ Plural 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                {
                    case "n":
                    case "in":
                    case "ni":
                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "n");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "en");
                        break;
                }
            }

            #endregion

            #region Präteritum Indikativ Plural 2 Person
            verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
            {
                if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                {
                    verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "et" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                    {
                        case "n":
                        case "in":
                        case "ni":
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "t" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "et" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                            break;
                    }
                }
            }
            else
            {
                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                {
                    case "n":
                    case "in":
                    case "ni":
                        verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "t" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        break;
                    default:
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            case "e":
                            case "e-":
                            case "em":
                            case "e2":
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "et" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "t" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                                break;
                        }
                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                {
                    if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                    {
                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "et");
                    }
                    else
                    {
                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                    }
                }
                else
                {
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                    {
                        case "n":
                        case "in":
                        case "ni":
                            verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                            break;
                        default:
                            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                            {
                                case "e":
                                case "e-":
                                case "em":
                                case "e2":
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "et");
                                    break;
                                default:
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                                    break;
                            }
                            break;

                    }
                }
            }

            #endregion

            #region Präteritum Indikativ Plural 3 Person
            verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
            {
                case "n":
                case "in":
                case "ni":
                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "n" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    break;
                default:
                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "en" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    break;
            }

            #endregion

            #region Präteritum Indikativ Plural 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !String.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
            {
                verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                {
                    case "n":
                    case "in":
                    case "ni":
                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "n");
                        break;
                    default:
                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters[ParameterUnregelmaessig.Parameter3] + "en");
                        break;
                }
            }
            #endregion
            return verb;
        }
    }
}
