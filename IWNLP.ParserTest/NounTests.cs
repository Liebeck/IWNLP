using IWNLP.Models;
using IWNLP.Models.Nouns;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class NounTests
    {
        [TestMethod]
        public void Haus()
        {
            string word = "Haus";
            int wiktionaryID = 1119;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Haus",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Haus"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Häuser"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Hauses"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Häuser"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Haus"}, new Inflection(){Article="dem", InflectedWord="Hause"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Häusern"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Haus"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Häuser"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Güterzug()
        {
            string word = "Güterzug";
            int wiktionaryID = 151293;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Güterzug",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Güterzug"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Güterzüge"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Güterzugs"}, new Inflection(){Article="des", InflectedWord="Güterzuges"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Güterzüge"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Güterzug"},new Inflection(){ Article ="dem", InflectedWord="Güterzuge"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Güterzügen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Güterzug"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Güterzüge"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Joghurt()
        {
            string word = "Joghurt";
            int wiktionaryID = 23051;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Joghurt",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum, Genus.Femininum, Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Joghurt"},new Inflection(){ Article ="das", InflectedWord="Joghurt"}, new Inflection(){ Article ="die", InflectedWord="Joghurt"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Joghurts"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Joghurts"}, new Inflection(){Article="des", InflectedWord="Joghurts"},new Inflection(){ Article ="der", InflectedWord="Joghurt"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Joghurts"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Joghurt"},new Inflection(){ Article ="dem", InflectedWord="Joghurt"},new Inflection(){ Article ="der", InflectedWord="Joghurt"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Joghurts"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Joghurt"},new Inflection(){ Article ="das", InflectedWord="Joghurt"}, new Inflection(){ Article ="die", InflectedWord="Joghurt"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Joghurts"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void April()
        {
            string word = "April";
            int wiktionaryID = 720;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="April",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="April"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Aprile"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="April"}, new Inflection(){Article="des", InflectedWord="Aprils"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Aprile"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="April"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Aprilen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="April"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Aprile"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Fremde()
        {
            string word = "Fremde";
            int wiktionaryID = 150532;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Fremde"},
                    GenitivSingular=new List<string>(){"Fremder"},
                    DativSingular=new List<string>(){"Fremder"},
                    AkkusativSingular=new List<string>(){"Fremde"},
                    NominativPlural=new List<string>(){"Fremde"},
                    GenitivPlural=new List<string>(){"Fremder"},
                    DativPlural=new List<string>(){"Fremden"},
                    AkkusativPlural=new List<string>(){"Fremde"},
                    NominativSingularSchwach=new List<string>(){"Fremde"},
                    GenitivSingularSchwach=new List<string>(){"Fremden"},
                    DativSingularSchwach=new List<string>(){"Fremden"},
                    AkkusativSingularSchwach=new List<string>(){"Fremde"},
                    NominativPluralSchwach=new List<string>(){"Fremden"},
                    GenitivPluralSchwach=new List<string>(){"Fremden"},
                    DativPluralSchwach=new List<string>(){"Fremden"},
                    AkkusativPluralSchwach=new List<string>(){"Fremden"},
                    NominativSingularGemischt=new List<string>(){"Fremde"},
                    GenitivSingularGemischt=new List<string>(){"Fremden"},
                    DativSingularGemischt=new List<string>(){"Fremden"},
                    AkkusativSingularGemischt=new List<string>(){"Fremde"},
                    NominativPluralGemischt=new List<string>(){"Fremden"},
                    GenitivPluralGemischt=new List<string>(){"Fremden"},
                    DativPluralGemischt=new List<string>(){"Fremden"},
                    AkkusativPluralGemischt=new List<string>(){"Fremden"},
                },
                new Models.Noun()
                {
                    Text=word,
                    POS = POS.Noun,
                    Genus = new List<Genus>(){Genus.Femininum},
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Fremde"}},
                    NominativPlural = new List<Inflection>(),
                    GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Fremde"}},
                    GenitivPlural = new List<Inflection>(),
                    DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Fremde"}},
                    DativPlural = new List<Inflection>(),
                    AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Fremde"}},
                    AkkusativPlural = new List<Inflection>(),
                },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Hannibal() // Eigenname
        {

            string word = "Hannibal";
            int wiktionaryID = 454497;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Codex()
        {
            string word = "Codex";
            int wiktionaryID = 33616;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Codex",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Codex"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Codices"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Codex"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article ="der", InflectedWord="Codices"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Codex"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article ="den", InflectedWord="Codices"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Codex"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Codices"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Index()
        {
            string word = "Index";
            int wiktionaryID = 5086;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Index",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Index"},new Inflection(){ Article ="der", InflectedWord="Index"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Indizes"},new Inflection(){ Article ="die", InflectedWord="Indices"},new Inflection(){ Article ="die", InflectedWord="Indexe"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Index"},new Inflection(){ Article ="des", InflectedWord="Indexes"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article ="der", InflectedWord="Indizes"}, new Inflection(){ Article ="der", InflectedWord="Indices"},new Inflection(){ Article ="der", InflectedWord="Indexe"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Index"},new Inflection(){ Article ="dem", InflectedWord="Index"},new Inflection(){ Article ="dem", InflectedWord="Indexe"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article ="den", InflectedWord="Indizes"},new Inflection(){ Article ="den", InflectedWord="Indices"},new Inflection(){ Article ="den", InflectedWord="Indexen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Index"},new Inflection(){ Article ="den", InflectedWord="Index"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Indizes"},new Inflection(){ Article ="die", InflectedWord="Indices"},new Inflection(){ Article ="die", InflectedWord="Indexe"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Masse()
        {
            string word = "Masse";
            int wiktionaryID = 17171;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Masse",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Masse"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Massen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Masse"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article ="der", InflectedWord="Massen"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Masse"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article ="den", InflectedWord="Massen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Masse"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Massen"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Strasse()
        {
            // Schweizer und Liechtensteiner Schreibweise
            string word = "Strasse";
            int wiktionaryID = 18409;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Schoss()
        {
            // 2 entries, one is "{{Schweizer und Liechtensteiner Schreibweise"
            string word = "Schoss";
            int wiktionaryID = 37410;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Schoss",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Schoss"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Schosse"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Schosses"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article ="der", InflectedWord="Schosse"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Schoss"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article ="den", InflectedWord="Schossen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Schoss"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Schosse"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Thor()
        {
            // 2 entries: alte Schreibweise und Eigenname
            string word = "Thor";
            int wiktionaryID = 18441;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Ablaß()
        {
            // 2 entries: Toponym und Nachname
            string word = "Ablaß";
            int wiktionaryID = 20198;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Citronensäure()
        {
            // contains "*Alternative Schreibweise von"
            string word = "Citronensäure";
            int wiktionaryID = 82973;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Citronensäure",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Citronensäure"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Citronensäure"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Citronensäure"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Citronensäure"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Ampelograph()
        {
            // contains "*Alternative Schreibweise von"
            string word = "Ampelograph";
            int wiktionaryID = 263917;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Ampelograph",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Ampelograph"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Ampelographen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Ampelographen"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Ampelographen"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Ampelographen"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Ampelographen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Ampelographen"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Ampelographen"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Zeitprozentverfahren()
        {
            // no definition, only "*Alternative Schreibweise zu"
            string word = "Zeitprozentverfahren";
            int wiktionaryID = 4930;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
                new Models.Noun()
                {
                    Text="Zeitprozentverfahren",
                    POS = POS.Noun,
                    Genus = new List<Genus>(){Genus.Neutrum},
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Zeitprozentverfahren"}},
                    NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zeitprozentverfahren"}},
                    GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Zeitprozentverfahrens"}},
                    GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Zeitprozentverfahren"}},
                    DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Zeitprozentverfahren"}},
                    DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Zeitprozentverfahren"}},
                    AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Zeitprozentverfahren"}},
                    AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zeitprozentverfahren"}},
                },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tolpatsch()
        {
            // no definition, only "{{Alte Schreibweise"
            string word = "Tolpatsch";
            int wiktionaryID = 5679;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Komputer()
        {
            // no definition, only "{{Alte Schreibweise"
            string word = "Komputer";
            int wiktionaryID = 9414;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Propentricarbonsäure()
        {
            string word = "1,2,3-Propentricarbonsäure";
            int wiktionaryID = 44684;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="1,2,3-Propentricarbonsäure",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="1,2,3-Propentricarbonsäure"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="1,2,3-Propentricarbonsäure"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="1,2,3-Propentricarbonsäure"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="1,2,3-Propentricarbonsäure"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        [Ignore]
        public void Konstante()
        {
            string word = "Konstante";
            int wiktionaryID = 92957;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Konstante",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Konstante"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Konstanten"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Konstante"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Konstanten"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Konstante"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Konstanten"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Konstante"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Konstanten"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Miami()
        {
            string word = "Miami";
            int wiktionaryID = 300285;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Interessenvertretung()
        {
            string word = "Interessenvertretung";
            int wiktionaryID = 269932;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Interessenvertretung",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Interessenvertretung"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Interessenvertretungen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Interessenvertretung"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Interessenvertretungen"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Interessenvertretung"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Interessenvertretungen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Interessenvertretung"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Interessenvertretungen"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Vertretung()
        {
            string word = "Vertretung";
            int wiktionaryID = 246253;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Vertretung",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Vertretung"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Vertretungen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Vertretung"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Vertretungen"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Vertretung"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Vertretungen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Vertretung"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Vertretungen"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Mutter()
        {
            string word = "Mutter";
            int wiktionaryID = 1053;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Mutter",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mutter"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mütter"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Mutter"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Mütter"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Mutter"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Müttern"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Mutter"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mütter"}},
             },
             new Models.Noun()
             {
                Text="Mutter",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mutter"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Muttern"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Mutter"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Muttern"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Mutter"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Muttern"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Mutter"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Muttern"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Mai()
        {
            string word = "Mai";
            int wiktionaryID = 721;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Mai",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Mai"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Maie"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Mai"},new Inflection(){ Article="des", InflectedWord="Mais"}, new Inflection(){ Article="des", InflectedWord="Maien"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Maie"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Mai"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Maien"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Mai"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Maie"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Juni()
        {
            string word = "Juni";
            int wiktionaryID = 722;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Juni",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Juni"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Junis"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Juni"},new Inflection(){ Article="des", InflectedWord="Junis"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Junis"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Juni"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Junis"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Juni"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Junis"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Art()
        {
            string word = "Art";
            int wiktionaryID = 2853;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Art",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Art"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Arten"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Art"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Arten"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Art"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Arten"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Art"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Arten"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void August()
        {
            string word = "August";
            int wiktionaryID = 724;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="August",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="August"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Auguste"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Augusts"}, new Inflection(){ Article="des", InflectedWord="Augustes"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Auguste"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="August"}, new Inflection(){ Article="dem", InflectedWord="Auguste"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Augusten"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="August"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Auguste"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }





        [TestMethod]
        public void Gelb()
        {
            string word = "Gelb";
            int wiktionaryID = 938;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Gelb",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Gelb"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelbs"},
                                                         new Inflection(){ Article="die", InflectedWord="Gelb"}},
                GenitivSingular = new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Gelbs"},
                                                         new Inflection(){ Article="des", InflectedWord="Gelb"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Gelbs"},
                                                       new Inflection(){ Article="der", InflectedWord="Gelb"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Gelb"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Gelbs"},
                                                     new Inflection(){ Article="den", InflectedWord="Gelb"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Gelb"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelbs"},
                                                         new Inflection(){ Article="die", InflectedWord="Gelb"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tag()
        {
            // Mit Hinweis auf Bedeutungen in [1,2]
            string word = "Tag";
            int wiktionaryID = 2110;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Tag",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tag"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tage"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tags"},new Inflection(){ Article="des", InflectedWord="Tages"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tage"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tag"},new Inflection(){ Article="dem", InflectedWord="Tage"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tagen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Tag"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tage"}},
             },
             new Models.Noun()
             {
                Text="Tag",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Tag"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tags"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tags"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tag"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tags"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Tag"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
             },
             new Models.Noun()
             {
                 Text="Tag",
                 POS = POS.Noun,
                 Genus = new List<Genus>(){Genus.Maskulinum},
                 WiktionaryID = wiktionaryID,
                 NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tag"}},
                 NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
                 GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tags"}},
                 GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tags"}},
                 DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tag"}},
                 DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tags"}},
                 AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Tag"}},
                 AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tun()
        {
            string word = "Tun";
            int wiktionaryID = 33169;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Tun",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Tun"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tuns"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tun"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Tun"}},
                AkkusativPlural = new List<Inflection>(),
             },
             new Models.Noun()
             {
                 Text="Tun",
                 POS = POS.Noun,
                 Genus = new List<Genus>(){Genus.Maskulinum},
                 WiktionaryID = wiktionaryID,
                 NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tun"}},
                 NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tune"}},
                 GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tuns"},new Inflection(){ Article="des", InflectedWord="Tunes"}},
                 GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tune"}},
                 DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tun"},new Inflection(){ Article="dem", InflectedWord="Tune"}},
                 DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tunen"}},
                 AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Tun"}},
                 AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tune"}},
             }
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tier()
        {
            string word = "Tier";
            int wiktionaryID = 3622;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Tier",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Tier"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tiere"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tiers"},new Inflection(){ Article="des", InflectedWord="Tieres"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tiere"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tier"},new Inflection(){ Article="dem", InflectedWord="Tiere"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tieren"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Tier"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tiere"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Pkw()
        {
            string word = "Pkw";
            int wiktionaryID = 2271;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Pkw",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Pkw"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Pkw"},new Inflection(){ Article="die", InflectedWord="Pkws"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Pkw"},new Inflection(){ Article="des", InflectedWord="Pkws"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Pkw"},new Inflection(){ Article="der", InflectedWord="Pkws"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Pkw"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Pkw"},new Inflection(){ Article="den", InflectedWord="Pkws"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Pkw"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Pkw"},new Inflection(){ Article="die", InflectedWord="Pkws"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Biak()
        {
            string word = "Biak";
            int wiktionaryID = 56588;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Deichgraf()
        {
            string word = "Deichgraf";
            int wiktionaryID = 121425;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Deichgraf",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Deichgraf"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Deichgrafen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Deichgrafen"},new Inflection(){ Article="des", InflectedWord="Deichgrafs"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Deichgrafen"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Deichgrafen"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Deichgrafen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Deichgrafen"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Deichgrafen"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Daguerreotyp()
        {
            // contains ''veraltet:'' Tag in Multiline <ref> Tag
            string word = "Daguerreotyp";
            int wiktionaryID = 319160;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Daguerreotyp",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Daguerreotyp"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Daguerreotype"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Daguerreotyps"},new Inflection(){ Article="des", InflectedWord="Daguerreotypes"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Daguerreotype"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Daguerreotyp"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Daguerreotypen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Daguerreotyp"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Daguerreotype"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Qualitätsschaumwein()
        {
            string word = "Qualitätsschaumwein";
            int wiktionaryID = 446941;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Qualitätsschaumwein",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Qualitätsschaumwein"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Qualitätsschaumweine"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Qualitätsschaumweins"},new Inflection(){ Article="des", InflectedWord="Qualitätsschaumweines"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Qualitätsschaumweine"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Qualitätsschaumwein"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Qualitätsschaumweinen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Qualitätsschaumwein"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Qualitätsschaumweine"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Nussknacker()
        {
            string word = "Nussknacker";
            int wiktionaryID = 96434;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Nussknacker",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Nussknacker"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Nussknacker"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Nussknackers"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Nussknacker"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Nussknacker"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Nussknackern"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Nussknacker"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Nussknacker"}},
             },
            };

            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Aas()
        {
            string word = "Aas";
            int wiktionaryID = 1901;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Aas",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Aas"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Aase"},new Inflection(){ Article="die", InflectedWord="Äser"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Aases"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Aase"},new Inflection(){ Article="der", InflectedWord="Äser"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Aas"},new Inflection(){ Article="dem", InflectedWord="Aase"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Aasen"},new Inflection(){ Article="den", InflectedWord="Äsern"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Aas"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Aase"},new Inflection(){ Article="die", InflectedWord="Äser"}},
             },
            };

            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void März()
        {
            string word = "März";
            int wiktionaryID = 719;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="März",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="März"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Märze"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="März"},new Inflection(){ Article="des", InflectedWord="Märzes"},new Inflection(){ Article="des", InflectedWord="Märzen"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Märze"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="März"},new Inflection(){ Article="dem", InflectedWord="Märzen"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Märzen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="März"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Märze"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Herz()
        {
            string word = "Herz";
            int wiktionaryID = 6505;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Herz"},new Inflection(){ Article="das", InflectedWord="Herz"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Herzen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Herzens"},new Inflection(){ Article="des", InflectedWord="Herzes"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Herzen"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Herzen"},new Inflection(){ Article="dem", InflectedWord="Herz"},new Inflection(){ Article="dem", InflectedWord="Herz"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Herzen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Herz"},new Inflection(){ Article="das", InflectedWord="Herz"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Herzen"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Mahr()
        {
            string word = "Mahr";
            int wiktionaryID = 262971;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {

                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum, Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Mahr"},new Inflection(){ Article="die", InflectedWord="Mahr"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mahre"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Mahrs"},new Inflection(){ Article="des", InflectedWord="Mahres"},new Inflection(){Article="des", InflectedWord="Mahren"},new Inflection(){Article="der", InflectedWord="Mahr"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Mahre"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Mahr"},new Inflection(){ Article="dem", InflectedWord="Mahre"},new Inflection(){ Article="dem", InflectedWord="Mahren"},new Inflection(){Article="der", InflectedWord="Mahr"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Mahren"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Mahr"},new Inflection(){ Article="den", InflectedWord="Mahren"},new Inflection(){ Article="die", InflectedWord="Mahr"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Mahre"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
        [TestMethod]
        public void Fötus()
        {
            string word = "Fötus";
            int wiktionaryID = 15449;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Fötus"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Föten"},new Inflection(){Article="die", InflectedWord="Fötusse"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Fötus"},new Inflection(){ Article="des", InflectedWord="Fötusses"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Föten"},new Inflection(){Article="der", InflectedWord="Fötusse"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Fötus"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Föten"},new Inflection(){Article="den", InflectedWord="Fötussen"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Fötus"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Föten"},new Inflection(){Article="die", InflectedWord="Fötusse"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Siebenschläfertag()
        {
            string word = "Siebenschläfertag";
            int wiktionaryID = 445847;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Siebenschläfertag"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Siebenschläfertage"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Siebenschläfertags"},new Inflection(){Article="des", InflectedWord="Siebenschläfertages"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Siebenschläfertage"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Siebenschläfertag"},new Inflection(){Article="dem", InflectedWord="Siebenschläfertage"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Siebenschläfertagen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Siebenschläfertag"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Siebenschläfertage"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void Tsunami()
        {
            string word = "Tsunami";
            int wiktionaryID = 10854;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {

                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum, Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tsunami"},new Inflection(){Article="die", InflectedWord="Tsunami"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tsunamis"},new Inflection(){Article="die", InflectedWord="Tsunami"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tsunamis"},new Inflection(){ Article="der", InflectedWord="Tsunami"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tsunamis"},new Inflection(){Article="der", InflectedWord="Tsunami"}},
                DativSingular = new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Tsunami"},new Inflection(){Article="der", InflectedWord="Tsunami"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tsunamis"},new Inflection(){Article="den", InflectedWord="Tsunami"}},
                AkkusativSingular = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tsunami"},new Inflection(){Article="die", InflectedWord="Tsunami"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tsunamis"},new Inflection(){Article="die", InflectedWord="Tsunami"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Firewall()
        {
            string word = "Firewall";
            int wiktionaryID = 37559;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum, Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewall"},new Inflection(){ Article ="der", InflectedWord="Firewall"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewalls"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewall"},new Inflection(){ Article ="des", InflectedWord="Firewall"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewalls"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewall"},new Inflection(){ Article ="dem", InflectedWord="Firewall"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Firewalls"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewall"},new Inflection(){ Article ="den", InflectedWord="Firewall"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewalls"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void Mail()
        {
            string word = "Mail";
            int wiktionaryID = 43059;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum, Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mail"},new Inflection(){Article="das", InflectedWord="Mail"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mails"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mail"},new Inflection(){Article="des", InflectedWord="Mails"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mails"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mail"},new Inflection(){Article="dem", InflectedWord="Mail"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Mails"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mail"},new Inflection(){Article="das", InflectedWord="Mail"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mails"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void DemodexFolliculorum()
        {

            string word = "Demodex folliculorum";
            int wiktionaryID = 10958;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void ErscheinungDesHerrn()
        {
            string word = "Erscheinung des Herrn";
            int wiktionaryID = 426428;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Erscheinung des Herrn"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Erscheinung des Herrn"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Erscheinung des Herrn"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Erscheinung des Herrn"}},
                AkkusativPlural = new List<Inflection>()
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }



        [TestMethod]
        public void StVincentUndDieGrenadinen()
        {
            string word = "St. Vincent und die Grenadinen";
            int wiktionaryID = 39047;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }



        [TestMethod]
        public void Apfelsäure()
        {
            string word = "Apfelsäure";
            int wiktionaryID = 84434;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text="Apfelsäure",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Apfelsäure"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Apfelsäure"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Apfelsäure"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Apfelsäure"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Teppich()
        {
            string word = "Teppich";
            int wiktionaryID = 15585;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Teppich"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Teppiche"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Teppichs"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Teppiche"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Teppich"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Teppichen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Teppich"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Teppiche"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Buggy()
        {
            string word = "Buggy";
            int wiktionaryID = 75742;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum, Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Buggy"}, new Inflection(){ Article ="das", InflectedWord="Buggy"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Buggys"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Buggys"}, new Inflection(){ Article ="des", InflectedWord="Buggys"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Buggys"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Buggy"}, new Inflection(){ Article ="dem", InflectedWord="Buggy"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Buggys"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Buggy"},  new Inflection(){ Article ="das", InflectedWord="Buggy"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Buggys"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Haendel()
        {
            string word = "Händel";
            int wiktionaryID = 123473;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Pluralwort},
                WiktionaryID = wiktionaryID,
                NominativSingular =  new List<Inflection>(),
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Händel"}},
                GenitivSingular = new List<Inflection>(),
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Händel"}},
                DativSingular = new List<Inflection>(),
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Händeln"}},
                AkkusativSingular = new List<Inflection>(),
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Händel"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Fetus()
        {
            string word = "Fetus";
            int wiktionaryID = 15451;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Fetus"},new Inflection(){ Article ="der", InflectedWord="Fetus"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Feten"},new Inflection(){ Article ="die", InflectedWord="Fetusse"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Fetus"},new Inflection(){ Article ="des", InflectedWord="Fetusses"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Feten"},new Inflection(){ Article ="der", InflectedWord="Fetusse"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Fetus"}, new Inflection(){ Article ="dem", InflectedWord="Fetus"}, new Inflection(){ Article ="dem", InflectedWord="Fetusse"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Feten"},new Inflection(){ Article ="den", InflectedWord="Fetussen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Fetus"}, new Inflection(){ Article ="den", InflectedWord="Fetus"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Feten"},new Inflection(){ Article ="die", InflectedWord="Fetusse"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Ballon()
        {
            string word = "Ballon";
            int wiktionaryID = 2756;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Ballon"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Ballons"},new Inflection(){ Article ="die", InflectedWord="Ballone"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Ballons"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Ballons"},new Inflection(){ Article ="der", InflectedWord="Ballone"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Ballon"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Ballons"},new Inflection(){ Article ="den", InflectedWord="Ballonen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Ballon"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Ballons"},new Inflection(){ Article ="die", InflectedWord="Ballone"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Rauchwaren()
        {
            string word = "Rauchwaren";
            int wiktionaryID = 542369;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                WiktionaryID = wiktionaryID,
                Genus = new List<Genus>(){Genus.Pluralwort},
                NominativSingular =  new List<Inflection>(),
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Rauchwaren"}},
                GenitivSingular = new List<Inflection>(),
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Rauchwaren"}},
                DativSingular = new List<Inflection>(),
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Rauchwaren"}},
                AkkusativSingular = new List<Inflection>(),
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Rauchwaren"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Zehntel()
        {
            string word = "Zehntel";
            int wiktionaryID = 522431;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Zehntel"},new Inflection(){ Article ="der", InflectedWord="Zehntel"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Zehntels"},new Inflection(){ Article ="des", InflectedWord="Zehntels"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Zehntel"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Zehntel"},new Inflection(){ Article ="dem", InflectedWord="Zehntel"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Zehnteln"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Zehntel"},new Inflection(){ Article ="den", InflectedWord="Zehntel"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
             },
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Zehntel"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Zehntel"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Zehntel"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Zehnteln"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Zehntel"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Riff()
        {
            string word = "Riff";
            int wiktionaryID = 15088;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Riff"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Riffe"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Riffes"},new Inflection(){ Article="des", InflectedWord="Riffs"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Riffe"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Riff"},new Inflection(){ Article="dem", InflectedWord="Riffe"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Riffen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Riff"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Riffe"}},
             },
                          new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Maskulinum,Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Riff"},new Inflection(){ Article="das", InflectedWord="Riff"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Riffs"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Riffs"},new Inflection(){ Article="des", InflectedWord="Riffs"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Riffs"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Riff"},new Inflection(){ Article="dem", InflectedWord="Riff"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Riffs"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="den", InflectedWord="Riff"},new Inflection(){ Article="das", InflectedWord="Riff"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Riffs"}},
             }
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Bogen()
        {
            string word = "Bogen";
            int wiktionaryID = 16867;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Bogen"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Bogen"},new Inflection(){ Article ="die", InflectedWord="Bögen"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Bogens"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Bogen"},new Inflection(){ Article ="der", InflectedWord="Bögen"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Bogen"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Bogen"},new Inflection(){ Article ="den", InflectedWord="Bögen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Bogen"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Bogen"},new Inflection(){ Article ="die", InflectedWord="Bögen"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Renforcé()
        {
            string word = "Renforcé";
            int wiktionaryID = 497419;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum,Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Renforcé"},new Inflection(){ Article ="das", InflectedWord="Renforcé"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Renforcés"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Renforcés"},new Inflection(){ Article ="des", InflectedWord="Renforcés"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Renforcés"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Renforcé"},new Inflection(){ Article ="dem", InflectedWord="Renforcé"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Renforcés"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Renforcé"},new Inflection(){ Article ="das", InflectedWord="Renforcé"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Renforcés"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Picknick()
        {
            string word = "Picknick";
            int wiktionaryID = 115173;
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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Picknick"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Picknicke"},new Inflection(){ Article ="die", InflectedWord="Picknicks"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Picknicks"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Picknicke"},new Inflection(){ Article ="der", InflectedWord="Picknicks"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Picknick"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Picknicken"},new Inflection(){ Article ="den", InflectedWord="Picknicks"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Picknick"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Picknicke"},new Inflection(){ Article ="die", InflectedWord="Picknicks"}},
             }
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Orden()
        {
            string word = "Bogen";
            int wiktionaryID = 25404;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Orden"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Orden"},new Inflection(){ Article ="die", InflectedWord="Örden"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Ordens"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Orden"},new Inflection(){ Article ="der", InflectedWord="Örden"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Orden"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Orden"},new Inflection(){ Article ="den", InflectedWord="Örden"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Orden"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Orden"},new Inflection(){ Article ="die", InflectedWord="Örden"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Schlot()
        {
            string word = "Schlot";
            int wiktionaryID = 85380;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Schlot"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Schlote"},new Inflection(){ Article ="die", InflectedWord="Schlöte"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Schlotes"}, new Inflection(){Article="des", InflectedWord="Schlots"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Schlote"},new Inflection(){ Article ="der", InflectedWord="Schlöte"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Schlot"},new Inflection(){Article="dem",InflectedWord="Schlote"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Schloten"},new Inflection(){ Article ="den", InflectedWord="Schlöten"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Schlot"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Schlote"},new Inflection(){ Article ="die", InflectedWord="Schlöte"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Admiral()
        {
            string word = "Admiral";
            int wiktionaryID = 11635;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Admiral"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Admirale"},new Inflection(){ Article ="die", InflectedWord="Admiräle"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Admirals"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Admirale"},new Inflection(){ Article ="der", InflectedWord="Admiräle"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Admiral"},new Inflection(){Article="dem",InflectedWord="Admirale"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Admiralen"},new Inflection(){ Article ="den", InflectedWord="Admirälen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Admiral"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Admirale"},new Inflection(){ Article ="die", InflectedWord="Admiräle"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Brautleute()
        {
            string word = "Brautleute";
            int wiktionaryID = 433358;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                WiktionaryID = wiktionaryID,
                Genus = new List<Genus>(){Genus.Pluralwort},
                NominativSingular =  new List<Inflection>(),
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Brautleute"}},
                GenitivSingular = new List<Inflection>(),
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Brautleute"}},
                DativSingular = new List<Inflection>(),
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Brautleuten"}},
                AkkusativSingular = new List<Inflection>(),
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Brautleute"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Queue()
        {
            string word = "Queue";
            int wiktionaryID = 85371;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>()
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Maskulinum, Genus.Femininum, Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Queue"},new Inflection(){ Article ="die", InflectedWord="Queue"},new Inflection(){ Article ="das", InflectedWord="Queue"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queues"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Queues"},new Inflection(){ Article ="der", InflectedWord="Queue"},new Inflection(){ Article ="des", InflectedWord="Queues"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Queues"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Queue"},new Inflection(){ Article ="der", InflectedWord="Queue"},new Inflection(){ Article ="dem", InflectedWord="Queue"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Queues"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Queue"},new Inflection(){ Article ="die", InflectedWord="Queue"},new Inflection(){ Article ="das", InflectedWord="Queue"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queues"}},
             },
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Femininum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queue"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queues"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Queue"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Queues"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Queue"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Queues"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queue"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Queues"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Fünftel()
        {
            string word = "Fünftel";
            int wiktionaryID = 216311;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Fünftel"},new Inflection(){ Article ="der", InflectedWord="Fünftel"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Fünftel"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Fünftels"},new Inflection(){ Article ="des", InflectedWord="Fünftels"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Fünftel"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Fünftel"},new Inflection(){ Article ="dem", InflectedWord="Fünftel"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Fünfteln"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="das", InflectedWord="Fünftel"},new Inflection(){ Article ="den", InflectedWord="Fünftel"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Fünftel"}},
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Avis()
        {
            string word = "Avis";
            int wiktionaryID = 617129;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    new Inflection(){ Article ="der", InflectedWord="Avis"},
                    new Inflection(){ Article ="das", InflectedWord="Avis"},
                    new Inflection(){ Article ="der", InflectedWord="Avis"},
                    new Inflection(){ Article ="das", InflectedWord="Avis"}
                },
                NominativPlural = new List<Inflection>(){
                    new Inflection(){ Article ="die", InflectedWord="Avis"},
                    new Inflection(){ Article ="die", InflectedWord="Avise"},
                },
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord="Avis"},
                    new Inflection(){ Article ="des", InflectedWord="Avis"},
                    new Inflection(){ Article ="des", InflectedWord="Avises"},
                    new Inflection(){ Article ="des", InflectedWord="Avises"},
                },
                GenitivPlural = new List<Inflection>(){
                    new Inflection(){ Article ="der", InflectedWord="Avis"},
                    new Inflection(){ Article ="der", InflectedWord="Avise"},
                },
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="dem", InflectedWord="Avis"},
                    new Inflection(){ Article ="dem", InflectedWord="Avis"},
                    new Inflection(){ Article ="dem", InflectedWord="Avis"},
                    new Inflection(){ Article ="dem", InflectedWord="Avis"},
                },
                DativPlural = new List<Inflection>(){
                    new Inflection(){ Article ="den", InflectedWord="Avis"},
                    new Inflection(){ Article ="den", InflectedWord="Avisen"},
                },
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="den", InflectedWord="Avis"},
                    new Inflection(){ Article ="das", InflectedWord="Avis"},
                    new Inflection(){ Article ="den", InflectedWord="Avis"},
                    new Inflection(){ Article ="das", InflectedWord="Avis"},
                },
                AkkusativPlural = new List<Inflection>(){
                    new Inflection(){ Article ="die", InflectedWord="Avis"},
                    new Inflection(){ Article ="die", InflectedWord="Avise"},
                },
             },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}
