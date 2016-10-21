using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models.Nouns
{
    public class AdjectivalDeclension : Word
    {
        public List<String> NominativSingular { get; set; }
        public List<String> NominativPlural { get; set; }
        public List<String> GenitivSingular { get; set; }
        public List<String> GenitivPlural { get; set; }
        public List<String> DativSingular { get; set; }
        public List<String> DativPlural { get; set; }
        public List<String> AkkusativSingular { get; set; }
        public List<String> AkkusativPlural { get; set; }

        public List<String> NominativSingularSchwach { get; set; }
        public List<String> NominativPluralSchwach { get; set; }
        public List<String> GenitivSingularSchwach { get; set; }
        public List<String> GenitivPluralSchwach { get; set; }
        public List<String> DativSingularSchwach { get; set; }
        public List<String> DativPluralSchwach { get; set; }
        public List<String> AkkusativSingularSchwach { get; set; }
        public List<String> AkkusativPluralSchwach { get; set; }

        public List<String> NominativSingularGemischt { get; set; }
        public List<String> NominativPluralGemischt { get; set; }
        public List<String> GenitivSingularGemischt { get; set; }
        public List<String> GenitivPluralGemischt { get; set; }
        public List<String> DativSingularGemischt { get; set; }
        public List<String> DativPluralGemischt { get; set; }
        public List<String> AkkusativSingularGemischt { get; set; }
        public List<String> AkkusativPluralGemischt { get; set; }

        public AdjectivalDeclension() 
        {
            this.POS = Models.POS.Noun;
        }

        public bool Equals(AdjectivalDeclension obj)
        {
            return base.Text == obj.Text
                && base.WiktionaryID == obj.WiktionaryID
                && base.POS == obj.POS
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativSingular, obj.NominativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativPlural, obj.NominativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivSingular, obj.GenitivSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivPlural, obj.GenitivPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativSingular, obj.DativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativPlural, obj.DativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativSingular, obj.AkkusativSingular)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativPlural, obj.AkkusativPlural)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativSingularSchwach, obj.NominativSingularSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativPluralSchwach, obj.NominativPluralSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivSingularSchwach, obj.GenitivSingularSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivPluralSchwach, obj.GenitivPluralSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativSingularSchwach, obj.DativSingularSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativPluralSchwach, obj.DativPluralSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativSingularSchwach, obj.AkkusativSingularSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativPluralSchwach, obj.AkkusativPluralSchwach)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativSingularGemischt, obj.NominativSingularGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.NominativPluralGemischt, obj.NominativPluralGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivSingularGemischt, obj.GenitivSingularGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.GenitivPluralGemischt, obj.GenitivPluralGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativSingularGemischt, obj.DativSingularGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.DativPluralGemischt, obj.DativPluralGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativSingularGemischt, obj.AkkusativSingularGemischt)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.AkkusativPluralGemischt, obj.AkkusativPluralGemischt);
        }

    }
}
