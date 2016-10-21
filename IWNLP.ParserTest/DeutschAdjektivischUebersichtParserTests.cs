using GenericXMLSerializer;
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
    public class DeutschAdjektivischUebersichtParserTests
    {
        [TestMethod]
        public void Bekannter()
        {
            String word = "Bekannter";
            int wiktionaryID = 123174;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Bekannte"},
                    GenitivSingularSchwach=new List<String>(){"Bekannten"},
                    DativSingularSchwach=new List<String>(){"Bekannten"},
                    AkkusativSingularSchwach=new List<String>(){"Bekannten"},
                    NominativPluralSchwach=new List<String>(){"Bekannten"},
                    GenitivPluralSchwach=new List<String>(){"Bekannten"},
                    DativPluralSchwach=new List<String>(){"Bekannten"},
                    AkkusativPluralSchwach=new List<String>(){"Bekannten"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void GeistlicherRat()
        {
            String word = "Geistlicher Rat";
            int wiktionaryID = 175534;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Geistliche Rat"},
                    GenitivSingularSchwach=new List<String>(){"Geistlichen Rats","Geistlichen Rates"},
                    DativSingularSchwach=new List<String>(){"Geistlichen Rat"},
                    AkkusativSingularSchwach=new List<String>(){"Geistlichen Rat"},
                    NominativPluralSchwach=new List<String>(){"Geistlichen Räte"},
                    GenitivPluralSchwach=new List<String>(){"Geistlichen Räte"},
                    DativPluralSchwach=new List<String>(){"Geistlichen Räten"},
                    AkkusativPluralSchwach=new List<String>(){"Geistlichen Räte"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Neues()
        {
            String word = "Neues";
            int wiktionaryID = 276441;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Neue"},
                    GenitivSingularSchwach=new List<String>(){"Neuen"},
                    DativSingularSchwach=new List<String>(){"Neuen"},
                    AkkusativSingularSchwach=new List<String>(){"Neue"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Inneres()
        {
            String word = "Inneres";
            int wiktionaryID = 262083;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Innere"},
                    GenitivSingularSchwach=new List<String>(){"Inneren","Innern"},
                    DativSingularSchwach=new List<String>(){"Inneren","Innern"},
                    AkkusativSingularSchwach=new List<String>(){"Innere"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void DeutschesEck()
        {
            String word = "Deutsches Eck";
            int wiktionaryID = 26385;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Deutsche Eck"},
                    GenitivSingularSchwach=new List<String>(){"Deutschen Ecks"},
                    DativSingularSchwach=new List<String>(){"Deutschen Eck"},
                    AkkusativSingularSchwach=new List<String>(){"Deutsche Eck"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void GebrannteWasser()
        {
            String word = "Gebrannte Wasser";
            int wiktionaryID = 272460;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new AdjectivalDeclension()
                {
                    Text=word,
                    WiktionaryID = wiktionaryID,
                    NominativPlural=new List<string>(){"Gebrannte Wasser"},
                    GenitivPlural=new List<string>(){"Gebrannter Wasser"},
                    DativPlural=new List<string>(){"Gebrannten Wassern"},
                    AkkusativPlural=new List<string>(){"Gebrannte Wasser"},
                    NominativPluralSchwach=new List<String>(){"Gebrannten Wasser"},
                    GenitivPluralSchwach=new List<String>(){"Gebrannten Wasser"},
                    DativPluralSchwach=new List<String>(){"Gebrannten Wassern"},
                    AkkusativPluralSchwach=new List<String>(){"Gebrannten Wasser"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Gelbes()
        {
            String word = "Gelbes";
            int wiktionaryID = 23615;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Gelbe"},
                    GenitivSingularSchwach=new List<String>(){"Gelben"},
                    DativSingularSchwach=new List<String>(){"Gelben"},
                    AkkusativSingularSchwach=new List<String>(){"Gelbe"},
                    NominativPluralSchwach=new List<String>(){"Gelben"},
                    GenitivPluralSchwach=new List<String>(){"Gelben"},
                    DativPluralSchwach=new List<String>(){"Gelben"},
                    AkkusativPluralSchwach=new List<String>(){"Gelben"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Asoziale()
        {
            String word = "Asoziale";
            int wiktionaryID = 326483;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    NominativSingularSchwach=new List<String>(){"Asoziale"},
                    GenitivSingularSchwach=new List<String>(){"Asozialen"},
                    DativSingularSchwach=new List<String>(){"Asozialen"},
                    AkkusativSingularSchwach=new List<String>(){"Asoziale"},
                    NominativPluralSchwach=new List<String>(){"Asozialen"},
                    GenitivPluralSchwach=new List<String>(){"Asozialen"},
                    DativPluralSchwach=new List<String>(){"Asozialen"},
                    AkkusativPluralSchwach=new List<String>(){"Asozialen"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Beschäftigter()
        {
            String word = "Beschäftigter";
            int wiktionaryID = 137120;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

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
                    GenitivPlural=new List<string>(){"	Beschäftigter"},
                    DativPlural=new List<string>(){"Beschäftigten"},
                    AkkusativPlural=new List<string>(){"Beschäftigte"},
                    NominativSingularSchwach=new List<String>(){"Beschäftigte"},
                    GenitivSingularSchwach=new List<String>(){"Beschäftigten"},
                    DativSingularSchwach=new List<String>(){"Beschäftigten"},
                    AkkusativSingularSchwach=new List<String>(){"Beschäftigten"},
                    NominativPluralSchwach=new List<String>(){"Beschäftigten"},
                    GenitivPluralSchwach=new List<String>(){"Beschäftigten"},
                    DativPluralSchwach=new List<String>(){"Beschäftigten"},
                    AkkusativPluralSchwach=new List<String>(){"Beschäftigten"},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
