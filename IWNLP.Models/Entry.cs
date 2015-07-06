using IWNLP.Models.Flections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IWNLP.Models
{
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(AdjectiveDeclination))]
    [XmlInclude(typeof(VerbConjugation))]
    public class Entry
    {
        public String Text { get; set; }
        public int WiktionaryID { get; set; }
        
        [XmlIgnore]
        public bool ParserError { get; set; }

        public override bool Equals(object obj)
        {
            if (this is Noun)
            {
                return ((Noun)this).Equals((Noun)obj);
            }
            else if (this is Adjective)
            {
                return ((Adjective)this).Equals((Adjective)obj);
            }
            else if (this is Verb) 
            {
                return ((Verb)this).Equals((Verb)obj);
            }
            else if (this is AdjectiveDeclination)
            {
                return ((AdjectiveDeclination)this).Equals((AdjectiveDeclination)obj);
            }
            else if (this is VerbConjugation)
            {
                return ((VerbConjugation)this).Equals((VerbConjugation)obj);
            }
            else if (this is Pronoun)
            {
                return ((Pronoun)this).Equals((Pronoun)obj);
            }
            return base.Equals(obj);
        }
    }
}
