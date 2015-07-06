using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models
{
    public class Pronoun : Word
    {

        public List<String> WerEinzahlM { get; set; }
        public List<String> WerEinzahlF { get; set; }
        public List<String> WerEinzahlN { get; set; }
        public List<String> WerEinzahlMehrzahl { get; set; }

        public List<String> WessenEinzahlM { get; set; }
        public List<String> WessenEinzahlF { get; set; }
        public List<String> WessenEinzahlN { get; set; }
        public List<String> WessenEinzahlMehrzahl { get; set; }

        public List<String> WemEinzahlM { get; set; }
        public List<String> WemEinzahlF { get; set; }
        public List<String> WemEinzahlN { get; set; }
        public List<String> WemEinzahlMehrzahl { get; set; }

        public List<String> WenEinzahlM { get; set; }
        public List<String> WenEinzahlF { get; set; }
        public List<String> WenEinzahlN { get; set; }
        public List<String> WenEinzahlMehrzahl { get; set; }

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
