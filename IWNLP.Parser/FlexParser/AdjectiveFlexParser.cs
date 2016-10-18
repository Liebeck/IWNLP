using IWNLP.Models.Flections;
using IWNLP.Parser.POSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser
{
    public class AdjectiveFlexParser : ParserBase
    {
        public AdjectiveDeclination Parse(String word, String[] text)
        {
            AdjectiveDeclination adjectiveDeclination = new AdjectiveDeclination();
            if (!(text.Select((content, index) => new { Content = content.Trim(), Index = index }).Any(x => x.Content.Contains("{{Deklinationsseite Adjektiv"))))
            {
                Common.PrintError(word, String.Format("AdjectiveFlexParser: No definition block: {0}", word));
                return null;
            }
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deklinationsseite Adjektiv")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart + 1 && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            for (int i = flexionSubstantivStart + 1; i <= flexionSubstantivEnd; i++)
            {
                text[i] = text[i].Trim();
                if (text[i].StartsWith("<!--") || text[i] == "}}")
                {
                    continue; // skip comments
                }
                if (!text[i].StartsWith("|") && !text[i].StartsWith("Positiv-Stamm"))
                {
                    Common.PrintError(word, String.Format("AdjectiveFlexParser: Error in: {0}||{1}", word, text[i]));
                }
                String line = text[i].Substring(1).Trim(); // Skip leading "|"
                if (line.EndsWith("}}"))
                {
                    line = line.Substring(0, line.Length - 2);// remove end of block, if it is in the same line
                }
                line = base.CleanLine(line);
                String[] forms = line.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<String> noValue = new List<string>() { "—", "-", "—", "–", "–", "—", "?" };
                if (forms.Length == 1 || (forms.Length == 2 && (noValue.Contains(forms[1]))))  // No value given
                {
                    continue;
                }
                forms[0] = forms[0].Trim(); // remove spaces
                if (forms[0].EndsWith("1") || forms[0].EndsWith("2") || forms[0].EndsWith("3") || forms[0].EndsWith("4"))
                {
                    forms[0] = forms[0].Substring(0, forms[0].Length - 2);
                }

                if (forms[0].StartsWith("Positiv-Stamm") || forms[0].StartsWith("ositiv-Stamm"))
                {
                    adjectiveDeclination.PositivStamm = forms[1];
                }
                else if (forms[0].StartsWith("Komparativ-Stamm-ohne-e"))
                {
                    adjectiveDeclination.KomparativStammOhneE = forms[1];
                }
                else if (forms[0].StartsWith("Komparativ-Stamm-Alternative"))
                {
                    adjectiveDeclination.KomparativStammAlternative = forms[1];
                }
                else if (forms[0].StartsWith("Komparativ-Stamm"))
                {
                    adjectiveDeclination.KomparativStamm = forms[1];
                }
                else if (forms[0].StartsWith("Komparativ-prädikativ"))
                {
                    adjectiveDeclination.KomparativPrädikativ = forms[1];
                }
                else if (forms[0].StartsWith("Komparativ-Stamm-ohne-e"))
                {
                    adjectiveDeclination.KomparativStammOhneE = forms[1];
                }
                else if (forms[0].StartsWith("Superlativ-Stamm-ohne-e"))
                {
                    adjectiveDeclination.SuperlativStammOhneE = forms[1];
                }
                else if (forms[0].StartsWith("Superlativ-Stamm-Alternative2"))
                {
                    adjectiveDeclination.SuperlativStammAlternative2 = forms[1];
                }
                else if (forms[0].StartsWith("Superlativ-Stamm-Alternative"))
                {
                    adjectiveDeclination.SuperlativStammAlternative = forms[1];
                }
                else if (forms[0].StartsWith("Superlativ-Stamm"))
                {
                    adjectiveDeclination.SuperlativStamm = forms[1];
                }
                else if (forms[0].StartsWith("Superlativ-prädikativ"))
                {
                    adjectiveDeclination.SuperlativPrädikativ = forms[1];
                }
                else if (forms[0].StartsWith("e-Endung"))
                {
                    adjectiveDeclination.EEndung = true;
                    if (forms[1] != "1")
                    {
                        Common.PrintError(word, String.Format("AdjectiveFlexParser: e-Endung wrong value {0}={1}", word, line));
                    }
                }
                else if (forms[0].StartsWith("Prädikativ"))
                {
                    if (forms[1] == "0" || forms[1] == "Ordinalzahl")
                    {
                        adjectiveDeclination.Prädikativ = forms[1];
                    }
                    else
                    {
                        Common.PrintError(word, String.Format("AdjectiveFlexParser: Prädikativ wrong value {0}={1}", word, line));
                    }
                }
                else if (forms[0].StartsWith("Positiv"))
                {
                    adjectiveDeclination.Positiv = forms[1];
                }
                else
                {
                    Common.PrintError(word, String.Format("AdjectiveFlexParser: unknown parameter {0}={1}", word, line));
                }
            }
            CreateFlexions(adjectiveDeclination);
            if (!String.IsNullOrEmpty(adjectiveDeclination.SuperlativStammOhneE) && !String.IsNullOrEmpty(adjectiveDeclination.SuperlativStammAlternative))
            {
                System.Diagnostics.Debugger.Break();
            }
            return adjectiveDeclination;
        }

        protected void CreateFlexions(AdjectiveDeclination ad)
        {
            #region POSITIV Deklination
            if (ad.PositivStamm != "<center>—</center>" && !String.IsNullOrEmpty(ad.PositivStamm))
            {
                String newForm = ad.PositivStamm;
                if (!ad.EEndung)
                {
                    newForm += "e";
                }

                // STARK
                ad.PositivMaskulinumNominativStark.Add(newForm + "r");
                ad.PositivFemininumNominativStark.Add(newForm);
                ad.PositivNeutrumNominativStark.Add(newForm + "s");
                ad.PositivPluralNominativStark.Add(newForm);

                ad.PositivMaskulinumGenitivStark.Add(newForm + "n");
                ad.PositivFemininumGenitivStark.Add(newForm + "r");
                ad.PositivNeutrumGenitivStark.Add(newForm + "n");
                ad.PositivPluralGenitivStark.Add(newForm + "r");

                ad.PositivMaskulinumDativStark.Add(newForm + "m");
                ad.PositivFemininumDativStark.Add(newForm + "r");
                ad.PositivNeutrumDativStark.Add(newForm + "m");
                ad.PositivPluralDativStark.Add(newForm + "n");

                ad.PositivMaskulinumAkkusativStark.Add(newForm + "n");
                ad.PositivFemininumAkkusativStark.Add(newForm);
                ad.PositivNeutrumAkkusativStark.Add(newForm + "s");
                ad.PositivPluralAkkusativStark.Add(newForm);

                // SCHWACH
                ad.PositivMaskulinumNominativSchwach.Add(newForm);
                ad.PositivFemininumNominativSchwach.Add(newForm);
                ad.PositivNeutrumNominativSchwach.Add(newForm);
                ad.PositivPluralNominativSchwach.Add(newForm + "n");

                ad.PositivMaskulinumGenitivSchwach.Add(newForm + "n");
                ad.PositivFemininumGenitivSchwach.Add(newForm + "n");
                ad.PositivNeutrumGenitivSchwach.Add(newForm + "n");
                ad.PositivPluralGenitivSchwach.Add(newForm + "n");


                ad.PositivMaskulinumDativSchwach.Add(newForm + "n");
                ad.PositivFemininumDativSchwach.Add(newForm + "n");
                ad.PositivNeutrumDativSchwach.Add(newForm + "n");
                ad.PositivPluralDativSchwach.Add(newForm + "n");

                ad.PositivMaskulinumAkkusativSchwach.Add(newForm + "n");
                ad.PositivFemininumAkkusativSchwach.Add(newForm);
                ad.PositivNeutrumAkkusativSchwach.Add(newForm);
                ad.PositivPluralAkkusativSchwach.Add(newForm + "n");

                // GEMISCHT
                ad.PositivMaskulinumNominativGemischt.Add(newForm + "r");
                ad.PositivFemininumNominativGemischt.Add(newForm);
                ad.PositivNeutrumNominativGemischt.Add(newForm + "s");
                ad.PositivPluralNominativGemischt.Add(newForm + "n");

                ad.PositivMaskulinumGenitivGemischt.Add(newForm + "n");
                ad.PositivFemininumGenitivGemischt.Add(newForm + "n");
                ad.PositivNeutrumGenitivGemischt.Add(newForm + "n");
                ad.PositivPluralGenitivGemischt.Add(newForm + "n");


                ad.PositivMaskulinumDativGemischt.Add(newForm + "n");
                ad.PositivFemininumDativGemischt.Add(newForm + "n");
                ad.PositivNeutrumDativGemischt.Add(newForm + "n");
                ad.PositivPluralDativGemischt.Add(newForm + "n");

                ad.PositivMaskulinumAkkusativGemischt.Add(newForm + "n");
                ad.PositivFemininumAkkusativGemischt.Add(newForm);
                ad.PositivNeutrumAkkusativGemischt.Add(newForm + "s");
                ad.PositivPluralAkkusativGemischt.Add(newForm + "n");

            }
            if (String.IsNullOrEmpty(ad.Positiv))
            {
                switch (StrRightC(ad.PositivStamm, 2))
                {
                    case "er":
                    case "en":
                        switch (StrRightC(ad.PositivStamm, 3))
                        {
                            case "eer":
                            case "ier":
                            case "mer":
                            case "nen":
                            case "wer":
                                break;
                            default:
                                if (StrRightC(ad.PositivStamm, 6) == "farben")
                                {
                                }
                                else
                                {
                                    // STARK
                                    ad.PositivMaskulinumNominativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "er");
                                    ad.PositivFemininumNominativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumNominativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "es");
                                    ad.PositivPluralNominativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");

                                    ad.PositivMaskulinumGenitivStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumGenitivStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "er");
                                    ad.PositivNeutrumGenitivStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivPluralGenitivStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "er");

                                    ad.PositivMaskulinumDativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "em");
                                    ad.PositivFemininumDativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "er");
                                    ad.PositivNeutrumDativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "em");
                                    ad.PositivPluralDativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumAkkusativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumAkkusativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumAkkusativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "es");
                                    ad.PositivPluralAkkusativStark.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");

                                    // SCHWACH
                                    ad.PositivMaskulinumNominativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivFemininumNominativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumNominativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivPluralNominativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumGenitivSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumGenitivSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivNeutrumGenitivSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivPluralGenitivSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumDativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumDativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivNeutrumDativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivPluralDativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumAkkusativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumAkkusativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumAkkusativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivPluralAkkusativSchwach.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    // SCHWACH
                                    ad.PositivMaskulinumNominativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "er");
                                    ad.PositivFemininumNominativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumNominativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "es");
                                    ad.PositivPluralNominativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumGenitivGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumGenitivGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivNeutrumGenitivGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivPluralGenitivGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumDativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumDativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivNeutrumDativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivPluralDativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");

                                    ad.PositivMaskulinumAkkusativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                    ad.PositivFemininumAkkusativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "e");
                                    ad.PositivNeutrumAkkusativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "es");
                                    ad.PositivPluralAkkusativGemischt.Add(StrCrop(ad.PositivStamm, 2) + StrRightC(ad.PositivStamm, 1) + "en");
                                }
                                break;
                        }
                        break;
                }
            }
            #endregion
            #region KOMPARATIV Deklination
            if (!String.IsNullOrEmpty(ad.KomparativStamm))
            {
                ad.KomparativMaskulinumNominativStark.Add(ad.KomparativStamm + "er");
                ad.KomparativFemininumNominativStark.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumNominativStark.Add(ad.KomparativStamm + "es");
                ad.KomparativPluralNominativStark.Add(ad.KomparativStamm + "e");

                ad.KomparativMaskulinumGenitivStark.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumGenitivStark.Add(ad.KomparativStamm + "er");
                ad.KomparativNeutrumGenitivStark.Add(ad.KomparativStamm + "en");
                ad.KomparativPluralGenitivStark.Add(ad.KomparativStamm + "er");

                ad.KomparativMaskulinumDativStark.Add(ad.KomparativStamm + "em");
                ad.KomparativFemininumDativStark.Add(ad.KomparativStamm + "er");
                ad.KomparativNeutrumDativStark.Add(ad.KomparativStamm + "em");
                ad.KomparativPluralDativStark.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumAkkusativStark.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumAkkusativStark.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumAkkusativStark.Add(ad.KomparativStamm + "es");
                ad.KomparativPluralAkkusativStark.Add(ad.KomparativStamm + "e");

                // SCHWACH 
                ad.KomparativMaskulinumNominativSchwach.Add(ad.KomparativStamm + "e");
                ad.KomparativFemininumNominativSchwach.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumNominativSchwach.Add(ad.KomparativStamm + "e");
                ad.KomparativPluralNominativSchwach.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumGenitivSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumGenitivSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativNeutrumGenitivSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativPluralGenitivSchwach.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumDativSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumDativSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativNeutrumDativSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativPluralDativSchwach.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumAkkusativSchwach.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumAkkusativSchwach.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumAkkusativSchwach.Add(ad.KomparativStamm + "e");
                ad.KomparativPluralAkkusativSchwach.Add(ad.KomparativStamm + "en");

                // GEMISCHT
                ad.KomparativMaskulinumNominativGemischt.Add(ad.KomparativStamm + "er");
                ad.KomparativFemininumNominativGemischt.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumNominativGemischt.Add(ad.KomparativStamm + "es");
                ad.KomparativPluralNominativGemischt.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumGenitivGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumGenitivGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativNeutrumGenitivGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativPluralGenitivGemischt.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumDativGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumDativGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativNeutrumDativGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativPluralDativGemischt.Add(ad.KomparativStamm + "en");

                ad.KomparativMaskulinumAkkusativGemischt.Add(ad.KomparativStamm + "en");
                ad.KomparativFemininumAkkusativGemischt.Add(ad.KomparativStamm + "e");
                ad.KomparativNeutrumAkkusativGemischt.Add(ad.KomparativStamm + "es");
                ad.KomparativPluralAkkusativGemischt.Add(ad.KomparativStamm + "en");

                if (!String.IsNullOrEmpty(ad.KomparativStammOhneE) || !String.IsNullOrEmpty(ad.KomparativStammAlternative))
                {
                    ad.KomparativMaskulinumNominativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "er");
                    ad.KomparativFemininumNominativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumNominativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "es");
                    ad.KomparativPluralNominativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");

                    ad.KomparativMaskulinumGenitivStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumGenitivStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "er");
                    ad.KomparativNeutrumGenitivStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativPluralGenitivStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "er");

                    ad.KomparativMaskulinumDativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "em");
                    ad.KomparativFemininumDativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "er");
                    ad.KomparativNeutrumDativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "em");
                    ad.KomparativPluralDativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumAkkusativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumAkkusativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumAkkusativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "es");
                    ad.KomparativPluralAkkusativStark.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");

                    // SCHWACH
                    ad.KomparativMaskulinumNominativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativFemininumNominativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumNominativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativPluralNominativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumGenitivSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumGenitivSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativNeutrumGenitivSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativPluralGenitivSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumDativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumDativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativNeutrumDativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativPluralDativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumAkkusativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumAkkusativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumAkkusativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativPluralAkkusativSchwach.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    // GEMISCHT
                    ad.KomparativMaskulinumNominativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "er");
                    ad.KomparativFemininumNominativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumNominativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "es");
                    ad.KomparativPluralNominativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumGenitivGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumGenitivGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativNeutrumGenitivGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativPluralGenitivGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumDativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumDativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativNeutrumDativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativPluralDativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");

                    ad.KomparativMaskulinumAkkusativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                    ad.KomparativFemininumAkkusativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "e");
                    ad.KomparativNeutrumAkkusativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "es");
                    ad.KomparativPluralAkkusativGemischt.Add(ad.KomparativStammOhneE + ad.KomparativStammAlternative + "en");
                }

            }
            #endregion
            #region SUPERLATIV Deklination
            if (!String.IsNullOrEmpty(ad.SuperlativStamm))
            {
                ad.SuperlativMaskulinumNominativStark.Add(ad.SuperlativStamm + "er");
                ad.SuperlativFemininumNominativStark.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumNominativStark.Add(ad.SuperlativStamm + "es");
                ad.SuperlativPluralNominativStark.Add(ad.SuperlativStamm + "e");

                ad.SuperlativMaskulinumGenitivStark.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumGenitivStark.Add(ad.SuperlativStamm + "er");
                ad.SuperlativNeutrumGenitivStark.Add(ad.SuperlativStamm + "en");
                ad.SuperlativPluralGenitivStark.Add(ad.SuperlativStamm + "er");

                ad.SuperlativMaskulinumDativStark.Add(ad.SuperlativStamm + "em");
                ad.SuperlativFemininumDativStark.Add(ad.SuperlativStamm + "er");
                ad.SuperlativNeutrumDativStark.Add(ad.SuperlativStamm + "em");
                ad.SuperlativPluralDativStark.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumAkkusativStark.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumAkkusativStark.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumAkkusativStark.Add(ad.SuperlativStamm + "es");
                ad.SuperlativPluralAkkusativStark.Add(ad.SuperlativStamm + "e");

                //// SCHWACH 
                ad.SuperlativMaskulinumNominativSchwach.Add(ad.SuperlativStamm + "e");
                ad.SuperlativFemininumNominativSchwach.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumNominativSchwach.Add(ad.SuperlativStamm + "e");
                ad.SuperlativPluralNominativSchwach.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumGenitivSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumGenitivSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativNeutrumGenitivSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativPluralGenitivSchwach.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumDativSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumDativSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativNeutrumDativSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativPluralDativSchwach.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumAkkusativSchwach.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumAkkusativSchwach.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumAkkusativSchwach.Add(ad.SuperlativStamm + "e");
                ad.SuperlativPluralAkkusativSchwach.Add(ad.SuperlativStamm + "en");

                //// GEMISCHT
                ad.SuperlativMaskulinumNominativGemischt.Add(ad.SuperlativStamm + "er");
                ad.SuperlativFemininumNominativGemischt.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumNominativGemischt.Add(ad.SuperlativStamm + "es");
                ad.SuperlativPluralNominativGemischt.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumGenitivGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumGenitivGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativNeutrumGenitivGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativPluralGenitivGemischt.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumDativGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumDativGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativNeutrumDativGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativPluralDativGemischt.Add(ad.SuperlativStamm + "en");

                ad.SuperlativMaskulinumAkkusativGemischt.Add(ad.SuperlativStamm + "en");
                ad.SuperlativFemininumAkkusativGemischt.Add(ad.SuperlativStamm + "e");
                ad.SuperlativNeutrumAkkusativGemischt.Add(ad.SuperlativStamm + "es");
                ad.SuperlativPluralAkkusativGemischt.Add(ad.SuperlativStamm + "en");

                if (!String.IsNullOrEmpty(ad.SuperlativStammOhneE) || !String.IsNullOrEmpty(ad.SuperlativStammAlternative))
                {
                    ad.SuperlativMaskulinumNominativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "er");
                    ad.SuperlativFemininumNominativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumNominativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "es");
                    ad.SuperlativPluralNominativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");

                    ad.SuperlativMaskulinumGenitivStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumGenitivStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "er");
                    ad.SuperlativNeutrumGenitivStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativPluralGenitivStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "er");

                    ad.SuperlativMaskulinumDativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "em");
                    ad.SuperlativFemininumDativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "er");
                    ad.SuperlativNeutrumDativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "em");
                    ad.SuperlativPluralDativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumAkkusativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumAkkusativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumAkkusativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "es");
                    ad.SuperlativPluralAkkusativStark.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");

                    //// SCHWACH
                    ad.SuperlativMaskulinumNominativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativFemininumNominativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumNominativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativPluralNominativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumGenitivSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumGenitivSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativNeutrumGenitivSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativPluralGenitivSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumDativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumDativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativNeutrumDativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativPluralDativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumAkkusativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumAkkusativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumAkkusativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativPluralAkkusativSchwach.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    //// GEMISCHT
                    ad.SuperlativMaskulinumNominativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "er");
                    ad.SuperlativFemininumNominativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumNominativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "es");
                    ad.SuperlativPluralNominativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumGenitivGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumGenitivGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativNeutrumGenitivGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativPluralGenitivGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumDativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumDativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativNeutrumDativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativPluralDativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");

                    ad.SuperlativMaskulinumAkkusativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                    ad.SuperlativFemininumAkkusativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "e");
                    ad.SuperlativNeutrumAkkusativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "es");
                    ad.SuperlativPluralAkkusativGemischt.Add(ad.SuperlativStammOhneE + ad.SuperlativStammAlternative + "en");
                }
                if (!String.IsNullOrEmpty(ad.SuperlativStammAlternative2))
                {
                    ad.SuperlativMaskulinumNominativStark.Add(ad.SuperlativStammAlternative2 + "er");
                    ad.SuperlativFemininumNominativStark.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumNominativStark.Add(ad.SuperlativStammAlternative2 + "es");
                    ad.SuperlativPluralNominativStark.Add(ad.SuperlativStammAlternative2 + "e");

                    ad.SuperlativMaskulinumGenitivStark.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumGenitivStark.Add(ad.SuperlativStammAlternative2 + "er");
                    ad.SuperlativNeutrumGenitivStark.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativPluralGenitivStark.Add(ad.SuperlativStammAlternative2 + "er");

                    ad.SuperlativMaskulinumDativStark.Add(ad.SuperlativStammAlternative2 + "em");
                    ad.SuperlativFemininumDativStark.Add(ad.SuperlativStammAlternative2 + "er");
                    ad.SuperlativNeutrumDativStark.Add(ad.SuperlativStammAlternative2 + "em");
                    ad.SuperlativPluralDativStark.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumAkkusativStark.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumAkkusativStark.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumAkkusativStark.Add(ad.SuperlativStammAlternative2 + "es");
                    ad.SuperlativPluralAkkusativStark.Add(ad.SuperlativStammAlternative2 + "e");

                    //// SCHWACH
                    ad.SuperlativMaskulinumNominativSchwach.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativFemininumNominativSchwach.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumNominativSchwach.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativPluralNominativSchwach.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumGenitivSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumGenitivSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativNeutrumGenitivSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativPluralGenitivSchwach.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumDativSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumDativSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativNeutrumDativSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativPluralDativSchwach.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumAkkusativSchwach.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumAkkusativSchwach.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumAkkusativSchwach.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativPluralAkkusativSchwach.Add(ad.SuperlativStammAlternative2 + "en");

                    //// GEMISCHT
                    ad.SuperlativMaskulinumNominativGemischt.Add(ad.SuperlativStammAlternative2 + "er");
                    ad.SuperlativFemininumNominativGemischt.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumNominativGemischt.Add(ad.SuperlativStammAlternative2 + "es");
                    ad.SuperlativPluralNominativGemischt.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumGenitivGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumGenitivGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativNeutrumGenitivGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativPluralGenitivGemischt.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumDativGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumDativGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativNeutrumDativGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativPluralDativGemischt.Add(ad.SuperlativStammAlternative2 + "en");

                    ad.SuperlativMaskulinumAkkusativGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                    ad.SuperlativFemininumAkkusativGemischt.Add(ad.SuperlativStammAlternative2 + "e");
                    ad.SuperlativNeutrumAkkusativGemischt.Add(ad.SuperlativStammAlternative2 + "es");
                    ad.SuperlativPluralAkkusativGemischt.Add(ad.SuperlativStammAlternative2 + "en");
                }
            }

            #endregion
        }


    }
}
