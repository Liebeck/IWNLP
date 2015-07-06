using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models.Flections
{
    public class VerbConjugation:Entry
    {
        public String PartizipII { get; set; }
        public String PartizipIIAlternativ { get; set; }
        public String PartizipIIVeraltet { get; set; }

        public List<String> PräsensAktivIndikativ_Singular1Person { get; set; }
        public List<String> PräsensAktivIndikativ_Singular2Person { get; set; }
        public List<String> PräsensAktivIndikativ_Singular3Person { get; set; }
        public List<String> PräsensAktivIndikativ_Plural1Person { get; set; }
        public List<String> PräsensAktivIndikativ_Plural2Person { get; set; }
        public List<String> PräsensAktivIndikativ_Plural3Person { get; set; }

        public List<String> PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<String> PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<String> PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<String> PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<String> PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<String> PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation { get; set; }

        public List<String> PräteritumAktivIndikativ_Singular1Person { get; set; }
        public List<String> PräteritumAktivIndikativ_Singular2Person { get; set; }
        public List<String> PräteritumAktivIndikativ_Singular3Person { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural1Person { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural2Person { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural3Person { get; set; }

        public List<String> PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<String> PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<String> PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<String> PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation { get; set; }

        public bool Equals(VerbConjugation obj) 
        {
            return this.PartizipII == obj.PartizipII
                && this.PartizipIIAlternativ == obj.PartizipIIAlternativ
                && this.PartizipIIVeraltet == obj.PartizipIIVeraltet
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular1Person, obj.PräsensAktivIndikativ_Singular1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular2Person, obj.PräsensAktivIndikativ_Singular2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular3Person, obj.PräsensAktivIndikativ_Singular3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural1Person, obj.PräsensAktivIndikativ_Plural1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural2Person, obj.PräsensAktivIndikativ_Plural2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural3Person, obj.PräsensAktivIndikativ_Plural3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation, obj.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation, obj.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular1Person, obj.PräteritumAktivIndikativ_Singular1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular2Person, obj.PräteritumAktivIndikativ_Singular2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Singular3Person, obj.PräteritumAktivIndikativ_Singular3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural1Person, obj.PräteritumAktivIndikativ_Plural1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural2Person, obj.PräteritumAktivIndikativ_Plural2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural3Person, obj.PräteritumAktivIndikativ_Plural3Person);
        }
    }
}
