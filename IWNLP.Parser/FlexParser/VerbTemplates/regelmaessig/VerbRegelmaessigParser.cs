using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser.VerbTemplates.regelmaessig
{
    public class VerbRegelmaessigParser : VerbConjugationParserBase
    {
        List<String> blacklist = new List<string>() 
        {
        "Flexion:wischen"
        };

        public Dictionary<String, String> ParseParameters(String[] input, String word)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            String truncatedWord = word.Replace("Flexion:", String.Empty);
            String[] inputSplitted = base.SplitTemplateInput(input, "{{Deutsch Verb regelmäßig|");
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
                    parameters[ParameterRegelmaessig.Parameter1] = inputSplitted[i++];
                    parameters[ParameterRegelmaessig.Parameter2] = inputSplitted[i++];
                    //if (truncatedWord.Length > 4) // there is only the case "Flexion:äsen". "Flexion:äsen" sets parameter 3 as empty value. The documentation says "the parameter 3 should not be set. Correct would be "parameter 3 should be set as empty"
                    //{
                    parameters[ParameterRegelmaessig.Parameter3] = inputSplitted[i++];
                    //}
                    parameters[ParameterRegelmaessig.Parameter4] = inputSplitted[i++];
                    parameters[ParameterRegelmaessig.Parameter5] = inputSplitted[i++];
                    parameters[ParameterRegelmaessig.Parameter6] = inputSplitted[i];
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
            verb.PartizipII = parameters[ParameterRegelmaessig.Parameter6];
            if (parameters.ContainsKey(ParameterRegelmaessig.PartizipPlus))
            {
                verb.PartizipIIAlternativ = parameters[ParameterRegelmaessig.PartizipPlus];
            }
            if (parameters.ContainsKey(ParameterRegelmaessig.PartizipVeraltet)) // example "Flexion:knöpfen"
            {
                verb.PartizipIIVeraltet = parameters[ParameterRegelmaessig.PartizipVeraltet];
            }

            List<String> condition = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "p", "s", "t", "v", "w", "x", "z", "ß" };
            List<String> condition2 = new List<string>() { "b", "c", "ch", "d", "f", "g", "j", "k", "m", "p", "s", "t", "v", "w", "x", "z", "ß" };
            List<String> condition3 = new List<string>() { "ä", "b", "f", "g", "h", "l", "s", "u", "z" };
            #region Präsens Indikativ Singular 1 Person
            if (parameters.ContainsKey("1. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular1Person = new List<string>();
                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters["1. Singular Indikativ Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivIndikativ_Singular1Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            // the check for parameter4 is not necessary
                            String form1 = parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "e";
                            String form2 = parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4];
                            String form3 = parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e";
                            form1 += GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2);
                            form2 += GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2);
                            form3 += GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(form1);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(form2);
                            verb.PräsensAktivIndikativ_Singular1Person.Add(form3);
                            break;
                        case "m":

                            if (!condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));

                            }
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "e"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));

                            break;
                        case "n":

                            if (!condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));

                            }
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "e"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));

                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "e"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "e"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "e"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            if (parameters[ParameterRegelmaessig.Parameter4] == "e")
                            {
                                verb.PräsensAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "e"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;

                    }
                }
            }
            #endregion
            #region Präsens Indikativ Singular 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivIndikativ_Singular1Person.Add(parameters["1. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "e");
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]);
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "e");
                                break;
                            case "m":
                                if (!condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]);

                                }
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                + parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "e");

                                break;
                            case "n":
                                if (!condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]);

                                }
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                + parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "e");

                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "e");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "e");
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "e");
                                break;
                            default:
                                if (parameters[ParameterRegelmaessig.Parameter4] == "e")
                                {
                                    verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "e");
                                }
                                break;

                        }
                    }
                }
            }
            #endregion

            #region Präsens Indikativ Singular 2 Person
            if (parameters.ContainsKey("2. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular2Person = new List<string>();
                if (parameters["2. Singular Indikativ Präsens Aktiv"].Contains("<br >") || parameters["2. Singular Indikativ Präsens Aktiv"].Contains("<br />"))
                {
                    String[] multipleValues = parameters["2. Singular Indikativ Präsens Aktiv"].Split(new String[] { "</br >", "<br />" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < multipleValues.Length; i++)
                    {
                        if (multipleValues[i].StartsWith("du ")) 
                        {
                            multipleValues[i] = multipleValues[i].Substring(3);
                        }
                        if (multipleValues[i].EndsWith(","))
                        {
                            multipleValues[i] = multipleValues[i].Substring(0, multipleValues[i].Length - 1);
                        }
                        verb.PräsensAktivIndikativ_Singular2Person.Add(multipleValues[i].Trim());
                    }
                }
                else 
                {
                    verb.PräsensAktivIndikativ_Singular2Person.Add(parameters["2. Singular Indikativ Präsens Aktiv"]);
                }
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivIndikativ_Singular2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "st"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                );
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "est"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "st"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "est"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                     + "st"
                                     + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                     + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                     );
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "st"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "st"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "st"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "s":
                        case "ß":
                        case "c":
                        case "x":
                        case "z":
                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:

                            verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + "st"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));

                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                verb.PräsensAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "est"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }

                            break;

                    }
                }
            }
            #endregion


            #region Präsens Indikativ Singular 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                    if (parameters["2. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"].Contains("<br >") || parameters["2. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"].Contains("<br />"))
                    {
                        String[] multipleValues = parameters["2. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"].Split(new String[] { "</br >", "<br />" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < multipleValues.Length; i++)
                        {
                            if (multipleValues[i].StartsWith("du "))
                            {
                                multipleValues[i] = multipleValues[i].Substring(3);
                            }
                            if (multipleValues[i].EndsWith(","))
                            {
                                multipleValues[i] = multipleValues[i].Substring(0, multipleValues[i].Length - 1);
                            }
                            verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(multipleValues[i].Trim());
                        }
                    }
                    else
                    {
                        verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters["2. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                    }
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "st");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "est");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "st");
                                }
                                break;
                            case "n":

                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "est");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "st");
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "st");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "st");
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "st");
                                break;
                            case "s":
                            case "ß":
                            case "c":
                            case "x":
                            case "z":
                                verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t");
                                break;
                            default:

                                verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "st");

                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "est");
                                }

                                break;

                        }
                    }
                }
            }
            #endregion
            #region Präsens Indikativ Singular 3 Person
            if (parameters.ContainsKey("3. Singular Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Singular3Person = new List<string>();
                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters["3. Singular Indikativ Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    verb.PräsensAktivIndikativ_Singular3Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "et"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "et"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                verb.PräsensAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "et"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }

                            break;
                    }
                }
            }
            #endregion


            #region Präsens Indikativ Singular 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(parameters["3. Singular Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv)))
                    {
                        verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                         + parameters[ParameterRegelmaessig.Parameter1]
                                         + parameters[ParameterRegelmaessig.Parameter2]
                                         + parameters[ParameterRegelmaessig.Parameter3]
                                         + "et");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "t");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t");
                                break;
                            default:
                                verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et");
                                }

                                break;
                        }
                    }

                }
            }
            #endregion


            #region Präsens Indikativ Plural 1 Person
            if (parameters.ContainsKey("1. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural1Person = new List<string>();
                verb.PräsensAktivIndikativ_Plural1Person.Add(parameters["1. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivIndikativ_Plural1Person = new List<string>();
                    verb.PräsensAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                        + parameters[ParameterRegelmaessig.Parameter4]
                        + "n"
                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                }
            }
            #endregion
            #region Präsens Indikativ Plural 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters["1. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                        verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                            + parameters[ParameterRegelmaessig.Parameter1]
                            + parameters[ParameterRegelmaessig.Parameter2]
                            + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "n");
                    }
                }
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person
            if (parameters.ContainsKey("2. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural2Person = new List<string>();
                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters["2. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivIndikativ_Plural2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                );
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "et"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        );
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                     + "et"
                                     + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                     + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                     );
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        );
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                            }
                            else
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        );
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                );
                            break;
                        default:
                            verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "t"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                );
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                verb.PräsensAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "et"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    );
                            }

                            break;

                    }
                }
            }
            #endregion

            #region Präsens Indikativ Plural 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters["2. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "et");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "et");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "t");
                                }
                                else
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "t");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "et");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "t");
                                break;
                            default:
                                verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "t");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "et");
                                }

                                break;

                        }
                    }
                }
            }
            #endregion

            #region Präsens Indikativ Plural 3 Person
            if (parameters.ContainsKey("3. Plural Indikativ Präsens Aktiv"))
            {
                verb.PräsensAktivIndikativ_Plural3Person = new List<string>();
                verb.PräsensAktivIndikativ_Plural3Person.Add(parameters["3. Plural Indikativ Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    if (parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] == "es")
                    {

                    }
                    else
                    {
                        verb.PräsensAktivIndikativ_Plural3Person = new List<string>();
                        verb.PräsensAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "n"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                    }

                }
            }
            #endregion

            #region Präsens Indikativ Plural 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters["3. Plural Indikativ Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv)))
                    {
                        if (parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] == "es")
                        {

                        }
                        else
                        {
                            verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                            verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                + parameters[ParameterRegelmaessig.Parameter1]
                                + parameters[ParameterRegelmaessig.Parameter2]
                                + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "n");
                        }

                    }
                }
            }
            #endregion


            #region Präteritum Indikativ Singular 1 Person
            if (parameters.ContainsKey("1. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular1Person = new List<string>();
                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters["1. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräteritumAktivIndikativ_Singular1Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "te"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ete"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ete"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "te"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }

                            }
                            break;
                    }
                }
            }
            #endregion
            #region Präteritum Indikativ Singular 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(parameters["1. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "te");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ete");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ete");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "te");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "te");
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "te");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }

                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person
            if (parameters.ContainsKey("2. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular2Person = new List<string>();
                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters["2. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräteritumAktivIndikativ_Singular2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "test"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "etest"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "test"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etest"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "etest"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "test"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etest"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "test"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "test"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etest"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "test"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "test"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etest"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }

                            }
                            break;
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(parameters["2. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "test");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "etest");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "test");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etest");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "etest");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "test");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etest");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "test");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "test");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etest");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "test");
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "test");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etest");
                                    }

                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 3 Person
            if (parameters.ContainsKey("3. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Singular3Person = new List<string>();
                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters["3. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    verb.PräteritumAktivIndikativ_Singular3Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "te"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ete"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ete"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "te"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "te"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ete"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }

                            }
                            break;
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Singular 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(parameters["3. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv)))
                    {
                        verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "te");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ete");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ete");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "te");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "te");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "te");
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "te");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ete");
                                    }

                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 1 Person
            if (parameters.ContainsKey("1. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters["1. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräteritumAktivIndikativ_Plural1Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "ten"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "eten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "eten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "ten"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }

                            }
                            break;
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Plural Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(parameters["1. Plural Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "ten");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ten");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ten");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "ten");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ten");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "ten");
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ten");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }

                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person
            if (parameters.ContainsKey("2. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters["2. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräteritumAktivIndikativ_Plural2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "tet"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "m":
                            if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "etet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "tet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etet"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "n":
                            if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "etet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "tet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etet"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "tet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "tet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etet"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                            }
                            break;
                        case "d":
                        case "t":
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                            + parameters[ParameterRegelmaessig.Parameter4]
                            + "tet"
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                            + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        default:
                            verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + "tet"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "etet"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }

                            }
                            break;
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Plural Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(parameters["2. Plural Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "tet");
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "etet");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "tet");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etet");
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "etet");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "tet");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etet");
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "tet");
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "tet");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etet");
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "tet");
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                    + parameters[ParameterRegelmaessig.Parameter1]
                                    + parameters[ParameterRegelmaessig.Parameter2]
                                    + parameters[ParameterRegelmaessig.Parameter3]
                                    + "tet");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "etet");
                                    }

                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präteritum Indikativ Plural 3 Person
            if (parameters.ContainsKey("3. Plural Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters["3. Plural Indikativ Präteritum Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] == "es"))
                    {
                        verb.PräteritumAktivIndikativ_Plural3Person = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                break;
                            case "m":
                                if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                }
                                break;
                            case "n":
                                if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "eten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + parameters[ParameterRegelmaessig.Parameter4]
                                    + "ten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                else
                                {
                                    verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                }
                                break;
                            case "d":
                            case "t":
                                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                + parameters[ParameterRegelmaessig.Parameter4]
                                + "ten"
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                break;
                            default:
                                verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                    + "ten"
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                    + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3]
                                        + "eten"
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1)
                                        + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }

                                }
                                break;
                        }
                    }

                }
            }
            #endregion

            #region Präteritum Indikativ Plural 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"))
                {
                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(parameters["3. Singular Indikativ Präteritum Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präteritum) || parameters.ContainsKey(ParameterRegelmaessig.PräteritumAktiv)))
                    {
                        if (!(parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] == "es"))
                        {

                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>();
                            switch (parameters[ParameterRegelmaessig.Parameter3])
                            {
                                case "e":
                                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "ten");
                                    break;
                                case "m":
                                    if (condition.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }
                                    else
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ten");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                                + parameters[ParameterRegelmaessig.Parameter1]
                                                + parameters[ParameterRegelmaessig.Parameter2]
                                                + parameters[ParameterRegelmaessig.Parameter3]
                                                + "eten");
                                        }
                                    }
                                    break;
                                case "n":
                                    if (condition2.Contains(parameters[ParameterRegelmaessig.Parameter2]))
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "eten");
                                    }
                                    else
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ten");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                                + parameters[ParameterRegelmaessig.Parameter1]
                                                + parameters[ParameterRegelmaessig.Parameter2]
                                                + parameters[ParameterRegelmaessig.Parameter3]
                                                + "eten");
                                        }
                                    }
                                    break;
                                case "r":
                                    if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + parameters[ParameterRegelmaessig.Parameter4]
                                            + "ten");
                                    }
                                    else
                                    {
                                        verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                            + parameters[ParameterRegelmaessig.Parameter1]
                                            + parameters[ParameterRegelmaessig.Parameter2]
                                            + parameters[ParameterRegelmaessig.Parameter3]
                                            + "ten");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                                + parameters[ParameterRegelmaessig.Parameter1]
                                                + parameters[ParameterRegelmaessig.Parameter2]
                                                + parameters[ParameterRegelmaessig.Parameter3]
                                                + "eten");
                                        }
                                    }
                                    break;
                                case "d":
                                case "t":
                                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + parameters[ParameterRegelmaessig.Parameter4]
                                        + "ten");
                                    break;
                                default:
                                    verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                        + parameters[ParameterRegelmaessig.Parameter1]
                                        + parameters[ParameterRegelmaessig.Parameter2]
                                        + parameters[ParameterRegelmaessig.Parameter3]
                                        + "ten");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräteritumVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        if (condition3.Contains(parameters[ParameterRegelmaessig.Parameter3]))
                                        {
                                            verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation.Add(GetOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2)
                                                + parameters[ParameterRegelmaessig.Parameter1]
                                                + parameters[ParameterRegelmaessig.Parameter2]
                                                + parameters[ParameterRegelmaessig.Parameter3]
                                                + "eten");
                                        }

                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular1Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters["1. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivKonjunktiv_Singular1Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        default:
                            verb.PräsensAktivKonjunktiv_Singular1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters["1. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "e");
                                }
                                break;
                            default:
                                verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4]);
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular2Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters["2. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            switch (parameters[ParameterRegelmaessig.Parameter4])
                            {
                                case "l":
                                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "st" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                    break;
                                case "r":
                                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "st" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                        verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                    break;
                                default:
                                    verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    break;
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        default:
                            verb.PräsensAktivKonjunktiv_Singular2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters["2. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                switch (parameters[ParameterRegelmaessig.Parameter4])
                                {
                                    case "l":
                                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "st");
                                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "est");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est");
                                        }
                                        break;
                                    case "r":
                                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "st");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "est");
                                            verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est");
                                        }
                                        break;
                                    default:
                                        verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est");
                                        break;
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "est");
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est");
                                }
                                break;
                            default:
                                verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "est");
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Singular3Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters["3. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    verb.PräsensAktivKonjunktiv_Singular3Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        default:
                            verb.PräsensAktivKonjunktiv_Singular3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "e" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Singular 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters["3. Singular Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "e");
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "e");
                                }
                                break;
                            default:
                                verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4]);
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural1Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters["1. Singular Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivKonjunktiv_Plural1Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        case "e":
                            verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                            {
                                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        default:
                            verb.PräsensAktivKonjunktiv_Plural1Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 1 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("1. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters["1. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "en");
                                }
                                break;
                            case "e":
                                verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n");
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                    verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                }
                                break;
                            default:
                                verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n");
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Plural Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural2Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters["2. Plural Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                {
                    verb.PräsensAktivKonjunktiv_Plural2Person = new List<string>();
                    switch (parameters[ParameterRegelmaessig.Parameter3])
                    {
                        case "e":
                            switch (parameters[ParameterRegelmaessig.Parameter4])
                            {
                                case "l":
                                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "t" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                    break;
                                case "r":
                                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "t" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                        verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    }
                                    break;
                                default:
                                    verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    break;
                            }
                            break;
                        case "r":
                            if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                            {
                                verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            else
                            {
                                verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            }
                            break;
                        default:
                            verb.PräsensAktivKonjunktiv_Plural2Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "et" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                            break;
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 2 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("2. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters["2. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich)))
                    {
                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "e":
                                switch (parameters[ParameterRegelmaessig.Parameter4])
                                {
                                    case "l":
                                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "t");
                                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "et");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et");
                                        }
                                        break;
                                    case "r":
                                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "t");
                                        if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                        {
                                            verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "et");
                                            verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et");
                                        }
                                        break;
                                    default:
                                        verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "et");
                                        break;
                                }
                                break;
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "et");
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "et");
                                }
                                break;
                            default:
                                verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "et");
                                break;
                        }
                    }
                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Plural Konjunktiv Präsens Aktiv"))
            {
                verb.PräsensAktivKonjunktiv_Plural3Person = new List<string>();
                verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters["3. Plural Konjunktiv Präsens Aktiv"]);
            }
            else
            {
                if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv) || parameters.ContainsKey(ParameterRegelmaessig.Hauptsatzkonjugation)))
                {
                    if (!parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) || (parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] != "es")) 
                    {
                        verb.PräsensAktivKonjunktiv_Plural3Person = new List<string>();
                        switch (parameters[ParameterRegelmaessig.Parameter3])
                        {
                            case "r":
                                if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                {
                                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                else
                                {
                                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                break;
                            case "e":
                                verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                {
                                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                    verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                }
                                break;

                            default:
                                verb.PräsensAktivKonjunktiv_Plural3Person.Add(parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n" + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil1) + GetWithSpaceOrEmpty(parameters, ParameterRegelmaessig.Teil2));
                                break;
                        }                    
                    }


                }
            }
            #endregion

            #region Präsens Konjunktiv Plural 3 Person Nebensatzkonjugation
            if (parameters.ContainsKey(ParameterRegelmaessig.Nebensatzkonjugation) && parameters[ParameterRegelmaessig.Nebensatzkonjugation] == "einteilig")
            {
                if (parameters.ContainsKey("3. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"))
                {
                    verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>();
                    verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters["3. Plural Konjunktiv Präsens Aktiv Nebensatzkonjugation"]);
                }
                else
                {
                    if (!(parameters.ContainsKey(ParameterRegelmaessig.Präsens) || parameters.ContainsKey(ParameterRegelmaessig.PräsensAktiv)))
                    {
                        if (!parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) || (parameters.ContainsKey(ParameterRegelmaessig.Unpersönlich) && parameters[ParameterRegelmaessig.Unpersönlich] != "es"))
                        {
                            verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>();
                            switch (parameters[ParameterRegelmaessig.Parameter3])
                            {
                                case "r":
                                    if (parameters[ParameterRegelmaessig.Parameter4] == "l")
                                    {
                                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                    }
                                    else
                                    {
                                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + "en");
                                    }
                                    break;
                                case "e":
                                    verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n");
                                    if (!(parameters.ContainsKey(ParameterRegelmaessig.PräsensVeraltet) || parameters.ContainsKey(ParameterRegelmaessig.veraltet)))
                                    {
                                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                        verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "en");
                                    }
                                    break;

                                default:
                                    verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters[ParameterRegelmaessig.Teil1] + GetOrEmpty(parameters, ParameterRegelmaessig.Teil2) + parameters[ParameterRegelmaessig.Parameter1] + parameters[ParameterRegelmaessig.Parameter2] + parameters[ParameterRegelmaessig.Parameter3] + parameters[ParameterRegelmaessig.Parameter4] + "n");
                                    break;
                            }
                        }

                    }
                }
            }
            #endregion

            #region Präteritum Konjunktiv Singular 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular1Person.Add(parameters["1. Singular Konjunktiv Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person = verb.PräteritumAktivIndikativ_Singular1Person;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 1 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "1. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation.Add(parameters["1. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular2Person.Add(parameters["2. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person = verb.PräteritumAktivIndikativ_Singular2Person;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 2 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "2. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation.Add(parameters["2. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Singular Indikativ Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular3Person.Add(parameters["3. Singular Indikativ Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person = verb.PräteritumAktivIndikativ_Singular3Person;
            }
            #endregion

            #region Präteritum Konjunktiv Singular 3 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "3. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation.Add(parameters["3. Singular Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 1 Person
            if (base.ContainsNonEmpty(parameters, "1. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural1Person.Add(parameters["1. Plural Konjunktiv Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person = verb.PräteritumAktivIndikativ_Plural1Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 1 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "1. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation.Add(parameters["1. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 2 Person
            if (base.ContainsNonEmpty(parameters, "2. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural2Person.Add(parameters["2. Plural Konjunktiv Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person = verb.PräteritumAktivIndikativ_Plural2Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 2 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "2. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation.Add(parameters["2. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 3 Person
            if (base.ContainsNonEmpty(parameters, "3. Plural Konjunktiv Präteritum Aktiv"))
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural3Person.Add(parameters["3. Plural Konjunktiv Präteritum Aktiv"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person = verb.PräteritumAktivIndikativ_Plural3Person;
            }
            #endregion

            #region Präteritum Konjunktiv Plural 3 Person Nebensatzkonjugation
            if (base.ContainsNonEmpty(parameters, "3. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"))
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>();
                verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation.Add(parameters["3. Plural Konjunktiv Präteritum Aktiv Nebensatzkonjugation"]);
            }
            else
            {
                verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation;
            }
            #endregion

            return verb;
        }

    }
}
