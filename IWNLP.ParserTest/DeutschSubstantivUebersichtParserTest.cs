﻿using GenericXMLSerializer;
using IWNLP.Models;
using IWNLP.Models.Nouns;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class DeutschSubstantivUebersichtParserTest
    {

        [TestMethod]
        public void LaunaDeutsch()
        {
            String word = "Launa-Deutsch";
            int wiktionaryID = 478362;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ 
                    new Inflection(){ Article ="das", InflectedWord="Launa-Deutsch"},
                    new Inflection(){ InflectedWord="Launa-Deutsch"},
                    new Inflection(){ Article ="das", InflectedWord="Launa-Deutsche"},
                },
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord="Launa-Deutsch"},
                    new Inflection(){ Article ="des", InflectedWord="Launa-Deutschs"},
                    new Inflection(){ InflectedWord="Launa-Deutsch"},
                    new Inflection(){ InflectedWord="Launa-Deutschs"},
                    new Inflection(){ Article ="des", InflectedWord="Launa-Deutschen"}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="dem", InflectedWord="Launa-Deutsch"},
                    new Inflection(){ InflectedWord="Launa-Deutschen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="das", InflectedWord="Launa-Deutsch"},
                    new Inflection(){ InflectedWord="Launa-Deutsche"}
                },
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void NatalerDeutsch()
        {
            String word = "Nataler Deutsch";
            int wiktionaryID = 73408;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Neutrum,Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="das", InflectedWord="Nataler Deutsch"},
                    new Inflection(){ InflectedWord="Nataler Deutsch"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord="Nataler Deutsch"},
                    new Inflection(){ Article ="des", InflectedWord="Nataler Deutschs"},
                    new Inflection(){ InflectedWord="Nataler Deutsch"},
                    new Inflection(){ InflectedWord="Nataler Deutschs"},
                    new Inflection(){ Article ="des", InflectedWord="Nataler Deutschen"}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="dem", InflectedWord="Nataler Deutsch"},
                    new Inflection(){ InflectedWord="Nataler Deutsch"},
                    new Inflection(){ Article ="dem", InflectedWord="Nataler Deutschen"},
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ 
                    new Inflection(){ Article ="das", InflectedWord="Nataler Deutsch"},
                    new Inflection(){ InflectedWord="Nataler Deutsche"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}