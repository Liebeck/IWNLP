using System;
using System.Collections.Generic;

namespace IWNLP.Models
{
    public class Verb : Word
    {
        // https://de.wiktionary.org/wiki/Vorlage:Deutsch_Verb_%C3%9Cbersicht/Doku 

        public bool ConjugationBlockMissing { get; set; }

        public List<string> Präsens_Ich { get; set; }
        public List<string> Präsens_Du { get; set; }
        public List<string> Präsens_ErSieEs { get; set; }
        public List<string> Präteritum_ich { get; set; }
        public List<string> KonjunktivII_Ich { get; set; }
        public List<string> ImperativSingular { get; set; }
        public List<string> ImperativPlural { get; set; }
        public List<string> PartizipII { get; set; }
        public List<string> Hilfsverb { get; set; }
        //public String Hilfsverb2 { get; set; }
        public string WeitereKonjugationen { get; set; }
        public string WeitereKonjugationen2 { get; set; }


        private bool unpersönlich = false;
        public bool Unpersönlich
        {
            get { return unpersönlich; }
            set { unpersönlich = value; }
        }

        public bool Equals(Verb obj)
        {
            return base.Text == obj.Text
                && base.WiktionaryID == obj.WiktionaryID
                && base.POS == obj.POS
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Hilfsverb, obj.Hilfsverb)
                && this.WeitereKonjugationen == obj.WeitereKonjugationen
                && this.WeitereKonjugationen2 == obj.WeitereKonjugationen2
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Präsens_Ich, obj.Präsens_Ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Präsens_Du, obj.Präsens_Du)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Präsens_ErSieEs, obj.Präsens_ErSieEs)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Präteritum_ich, obj.Präteritum_ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KonjunktivII_Ich, obj.KonjunktivII_Ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.ImperativSingular, obj.ImperativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.ImperativPlural, obj.ImperativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PartizipII, obj.PartizipII);
        }

    }
}
