using GenericXMLSerializer;
using IWNLP.Models;
using IWNLP.Models.Nouns;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class NounTests
    {
        [TestMethod]
        public void Haus()
        {
            String word = "Haus";
            String filename = @"..\..\TestInput\Nouns\Haus.txt";
            int wiktionaryID = 1119;
            String text = Common.ReadFromFile(filename);

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
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Güterzug()
        {
            String word = "Güterzug";
            String filename = @"..\..\TestInput\Nouns\Güterzug.txt";
            int wiktionaryID = 151293;
            String text = Common.ReadFromFile(filename);

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
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Güterzug"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Güterzügen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Güterzug"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Güterzüge"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Joghurt()
        {
            String word = "Joghurt";
            String filename = @"..\..\TestInput\Nouns\Joghurt.txt";
            int wiktionaryID = 23051;
            String text = Common.ReadFromFile(filename);

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
            String word = "April";
            String filename = @"..\..\TestInput\Nouns\April.txt";
            int wiktionaryID = 720;
            String text = Common.ReadFromFile(filename);

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
            String word = "Fremde";
            String filename = @"..\..\TestInput\Nouns\Fremde.txt";
            int wiktionaryID = 73942;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Fremde",
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
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Hannibal() // Eigenname
        {

            String word = "Hannibal";
            String filename = @"..\..\TestInput\Nouns\Hannibal.txt";
            int wiktionaryID = 454497;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Codex()
        {
            String word = "Codex";
            String filename = @"..\..\TestInput\Nouns\Codex.txt";
            int wiktionaryID = 33616;
            String text = Common.ReadFromFile(filename);

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
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Index()
        {
            String word = "Index";
            String filename = @"..\..\TestInput\Nouns\Index.txt";
            int wiktionaryID = 5086;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Index"},new Inflection(){ Article ="der", InflectedWord="Index"},new Inflection(){ Article ="der", InflectedWord="Index"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Indizes"},new Inflection(){ Article ="die", InflectedWord="Indices"},new Inflection(){ Article ="die", InflectedWord="Indexe"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Index"},new Inflection(){ Article ="des", InflectedWord="Indexes"},new Inflection(){ Article ="des", InflectedWord="Indicis"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article ="der", InflectedWord="Indizes"}, new Inflection(){ Article ="der", InflectedWord="Indices"},new Inflection(){ Article ="der", InflectedWord="Indexe"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Index"},new Inflection(){ Article ="dem", InflectedWord="Index"},new Inflection(){ Article ="dem", InflectedWord="Indexe"},new Inflection(){ Article ="dem", InflectedWord="Indici"},new Inflection(){ Article ="dem", InflectedWord="Indice"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article ="den", InflectedWord="Indizes"},new Inflection(){ Article ="den", InflectedWord="Indices"},new Inflection(){ Article ="den", InflectedWord="Indicibus"},new Inflection(){ Article ="den", InflectedWord="Indexen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Index"},new Inflection(){ Article ="den", InflectedWord="Index"},new Inflection(){ Article ="den", InflectedWord="Indicem"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article ="die", InflectedWord="Indizes"},new Inflection(){ Article ="die", InflectedWord="Indices"},new Inflection(){ Article ="die", InflectedWord="Indexe"}},
             },
            };


            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Masse()
        {
            String word = "Masse";
            String filename = @"..\..\TestInput\Nouns\Masse.txt";
            int wiktionaryID = 17171;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Strasse()
        {
            // Schweizer und Liechtensteiner Schreibweise
            String word = "Strasse";
            String filename = @"..\..\TestInput\Nouns\Strasse.txt";
            int wiktionaryID = 18409;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Schoss()
        {
            // 2 entries, one is "{{Schweizer und Liechtensteiner Schreibweise"
            String word = "Schoss";
            String filename = @"..\..\TestInput\Nouns\Schoss.txt";
            int wiktionaryID = 37410;
            String text = Common.ReadFromFile(filename);

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
            String word = "Thor";
            String filename = @"..\..\TestInput\Nouns\Thor.txt";
            int wiktionaryID = 18441;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Ablaß()
        {
            // 2 entries: Toponym und Nachname
            String word = "Ablaß";
            String filename = @"..\..\TestInput\Nouns\Ablaß.txt";
            int wiktionaryID = 20198;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Citronensäure()
        {
            // contains "*Alternative Schreibweise von"
            String word = "Citronensäure";
            String filename = @"..\..\TestInput\Nouns\Citronensäure.txt";
            int wiktionaryID = 82973;
            String text = Common.ReadFromFile(filename);

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
            String word = "Ampelograph";
            String filename = @"..\..\TestInput\Nouns\Ampelograph.txt";
            int wiktionaryID = 263917;
            String text = Common.ReadFromFile(filename);

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
            String word = "Zeitprozentverfahren";
            String filename = @"..\..\TestInput\Nouns\Zeitprozentverfahren.txt";
            int wiktionaryID = 4930;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tolpatsch()
        {
            // no definition, only "{{Alte Schreibweise"
            String word = "Tolpatsch";
            String filename = @"..\..\TestInput\Nouns\Tolpatsch.txt";
            int wiktionaryID = 5679;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Komputer()
        {
            // no definition, only "{{Alte Schreibweise"
            String word = "Komputer";
            String filename = @"..\..\TestInput\Nouns\Komputer.txt";
            int wiktionaryID = 9414;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Propentricarbonsäure()
        {
            String word = "1,2,3-Propentricarbonsäure";
            String filename = @"..\..\TestInput\Nouns\Propentricarbonsäure.txt";
            int wiktionaryID = 44684;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Konstante()
        {
            String word = "Konstante";
            String filename = @"..\..\TestInput\Nouns\Konstante.txt";
            int wiktionaryID = 92957;
            String text = Common.ReadFromFile(filename);

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
            String word = "Miami";
            String filename = @"..\..\TestInput\Nouns\Miami.txt";
            int wiktionaryID = 300285;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Miami",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){ new Inflection(){InflectedWord="Miami"}, new Inflection(){ Article="das", InflectedWord="Miami"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Miami"},new Inflection(){ Article="des", InflectedWord="Miamis"},new Inflection(){ InflectedWord="Miamis"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Miami"},new Inflection(){ Article="dem", InflectedWord="Miami"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Miami"},new Inflection(){ InflectedWord="Miami"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Interessenvertretung()
        {
            String word = "Interessenvertretung";
            String filename = @"..\..\TestInput\Nouns\Interessenvertretung.txt";
            int wiktionaryID = 269932;
            String text = Common.ReadFromFile(filename);

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
            String word = "Vertretung";
            String filename = @"..\..\TestInput\Nouns\Vertretung.txt";
            int wiktionaryID = 246368;
            String text = Common.ReadFromFile(filename);

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
            String word = "Mutter";
            String filename = @"..\..\TestInput\Nouns\Mutter.txt";
            int wiktionaryID = 1053;
            String text = Common.ReadFromFile(filename);

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
            String word = "Mai";
            String filename = @"..\..\TestInput\Nouns\Mai.txt";
            int wiktionaryID = 721;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Juni()
        {
            String word = "Juni";
            String filename = @"..\..\TestInput\Nouns\Juni.txt";
            int wiktionaryID = 722;
            String text = Common.ReadFromFile(filename);

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
            String word = "Art";
            String filename = @"..\..\TestInput\Nouns\Art.txt";
            int wiktionaryID = 2853;
            String text = Common.ReadFromFile(filename);

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
            String word = "August";
            String filename = @"..\..\TestInput\Nouns\August.txt";
            int wiktionaryID = 724;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Niederländisch()
        {
            String word = "Niederländisch";
            String filename = @"..\..\TestInput\Nouns\Niederländisch.txt";
            int wiktionaryID = 1047;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){new Inflection(){  InflectedWord="Niederländisch"}, new Inflection(){Article="das", InflectedWord="Niederländisch"}, new Inflection(){ Article="das", InflectedWord="Niederländische"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Niederländischs"}, new Inflection(){ Article="des", InflectedWord="Niederländischs"}, new Inflection(){Article="des", InflectedWord="Niederländischen"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Niederländisch"}, new Inflection(){ Article="dem", InflectedWord="Niederländisch"}, new Inflection(){Article="dem", InflectedWord="Niederländischen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Niederländisch"}, new Inflection(){ Article="das", InflectedWord="Niederländisch"}, new Inflection(){Article="das", InflectedWord="Niederländische"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Afrikaans()
        {
            String word = "Afrikaans";
            String filename = @"..\..\TestInput\Nouns\Afrikaans.txt";
            int wiktionaryID = 2134;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Afrikaans"}, new Inflection(){Article="das", InflectedWord="Afrikaans"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Afrikaans"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Afrikaans"}, new Inflection(){ Article="dem", InflectedWord="Afrikaans"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ InflectedWord="Afrikaans"}, new Inflection(){Article="das", InflectedWord="Afrikaans"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Gelb()
        {
            String word = "Gelb";
            String filename = @"..\..\TestInput\Nouns\Gelb.txt";
            int wiktionaryID = 938;
            String text = Common.ReadFromFile(filename);

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
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelbs"},new Inflection(){ Article="die", InflectedWord="Gelbtöne"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Gelbs"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Gelbs"},new Inflection(){ Article="der", InflectedWord="Gelbtöne"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Gelb"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Gelbs"},new Inflection(){ Article="den", InflectedWord="Gelbtönen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Gelb"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelbs"},new Inflection(){ Article="die", InflectedWord="Gelbtöne"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tag()
        {
            // Mit Hinweis auf Bedeutungen in [1,2]
            String word = "Tag";
            String filename = @"..\..\TestInput\Nouns\Tag.txt";
            int wiktionaryID = 2110;
            String text = Common.ReadFromFile(filename);

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
                Genus = new List<Genus>(){Genus.Maskulinum, Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Tag"},new Inflection(){ Article="der", InflectedWord="Tag"}},
                NominativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="Tags"}},
                GenitivPlural = new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Tags"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="Tag"}},
                DativPlural = new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Tags"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="Tag"},new Inflection(){ Article="den", InflectedWord="Tag"}},
                AkkusativPlural = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Tags"}},
             },
            };


            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tun()
        {
            String word = "Tun";
            String filename = @"..\..\TestInput\Nouns\Tun.txt";
            int wiktionaryID = 33169;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
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
             },
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
             }
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Tier()
        {
            String word = "Tier";
            String filename = @"..\..\TestInput\Nouns\Tier.txt";
            int wiktionaryID = 3622;
            String text = Common.ReadFromFile(filename);

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
            String word = "Pkw";
            String filename = @"..\..\TestInput\Nouns\Pkw.txt";
            int wiktionaryID = 2272;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Biak()
        {
            String word = "Biak";
            String filename = @"..\..\TestInput\Nouns\Biak.txt";
            int wiktionaryID = 56588;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text="Biak",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="das", InflectedWord="Biak"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){InflectedWord="Biaks"},new Inflection(){ Article="des", InflectedWord="Biaks"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="dem", InflectedWord="Biak"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="das", InflectedWord="Biak"}},
                AkkusativPlural = new List<Inflection>(),
             },
             new Models.Noun()
             {
                Text="Biak",
                POS = POS.Noun,
                Genus = new List<Genus>(){Genus.Neutrum},
                WiktionaryID = wiktionaryID,
                NominativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="das", InflectedWord="Biak"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){InflectedWord="Biak"},new Inflection(){ Article="des", InflectedWord="Biak"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="dem", InflectedWord="Biak"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){new Inflection(){ InflectedWord="Biak"},new Inflection(){ Article="das", InflectedWord="Biak"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };

            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Deichgraf()
        {
            String word = "Deichgraf";
            String filename = @"..\..\TestInput\Nouns\Deichgraf.txt";
            int wiktionaryID = 121425;
            String text = Common.ReadFromFile(filename);

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
            String word = "Daguerreotyp";
            String filename = @"..\..\TestInput\Nouns\Daguerreotyp.txt";
            int wiktionaryID = 319160;
            String text = Common.ReadFromFile(filename);

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
            String word = "Qualitätsschaumwein";
            String filename = @"..\..\TestInput\Nouns\Qualitätsschaumwein.txt";
            int wiktionaryID = 446941;
            String text = Common.ReadFromFile(filename);

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
            String word = "Nussknacker";
            String filename = @"..\..\TestInput\Nouns\Nussknacker.txt";
            int wiktionaryID = 96434;
            String text = Common.ReadFromFile(filename);

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

            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Aas()
        {
            String word = "Aas";
            String filename = @"..\..\TestInput\Nouns\Aas.txt";
            int wiktionaryID = 1901;
            String text = Common.ReadFromFile(filename);

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

            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void März()
        {
            String word = "März";
            String filename = @"..\..\TestInput\Nouns\März.txt";
            int wiktionaryID = 719;
            String text = Common.ReadFromFile(filename);

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
            String word = "Herz";
            String filename = @"..\..\TestInput\Nouns\Herz.txt";
            int wiktionaryID = 6505;
            String text = Common.ReadFromFile(filename);

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
            String word = "Mahr";
            String filename = @"..\..\TestInput\Nouns\Mahr.txt";
            int wiktionaryID = 6505;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
        [TestMethod]
        public void Fötus()
        {
            String word = "Fötus";
            String filename = @"..\..\TestInput\Nouns\Fötus.txt";
            int wiktionaryID = 15449;
            String text = Common.ReadFromFile(filename);

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
            String word = "Siebenschläfertag";
            String filename = @"..\..\TestInput\Nouns\Siebenschläfertag.txt";
            int wiktionaryID = 445847;
            String text = Common.ReadFromFile(filename);

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
            String word = "Tsunami";
            String filename = @"..\..\TestInput\Nouns\Tsunami.txt";
            int wiktionaryID = 10854;
            String text = Common.ReadFromFile(filename);

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
            String word = "Firewall";
            String filename = @"..\..\TestInput\Nouns\Firewall.txt";
            int wiktionaryID = 37559;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewall"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewalls"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewall"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewalls"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Firewall"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Firewalls"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewall"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Firewalls"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void Mail()
        {
            String word = "Mail";
            String filename = @"..\..\TestInput\Nouns\Mail.txt";
            int wiktionaryID = 43059;
            String text = Common.ReadFromFile(filename);

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
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mail"},new Inflection(){Article="der", InflectedWord="Mails"},new Inflection(){Article="des", InflectedWord="Mail"},new Inflection(){Article="des", InflectedWord="Mails"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mails"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Mail"},new Inflection(){Article="dem", InflectedWord="Mail"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Mails"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mail"},new Inflection(){Article="das", InflectedWord="Mail"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Mails"}},
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void DemodexFolliculorum() 
        {

            String word = "Demodex folliculorum";
            String filename = @"..\..\TestInput\Nouns\Demodex folliculorum.txt";
            int wiktionaryID = 10958;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void ErscheinungDesHerrn()
        {
            String word = "Erscheinung des Herrn";
            String filename = @"..\..\TestInput\Nouns\ErscheinungDesHerrn.txt";
            int wiktionaryID = 426428;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Erscheinung des Herrn"}, new Inflection(){ InflectedWord="Erscheinung des Herrn"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Erscheinung des Herrn"}, new Inflection(){InflectedWord="Erscheinung des Herrn"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Erscheinung des Herrn"}, new Inflection(){InflectedWord="Erscheinung des Herrn"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Erscheinung des Herrn"}, new Inflection(){InflectedWord="Erscheinung des Herrn"}},
                AkkusativPlural = new List<Inflection>()
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void MariaVomSiege()
        {
            String word = "Maria vom Siege";
            String filename = @"..\..\TestInput\Nouns\MariaVomSiege.txt";
            int wiktionaryID = 164603;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Maria vom Siege"}, new Inflection(){ InflectedWord="Maria vom Siege"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Maria vom Siege"}, new Inflection(){InflectedWord="Maria vom Siege"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="der", InflectedWord="Maria vom Siege"}, new Inflection(){InflectedWord="Maria vom Siege"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="die", InflectedWord="Maria vom Siege"}, new Inflection(){InflectedWord="Maria vom Siege"}},
                AkkusativPlural = new List<Inflection>()
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void StVincentUndDieGrenadinen()
        {
            String word = "St. Vincent und die Grenadinen";
            String filename = @"..\..\TestInput\Nouns\StVincentUndDieGrenadinen.txt";
            int wiktionaryID = 39047;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="St. Vincent und die Grenadinen"}, new Inflection(){ InflectedWord="St. Vincent und die Grenadinen"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article="des", InflectedWord="St. Vincent und der Grenadinen"}, new Inflection(){ Article="des",InflectedWord="St. Vincents und der Grenadinen"}, new Inflection(){InflectedWord="St. Vincents und der Grenadinen"}, new Inflection(){ InflectedWord="von St. Vincent und die Grenadinen"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article="dem", InflectedWord="St. Vincent und den Grenadinen"}, new Inflection(){InflectedWord="St. Vincent und den Grenadinen"}, new Inflection(){Article="dem", InflectedWord="St. Vincent und die Grenadinen"}, new Inflection(){InflectedWord="St. Vincent und die Grenadinen"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article="das", InflectedWord="St. Vincent und die Grenadinen"}, new Inflection(){InflectedWord="St. Vincent und die Grenadinen"}},
                AkkusativPlural = new List<Inflection>()
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Nord()
        {
            String word = "Nord";
            String filename = @"..\..\TestInput\Nouns\Nord.txt";
            int wiktionaryID = 21287;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Nord"},new Inflection(){InflectedWord="Nord"}},
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Nord"},new Inflection(){Article="des", InflectedWord="Nords"},new Inflection(){InflectedWord="Nords"}, new Inflection(){ InflectedWord="Nord"}},
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Nord"},new Inflection(){InflectedWord="Nord"}},
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Nord"},new Inflection(){InflectedWord="Nord"}},
                AkkusativPlural = new List<Inflection>(),
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Apfelsäure()
        {
            String word = "Apfelsäure";
            String filename = @"..\..\TestInput\Nouns\Apfelsaeure.txt";
            int wiktionaryID = 84434;
            String text = Common.ReadFromFile(filename);

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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Teppich()
        {
            String word = "Teppich";
            String filename = @"..\..\TestInput\Nouns\Teppich.txt";
            int wiktionaryID = 15585;
            String text = Common.ReadFromFile(filename);

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
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Teppichs"},new Inflection(){ Article="des", InflectedWord="Teppiches"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Teppiche"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Teppich"}, new Inflection(){Article="dem", InflectedWord="Teppiche"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Teppichen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Teppich"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Teppiche"}},
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Buggy()
        {
            String word = "Buggy";
            String filename = @"..\..\TestInput\Nouns\Buggy.txt";
            int wiktionaryID = 75742;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Buggy"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Buggys"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Buggys"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Buggys"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Buggy"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Buggys"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Buggy"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Buggys"}},
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Haendel()
        {
            String word = "Händel";
            String filename = @"..\..\TestInput\Nouns\Haendel.txt";
            int wiktionaryID = 123473;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Noun()
             {
                Text=word,
                POS = POS.Noun,
                Genus = new List<Genus>(){ Genus.Femininum},
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
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Fetus()
        {
            String word = "Fetus";
            String filename = @"..\..\TestInput\Nouns\Fetus.txt";
            int wiktionaryID = 15451;
            String text = Common.ReadFromFile(filename);

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
                NominativSingular = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Fetus"}},
                NominativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Feten"},new Inflection(){ Article ="die", InflectedWord="Fetusse"}},
                GenitivSingular = new List<Inflection>(){ new Inflection(){ Article ="des", InflectedWord="Fetus"},new Inflection(){ Article ="des", InflectedWord="Fetusses"}},
                GenitivPlural = new List<Inflection>(){ new Inflection(){ Article ="der", InflectedWord="Feten"},new Inflection(){ Article ="der", InflectedWord="Fetusse"}},
                DativSingular = new List<Inflection>(){ new Inflection(){ Article ="dem", InflectedWord="Fetus"}},
                DativPlural = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Feten"},new Inflection(){ Article ="den", InflectedWord="Fetussen"}},
                AkkusativSingular = new List<Inflection>(){ new Inflection(){ Article ="den", InflectedWord="Fetus"}},
                AkkusativPlural = new List<Inflection>(){ new Inflection(){ Article ="die", InflectedWord="Feten"},new Inflection(){ Article ="die", InflectedWord="Fetusse"}},
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
