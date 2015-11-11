using GenericXMLSerializer;
using IWNLP.Models;
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
    public class AdjectiveTests
    {
        [TestMethod]
        public void zirkulär()
        {
            String word = "zirkulär";
            int wiktionaryID = 11228;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"zirkulär"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void tot()
        {
            String word = "tot";

            int wiktionaryID = 14223;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"tot"},
                Komparativ = new List<string>(){"toter", "töter"},
                 Superlativ = new List<string>(){"totesten","tötesten"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void doll()
        {
            String word = "doll";
            int wiktionaryID = 22355;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"doll"},
                Komparativ = new List<string>(){"doller", "döller"},
                 Superlativ = new List<string>(){"dollsten"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void einzig()
        {
            String word = "einzig";
            int wiktionaryID = 80153;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"einzig"},
                Superlativ = new List<string>(){"einzigste"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gesund()
        {
            String word = "gesund";
            int wiktionaryID = 17499;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"gesund"},
                Superlativ = new List<string>(){"gesünder","gesunder"},
                Komparativ=new List<string>(){"gesündesten","gesundesten"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void abgeneigt()
        {
            String word = "abgeneigt";
            int wiktionaryID = 173607;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"abgeneigt"},
                Superlativ = new List<string>(){"abgeneigter"},
                Komparativ=new List<string>(){"abgeneigtesten"}

             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void astral()
        {
            String word = "astral";
            int wiktionaryID = 115740;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"astral"},
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void aromatisch()
        {
            String word = "aromatisch";
            int wiktionaryID = 150394;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"aromatisch"},
                Superlativ = new List<string>(){"aromatischer"},
                Komparativ=new List<string>(){"aromatischsten"}
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void spielend()
        {
            String word = "spielend";
            int wiktionaryID = 115740;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"spielend"},
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void dumm()
        {
            String word = "dumm";
            int wiktionaryID = 4264;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"dumm"},
                Superlativ = new List<string>(){"dümmer"},
                Komparativ=new List<string>(){"dümmsten"}
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void karg()
        {
            String word = "karg";
            int wiktionaryID = 78721;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"karg"},
                Superlativ = new List<string>(){"karger","kärger"},
                Komparativ=new List<string>(){"kargsten","kärgsten"}
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void nass()
        {
            String word = "nass";
            int wiktionaryID = 28108;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"nass"},
                Superlativ = new List<string>(){"nasser","nässer"},
                Komparativ=new List<string>(){"nassesten","nässesten"}
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void wenig()
        {
            String word = "wenig";
            int wiktionaryID = 18748;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {

                Text=word,
                POS = POS.Adjective,
                WiktionaryID = wiktionaryID,
                Positiv=new List<string>(){"wenig"},
                Superlativ = new List<string>(){"weniger","minder"},
                Komparativ=new List<string>(){"wenigsten","mindesten"}
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}
