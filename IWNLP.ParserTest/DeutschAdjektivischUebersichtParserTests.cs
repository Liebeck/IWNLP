using IWNLP.Models.Nouns;
using IWNLP.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class DeutschAdjektivischUebersichtParserTests
    {
        [TestMethod]
        public void Bekannter()
        {
            string word = "Bekannter";
            int wiktionaryID = 123174;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Bekannter"},
                    GenitivSingular=new List<string>(){"Bekannten"},
                    DativSingular=new List<string>(){"Bekanntem"},
                    AkkusativSingular=new List<string>(){"Bekannten"},
                    NominativPlural=new List<string>(){"Bekannte"},
                    GenitivPlural=new List<string>(){"Bekannter"},
                    DativPlural=new List<string>(){"Bekannten"},
                    AkkusativPlural=new List<string>(){"Bekannte"},
                    NominativSingularSchwach=new List<string>(){"Bekannte"},
                    GenitivSingularSchwach=new List<string>(){"Bekannten"},
                    DativSingularSchwach=new List<string>(){"Bekannten"},
                    AkkusativSingularSchwach=new List<string>(){"Bekannten"},
                    NominativPluralSchwach=new List<string>(){"Bekannten"},
                    GenitivPluralSchwach=new List<string>(){"Bekannten"},
                    DativPluralSchwach=new List<string>(){"Bekannten"},
                    AkkusativPluralSchwach=new List<string>(){"Bekannten"},
                    NominativSingularGemischt=new List<string>(){"Bekannter"},
                    GenitivSingularGemischt=new List<string>(){"Bekannten"},
                    DativSingularGemischt=new List<string>(){"Bekannten"},
                    AkkusativSingularGemischt=new List<string>(){"Bekannten"},
                    NominativPluralGemischt=new List<string>(){"Bekannten"},
                    GenitivPluralGemischt=new List<string>(){"Bekannten"},
                    DativPluralGemischt=new List<string>(){"Bekannten"},
                    AkkusativPluralGemischt=new List<string>(){"Bekannten"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void GeistlicherRat()
        {
            string word = "Geistlicher Rat";
            int wiktionaryID = 175534;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Geistlicher Rat"},
                    GenitivSingular=new List<string>(){"Geistlichen Rats","Geistlichen Rates"},
                    DativSingular=new List<string>(){"Geistlichem Rat"},
                    AkkusativSingular=new List<string>(){"Geistlichen Rat"},
                    NominativPlural=new List<string>(){"Geistliche Räte"},
                    GenitivPlural=new List<string>(){"Geistlicher Räte"},
                    DativPlural=new List<string>(){"Geistlichen Räten"},
                    AkkusativPlural=new List<string>(){"Geistliche Räte"},
                    NominativSingularSchwach=new List<string>(){"Geistliche Rat"},
                    GenitivSingularSchwach=new List<string>(){"Geistlichen Rats","Geistlichen Rates"},
                    DativSingularSchwach=new List<string>(){"Geistlichen Rat"},
                    AkkusativSingularSchwach=new List<string>(){"Geistlichen Rat"},
                    NominativPluralSchwach=new List<string>(){"Geistlichen Räte"},
                    GenitivPluralSchwach=new List<string>(){"Geistlichen Räte"},
                    DativPluralSchwach=new List<string>(){"Geistlichen Räten"},
                    AkkusativPluralSchwach=new List<string>(){"Geistlichen Räte"},
                    NominativSingularGemischt=new List<string>(){"Geistlicher Rat"},
                    GenitivSingularGemischt=new List<string>(){"Geistlichen Rats","Geistlichen Rates"},
                    DativSingularGemischt=new List<string>(){"Geistlichen Rat"},
                    AkkusativSingularGemischt=new List<string>(){"Geistlichen Rat"},
                    NominativPluralGemischt=new List<string>(){"Geistlichen Räte"},
                    GenitivPluralGemischt=new List<string>(){"Geistlichen Räte"},
                    DativPluralGemischt=new List<string>(){"Geistlichen Räten"},
                    AkkusativPluralGemischt=new List<string>(){"Geistlichen Räte"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Neues()
        {
            string word = "Neues";
            int wiktionaryID = 276441;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Neues"},
                    GenitivSingular=new List<string>(){"Neuen"},
                    DativSingular=new List<string>(){"Neuem"},
                    AkkusativSingular=new List<string>(){"Neues"},
                    NominativSingularSchwach=new List<string>(){"Neue"},
                    GenitivSingularSchwach=new List<string>(){"Neuen"},
                    DativSingularSchwach=new List<string>(){"Neuen"},
                    AkkusativSingularSchwach=new List<string>(){"Neue"},
                    NominativSingularGemischt=new List<string>(){"Neues"},
                    GenitivSingularGemischt=new List<string>(){"Neuen"},
                    DativSingularGemischt=new List<string>(){"Neuen"},
                    AkkusativSingularGemischt=new List<string>(){"Neues"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Inneres()
        {
            string word = "Inneres";
            int wiktionaryID = 262083;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Inneres"},
                    GenitivSingular=new List<string>(){"Inneren","Innern"},
                    DativSingular=new List<string>(){"Innerem"},
                    AkkusativSingular=new List<string>(){"Inneres"},
                    NominativSingularSchwach=new List<string>(){"Innere"},
                    GenitivSingularSchwach=new List<string>(){"Inneren","Innern"},
                    DativSingularSchwach=new List<string>(){"Inneren","Innern"},
                    AkkusativSingularSchwach=new List<string>(){"Innere"},
                    NominativSingularGemischt=new List<string>(){"Inneres"},
                    GenitivSingularGemischt=new List<string>(){"Inneren", "Innern"},
                    DativSingularGemischt=new List<string>(){"Inneren","Innern"},
                    AkkusativSingularGemischt=new List<string>(){"Inneres"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void DeutschesEck()
        {
            string word = "Deutsches Eck";
            int wiktionaryID = 26385;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Deutsches Eck"},
                    GenitivSingular=new List<string>(){"Deutschen Ecks"},
                    DativSingular=new List<string>(){"Deutschem Eck"},
                    AkkusativSingular=new List<string>(){"Deutsches Eck"},
                    NominativSingularSchwach=new List<string>(){"Deutsche Eck"},
                    GenitivSingularSchwach=new List<string>(){"Deutschen Ecks"},
                    DativSingularSchwach=new List<string>(){"Deutschen Eck"},
                    AkkusativSingularSchwach=new List<string>(){"Deutsche Eck"},
                    NominativSingularGemischt=new List<string>(){"Deutsches Eck"},
                    GenitivSingularGemischt=new List<string>(){"Deutschen Ecks"},
                    DativSingularGemischt=new List<string>(){"Deutschen Eck"},
                    AkkusativSingularGemischt=new List<string>(){"Deutsches Eck"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void Gelbes()
        {
            string word = "Gelbes";
            int wiktionaryID = 23615;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Gelbes"},
                    GenitivSingular=new List<string>(){"Gelben"},
                    DativSingular=new List<string>(){"Gelbem"},
                    AkkusativSingular=new List<string>(){"Gelbes"},
                    NominativPlural=new List<string>(){"Gelbe"},
                    GenitivPlural=new List<string>(){"Gelber"},
                    DativPlural=new List<string>(){"Gelben"},
                    AkkusativPlural=new List<string>(){"Gelbe"},
                    NominativSingularSchwach=new List<string>(){"Gelbe"},
                    GenitivSingularSchwach=new List<string>(){"Gelben"},
                    DativSingularSchwach=new List<string>(){"Gelben"},
                    AkkusativSingularSchwach=new List<string>(){"Gelbe"},
                    NominativPluralSchwach=new List<string>(){"Gelben"},
                    GenitivPluralSchwach=new List<string>(){"Gelben"},
                    DativPluralSchwach=new List<string>(){"Gelben"},
                    AkkusativPluralSchwach=new List<string>(){"Gelben"},
                    NominativSingularGemischt=new List<string>(){"Gelbes"},
                    GenitivSingularGemischt=new List<string>(){"Gelben"},
                    DativSingularGemischt=new List<string>(){"Gelben"},
                    AkkusativSingularGemischt=new List<string>(){"Gelbes"},
                    NominativPluralGemischt=new List<string>(){"Gelben"},
                    GenitivPluralGemischt=new List<string>(){"Gelben"},
                    DativPluralGemischt=new List<string>(){"Gelben"},
                    AkkusativPluralGemischt=new List<string>(){"Gelben"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Asoziale()
        {
            string word = "Asoziale";
            int wiktionaryID = 326483;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Asoziale"},
                    GenitivSingular=new List<string>(){"Asozialer"},
                    DativSingular=new List<string>(){"Asozialer"},
                    AkkusativSingular=new List<string>(){"Asoziale"},
                    NominativPlural=new List<string>(){"Asoziale"},
                    GenitivPlural=new List<string>(){"Asozialer"},
                    DativPlural=new List<string>(){"Asozialen"},
                    AkkusativPlural=new List<string>(){"Asoziale"},
                    NominativSingularSchwach=new List<string>(){"Asoziale"},
                    GenitivSingularSchwach=new List<string>(){"Asozialen"},
                    DativSingularSchwach=new List<string>(){"Asozialen"},
                    AkkusativSingularSchwach=new List<string>(){"Asoziale"},
                    NominativPluralSchwach=new List<string>(){"Asozialen"},
                    GenitivPluralSchwach=new List<string>(){"Asozialen"},
                    DativPluralSchwach=new List<string>(){"Asozialen"},
                    AkkusativPluralSchwach=new List<string>(){"Asozialen"},
                    NominativSingularGemischt=new List<string>(){"Asoziale"},
                    GenitivSingularGemischt=new List<string>(){"Asozialen"},
                    DativSingularGemischt=new List<string>(){"Asozialen"},
                    AkkusativSingularGemischt=new List<string>(){"Asoziale"},
                    NominativPluralGemischt=new List<string>(){"Asozialen"},
                    GenitivPluralGemischt=new List<string>(){"Asozialen"},
                    DativPluralGemischt=new List<string>(){"Asozialen"},
                    AkkusativPluralGemischt=new List<string>(){"Asozialen"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Beschäftigter()
        {
            string word = "Beschäftigter";
            int wiktionaryID = 137120;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Beschäftigter"},
                    GenitivSingular=new List<string>(){"Beschäftigten"},
                    DativSingular=new List<string>(){"Beschäftigtem"},
                    AkkusativSingular=new List<string>(){"Beschäftigten"},
                    NominativPlural=new List<string>(){"Beschäftigte"},
                    GenitivPlural=new List<string>(){"Beschäftigter"},
                    DativPlural=new List<string>(){"Beschäftigten"},
                    AkkusativPlural=new List<string>(){"Beschäftigte"},
                    NominativSingularSchwach=new List<string>(){"Beschäftigte"},
                    GenitivSingularSchwach=new List<string>(){"Beschäftigten"},
                    DativSingularSchwach=new List<string>(){"Beschäftigten"},
                    AkkusativSingularSchwach=new List<string>(){"Beschäftigten"},
                    NominativPluralSchwach=new List<string>(){"Beschäftigten"},
                    GenitivPluralSchwach=new List<string>(){"Beschäftigten"},
                    DativPluralSchwach=new List<string>(){"Beschäftigten"},
                    AkkusativPluralSchwach=new List<string>(){"Beschäftigten"},
                    NominativSingularGemischt=new List<string>(){"Beschäftigter"},
                    GenitivSingularGemischt=new List<string>(){"Beschäftigten"},
                    DativSingularGemischt=new List<string>(){"Beschäftigten"},
                    AkkusativSingularGemischt=new List<string>(){"Beschäftigten"},
                    NominativPluralGemischt=new List<string>(){"Beschäftigten"},
                    GenitivPluralGemischt=new List<string>(){"Beschäftigten"},
                    DativPluralGemischt=new List<string>(){"Beschäftigten"},
                    AkkusativPluralGemischt=new List<string>(){"Beschäftigten"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void ArabischerFruehling()
        {
            string word = "Arabischer Frühling";
            int wiktionaryID = 267863;
            string text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativSingular = new List<string>(){"Arabischer Frühling"},
                    GenitivSingular=new List<string>(){"Arabischen Frühlings"},
                    DativSingular=new List<string>(){"Arabischem Frühling"},
                    AkkusativSingular=new List<string>(){"Arabischen Frühling"},
                    NominativSingularSchwach=new List<string>(){"Arabische Frühling"},
                    GenitivSingularSchwach=new List<string>(){"Arabischen Frühlings"},
                    DativSingularSchwach=new List<string>(){"Arabischen Frühling"},
                    AkkusativSingularSchwach=new List<string>(){"Arabischen Frühling"},
                    NominativSingularGemischt=new List<string>(){"Arabischer Frühling"},
                    GenitivSingularGemischt=new List<string>(){"Arabischen Frühlings"},
                    DativSingularGemischt=new List<string>(){"Arabischen Frühling"},
                    AkkusativSingularGemischt=new List<string>(){"Arabischen Frühling"},
                },
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
