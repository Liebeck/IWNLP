using System;
using System.Collections.Generic;

namespace IWNLP.Models.Nouns
{
    public class AdjectivalDeclension : Word
    {
        public List<string> NominativSingular { get; set; }
        public List<string> NominativPlural { get; set; }
        public List<string> GenitivSingular { get; set; }
        public List<string> GenitivPlural { get; set; }
        public List<string> DativSingular { get; set; }
        public List<string> DativPlural { get; set; }
        public List<string> AkkusativSingular { get; set; }
        public List<string> AkkusativPlural { get; set; }

        public List<string> NominativSingularSchwach { get; set; }
        public List<string> NominativPluralSchwach { get; set; }
        public List<string> GenitivSingularSchwach { get; set; }
        public List<string> GenitivPluralSchwach { get; set; }
        public List<string> DativSingularSchwach { get; set; }
        public List<string> DativPluralSchwach { get; set; }
        public List<string> AkkusativSingularSchwach { get; set; }
        public List<string> AkkusativPluralSchwach { get; set; }

        public List<string> NominativSingularGemischt { get; set; }
        public List<string> NominativPluralGemischt { get; set; }
        public List<string> GenitivSingularGemischt { get; set; }
        public List<string> GenitivPluralGemischt { get; set; }
        public List<string> DativSingularGemischt { get; set; }
        public List<string> DativPluralGemischt { get; set; }
        public List<string> AkkusativSingularGemischt { get; set; }
        public List<string> AkkusativPluralGemischt { get; set; }

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
