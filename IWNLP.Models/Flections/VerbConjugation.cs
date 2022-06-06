using System;
using System.Collections.Generic;

namespace IWNLP.Models.Flections
{
    public class VerbConjugation:Entry
    {
        public string PartizipII { get; set; }
        public string PartizipIIAlternativ { get; set; }
        public string PartizipIIVeraltet { get; set; }

        public List<string> PräsensAktivIndikativ_Singular1Person { get; set; }
        public List<string> PräsensAktivIndikativ_Singular2Person { get; set; }
        public List<string> PräsensAktivIndikativ_Singular3Person { get; set; }
        public List<string> PräsensAktivIndikativ_Plural1Person { get; set; }
        public List<string> PräsensAktivIndikativ_Plural2Person { get; set; }
        public List<string> PräsensAktivIndikativ_Plural3Person { get; set; }

        public List<string> PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation { get; set; }

        public List<string> PräteritumAktivIndikativ_Singular1Person { get; set; }
        public List<string> PräteritumAktivIndikativ_Singular2Person { get; set; }
        public List<string> PräteritumAktivIndikativ_Singular3Person { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural1Person { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural2Person { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural3Person { get; set; }

        public List<string> PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation { get; set; }

        public List<string> PräsensAktivKonjunktiv_Singular1Person { get; set; }
        public List<string> PräsensAktivKonjunktiv_Singular2Person { get; set; }
        public List<string> PräsensAktivKonjunktiv_Singular3Person { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural1Person { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural2Person { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural3Person { get; set; }

        public List<string> PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation { get; set; }

        public List<string> PräteritumAktivKonjunktiv_Singular1Person { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Singular2Person { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Singular3Person { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural1Person { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural2Person { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural3Person { get; set; }

        public List<string> PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation { get; set; }
        public List<string> PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation { get; set; }

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
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivIndikativ_Plural3Person, obj.PräteritumAktivIndikativ_Plural3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular1Person, obj.PräsensAktivKonjunktiv_Singular1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular2Person, obj.PräsensAktivKonjunktiv_Singular2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular3Person, obj.PräsensAktivKonjunktiv_Singular3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural1Person, obj.PräsensAktivKonjunktiv_Plural1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural2Person, obj.PräsensAktivKonjunktiv_Plural2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural3Person, obj.PräsensAktivKonjunktiv_Plural3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation, obj.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation, obj.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular1Person, obj.PräteritumAktivKonjunktiv_Singular1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular2Person, obj.PräteritumAktivKonjunktiv_Singular2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Singular3Person, obj.PräteritumAktivKonjunktiv_Singular3Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural1Person, obj.PräteritumAktivKonjunktiv_Plural1Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural2Person, obj.PräteritumAktivKonjunktiv_Plural2Person)
                && EnumerableUnorderedEqual.IsUnorderedEnumerableEqual(this.PräteritumAktivKonjunktiv_Plural3Person, obj.PräteritumAktivKonjunktiv_Plural3Person);
        }
    }
}
