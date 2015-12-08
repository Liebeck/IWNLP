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

        public List<Inflection> NominativSingularSchwach { get; set; }
        public List<Inflection> NominativPluralSchwach { get; set; }
        public List<Inflection> GenitivSingularSchwach { get; set; }
        public List<Inflection> GenitivPluralSchwach { get; set; }
        public List<Inflection> DativSingularSchwach { get; set; }
        public List<Inflection> DativPluralSchwach { get; set; }
        public List<Inflection> AkkusativSingularSchwach { get; set; }
        public List<Inflection> AkkusativPluralSchwach { get; set; }
    }
}
