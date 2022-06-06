using IWNLP.Models;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class POSTests
    {

        public bool ArePosTagsEqual(List<Models.Word> words, List<Models.Word> expectedWords) 
        {
            if (words.Count != expectedWords.Count) 
            {
                return false;
            }
            for (int i = 0; i < words.Count; i++) 
            {
                if (words[i].POS != expectedWords[i].POS) 
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void dunkel()
        {
            String word = "dunkel";
            String filename = @"..\..\TestInput\POS\dunkel.txt";
            int wiktionaryID = 28866;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Word> words = parser.ParseText(word, text, wiktionaryID).Cast<Models.Word>().ToList();
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {
                POS = POS.Adjective,
             },
            };

            Assert.IsTrue(ArePosTagsEqual(words, expectedWords), "failed");
        }

        [TestMethod]
        public void wohlgenährt()
        {
            String word = "wohlgenährt";
            String filename = @"..\..\TestInput\POS\wohlgenährt.txt";
            int wiktionaryID = 109027;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();

            List<Models.Word> words = parser.ParseText(word, text, wiktionaryID).Cast<Models.Word>().ToList();
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Adjective()
             {
                POS = POS.Adjective,
             },
            };

            Assert.IsTrue(ArePosTagsEqual(words, expectedWords), "failed");
        }
    }
}
