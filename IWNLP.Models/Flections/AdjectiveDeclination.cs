using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models.Flections
{
    public class AdjectiveDeclination:Entry
    {
        public String PositivStamm { get; set; }
        public String KomparativStamm { get; set; }
        public String KomparativStammOhneE { get; set; }
        public String KomparativStammAlternative { get; set; }
        public String KomparativPrädikativ { get; set; }
        public String SuperlativStamm { get; set; }
        public String SuperlativStammOhneE { get; set; }
        public String SuperlativStammAlternative { get; set; }
        public String SuperlativStammAlternative2 { get; set; }
        public String SuperlativPrädikativ { get; set; }
        public bool EEndung { get; set; }
        public String Prädikativ { get; set; }
        public String Positiv { get; set; }


        public List<String> PositivMaskulinumNominativStark { get; set; }
        public List<String> PositivMaskulinumGenitivStark { get; set; }
        public List<String> PositivMaskulinumDativStark { get; set; }
        public List<String> PositivMaskulinumAkkusativStark { get; set; }
        public List<String> PositivFemininumNominativStark { get; set; }
        public List<String> PositivFemininumGenitivStark { get; set; }
        public List<String> PositivFemininumDativStark { get; set; }
        public List<String> PositivFemininumAkkusativStark { get; set; }
        public List<String> PositivNeutrumNominativStark { get; set; }
        public List<String> PositivNeutrumGenitivStark { get; set; }
        public List<String> PositivNeutrumDativStark { get; set; }
        public List<String> PositivNeutrumAkkusativStark { get; set; }
        public List<String> PositivPluralNominativStark { get; set; }
        public List<String> PositivPluralGenitivStark { get; set; }
        public List<String> PositivPluralDativStark { get; set; }
        public List<String> PositivPluralAkkusativStark { get; set; }

        public List<String> PositivMaskulinumNominativSchwach { get; set; }
        public List<String> PositivMaskulinumGenitivSchwach { get; set; }
        public List<String> PositivMaskulinumDativSchwach { get; set; }
        public List<String> PositivMaskulinumAkkusativSchwach { get; set; }
        public List<String> PositivFemininumNominativSchwach { get; set; }
        public List<String> PositivFemininumGenitivSchwach { get; set; }
        public List<String> PositivFemininumDativSchwach { get; set; }
        public List<String> PositivFemininumAkkusativSchwach { get; set; }
        public List<String> PositivNeutrumNominativSchwach { get; set; }
        public List<String> PositivNeutrumGenitivSchwach { get; set; }
        public List<String> PositivNeutrumDativSchwach { get; set; }
        public List<String> PositivNeutrumAkkusativSchwach { get; set; }
        public List<String> PositivPluralNominativSchwach { get; set; }
        public List<String> PositivPluralGenitivSchwach { get; set; }
        public List<String> PositivPluralDativSchwach { get; set; }
        public List<String> PositivPluralAkkusativSchwach { get; set; }

        public List<String> PositivMaskulinumNominativGemischt { get; set; }
        public List<String> PositivMaskulinumGenitivGemischt { get; set; }
        public List<String> PositivMaskulinumDativGemischt { get; set; }
        public List<String> PositivMaskulinumAkkusativGemischt { get; set; }
        public List<String> PositivFemininumNominativGemischt { get; set; }
        public List<String> PositivFemininumGenitivGemischt { get; set; }
        public List<String> PositivFemininumDativGemischt { get; set; }
        public List<String> PositivFemininumAkkusativGemischt { get; set; }
        public List<String> PositivNeutrumNominativGemischt { get; set; }
        public List<String> PositivNeutrumGenitivGemischt { get; set; }
        public List<String> PositivNeutrumDativGemischt { get; set; }
        public List<String> PositivNeutrumAkkusativGemischt { get; set; }
        public List<String> PositivPluralNominativGemischt { get; set; }
        public List<String> PositivPluralGenitivGemischt { get; set; }
        public List<String> PositivPluralDativGemischt { get; set; }
        public List<String> PositivPluralAkkusativGemischt { get; set; }

        public List<String> KomparativMaskulinumNominativStark { get; set; }
        public List<String> KomparativMaskulinumGenitivStark { get; set; }
        public List<String> KomparativMaskulinumDativStark { get; set; }
        public List<String> KomparativMaskulinumAkkusativStark { get; set; }
        public List<String> KomparativFemininumNominativStark { get; set; }
        public List<String> KomparativFemininumGenitivStark { get; set; }
        public List<String> KomparativFemininumDativStark { get; set; }
        public List<String> KomparativFemininumAkkusativStark { get; set; }
        public List<String> KomparativNeutrumNominativStark { get; set; }
        public List<String> KomparativNeutrumGenitivStark { get; set; }
        public List<String> KomparativNeutrumDativStark { get; set; }
        public List<String> KomparativNeutrumAkkusativStark { get; set; }
        public List<String> KomparativPluralNominativStark { get; set; }
        public List<String> KomparativPluralGenitivStark { get; set; }
        public List<String> KomparativPluralDativStark { get; set; }
        public List<String> KomparativPluralAkkusativStark { get; set; }

        public List<String> KomparativMaskulinumNominativSchwach { get; set; }
        public List<String> KomparativMaskulinumGenitivSchwach { get; set; }
        public List<String> KomparativMaskulinumDativSchwach { get; set; }
        public List<String> KomparativMaskulinumAkkusativSchwach { get; set; }
        public List<String> KomparativFemininumNominativSchwach { get; set; }
        public List<String> KomparativFemininumGenitivSchwach { get; set; }
        public List<String> KomparativFemininumDativSchwach { get; set; }
        public List<String> KomparativFemininumAkkusativSchwach { get; set; }
        public List<String> KomparativNeutrumNominativSchwach { get; set; }
        public List<String> KomparativNeutrumGenitivSchwach { get; set; }
        public List<String> KomparativNeutrumDativSchwach { get; set; }
        public List<String> KomparativNeutrumAkkusativSchwach { get; set; }
        public List<String> KomparativPluralNominativSchwach { get; set; }
        public List<String> KomparativPluralGenitivSchwach { get; set; }
        public List<String> KomparativPluralDativSchwach { get; set; }
        public List<String> KomparativPluralAkkusativSchwach { get; set; }

        public List<String> KomparativMaskulinumNominativGemischt { get; set; }
        public List<String> KomparativMaskulinumGenitivGemischt { get; set; }
        public List<String> KomparativMaskulinumDativGemischt { get; set; }
        public List<String> KomparativMaskulinumAkkusativGemischt { get; set; }
        public List<String> KomparativFemininumNominativGemischt { get; set; }
        public List<String> KomparativFemininumGenitivGemischt { get; set; }
        public List<String> KomparativFemininumDativGemischt { get; set; }
        public List<String> KomparativFemininumAkkusativGemischt { get; set; }
        public List<String> KomparativNeutrumNominativGemischt { get; set; }
        public List<String> KomparativNeutrumGenitivGemischt { get; set; }
        public List<String> KomparativNeutrumDativGemischt { get; set; }
        public List<String> KomparativNeutrumAkkusativGemischt { get; set; }
        public List<String> KomparativPluralNominativGemischt { get; set; }
        public List<String> KomparativPluralGenitivGemischt { get; set; }
        public List<String> KomparativPluralDativGemischt { get; set; }
        public List<String> KomparativPluralAkkusativGemischt { get; set; }

        public List<String> SuperlativMaskulinumNominativStark { get; set; }
        public List<String> SuperlativMaskulinumGenitivStark { get; set; }
        public List<String> SuperlativMaskulinumDativStark { get; set; }
        public List<String> SuperlativMaskulinumAkkusativStark { get; set; }
        public List<String> SuperlativFemininumNominativStark { get; set; }
        public List<String> SuperlativFemininumGenitivStark { get; set; }
        public List<String> SuperlativFemininumDativStark { get; set; }
        public List<String> SuperlativFemininumAkkusativStark { get; set; }
        public List<String> SuperlativNeutrumNominativStark { get; set; }
        public List<String> SuperlativNeutrumGenitivStark { get; set; }
        public List<String> SuperlativNeutrumDativStark { get; set; }
        public List<String> SuperlativNeutrumAkkusativStark { get; set; }
        public List<String> SuperlativPluralNominativStark { get; set; }
        public List<String> SuperlativPluralGenitivStark { get; set; }
        public List<String> SuperlativPluralDativStark { get; set; }
        public List<String> SuperlativPluralAkkusativStark { get; set; }

        public List<String> SuperlativMaskulinumNominativSchwach { get; set; }
        public List<String> SuperlativMaskulinumGenitivSchwach { get; set; }
        public List<String> SuperlativMaskulinumDativSchwach { get; set; }
        public List<String> SuperlativMaskulinumAkkusativSchwach { get; set; }
        public List<String> SuperlativFemininumNominativSchwach { get; set; }
        public List<String> SuperlativFemininumGenitivSchwach { get; set; }
        public List<String> SuperlativFemininumDativSchwach { get; set; }
        public List<String> SuperlativFemininumAkkusativSchwach { get; set; }
        public List<String> SuperlativNeutrumNominativSchwach { get; set; }
        public List<String> SuperlativNeutrumGenitivSchwach { get; set; }
        public List<String> SuperlativNeutrumDativSchwach { get; set; }
        public List<String> SuperlativNeutrumAkkusativSchwach { get; set; }
        public List<String> SuperlativPluralNominativSchwach { get; set; }
        public List<String> SuperlativPluralGenitivSchwach { get; set; }
        public List<String> SuperlativPluralDativSchwach { get; set; }
        public List<String> SuperlativPluralAkkusativSchwach { get; set; }

        public List<String> SuperlativMaskulinumNominativGemischt { get; set; }
        public List<String> SuperlativMaskulinumGenitivGemischt { get; set; }
        public List<String> SuperlativMaskulinumDativGemischt { get; set; }
        public List<String> SuperlativMaskulinumAkkusativGemischt { get; set; }
        public List<String> SuperlativFemininumNominativGemischt { get; set; }
        public List<String> SuperlativFemininumGenitivGemischt { get; set; }
        public List<String> SuperlativFemininumDativGemischt { get; set; }
        public List<String> SuperlativFemininumAkkusativGemischt { get; set; }
        public List<String> SuperlativNeutrumNominativGemischt { get; set; }
        public List<String> SuperlativNeutrumGenitivGemischt { get; set; }
        public List<String> SuperlativNeutrumDativGemischt { get; set; }
        public List<String> SuperlativNeutrumAkkusativGemischt { get; set; }
        public List<String> SuperlativPluralNominativGemischt { get; set; }
        public List<String> SuperlativPluralGenitivGemischt { get; set; }
        public List<String> SuperlativPluralDativGemischt { get; set; }
        public List<String> SuperlativPluralAkkusativGemischt { get; set; }

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
