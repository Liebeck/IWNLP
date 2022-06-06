using System;
using System.Collections.Generic;

namespace IWNLP.Models
{
    public class Pronoun : Word
    {

        public List<string> WerEinzahlM { get; set; }
        public List<string> WerEinzahlF { get; set; }
        public List<string> WerEinzahlN { get; set; }
        public List<string> WerEinzahlMehrzahl { get; set; }

        public List<string> WessenEinzahlM { get; set; }
        public List<string> WessenEinzahlF { get; set; }
        public List<string> WessenEinzahlN { get; set; }
        public List<string> WessenEinzahlMehrzahl { get; set; }

        public List<string> WemEinzahlM { get; set; }
        public List<string> WemEinzahlF { get; set; }
        public List<string> WemEinzahlN { get; set; }
        public List<string> WemEinzahlMehrzahl { get; set; }

        public List<string> WenEinzahlM { get; set; }
        public List<string> WenEinzahlF { get; set; }
        public List<string> WenEinzahlN { get; set; }
        public List<string> WenEinzahlMehrzahl { get; set; }

        public bool Equals(Pronoun obj)
        {
            return base.Text == obj.Text
                && base.WiktionaryID == obj.WiktionaryID
                && base.POS == obj.POS
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WerEinzahlM, obj.WerEinzahlM)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WerEinzahlF, obj.WerEinzahlF)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WerEinzahlN, obj.WerEinzahlN)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WerEinzahlMehrzahl, obj.WerEinzahlMehrzahl)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WessenEinzahlM, obj.WessenEinzahlM)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WessenEinzahlF, obj.WessenEinzahlF)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WessenEinzahlN, obj.WessenEinzahlN)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WessenEinzahlMehrzahl, obj.WessenEinzahlMehrzahl)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WemEinzahlM, obj.WemEinzahlM)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WemEinzahlF, obj.WemEinzahlF)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WemEinzahlN, obj.WemEinzahlN)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WemEinzahlMehrzahl, obj.WemEinzahlMehrzahl)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WenEinzahlM, obj.WenEinzahlM)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WenEinzahlF, obj.WenEinzahlF)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WenEinzahlN, obj.WenEinzahlN)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.WenEinzahlMehrzahl, obj.WenEinzahlMehrzahl);
        }    
    }
}
