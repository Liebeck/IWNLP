﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IWNLP.Models
{
    [XmlInclude(typeof(Noun))]
    [XmlInclude(typeof(Adjective))]
    [XmlInclude(typeof(Verb))]
    [XmlInclude(typeof(Pronoun))]
    public class Word : Entry
    {
        public List<WikiPOSTag> WikiPOSTags { get; set; }
        public POS POS { get; set; }
    }
}
