using IWNLP.Models.Nouns;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IWNLP.Models
{
    [XmlInclude(typeof(Noun))]
    [XmlInclude(typeof(Adjective))]
    [XmlInclude(typeof(Verb))]
    [XmlInclude(typeof(Pronoun))]
    [XmlInclude(typeof(AdjectivalDeclension))]
    public class Word : Entry
    {
        public List<WikiPOSTag> WikiPOSTags { get; set; }
        public POS POS { get; set; }
    }
}
