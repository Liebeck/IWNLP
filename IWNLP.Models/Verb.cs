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

        public List<String> Gegenwart_Ich { get; set; }
        public List<String> Gegenwart_Du { get; set; }
        public List<String> Gegenwart_ErSieEs { get; set; }
        public List<String> Vergangenheit1_Ich { get; set; }
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
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Gegenwart_Ich, obj.Gegenwart_Ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Gegenwart_Du, obj.Gegenwart_Du)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Gegenwart_ErSieEs, obj.Gegenwart_ErSieEs)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Vergangenheit1_Ich, obj.Vergangenheit1_Ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.KonjunktivII_Ich, obj.KonjunktivII_Ich)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.ImperativSingular, obj.ImperativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.ImperativPlural, obj.ImperativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PartizipII, obj.PartizipII);
        }

    }
}
