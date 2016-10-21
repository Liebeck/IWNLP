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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Bekannte"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Bekannten"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Bekannten"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Bekannten"}},
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Bekannten"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Bekannten"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Bekannten"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Bekannten"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Geistliche Rat"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Geistlichen Rats"},new Inflection(){ Article="des", InflectedWord="Geistlichen Rates"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Geistlichen Rat"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Geistlichen Rat"}},
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Geistlichen Räte"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Geistlichen Räte"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Geistlichen Räten"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Geistlichen Räte"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Neue"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Neuen"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Neuen"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Neue"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Innere"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Inneren"},new Inflection(){ Article="des", InflectedWord="Innern"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Inneren"},new Inflection(){ Article="dem", InflectedWord="Innern"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Innere"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Deutsche Eck"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Deutschen Ecks"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Deutschen Eck"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Deutsche Eck"}},
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
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gebrannten Wasser"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Gebrannten Wasser"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Gebrannten Wassern"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gebrannten Wasser"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Gelbe"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Gelben"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Gelben"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="das", InflectedWord="Gelbe"}},
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelben"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Gelben"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Gelben"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Gelben"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Asoziale"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Asozialen"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Asozialen"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Asoziale"}},
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Asozialen"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Asozialen"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Asozialen"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Asozialen"}},
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
                    NominativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Beschäftigte"}},
                    GenitivSingularSchwach=new List<Inflection>(){new Inflection(){ Article="des", InflectedWord="Beschäftigten"}},
                    DativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="dem", InflectedWord="Beschäftigten"}},
                    AkkusativSingularSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Beschäftigten"}},
                    NominativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Beschäftigten"}},
                    GenitivPluralSchwach=new List<Inflection>(){new Inflection(){ Article="der", InflectedWord="Beschäftigten"}},
                    DativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="den", InflectedWord="Beschäftigten"}},
                    AkkusativPluralSchwach=new List<Inflection>(){new Inflection(){ Article="die", InflectedWord="Beschäftigten"}},
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
