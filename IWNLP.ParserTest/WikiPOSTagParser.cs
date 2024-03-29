﻿using IWNLP.Models;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class WikiPOSTagParser
    {
        [TestMethod]
        public void SubstantivEigenname()
        {
            // Hannibal
            String input = "=== {{Wortart|Substantiv|Deutsch}}, {{m}}, {{Wortart|Eigenname|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Substantiv, WikiPOSTag.Eigenname
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void SubstantivAdjektiveDeklination()
        {
            String input = "=== {{Wortart|Substantiv|Deutsch}}, {{f}}, ''adjektivische Deklination'' ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Substantiv
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void SubstantivToponym()
        {
            String input = "=== {{Wortart|Substantiv|Deutsch}}, {{n}}, {{Wortart|Toponym|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Substantiv, WikiPOSTag.Toponym
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void SubstantivAbkürzung()
        {
            // PKW
            String input = "=== {{Wortart|Substantiv|Deutsch}}, {{m}}, {{Wortart|Abkürzung|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Substantiv, WikiPOSTag.Abkürzung
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void Verb()
        {
            String input = "=== {{Wortart|Verb|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Verb
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void Adjektiv()
        {
            String input = "=== {{Wortart|Adjektiv|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Adjektiv
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void Abkürzung1()
        {
            String input = "=== {{Wortart|Abkürzung|Deutsch}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Abkürzung
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }

        [TestMethod]
        public void Abkürzung2()
        {
            String input = "=== {{Wortart|Abkürzung (Deutsch)}} ===";
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.WikiPOSTag> parsedWikiPOSTags = parser.GetWikiPosTags(input);
            List<Models.WikiPOSTag> expectedWikiPOSTags = new List<Models.WikiPOSTag>() 
            {
                WikiPOSTag.Abkürzung
            };
            CollectionAssert.AreEqual(expectedWikiPOSTags, parsedWikiPOSTags, "failed");
        }


    }
}
