using System;
using System.Collections.Generic;

namespace IWNLP.Models.Flections
{
    public class AdjectiveDeclination:Entry
    {
        public string PositivStamm { get; set; }
        public string KomparativStamm { get; set; }
        public string KomparativStammOhneE { get; set; }
        public string KomparativStammAlternative { get; set; }
        public string KomparativPrädikativ { get; set; }
        public string SuperlativStamm { get; set; }
        public string SuperlativStammOhneE { get; set; }
        public string SuperlativStammAlternative { get; set; }
        public string SuperlativStammAlternative2 { get; set; }
        public string SuperlativPrädikativ { get; set; }
        public bool EEndung { get; set; }
        public string Prädikativ { get; set; }
        public string Positiv { get; set; }


        public List<string> PositivMaskulinumNominativStark { get; set; }
        public List<string> PositivMaskulinumGenitivStark { get; set; }
        public List<string> PositivMaskulinumDativStark { get; set; }
        public List<string> PositivMaskulinumAkkusativStark { get; set; }
        public List<string> PositivFemininumNominativStark { get; set; }
        public List<string> PositivFemininumGenitivStark { get; set; }
        public List<string> PositivFemininumDativStark { get; set; }
        public List<string> PositivFemininumAkkusativStark { get; set; }
        public List<string> PositivNeutrumNominativStark { get; set; }
        public List<string> PositivNeutrumGenitivStark { get; set; }
        public List<string> PositivNeutrumDativStark { get; set; }
        public List<string> PositivNeutrumAkkusativStark { get; set; }
        public List<string> PositivPluralNominativStark { get; set; }
        public List<string> PositivPluralGenitivStark { get; set; }
        public List<string> PositivPluralDativStark { get; set; }
        public List<string> PositivPluralAkkusativStark { get; set; }

        public List<string> PositivMaskulinumNominativSchwach { get; set; }
        public List<string> PositivMaskulinumGenitivSchwach { get; set; }
        public List<string> PositivMaskulinumDativSchwach { get; set; }
        public List<string> PositivMaskulinumAkkusativSchwach { get; set; }
        public List<string> PositivFemininumNominativSchwach { get; set; }
        public List<string> PositivFemininumGenitivSchwach { get; set; }
        public List<string> PositivFemininumDativSchwach { get; set; }
        public List<string> PositivFemininumAkkusativSchwach { get; set; }
        public List<string> PositivNeutrumNominativSchwach { get; set; }
        public List<string> PositivNeutrumGenitivSchwach { get; set; }
        public List<string> PositivNeutrumDativSchwach { get; set; }
        public List<string> PositivNeutrumAkkusativSchwach { get; set; }
        public List<string> PositivPluralNominativSchwach { get; set; }
        public List<string> PositivPluralGenitivSchwach { get; set; }
        public List<string> PositivPluralDativSchwach { get; set; }
        public List<string> PositivPluralAkkusativSchwach { get; set; }

        public List<string> PositivMaskulinumNominativGemischt { get; set; }
        public List<string> PositivMaskulinumGenitivGemischt { get; set; }
        public List<string> PositivMaskulinumDativGemischt { get; set; }
        public List<string> PositivMaskulinumAkkusativGemischt { get; set; }
        public List<string> PositivFemininumNominativGemischt { get; set; }
        public List<string> PositivFemininumGenitivGemischt { get; set; }
        public List<string> PositivFemininumDativGemischt { get; set; }
        public List<string> PositivFemininumAkkusativGemischt { get; set; }
        public List<string> PositivNeutrumNominativGemischt { get; set; }
        public List<string> PositivNeutrumGenitivGemischt { get; set; }
        public List<string> PositivNeutrumDativGemischt { get; set; }
        public List<string> PositivNeutrumAkkusativGemischt { get; set; }
        public List<string> PositivPluralNominativGemischt { get; set; }
        public List<string> PositivPluralGenitivGemischt { get; set; }
        public List<string> PositivPluralDativGemischt { get; set; }
        public List<string> PositivPluralAkkusativGemischt { get; set; }

        public List<string> KomparativMaskulinumNominativStark { get; set; }
        public List<string> KomparativMaskulinumGenitivStark { get; set; }
        public List<string> KomparativMaskulinumDativStark { get; set; }
        public List<string> KomparativMaskulinumAkkusativStark { get; set; }
        public List<string> KomparativFemininumNominativStark { get; set; }
        public List<string> KomparativFemininumGenitivStark { get; set; }
        public List<string> KomparativFemininumDativStark { get; set; }
        public List<string> KomparativFemininumAkkusativStark { get; set; }
        public List<string> KomparativNeutrumNominativStark { get; set; }
        public List<string> KomparativNeutrumGenitivStark { get; set; }
        public List<string> KomparativNeutrumDativStark { get; set; }
        public List<string> KomparativNeutrumAkkusativStark { get; set; }
        public List<string> KomparativPluralNominativStark { get; set; }
        public List<string> KomparativPluralGenitivStark { get; set; }
        public List<string> KomparativPluralDativStark { get; set; }
        public List<string> KomparativPluralAkkusativStark { get; set; }

        public List<string> KomparativMaskulinumNominativSchwach { get; set; }
        public List<string> KomparativMaskulinumGenitivSchwach { get; set; }
        public List<string> KomparativMaskulinumDativSchwach { get; set; }
        public List<string> KomparativMaskulinumAkkusativSchwach { get; set; }
        public List<string> KomparativFemininumNominativSchwach { get; set; }
        public List<string> KomparativFemininumGenitivSchwach { get; set; }
        public List<string> KomparativFemininumDativSchwach { get; set; }
        public List<string> KomparativFemininumAkkusativSchwach { get; set; }
        public List<string> KomparativNeutrumNominativSchwach { get; set; }
        public List<string> KomparativNeutrumGenitivSchwach { get; set; }
        public List<string> KomparativNeutrumDativSchwach { get; set; }
        public List<string> KomparativNeutrumAkkusativSchwach { get; set; }
        public List<string> KomparativPluralNominativSchwach { get; set; }
        public List<string> KomparativPluralGenitivSchwach { get; set; }
        public List<string> KomparativPluralDativSchwach { get; set; }
        public List<string> KomparativPluralAkkusativSchwach { get; set; }

        public List<string> KomparativMaskulinumNominativGemischt { get; set; }
        public List<string> KomparativMaskulinumGenitivGemischt { get; set; }
        public List<string> KomparativMaskulinumDativGemischt { get; set; }
        public List<string> KomparativMaskulinumAkkusativGemischt { get; set; }
        public List<string> KomparativFemininumNominativGemischt { get; set; }
        public List<string> KomparativFemininumGenitivGemischt { get; set; }
        public List<string> KomparativFemininumDativGemischt { get; set; }
        public List<string> KomparativFemininumAkkusativGemischt { get; set; }
        public List<string> KomparativNeutrumNominativGemischt { get; set; }
        public List<string> KomparativNeutrumGenitivGemischt { get; set; }
        public List<string> KomparativNeutrumDativGemischt { get; set; }
        public List<string> KomparativNeutrumAkkusativGemischt { get; set; }
        public List<string> KomparativPluralNominativGemischt { get; set; }
        public List<string> KomparativPluralGenitivGemischt { get; set; }
        public List<string> KomparativPluralDativGemischt { get; set; }
        public List<string> KomparativPluralAkkusativGemischt { get; set; }

        public List<string> SuperlativMaskulinumNominativStark { get; set; }
        public List<string> SuperlativMaskulinumGenitivStark { get; set; }
        public List<string> SuperlativMaskulinumDativStark { get; set; }
        public List<string> SuperlativMaskulinumAkkusativStark { get; set; }
        public List<string> SuperlativFemininumNominativStark { get; set; }
        public List<string> SuperlativFemininumGenitivStark { get; set; }
        public List<string> SuperlativFemininumDativStark { get; set; }
        public List<string> SuperlativFemininumAkkusativStark { get; set; }
        public List<string> SuperlativNeutrumNominativStark { get; set; }
        public List<string> SuperlativNeutrumGenitivStark { get; set; }
        public List<string> SuperlativNeutrumDativStark { get; set; }
        public List<string> SuperlativNeutrumAkkusativStark { get; set; }
        public List<string> SuperlativPluralNominativStark { get; set; }
        public List<string> SuperlativPluralGenitivStark { get; set; }
        public List<string> SuperlativPluralDativStark { get; set; }
        public List<string> SuperlativPluralAkkusativStark { get; set; }

        public List<string> SuperlativMaskulinumNominativSchwach { get; set; }
        public List<string> SuperlativMaskulinumGenitivSchwach { get; set; }
        public List<string> SuperlativMaskulinumDativSchwach { get; set; }
        public List<string> SuperlativMaskulinumAkkusativSchwach { get; set; }
        public List<string> SuperlativFemininumNominativSchwach { get; set; }
        public List<string> SuperlativFemininumGenitivSchwach { get; set; }
        public List<string> SuperlativFemininumDativSchwach { get; set; }
        public List<string> SuperlativFemininumAkkusativSchwach { get; set; }
        public List<string> SuperlativNeutrumNominativSchwach { get; set; }
        public List<string> SuperlativNeutrumGenitivSchwach { get; set; }
        public List<string> SuperlativNeutrumDativSchwach { get; set; }
        public List<string> SuperlativNeutrumAkkusativSchwach { get; set; }
        public List<string> SuperlativPluralNominativSchwach { get; set; }
        public List<string> SuperlativPluralGenitivSchwach { get; set; }
        public List<string> SuperlativPluralDativSchwach { get; set; }
        public List<string> SuperlativPluralAkkusativSchwach { get; set; }

        public List<string> SuperlativMaskulinumNominativGemischt { get; set; }
        public List<string> SuperlativMaskulinumGenitivGemischt { get; set; }
        public List<string> SuperlativMaskulinumDativGemischt { get; set; }
        public List<string> SuperlativMaskulinumAkkusativGemischt { get; set; }
        public List<string> SuperlativFemininumNominativGemischt { get; set; }
        public List<string> SuperlativFemininumGenitivGemischt { get; set; }
        public List<string> SuperlativFemininumDativGemischt { get; set; }
        public List<string> SuperlativFemininumAkkusativGemischt { get; set; }
        public List<string> SuperlativNeutrumNominativGemischt { get; set; }
        public List<string> SuperlativNeutrumGenitivGemischt { get; set; }
        public List<string> SuperlativNeutrumDativGemischt { get; set; }
        public List<string> SuperlativNeutrumAkkusativGemischt { get; set; }
        public List<string> SuperlativPluralNominativGemischt { get; set; }
        public List<string> SuperlativPluralGenitivGemischt { get; set; }
        public List<string> SuperlativPluralDativGemischt { get; set; }
        public List<string> SuperlativPluralAkkusativGemischt { get; set; }

        public AdjectiveDeclination()
        {
            this.PositivMaskulinumNominativStark = new List<string>();
            this.PositivFemininumNominativStark = new List<string>();
            this.PositivNeutrumNominativStark = new List<string>();
            this.PositivPluralNominativStark = new List<string>();

            this.PositivMaskulinumGenitivStark = new List<string>();
            this.PositivFemininumGenitivStark = new List<string>();
            this.PositivNeutrumGenitivStark = new List<string>();
            this.PositivPluralGenitivStark = new List<string>();

            this.PositivMaskulinumDativStark = new List<string>();
            this.PositivFemininumDativStark = new List<string>();
            this.PositivNeutrumDativStark = new List<string>();
            this.PositivPluralDativStark = new List<string>();

            this.PositivMaskulinumAkkusativStark = new List<string>();
            this.PositivFemininumAkkusativStark = new List<string>();
            this.PositivNeutrumAkkusativStark = new List<string>();
            this.PositivPluralAkkusativStark = new List<string>();

            this.PositivMaskulinumNominativSchwach = new List<string>();
            this.PositivFemininumNominativSchwach = new List<string>();
            this.PositivNeutrumNominativSchwach = new List<string>();
            this.PositivPluralNominativSchwach = new List<string>();

            this.PositivMaskulinumGenitivSchwach = new List<string>();
            this.PositivFemininumGenitivSchwach = new List<string>();
            this.PositivNeutrumGenitivSchwach = new List<string>();
            this.PositivPluralGenitivSchwach = new List<string>();

            this.PositivMaskulinumDativSchwach = new List<string>();
            this.PositivFemininumDativSchwach = new List<string>();
            this.PositivNeutrumDativSchwach = new List<string>();
            this.PositivPluralDativSchwach = new List<string>();

            this.PositivMaskulinumAkkusativSchwach = new List<string>();
            this.PositivFemininumAkkusativSchwach = new List<string>();
            this.PositivNeutrumAkkusativSchwach = new List<string>();
            this.PositivPluralAkkusativSchwach = new List<string>();

            this.PositivMaskulinumNominativGemischt = new List<string>();
            this.PositivFemininumNominativGemischt = new List<string>();
            this.PositivNeutrumNominativGemischt = new List<string>();
            this.PositivPluralNominativGemischt = new List<string>();

            this.PositivMaskulinumGenitivGemischt = new List<string>();
            this.PositivFemininumGenitivGemischt = new List<string>();
            this.PositivNeutrumGenitivGemischt = new List<string>();
            this.PositivPluralGenitivGemischt = new List<string>();

            this.PositivMaskulinumDativGemischt = new List<string>();
            this.PositivFemininumDativGemischt = new List<string>();
            this.PositivNeutrumDativGemischt = new List<string>();
            this.PositivPluralDativGemischt = new List<string>();

            this.PositivMaskulinumAkkusativGemischt = new List<string>();
            this.PositivFemininumAkkusativGemischt = new List<string>();
            this.PositivNeutrumAkkusativGemischt = new List<string>();
            this.PositivPluralAkkusativGemischt = new List<string>();

            // KOMPARATIV
            this.KomparativMaskulinumNominativStark = new List<string>();
            this.KomparativFemininumNominativStark = new List<string>();
            this.KomparativNeutrumNominativStark = new List<string>();
            this.KomparativPluralNominativStark = new List<string>();

            this.KomparativMaskulinumGenitivStark = new List<string>();
            this.KomparativFemininumGenitivStark = new List<string>();
            this.KomparativNeutrumGenitivStark = new List<string>();
            this.KomparativPluralGenitivStark = new List<string>();

            this.KomparativMaskulinumDativStark = new List<string>();
            this.KomparativFemininumDativStark = new List<string>();
            this.KomparativNeutrumDativStark = new List<string>();
            this.KomparativPluralDativStark = new List<string>();

            this.KomparativMaskulinumAkkusativStark = new List<string>();
            this.KomparativFemininumAkkusativStark = new List<string>();
            this.KomparativNeutrumAkkusativStark = new List<string>();
            this.KomparativPluralAkkusativStark = new List<string>();

            this.KomparativMaskulinumNominativSchwach = new List<string>();
            this.KomparativFemininumNominativSchwach = new List<string>();
            this.KomparativNeutrumNominativSchwach = new List<string>();
            this.KomparativPluralNominativSchwach = new List<string>();

            this.KomparativMaskulinumGenitivSchwach = new List<string>();
            this.KomparativFemininumGenitivSchwach = new List<string>();
            this.KomparativNeutrumGenitivSchwach = new List<string>();
            this.KomparativPluralGenitivSchwach = new List<string>();

            this.KomparativMaskulinumDativSchwach = new List<string>();
            this.KomparativFemininumDativSchwach = new List<string>();
            this.KomparativNeutrumDativSchwach = new List<string>();
            this.KomparativPluralDativSchwach = new List<string>();

            this.KomparativMaskulinumAkkusativSchwach = new List<string>();
            this.KomparativFemininumAkkusativSchwach = new List<string>();
            this.KomparativNeutrumAkkusativSchwach = new List<string>();
            this.KomparativPluralAkkusativSchwach = new List<string>();

            this.KomparativMaskulinumNominativGemischt = new List<string>();
            this.KomparativFemininumNominativGemischt = new List<string>();
            this.KomparativNeutrumNominativGemischt = new List<string>();
            this.KomparativPluralNominativGemischt = new List<string>();

            this.KomparativMaskulinumGenitivGemischt = new List<string>();
            this.KomparativFemininumGenitivGemischt = new List<string>();
            this.KomparativNeutrumGenitivGemischt = new List<string>();
            this.KomparativPluralGenitivGemischt = new List<string>();

            this.KomparativMaskulinumDativGemischt = new List<string>();
            this.KomparativFemininumDativGemischt = new List<string>();
            this.KomparativNeutrumDativGemischt = new List<string>();
            this.KomparativPluralDativGemischt = new List<string>();

            this.KomparativMaskulinumAkkusativGemischt = new List<string>();
            this.KomparativFemininumAkkusativGemischt = new List<string>();
            this.KomparativNeutrumAkkusativGemischt = new List<string>();
            this.KomparativPluralAkkusativGemischt = new List<string>();

            // SUPERLATIV
            this.SuperlativMaskulinumNominativStark = new List<string>();
            this.SuperlativFemininumNominativStark = new List<string>();
            this.SuperlativNeutrumNominativStark = new List<string>();
            this.SuperlativPluralNominativStark = new List<string>();

            this.SuperlativMaskulinumGenitivStark = new List<string>();
            this.SuperlativFemininumGenitivStark = new List<string>();
            this.SuperlativNeutrumGenitivStark = new List<string>();
            this.SuperlativPluralGenitivStark = new List<string>();

            this.SuperlativMaskulinumDativStark = new List<string>();
            this.SuperlativFemininumDativStark = new List<string>();
            this.SuperlativNeutrumDativStark = new List<string>();
            this.SuperlativPluralDativStark = new List<string>();

            this.SuperlativMaskulinumAkkusativStark = new List<string>();
            this.SuperlativFemininumAkkusativStark = new List<string>();
            this.SuperlativNeutrumAkkusativStark = new List<string>();
            this.SuperlativPluralAkkusativStark = new List<string>();

            this.SuperlativMaskulinumNominativSchwach = new List<string>();
            this.SuperlativFemininumNominativSchwach = new List<string>();
            this.SuperlativNeutrumNominativSchwach = new List<string>();
            this.SuperlativPluralNominativSchwach = new List<string>();

            this.SuperlativMaskulinumGenitivSchwach = new List<string>();
            this.SuperlativFemininumGenitivSchwach = new List<string>();
            this.SuperlativNeutrumGenitivSchwach = new List<string>();
            this.SuperlativPluralGenitivSchwach = new List<string>();

            this.SuperlativMaskulinumDativSchwach = new List<string>();
            this.SuperlativFemininumDativSchwach = new List<string>();
            this.SuperlativNeutrumDativSchwach = new List<string>();
            this.SuperlativPluralDativSchwach = new List<string>();

            this.SuperlativMaskulinumAkkusativSchwach = new List<string>();
            this.SuperlativFemininumAkkusativSchwach = new List<string>();
            this.SuperlativNeutrumAkkusativSchwach = new List<string>();
            this.SuperlativPluralAkkusativSchwach = new List<string>();

            this.SuperlativMaskulinumNominativGemischt = new List<string>();
            this.SuperlativFemininumNominativGemischt = new List<string>();
            this.SuperlativNeutrumNominativGemischt = new List<string>();
            this.SuperlativPluralNominativGemischt = new List<string>();

            this.SuperlativMaskulinumGenitivGemischt = new List<string>();
            this.SuperlativFemininumGenitivGemischt = new List<string>();
            this.SuperlativNeutrumGenitivGemischt = new List<string>();
            this.SuperlativPluralGenitivGemischt = new List<string>();

            this.SuperlativMaskulinumDativGemischt = new List<string>();
            this.SuperlativFemininumDativGemischt = new List<string>();
            this.SuperlativNeutrumDativGemischt = new List<string>();
            this.SuperlativPluralDativGemischt = new List<string>();

            this.SuperlativMaskulinumAkkusativGemischt = new List<string>();
            this.SuperlativFemininumAkkusativGemischt = new List<string>();
            this.SuperlativNeutrumAkkusativGemischt = new List<string>();
            this.SuperlativPluralAkkusativGemischt = new List<string>();
        }

        public bool Equals(AdjectiveDeclination obj)
        {
            return this.PositivStamm == obj.PositivStamm
                && this.KomparativStamm == obj.KomparativStamm
                && this.KomparativStammOhneE == obj.KomparativStammOhneE
                && this.KomparativStammAlternative == obj.KomparativStammAlternative
                && this.KomparativPrädikativ == obj.KomparativPrädikativ
                && this.SuperlativStamm == obj.SuperlativStamm
                && this.SuperlativStammOhneE == obj.SuperlativStammOhneE
                && this.SuperlativStammAlternative == obj.SuperlativStammAlternative
                && this.SuperlativStammAlternative2 == obj.SuperlativStammAlternative2
                && this.SuperlativPrädikativ == obj.SuperlativPrädikativ
                && this.EEndung == obj.EEndung
                && this.Prädikativ == obj.Prädikativ
                && this.Positiv == obj.Positiv
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumNominativStark, obj.PositivMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumGenitivStark, obj.PositivMaskulinumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumDativStark, obj.PositivMaskulinumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumAkkusativStark, obj.PositivMaskulinumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumNominativStark, obj.PositivFemininumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumGenitivStark, obj.PositivFemininumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumDativStark, obj.PositivFemininumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumAkkusativStark, obj.PositivFemininumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumNominativStark, obj.PositivNeutrumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumGenitivStark, obj.PositivNeutrumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumDativStark, obj.PositivNeutrumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumAkkusativStark, obj.PositivNeutrumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralNominativStark, obj.PositivPluralNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralGenitivStark, obj.PositivPluralGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralDativStark, obj.PositivPluralDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralAkkusativStark, obj.PositivPluralAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumNominativSchwach, obj.PositivMaskulinumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumGenitivSchwach, obj.PositivMaskulinumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumDativSchwach, obj.PositivMaskulinumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumAkkusativSchwach, obj.PositivMaskulinumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumNominativSchwach, obj.PositivFemininumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumGenitivSchwach, obj.PositivFemininumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumDativSchwach, obj.PositivFemininumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumAkkusativSchwach, obj.PositivFemininumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumNominativSchwach, obj.PositivNeutrumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumGenitivSchwach, obj.PositivNeutrumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumDativSchwach, obj.PositivNeutrumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumAkkusativSchwach, obj.PositivNeutrumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralNominativSchwach, obj.PositivPluralNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralGenitivSchwach, obj.PositivPluralGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralDativSchwach, obj.PositivPluralDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralAkkusativSchwach, obj.PositivPluralAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumNominativStark, obj.PositivMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumGenitivGemischt, obj.PositivMaskulinumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumDativGemischt, obj.PositivMaskulinumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivMaskulinumAkkusativGemischt, obj.PositivMaskulinumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumNominativGemischt, obj.PositivFemininumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumGenitivGemischt, obj.PositivFemininumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumDativGemischt, obj.PositivFemininumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivFemininumAkkusativGemischt, obj.PositivFemininumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumNominativGemischt, obj.PositivNeutrumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumGenitivGemischt, obj.PositivNeutrumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumDativGemischt, obj.PositivNeutrumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivNeutrumAkkusativGemischt, obj.PositivNeutrumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralNominativGemischt, obj.PositivPluralNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralGenitivGemischt, obj.PositivPluralGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralDativGemischt, obj.PositivPluralDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PositivPluralAkkusativGemischt, obj.PositivPluralAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumNominativStark, obj.KomparativMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumGenitivStark, obj.KomparativMaskulinumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumDativStark, obj.KomparativMaskulinumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumAkkusativStark, obj.KomparativMaskulinumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumNominativStark, obj.KomparativFemininumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumGenitivStark, obj.KomparativFemininumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumDativStark, obj.KomparativFemininumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumAkkusativStark, obj.KomparativFemininumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumNominativStark, obj.KomparativNeutrumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumGenitivStark, obj.KomparativNeutrumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumDativStark, obj.KomparativNeutrumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumAkkusativStark, obj.KomparativNeutrumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralNominativStark, obj.KomparativPluralNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralGenitivStark, obj.KomparativPluralGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralDativStark, obj.KomparativPluralDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralAkkusativStark, obj.KomparativPluralAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumNominativSchwach, obj.KomparativMaskulinumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumGenitivSchwach, obj.KomparativMaskulinumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumDativSchwach, obj.KomparativMaskulinumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumAkkusativSchwach, obj.KomparativMaskulinumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumNominativSchwach, obj.KomparativFemininumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumGenitivSchwach, obj.KomparativFemininumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumDativSchwach, obj.KomparativFemininumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumAkkusativSchwach, obj.KomparativFemininumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumNominativSchwach, obj.KomparativNeutrumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumGenitivSchwach, obj.KomparativNeutrumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumDativSchwach, obj.KomparativNeutrumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumAkkusativSchwach, obj.KomparativNeutrumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralNominativSchwach, obj.KomparativPluralNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralGenitivSchwach, obj.KomparativPluralGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralDativSchwach, obj.KomparativPluralDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralAkkusativSchwach, obj.KomparativPluralAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumNominativStark, obj.KomparativMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumGenitivGemischt, obj.KomparativMaskulinumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumDativGemischt, obj.KomparativMaskulinumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativMaskulinumAkkusativGemischt, obj.KomparativMaskulinumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumNominativGemischt, obj.KomparativFemininumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumGenitivGemischt, obj.KomparativFemininumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumDativGemischt, obj.KomparativFemininumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativFemininumAkkusativGemischt, obj.KomparativFemininumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumNominativGemischt, obj.KomparativNeutrumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumGenitivGemischt, obj.KomparativNeutrumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumDativGemischt, obj.KomparativNeutrumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativNeutrumAkkusativGemischt, obj.KomparativNeutrumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralNominativGemischt, obj.KomparativPluralNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralGenitivGemischt, obj.KomparativPluralGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralDativGemischt, obj.KomparativPluralDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KomparativPluralAkkusativGemischt, obj.KomparativPluralAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumNominativStark, obj.SuperlativMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumGenitivStark, obj.SuperlativMaskulinumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumDativStark, obj.SuperlativMaskulinumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumAkkusativStark, obj.SuperlativMaskulinumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumNominativStark, obj.SuperlativFemininumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumGenitivStark, obj.SuperlativFemininumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumDativStark, obj.SuperlativFemininumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumAkkusativStark, obj.SuperlativFemininumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumNominativStark, obj.SuperlativNeutrumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumGenitivStark, obj.SuperlativNeutrumGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumDativStark, obj.SuperlativNeutrumDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumAkkusativStark, obj.SuperlativNeutrumAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralNominativStark, obj.SuperlativPluralNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralGenitivStark, obj.SuperlativPluralGenitivStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralDativStark, obj.SuperlativPluralDativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralAkkusativStark, obj.SuperlativPluralAkkusativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumNominativSchwach, obj.SuperlativMaskulinumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumGenitivSchwach, obj.SuperlativMaskulinumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumDativSchwach, obj.SuperlativMaskulinumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumAkkusativSchwach, obj.SuperlativMaskulinumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumNominativSchwach, obj.SuperlativFemininumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumGenitivSchwach, obj.SuperlativFemininumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumDativSchwach, obj.SuperlativFemininumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumAkkusativSchwach, obj.SuperlativFemininumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumNominativSchwach, obj.SuperlativNeutrumNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumGenitivSchwach, obj.SuperlativNeutrumGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumDativSchwach, obj.SuperlativNeutrumDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumAkkusativSchwach, obj.SuperlativNeutrumAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralNominativSchwach, obj.SuperlativPluralNominativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralGenitivSchwach, obj.SuperlativPluralGenitivSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralDativSchwach, obj.SuperlativPluralDativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralAkkusativSchwach, obj.SuperlativPluralAkkusativSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumNominativStark, obj.SuperlativMaskulinumNominativStark)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumGenitivGemischt, obj.SuperlativMaskulinumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumDativGemischt, obj.SuperlativMaskulinumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativMaskulinumAkkusativGemischt, obj.SuperlativMaskulinumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumNominativGemischt, obj.SuperlativFemininumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumGenitivGemischt, obj.SuperlativFemininumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumDativGemischt, obj.SuperlativFemininumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativFemininumAkkusativGemischt, obj.SuperlativFemininumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumNominativGemischt, obj.SuperlativNeutrumNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumGenitivGemischt, obj.SuperlativNeutrumGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumDativGemischt, obj.SuperlativNeutrumDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativNeutrumAkkusativGemischt, obj.SuperlativNeutrumAkkusativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralNominativGemischt, obj.SuperlativPluralNominativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralGenitivGemischt, obj.SuperlativPluralGenitivGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralDativGemischt, obj.SuperlativPluralDativGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.SuperlativPluralAkkusativGemischt, obj.SuperlativPluralAkkusativGemischt);
        }

    }
}
