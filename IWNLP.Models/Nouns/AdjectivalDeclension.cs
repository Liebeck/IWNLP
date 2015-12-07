using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models.Nouns
{
    public class AdjectivalDeclension : Word
    {
        public Genus Genus { get; set; }
        public String NominativSingular { get; set; }
        public String NominativPlural { get; set; }
        public String GenitivSingular { get; set; }
        public String GenitivPlural { get; set; }
        public String DativSingular { get; set; }
        public String DativPlural { get; set; }
        public String AkkusativSingular { get; set; }
        public String AkkusativPlural { get; set; }

        public Inflection NominativSingularSchwach { get; set; }
        public Inflection NominativPluralSchwach { get; set; }
        public Inflection GenitivSingularSchwach { get; set; }
        public Inflection GenitivPluralSchwach { get; set; }
        public Inflection DativSingularSchwach { get; set; }
        public Inflection DativPluralSchwach { get; set; }
        public Inflection AkkusativSingularSchwach { get; set; }
        public Inflection AkkusativPluralSchwach { get; set; }
    }
}
