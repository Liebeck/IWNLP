using IWNLP.Models;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ = new List<string>(){"toter"},
                Superlativ = new List<string>(){"totesten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ = new List<string>(){"gesünder","gesunder"},
                Superlativ=new List<string>(){"gesündesten","gesundesten"}

             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ = new List<string>(){"abgeneigter"},
                Superlativ=new List<string>(){"abgeneigtesten"}

             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ= new List<string>(){"aromatischer"},
                Superlativ=new List<string>(){"aromatischsten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void spielend()
        {
            String word = "spielend";
            int wiktionaryID = 166504;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            words = words.Where(x => ((Word)x).POS == POS.Adjective).ToList(); // filter out "spielend" as Partizip I
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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ= new List<string>(){"dümmer"},
                Superlativ=new List<string>(){"dümmsten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ= new List<string>(){"karger","kärger"},
                Superlativ=new List<string>(){"kargsten","kärgsten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ=new List<string>(){"nasser","nässer"},
                Superlativ=new List<string>(){"nassesten","nässesten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
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
                Komparativ= new List<string>(){"weniger"},
                Superlativ=new List<string>(){"wenigsten"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void weltgrößte()
        {
            String word = "weltgrößte";
            int wiktionaryID = 411251;
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
                Superlativ=new List<string>(){"weltgrößte"}
             },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}
