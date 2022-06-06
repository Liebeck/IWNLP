using IWNLP.Models.Nouns;
using System.Collections.Generic;

namespace IWNLP.Models
{
    public class Noun : Word
    {
        public List<Genus> Genus { get; set; }

        public List<Inflection> NominativSingular { get; set; }
        public List<Inflection> NominativPlural { get; set; }
        public List<Inflection> GenitivSingular { get; set; }
        public List<Inflection> GenitivPlural { get; set; }
        public List<Inflection> DativSingular { get; set; }
        public List<Inflection> DativPlural { get; set; }
        public List<Inflection> AkkusativSingular { get; set; }
        public List<Inflection> AkkusativPlural { get; set; }

        public bool Equals(Noun obj)
        {
            return base.Text == obj.Text
                && base.WiktionaryID == obj.WiktionaryID
                && base.POS == obj.POS
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.Genus, obj.Genus)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativSingular, obj.NominativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativPlural, obj.NominativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivSingular, obj.GenitivSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivPlural, obj.GenitivPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativSingular, obj.DativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativPlural, obj.DativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativSingular, obj.AkkusativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativPlural, obj.AkkusativPlural);
        }
    }
}
