using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IWNLP.Models
{
    public class Adjective: Word
    {
        public List<String> Positiv { get; set; }
        public List<String> Komparativ { get; set; }
        public List<String> Superlativ { get; set; }
        public bool KeineWeiterenFormen { get; set; }

        public AdjectiveDeclination Delication { get; set; }

        public bool Equals(Adjective obj)
        {
            return base.Text == obj.Text
                && base.WiktionaryID == obj.WiktionaryID
                && base.POS == obj.POS
                && this.KeineWeiterenFormen == obj.KeineWeiterenFormen
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Positiv, obj.Positiv)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Komparativ, obj.Komparativ)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Superlativ, obj.Superlativ);
        }
    }
}
