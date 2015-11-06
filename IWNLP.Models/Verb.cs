using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models
{
    public class Verb : Word
    {
        // https://de.wiktionary.org/wiki/Vorlage:Deutsch_Verb_%C3%9Cbersicht/Doku 

        public bool ConjugationBlockMissing { get; set; }

        public List<String> Präsens_Ich { get; set; }
        public List<String> Präsens_Du { get; set; }
        public List<String> Präsens_ErSieEs { get; set; }
        public List<String> Präteritum_ich { get; set; }
        public List<String> KonjunktivII_Ich { get; set; }
        public List<String> ImperativSingular { get; set; }
        public List<String> ImperativPlural { get; set; }
        public List<String> PartizipII { get; set; }
        public String Hilfsverb { get; set; }
        public String Hilfsverb2 { get; set; }
        public String WeitereKonjugationen { get; set; }
        public String WeitereKonjugationen2 { get; set; }


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
                && this.Hilfsverb == obj.Hilfsverb
                && this.Hilfsverb2 == obj.Hilfsverb2
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
