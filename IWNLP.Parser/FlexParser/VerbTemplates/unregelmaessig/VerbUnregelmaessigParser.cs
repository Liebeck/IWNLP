﻿using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.FlexParser.VerbTemplates.unregelmaessig
{
    public class VerbUnregelmaessigParser : VerbConjugationParserBase
    {
        public Dictionary<string, string> ParseParameters(string[] input, string word)
        {
            string[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch Verb unregelmäßig|");
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
                else // also keep empty values
                {
                    // find next unnamed parameter
                    parameters[base.GetNextUnnamedParameter(parameters)] = inputSplitted[i];
                }
            }

            if (parameters.Count == 0)
            {
                Common.PrintError(word, string.Format("VerbUnregelmaessigParser: {0} zero parameters", word));
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
            List<string> condition = new List<string>() { "dürfen", "können", "mögen", "müssen", "sollen", "wissen", "wollen" };
            List<string> condition2 = new List<string>() { "behält", "beläd", "berät", "brät", "enthält", "entläd", "enträt", "erhält", "errät", "gerät", "hält", "läd", "missrät", "rät", "überbrät", "überhält", "überläd", "unterhält", "verbrät", "verhält", "verläd", "verrät", "widerrät", "wir" };

            verb.PartizipII = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter5];
            if (parameters.ContainsKey(ParameterUnregelmaessig.PartizipPlus))
            {
                verb.PartizipIIAlternativ = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.PartizipPlus];
            }
            #region Präsens Indikativ Singular 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivIndikativ_Singular1Person = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (ich)"))
                {
                    if (!parameters["Indikativ Präsens (ich)"].Contains("<br />ich"))
                    {
                        verb.PräsensAktivIndikativ_Singular1Person.Add(parameters["Indikativ Präsens (ich)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                    else // example: "Flexion:tun"
                    {
                        string[] multipleValues = parameters["Indikativ Präsens (ich)"].Split(new string[] { "<br />ich" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multipleValues.Length; i++)
                        {
                            verb.PräsensAktivIndikativ_Singular1Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                    }
                }
                else
                {
                    string indicative = string.Empty;
                    if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter10) && !string.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter10]))
                    {
                        List<string> exceptionList1 = new List<string>() { "dürfen", "können", "mögen", "müssen", "sollen", "wissen", "wollen" };
                        if (exceptionList1.Contains(parameters[ParameterUnregelmaessig.Parameter10]))
                        {
                            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !string.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
                            {
                                indicative = parameters[ParameterUnregelmaessig.Parameter6];
                            }
                            else
                            {
                                indicative = parameters[ParameterUnregelmaessig.Parameter2];
                            }
                        }
                        else
                        {
                            if (parameters.ContainsKey(ParameterUnregelmaessig.Parameter6) && !string.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter6]))
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
            }


            #endregion
            #region Präsens Indikativ Singular 1 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if ((parameters.ContainsKey(ParameterUnregelmaessig.Parameter1) && !string.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Parameter1]))
                || (parameters.ContainsKey(ParameterUnregelmaessig.Reflexiv) && !string.IsNullOrEmpty(parameters[ParameterUnregelmaessig.Reflexiv])))
                {
                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Indikativ Präsens (ich)"))
                    {
                        verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (ich)"]);
                    }
                    else
                    {
                        string indicativeNebensatz = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                        if (ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                            {
                                indicativeNebensatz += GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "e";
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter6)))
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
            }
            #endregion

            #region Präsens Indikativ Singular 2 Person
            
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivIndikativ_Singular2Person = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (du)"))
                {
                    parameters["Indikativ Präsens (du)"] = CleanLine(parameters["Indikativ Präsens (du)"]);
                    List<string> multilineFormats = new List<string>() { "<br>du", "<br />du" };

                    if (!multilineFormats.Any(x => parameters["Indikativ Präsens (du)"].Contains(x)))
                    {
                        verb.PräsensAktivIndikativ_Singular2Person.Add(parameters["Indikativ Präsens (du)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                    else // example: "Flexion:bieten"
                    {
                        parameters["Indikativ Präsens (du)"] = parameters["Indikativ Präsens (du)"].Replace(",", string.Empty);
                        string[] multipleValues = parameters["Indikativ Präsens (du)"].Split(multilineFormats.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multipleValues.Length; i++)
                        {
                            verb.PräsensAktivIndikativ_Singular2Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                    }
                }
                else
                {
                    string indicative = string.Empty;
                    if (this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
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
                if (parameters.ContainsKey("Indikativ Präsens Alternativform (du)"))
                {
                    verb.PräsensAktivIndikativ_Singular2Person.Add(parameters["Indikativ Präsens Alternativform (du)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
            }
            #endregion
            #region Präsens Indikativ Singular 2 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Indikativ Präsens (du)"))
                    {
                        verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (du)"]);
                    }
                    else
                    {
                        string indicativeNebensatz = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                        if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
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
                    if (parameters.ContainsKey("Indikativ Präsens Alternativform (du)"))
                    {
                        verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens Alternativform (du)"]);
                    }

                }
            }
            #endregion

            #region Präsens Indikativ Singular 3 Person
            verb.PräsensAktivIndikativ_Singular3Person = new List<string>();

            if (parameters.ContainsKey("Indikativ Präsens (man)"))
            {
                parameters["Indikativ Präsens (man)"] = CleanLine(parameters["Indikativ Präsens (man)"]);
                List<string> multilineFormats = new List<string>() { "<br />er/sie/es", "<br>er/sie/es", "<br />" };

                if (!multilineFormats.Any(x => parameters["Indikativ Präsens (man)"].Contains(x)))
                {
                    verb.PräsensAktivIndikativ_Singular3Person.Add(parameters["Indikativ Präsens (man)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else // example: "Flexion:gebieten"
                {
                    parameters["Indikativ Präsens (man)"] = parameters["Indikativ Präsens (man)"].Replace(",", string.Empty);
                    string[] multipleValues = parameters["Indikativ Präsens (man)"].Split(multilineFormats.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        verb.PräsensAktivIndikativ_Singular3Person.Add(multipleValues[i].Trim() + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    }
                }
            }
            else
            {
                string indicative = string.Empty;
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                {
                    if (condition.Contains(parameters[ParameterUnregelmaessig.Parameter10]))
                    {
                        if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
                        {
                            indicative += parameters[ParameterUnregelmaessig.Parameter6];
                        }
                        else
                        {
                            indicative += parameters[ParameterUnregelmaessig.Parameter2];
                        }
                    }
                    else // default in switch
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            indicative += GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "t";
                        }
                        else
                        {
                            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
                            {
                                indicative += parameters[ParameterUnregelmaessig.Parameter6];
                            }
                            else
                            {
                                indicative += parameters[ParameterUnregelmaessig.Parameter2];
                            }
                        }
                    }
                }
                else // parameter 10 not set
                {
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
                    {
                        indicative += parameters[ParameterUnregelmaessig.Parameter6];
                    }
                    else
                    {
                        indicative += parameters[ParameterUnregelmaessig.Parameter2];
                    }
                    if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) == "i")
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            case "e":
                            case "e-":
                            case "e2":
                                break;
                            default:
                                indicative += "t";
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
            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
            {
                verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (man)"))
                {
                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (man)"]);
                }
                else
                {
                    string indicativeNebensatz = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1);
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter2] + "t";
                        }
                        else
                        {
                            indicativeNebensatz += parameters[ParameterUnregelmaessig.Parameter6];
                        }
                    }
                    else
                    {
                        if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter6))
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
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivIndikativ_Plural1Person = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (wir)"))
                {
                    verb.PräsensAktivIndikativ_Plural1Person.Add(parameters["Indikativ Präsens (wir)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    string indicative = string.Empty;
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                    {
                        indicative = parameters[ParameterUnregelmaessig.Parameter10];
                    }
                    else
                    {
                        indicative = parameters[ParameterUnregelmaessig.Parameter2] + "en";
                    }
                    verb.PräsensAktivIndikativ_Plural1Person.Add(indicative + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
            }
            #endregion

            #region Präsens Indikativ Plural 1 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Indikativ Präsens (wir)"))
                    {
                        verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (wir)"]);
                    }
                    else
                    {
                        verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                    }
                }
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivIndikativ_Plural2Person = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (ihr)"))
                {
                    verb.PräsensAktivIndikativ_Plural2Person.Add(parameters["Indikativ Präsens (ihr)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    string indicative = parameters[ParameterUnregelmaessig.Parameter2];
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
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Indikativ Präsens (ihr)"))
                    {
                        verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterUnregelmaessig.Parameter1] + parameters["Indikativ Präsens (ihr)"]);
                    }
                    else
                    {
                        string indicativeNebensatz = GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2];
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
            }
            #endregion

            #region Präsens Indikativ Plural 3 Plural
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivIndikativ_Plural3Person = new List<string>();
                if (parameters.ContainsKey("Indikativ Präsens (sie)"))
                {
                    verb.PräsensAktivIndikativ_Plural3Person.Add(parameters["Indikativ Präsens (sie)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    string indicative = string.Empty;
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
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
            }
            #endregion

            #region Präsens Indikativ Plural 3 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Indikativ Präsens (sie)"))
                    {
                        verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präsens (sie)"]);
                    }
                    else
                    {
                        verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                    }

                }
            }
            #endregion

            #region Präteritum Indikativ Singular 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivIndikativ_Singular1Person = new List<string>();
                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (ich)"))
                {
                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (ich)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (base.ContainsNonEmpty(parameters, "11"))
                {
                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters["11"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                
            }
            #endregion

            #region Präteritum Indikativ Singular 1 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3]);
                    if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (ich)"))
                    {
                        verb.PräteritumAktivIndikativ_Singular1Person.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (ich)"]);
                    }
                    if (base.ContainsNonEmpty(parameters, "11"))
                    {
                        verb.PräteritumAktivIndikativ_Singular1Person.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"]);
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivIndikativ_Singular2Person = new List<string>();
                switch (StrSubrev(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3), 3, 3))
                {
                    case "alt":
                    case "and":
                    case "bat":
                    case "bot":
                    case "elt":
                    case "ied":
                    case "iet":
                    case "itt":
                    case "lud":
                    case "rat":
                    case "tat":
                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
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
                        if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (du)"))
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (du)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                        if (base.ContainsNonEmpty(parameters, "11"))
                        {
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters["11"] + "st" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                        break;
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                    switch (StrSubrev(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3), 3, 3))
                    {
                        case "alt":
                        case "and":
                        case "bat":
                        case "bot":
                        case "elt":
                        case "ied":
                        case "iet":
                        case "itt":
                        case "lud":
                        case "rat":
                        case "tat":
                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "est");
                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                            break;
                        default:
                            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                            {
                                case "n":
                                case "in":
                                case "ni":
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                    break;
                                default:
                                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                    {
                                        case "e":
                                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "est");
                                            break;
                                        case "e2":
                                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3]);
                                            break;
                                        case "-s":
                                            switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3))
                                            {
                                                case "erkor":
                                                case "kor":
                                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                                    break;
                                                default:
                                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                                                    break;
                                            }
                                            break;
                                        default:
                                            verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "st");
                                            break;
                                    }
                                    break;
                            }
                            if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (du)"))
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (du)"]);
                            }
                            if (base.ContainsNonEmpty(parameters, "11"))
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"] + "st");
                            }
                            break;
                    }
                }
            }
            #endregion


            #region Präteritum Indikativ Singular 3 Person
            verb.PräteritumAktivIndikativ_Singular3Person = new List<string>();
            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter3] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (es)"))
            {
                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (es)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            if (base.ContainsNonEmpty(parameters, "11"))
            {
                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters["11"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präteritum Indikativ Singular 3 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
            {
                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3]);
                if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (es)"))
                {
                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (es)"]);
                }
                if (base.ContainsNonEmpty(parameters, "11"))
                {
                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"]);
                }
            }

            #endregion

            #region Präteritum Indikativ Plural 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
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
            }
            if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (wir)"))
            {
                if (verb.PräteritumAktivIndikativ_Plural1Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (wir)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            if (base.ContainsNonEmpty(parameters, "11"))
            {
                if (verb.PräteritumAktivIndikativ_Plural1Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters["11"] + "en" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präteritum Indikativ Plural 1 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                    {
                        case "n":
                        case "in":
                        case "ni":
                            verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "n");
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "en");
                            break;
                    }
                    if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (wir)"))
                    {
                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (wir)"]);
                    }
                    if (base.ContainsNonEmpty(parameters, "11"))
                    {
                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"] + "en");
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
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
            }
            if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (ihr)"))
            {
                if (verb.PräteritumAktivIndikativ_Plural2Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (ihr)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            if (base.ContainsNonEmpty(parameters, "11"))
            {
                if (verb.PräteritumAktivIndikativ_Plural2Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters["11"] + "t" + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                    {
                        if (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter2) + "n" == GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter10))
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "et");
                        }
                        else
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                        }
                    }
                    else
                    {
                        switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                        {
                            case "n":
                            case "in":
                            case "ni":
                                verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                                break;
                            default:
                                switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                                {
                                    case "e":
                                    case "e-":
                                    case "em":
                                    case "e2":
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "et");
                                        break;
                                    default:
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "t");
                                        break;
                                }
                                break;
                        }
                    }
                    if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (ihr)"))
                    {
                        if (verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation == null)
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                        }
                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (ihr)"]);
                    }
                    if (base.ContainsNonEmpty(parameters, "11"))
                    {
                        if (verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation == null)
                        {
                            verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                        }
                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"] + "t");
                    }
                }

            }
            #endregion

            #region Präteritum Indikativ Plural 3 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
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
            }
            if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (sie)"))
            {
                if (verb.PräteritumAktivIndikativ_Plural3Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters["Indikativ Präteritum Aktiv Alternativform (sie)"] + GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            if (base.ContainsNonEmpty(parameters, "11"))
            {
                if (verb.PräteritumAktivIndikativ_Plural3Person == null)
                {
                    verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
                }
                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters["11"] + "en" +GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            #endregion

            #region Präteritum Indikativ Plural 3 Person Nebensatzkonjugation
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                    switch (GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8))
                    {
                        case "n":
                        case "in":
                        case "ni":
                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "n");
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter3] + "en");
                            break;
                    }
                    if (base.ContainsNonEmpty(parameters, "Indikativ Präteritum Aktiv Alternativform (sie)"))
                    {
                        if (verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation == null)
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                        }
                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Indikativ Präteritum Aktiv Alternativform (sie)"]);
                    }
                    if (base.ContainsNonEmpty(parameters, "11"))
                    {
                        if (verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation == null)
                        {
                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                        }
                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["11"] + "en");
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivKonjunktiv_Singular1Person = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (ich)"))
                {
                    verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters["Konjunktiv Präsens (ich)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Konjunktiv Präsens (ich)"))
                    {
                        verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (ich)"]);
                    }
                    else
                    {
                        verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "e");
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivKonjunktiv_Singular2Person = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (du)"))
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters["Konjunktiv Präsens (du)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "est" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (parameters.ContainsKey("Konjunktiv Präsens Alternativform (du)"))
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters["Konjunktiv Präsens Alternativform (du)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }


                // NEBENSATZ
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Konjunktiv Präsens (du)"))
                    {
                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (du)"]);
                    }
                    else
                    {
                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "est");
                    }
                    if (parameters.ContainsKey("Konjunktiv Präsens Alternativform (du)"))
                    {
                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens Alternativform (du)"]);
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 3 Person
            verb.PräsensAktivKonjunktiv_Singular3Person = new List<string>();
            if (parameters.ContainsKey("Konjunktiv Präsens (man)"))
            {
                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters["Konjunktiv Präsens (man)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            else
            {
                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }

            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
            {
                verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (man)"))
                {
                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (ich)"]);
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "e");
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivKonjunktiv_Plural1Person = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (wir)"))
                {
                    verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters["Konjunktiv Präsens (wir)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Konjunktiv Präsens (wir)"))
                    {
                        verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (wir)"]);
                    }
                    else
                    {
                        verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivKonjunktiv_Plural2Person = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (ihr)"))
                {
                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters["Konjunktiv Präsens (ihr)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "et" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Konjunktiv Präsens (ihr)"))
                    {
                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (ihr)"]);
                    }
                    else
                    {
                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "et");
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 3 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräsensAktivKonjunktiv_Plural3Person = new List<string>();
                if (parameters.ContainsKey("Konjunktiv Präsens (sie)"))
                {
                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters["Konjunktiv Präsens (sie)"] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter2] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>();
                    if (parameters.ContainsKey("Konjunktiv Präsens (sie)"))
                    {
                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters["Konjunktiv Präsens (sie)"]);
                    }
                    else
                    {
                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter2] + "en");
                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Singular 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person = new List<string>();
                if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                {
                    verb.PräteritumAktivKonjunktiv_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräteritumAktivKonjunktiv_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Singular1Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                // Nebensatz
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>();
                    if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                    {
                        verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4]);
                    }
                    else
                    {
                        verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "e");
                    }
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                    {
                        verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "e");
                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Singular 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "est" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                if (!(this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7) || this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10)))
                {
                    if (!(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) == this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4)))
                    {
                        if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                        {
                            verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "st" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                    }
                }
                if (this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "est" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    if (!this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                    {
                        if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) != this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                            {
                                verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "st" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                            }
                        }
                    }
                }



                // Nebensatz
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "est");
                    if (!(this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7) || this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10)))
                    {
                        if (!(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) == this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4)))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                            {
                                verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "st");
                            }
                        }
                    }
                    if (this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                    {
                        verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "est");
                        if (!this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) != this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4))
                            {
                                if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                                {
                                    verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "st");
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Singular 3 Person
            verb.PräteritumAktivKonjunktiv_Singular3Person = new List<string>();
            if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }
            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "e" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
            }

            // Nebensatz
            if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>();
                if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                {
                    verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4]);
                }
                else
                {
                    verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "e");
                }
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "e");
                }
            }
            #endregion

            #region Präteritum Konjunktiv Plural 1 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person = new List<string>();
                if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                {
                    verb.PräteritumAktivKonjunktiv_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "n" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräteritumAktivKonjunktiv_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Plural1Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                // Nebensatz
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>();
                    if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                    {
                        verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "n");
                    }
                    else
                    {
                        verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "en");
                    }
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                    {
                        verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "en");
                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Plural 2 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "et" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                if (!(this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7) || this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10)))
                {
                    if (!(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) == this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4)))
                    {
                        if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                        {
                            verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "t" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                        }
                    }
                }
                if (this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "et" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                    if (!this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                    {
                        if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) != this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                            {
                                verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "t" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                            }
                        }
                    }
                }



                // Nebensatz
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "et");
                    if (!(this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7) || this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter10)))
                    {
                        if (!(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) == this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4)))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                            {
                                verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "t");
                            }
                        }
                    }
                    if (this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                    {
                        verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "et");
                        if (!this.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter7))
                        {
                            if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter3) != this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter4))
                            {
                                if (this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter8) != "n")
                                {
                                    verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "t");
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Plural 3 Person
            if (!(parameters.ContainsKey(ParameterUnregelmaessig.Unpersönlich)))
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person = new List<string>();
                if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                {
                    verb.PräteritumAktivKonjunktiv_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "n" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                else
                {
                    verb.PräteritumAktivKonjunktiv_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter4] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                {
                    verb.PräteritumAktivKonjunktiv_Plural3Person.Add(parameters[ParameterUnregelmaessig.Parameter9] + "en" + this.GetWithSpaceOrEmpty(parameters, ParameterUnregelmaessig.Parameter1));
                }

                // Nebensatz
                if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter1) || base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Reflexiv))
                {
                    verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>();
                    if (base.StrSub(parameters[ParameterUnregelmaessig.Parameter4], parameters[ParameterUnregelmaessig.Parameter4].Length - 2, 2) == "ie")
                    {
                        verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "n");
                    }
                    else
                    {
                        verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter4] + "en");
                    }
                    if (base.ContainsNonEmpty(parameters, ParameterUnregelmaessig.Parameter9))
                    {
                        verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(this.GetOrEmpty(parameters, ParameterUnregelmaessig.Parameter1) + parameters[ParameterUnregelmaessig.Parameter9] + "en");
                    }
                }
            }
            #endregion

            return verb;
        }
    }
}
