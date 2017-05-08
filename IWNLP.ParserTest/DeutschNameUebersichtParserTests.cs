using GenericXMLSerializer;
using IWNLP.Models;
using IWNLP.Models.Nouns;
using IWNLP.Parser;
using IWNLP.Parser.POSParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class DeutschNameUebersichtParserTests
    {
        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_TwoLines()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Maria vom Siege";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht",
                "|Genus=f",
                "|kein-s=1",
                "|Bild 1=Bermatingen Pfarrkirche Maria vom Siege 2.jpg|160px|2|“Maria vom Siege“ in der Pfarrkirche von Bermatingen",
                "|Bild 2=NtraSradelasVictorias0001.JPG|160px|2|“Maria vom Siege“ bei einer Prozession in Lima, Peru",
                "}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(2, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_OneLineTwoParameters()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Hindi";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht|Genus=n}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(1, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_OneLine()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Hindi";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht",
                "|Genus=m",
                "}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(1, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void Nord()
        {
            String word = "Nord";
            int wiktionaryID = 21287;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){Article ="der", InflectedWord="Nord"},
                    new Inflection(){InflectedWord="Nord"}
                },
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord="Nord"},
                    new Inflection(){InflectedWord="Nords"}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){Article ="dem", InflectedWord="Nord"},
                    new Inflection(){InflectedWord="Nord"}
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){Article ="den", InflectedWord="Nord"},
                    new Inflection(){InflectedWord="Nord"}
                },
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Afrikaans()
        {
            String word = "Afrikaans";
            int wiktionaryID = 2134;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Afrikaans",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){Article="das", InflectedWord="Afrikaans"},
                    new Inflection(){InflectedWord="Afrikaans"},
                },
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){Article="des", InflectedWord="Afrikaans"},
                    new Inflection(){Article="des", InflectedWord="Afrikaans’"},
                    new Inflection(){InflectedWord="Afrikaans’"}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){Article="dem", InflectedWord="Afrikaans"},
                    new Inflection(){InflectedWord="Afrikaans"},
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){Article="das", InflectedWord="Afrikaans"},
                    new Inflection(){InflectedWord="Afrikaans"}, 
                },
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void MariaVomSiege()
        {
            String word = "Maria vom Siege";
            int wiktionaryID = 164603;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){Article="die", InflectedWord="Maria vom Siege"},
                    new Inflection(){InflectedWord="Maria vom Siege"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){Article="der", InflectedWord="Maria vom Siege"}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){Article="der", InflectedWord="Maria vom Siege"},
                    new Inflection(){InflectedWord="Maria vom Siege"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){Article="die", InflectedWord="Maria vom Siege"},
                    new Inflection(){InflectedWord="Maria vom Siege"}},
                AkkusativPlural = new List<Inflection>()
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Gott()
        {
            String word = "Gott";
            int wiktionaryID = 5189;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){Article="der", InflectedWord="Gott"},
                    new Inflection(){InflectedWord="Gott"}},
                NominativPlural = new List<Inflection>()
                {
                    new Inflection(){ Article="die", InflectedWord="Götter"}
                },
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){Article="des", InflectedWord="Gott"},
                    new Inflection(){ InflectedWord="Gotts"},
                    new Inflection(){ InflectedWord="Gottes"}
                },
                GenitivPlural = new List<Inflection>()
                {
                    new Inflection(){ Article="der", InflectedWord="Götter"}
                },
                DativSingular = new List<Inflection>(){
                    new Inflection(){Article="dem", InflectedWord="Gott"},
                    new Inflection(){InflectedWord="Gott"},
                    new Inflection(){InflectedWord="Gotte"}},
                DativPlural = new List<Inflection>()
                {
                    new Inflection(){ Article="den", InflectedWord="Göttern"}
                },
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){Article="den", InflectedWord="Gott"},
                    new Inflection(){InflectedWord="Gott"}},
                AkkusativPlural = new List<Inflection>()
                {
                    new Inflection(){ Article="die", InflectedWord="Götter"}
                },
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Manx()
        {
            String word = "Manx";
            int wiktionaryID = 32045;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){
                    new Inflection(){Article="das", InflectedWord="Manx"},
                    new Inflection(){InflectedWord="Manx"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){Article="des", InflectedWord="Manx"},
                    new Inflection(){Article="des", InflectedWord="Manxs"},
                    new Inflection(){InflectedWord="Manxs"},
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){Article="dem", InflectedWord="Manx"},
                    new Inflection(){InflectedWord="Manx"}
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){Article="das", InflectedWord="Manx"},
                    new Inflection(){InflectedWord="Manx"}
                },
                AkkusativPlural = new List<Inflection>(),
             },
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
                NominativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
                GenitivSingular = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                DativSingular = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                DativPlural = new List<Inflection>(){new Inflection(){Article="den", InflectedWord="Manx"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
             },
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                NominativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
                GenitivSingular = new List<Inflection>(){new Inflection(){Article="des", InflectedWord="Manx"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                DativSingular = new List<Inflection>(){new Inflection(){Article="dem", InflectedWord="Manx"}},
                DativPlural = new List<Inflection>(){new Inflection(){Article="den", InflectedWord="Manx"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){Article="den", InflectedWord="Manx"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
             },
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(),
                NominativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
                GenitivSingular = new List<Inflection>(),
                GenitivPlural = new List<Inflection>(){new Inflection(){Article="der", InflectedWord="Manx"}},
                DativSingular = new List<Inflection>(),
                DativPlural = new List<Inflection>(){new Inflection(){Article="den", InflectedWord="Manx"}},
                AkkusativSingular = new List<Inflection>(),
                AkkusativPlural = new List<Inflection>(){new Inflection(){Article="die", InflectedWord="Manx"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}
