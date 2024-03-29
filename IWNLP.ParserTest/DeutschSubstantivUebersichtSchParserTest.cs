﻿using IWNLP.Models;
using IWNLP.Models.Nouns;
using IWNLP.Parser;
using IWNLP.Parser.POSParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class DeutschSubstantivUebersichtParserTest
    {

        [TestMethod]
        public void DeutschSubstantivUebersichtParser_Parameter_OneLine()
        {
            DeutschSubstantivUebersichtSchParser parser = new DeutschSubstantivUebersichtSchParser();
            string[] lines = new string[]
            {
                "{{Deutsch Substantiv Übersicht -sch}}"
            };
            List<string> cleanedTemplateBlock = parser.GetCleanedTemplateBlock("Launa-Deutsch", lines);
            Assert.AreEqual(0, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschSubstantivUebersichtParser_Parameter_TwoLinesLines()
        {
            DeutschSubstantivUebersichtSchParser parser = new DeutschSubstantivUebersichtSchParser();
            string[] lines = new string[]
            {
                "{{Deutsch Substantiv Übersicht -sch",
                "}}"
            };
            List<string> cleanedTemplateBlock = parser.GetCleanedTemplateBlock("Albanisch", lines);
            Assert.AreEqual(0, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschSubstantivUebersichtParser_Parameter_TwoLinesLinesWithImage()
        {
            DeutschSubstantivUebersichtSchParser parser = new DeutschSubstantivUebersichtSchParser();
            string[] lines = new string[]
            {
                "{{Deutsch Substantiv Übersicht -sch",
                "|Bild=New-Map-Francophone_World.PNG|mini|1|Länder mit ''Französisch'' als Muttersprache (blau), Verwaltungssprache (blau), Verkehrssprache (hellblau), Minderheitensprache (grün)",
                "}}"
            };
            List<string> cleanedTemplateBlock = parser.GetCleanedTemplateBlock("Französisch", lines);
            Assert.AreEqual(0, cleanedTemplateBlock.Count);
        }


        [TestMethod]
        public void LaunaDeutsch()
        {
            string word = "Launa-Deutsch";
            int wiktionaryID = 478362;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    new Inflection(){ InflectedWord="Launa-Deutsch"},
                    new Inflection(){ Article ="dem", InflectedWord="Launa-Deutschen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="das", InflectedWord="Launa-Deutsch"},
                    new Inflection(){ InflectedWord="Launa-Deutsch"},
                    new Inflection(){ Article ="das", InflectedWord="Launa-Deutsche"}
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
            string word = "Nataler Deutsch";
            int wiktionaryID = 73408;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    new Inflection(){ Article ="das", InflectedWord="Nataler Deutsch"},
                    new Inflection(){ InflectedWord="Nataler Deutsch"},
                    new Inflection(){ Article ="das", InflectedWord="Nataler Deutsche"},
                },
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
                    new Inflection(){ InflectedWord="Nataler Deutsch"},
                    new Inflection(){ Article ="das", InflectedWord="Nataler Deutsche"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Niederländisch()
        {
            string word = "Niederländisch";
            int wiktionaryID = 1047;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Niederländisch",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Niederländisch"},
                    new Inflection(){ InflectedWord="Niederländisch"},
                    new Inflection(){ Article="das", InflectedWord="Niederländische"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article="des", InflectedWord="Niederländisch"},
                    new Inflection(){ InflectedWord="Niederländisch"},
                    new Inflection(){ Article="des", InflectedWord="Niederländischs"},
                    new Inflection(){ InflectedWord="Niederländischs"},
                    new Inflection(){ Article="des", InflectedWord="Niederländischen"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article="dem", InflectedWord="Niederländisch"},
                    new Inflection(){ InflectedWord="Niederländisch"},
                    new Inflection(){ Article="dem", InflectedWord="Niederländischen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Niederländisch"},
                    new Inflection(){ InflectedWord="Niederländisch"},
                    new Inflection(){ Article="das", InflectedWord="Niederländische"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void UlsterIrisch()
        {
            string word = "Ulster-Irisch";
            int wiktionaryID = 122925;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Ulster-Irisch",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Ulster-Irisch"},
                    new Inflection(){ InflectedWord="Ulster-Irisch"},
                    new Inflection(){ Article="das", InflectedWord="Ulster-Irische"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article="des", InflectedWord="Ulster-Irisch"},
                    new Inflection(){ InflectedWord="Ulster-Irisch"},
                    new Inflection(){ Article="des", InflectedWord="Ulster-Irischs"},
                    new Inflection(){ InflectedWord="Ulster-Irischs"},
                    new Inflection(){ Article="des", InflectedWord="Ulster-Irischen"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article="dem", InflectedWord="Ulster-Irisch"},
                    new Inflection(){ InflectedWord="Ulster-Irisch"},
                    new Inflection(){ Article="dem", InflectedWord="Ulster-Irischen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Ulster-Irisch"},
                    new Inflection(){ InflectedWord="Ulster-Irisch"},
                    new Inflection(){ Article="das", InflectedWord="Ulster-Irische"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Hessisch()
        {
            string word = "Hessisch";
            int wiktionaryID = 74231;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Hessisch",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Hessisch"},
                    new Inflection(){ InflectedWord="Hessisch"},
                    new Inflection(){ Article="das", InflectedWord="Hessische"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article="des", InflectedWord="Hessisch"},
                    new Inflection(){ InflectedWord="Hessisch"},
                    new Inflection(){ Article="des", InflectedWord="Hessischs"},
                    new Inflection(){ InflectedWord="Hessischs"},
                    new Inflection(){ Article="des", InflectedWord="Hessischen"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article="dem", InflectedWord="Hessisch"},
                    new Inflection(){ InflectedWord="Hessisch"},
                    new Inflection(){ Article="dem", InflectedWord="Hessischen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article="das", InflectedWord="Hessisch"},
                    new Inflection(){ InflectedWord="Hessisch"},
                    new Inflection(){ Article="das", InflectedWord="Hessische"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}
