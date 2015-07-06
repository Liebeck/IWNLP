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
            String filename = @"..\..\TestInput\Adjectives\zirkulaer.txt";
            int wiktionaryID = 11228;
            String text = Common.ReadFromFile(filename);

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
            String filename = @"..\..\TestInput\Adjectives\tot.txt";
            int wiktionaryID = 14223;
            String text = Common.ReadFromFile(filename);

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
                 Superlativ = new List<string>(){"am totesten","am tötesten"}

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
            String filename = @"..\..\TestInput\Adjectives\doll.txt";
            int wiktionaryID = 22355;
            String text = Common.ReadFromFile(filename);

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
                 Superlativ = new List<string>(){"am dollsten"}

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
            String filename = @"..\..\TestInput\Adjectives\einzig.txt";
            int wiktionaryID = 80153;
            String text = Common.ReadFromFile(filename);

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
    }
}
