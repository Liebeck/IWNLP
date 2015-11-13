using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IWNLP.Parser;
using GenericXMLSerializer;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class VerbTests
    {
        [TestMethod]
        public void abblättern()
        {
            String word = "abblättern";
            int wiktionaryID = 19631;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text="abblättern",
                WiktionaryID = wiktionaryID,
                Präsens_Du = new List<string>(){"blätterst ab"},
                Präsens_ErSieEs = new List<string>(){"blättert ab"},
                Präsens_Ich = new List<string>(){"blättere ab", "blättre ab"},
                ImperativPlural = new List<string>(){"blättert ab!"},
                ImperativSingular = new List<string>(){"blättre ab!", "blättere ab!"},
                KonjunktivII_Ich = new List<string>(){"blätterte ab"},
                Präteritum_ich = new List<string>(){"blätterte ab"},
                PartizipII = new List<string>(){"abgeblättert"},
                Hilfsverb = "sein",
                POS = Models.POS.Verb
             },
            };
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }



        [TestMethod]
        public void erkälten()
        {
            String word = "erkälten";
            int wiktionaryID = 119977;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text="erkälten",
                WiktionaryID = wiktionaryID,
                Präsens_Du = new List<string>(){"erkältest dich"},
                Präsens_ErSieEs = new List<string>(){"erkältet sich"},
                Präsens_Ich = new List<string>(){"erkälte mich"},
                ImperativPlural = new List<string>(){"erkältet euch!"},
                ImperativSingular = new List<string>(){"erkälte dich!"},
                KonjunktivII_Ich = new List<string>(){"erkältete mich"},
                Präteritum_ich = new List<string>(){"erkältete mich"},
                PartizipII = new List<string>(){"sich erkältet"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };

            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void rennen()
        {
            String word = "rennen";
            int wiktionaryID = 17667;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"renne"},
                Präsens_Du = new List<string>(){"rennst"},
                Präsens_ErSieEs = new List<string>(){"rennt"},
                Präteritum_ich = new List<string>(){"rannte"},
                KonjunktivII_Ich = new List<string>(){"rennte"},
                ImperativSingular = new List<string>(){"renn!", "renne!"},
                ImperativPlural = new List<string>(){"rennt!"},
                PartizipII = new List<string>(){"gerannt"},
                Hilfsverb = "sein",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void aussortieren()
        {
            String word = "aussortieren";
            int wiktionaryID = 73284;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"sortiere aus", "aussortiere"},
                Präsens_Du = new List<string>(){"sortierst aus", "aussortierst"},
                Präsens_ErSieEs = new List<string>(){"sortiert aus", "aussortiert"},
                Präteritum_ich = new List<string>(){"sortierte aus", "aussortierte"},
                KonjunktivII_Ich = new List<string>(){"sortierte aus","aussortierte"},
                ImperativSingular = new List<string>(){"sortiere aus!", "sortier aus!"},
                ImperativPlural = new List<string>(){"sortiert aus!"},
                PartizipII = new List<string>(){"aussortiert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"sortiere aus", "aussortiere"},
                Präsens_Du = new List<string>(){"sortierst aus", "aussortierst"},
                Präsens_ErSieEs = new List<string>(){"sortiert aus", "aussortiert"},
                Präteritum_ich = new List<string>(){"sortierte aus", "aussortierte"},
                KonjunktivII_Ich = new List<string>(){"sortierte aus","aussortierte"},
                ImperativSingular = new List<string>(){"sortiere aus!", "sortier aus!"},
                ImperativPlural = new List<string>(){"sortiert aus!"},
                PartizipII = new List<string>(){"aussortiert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             }
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void versalzen()
        {
            String word = "versalzen";
            int wiktionaryID = 15963;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"versalze"},
                Präsens_Du = new List<string>(){"versalzt"},
                Präsens_ErSieEs = new List<string>(){"versalzt"},
                Präteritum_ich = new List<string>(){"versalzte"},
                KonjunktivII_Ich = new List<string>(){"versalzte"},
                ImperativSingular = new List<string>(){"versalze!"},
                ImperativPlural = new List<string>(){"versalzt!"},
                PartizipII = new List<string>(){"versalzen", "versalzt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void piken()
        {
            String word = "piken";
            int wiktionaryID = 263014;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"pike"},
                Präsens_Du = new List<string>(){"pikst"},
                Präsens_ErSieEs = new List<string>(){"pikt"},
                Präteritum_ich = new List<string>(){"pikte"},
                KonjunktivII_Ich = new List<string>(){"pikte"},
                ImperativSingular = new List<string>(){"pik!","pike!"},
                ImperativPlural = new List<string>(){"pikt!"},
                PartizipII = new List<string>(){"gepikt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void senden()
        {
            String word = "senden";
            int wiktionaryID = 61867;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"sende"},
                Präsens_Du = new List<string>(){"sendest"},
                Präsens_ErSieEs = new List<string>(){"sendet"},
                Präteritum_ich = new List<string>(){"sendete","sandte"},
                KonjunktivII_Ich = new List<string>(){"sendete"},
                ImperativSingular = new List<string>(){"sende!","send!"},
                ImperativPlural = new List<string>(){"sendet!"},
                PartizipII = new List<string>(){"gesendet","gesandt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void rinnen()
        {
            String word = "rinnen";
            int wiktionaryID = 58429;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"rinne"},
                Präsens_Du = new List<string>(){"rinnst"},
                Präsens_ErSieEs = new List<string>(){"rinnt"},
                Präteritum_ich = new List<string>(){"rann"},
                KonjunktivII_Ich = new List<string>(){"ränne","rönne"},
                ImperativSingular = new List<string>(){"rinn!","rinne!"},
                ImperativPlural = new List<string>(){"rinnt!"},
                PartizipII = new List<string>(){"geronnen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void fläzen()
        {
            String word = "fläzen";
            int wiktionaryID = 57154;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"fläze"},
                Präsens_Du = new List<string>(){"fläzt","fläzest"},
                Präsens_ErSieEs = new List<string>(){"fläzt"},
                Präteritum_ich = new List<string>(){"fläzte"},
                KonjunktivII_Ich = new List<string>(){"fläzte"},
                ImperativSingular = new List<string>(){"fläz!","fläze!"},
                ImperativPlural = new List<string>(){"fläzt!"},
                PartizipII = new List<string>(){"gefläzt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void überführen()
        {
            String word = "überführen";
            int wiktionaryID = 170180;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"überführe"},
                Präsens_Du = new List<string>(){"überführst"},
                Präsens_ErSieEs = new List<string>(){"überführt"},
                Präteritum_ich = new List<string>(){"überführte"},
                KonjunktivII_Ich = new List<string>(){"überführte"},
                ImperativSingular = new List<string>(){"überführe!"},
                ImperativPlural = new List<string>(){"überführt!"},
                PartizipII = new List<string>(){"übergeführt","überführt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void speisen()
        {
            String word = "speisen";
            int wiktionaryID = 89118;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"speise"},
                Präsens_Du = new List<string>(){"speist"},
                Präsens_ErSieEs = new List<string>(){"speist"},
                Präteritum_ich = new List<string>(){"speiste"},
                KonjunktivII_Ich = new List<string>(){"speiste"},
                ImperativSingular = new List<string>(){"speise!"},
                ImperativPlural = new List<string>(){"speiset!"},
                PartizipII = new List<string>(){"gespeist","gespiesen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void scheren()
        {
            String word = "scheren";
            int wiktionaryID = 133553;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schere"},
                Präsens_Du = new List<string>(){"scherst"},
                Präsens_ErSieEs = new List<string>(){"schert"},
                Präteritum_ich = new List<string>(){"schor","scherte"},
                KonjunktivII_Ich = new List<string>(){"schöre","scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschoren","geschert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schere"},
                Präsens_Du = new List<string>(){"scherst"},
                Präsens_ErSieEs = new List<string>(){"schert","schiert"},
                Präteritum_ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schere"},
                Präsens_Du = new List<string>(){"scherst"},
                Präsens_ErSieEs = new List<string>(){"schert"},
                Präteritum_ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                Hilfsverb2="sein",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schere"},
                Präsens_Du = new List<string>(){"scherst"},
                Präsens_ErSieEs = new List<string>(){"schert"},
                Präteritum_ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schere"},
                Präsens_Du = new List<string>(){"scherst"},
                Präsens_ErSieEs = new List<string>(){"schert"},
                Präteritum_ich = new List<string>(){"schor"},
                KonjunktivII_Ich = new List<string>(){"schöre"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschoren"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void scheuen()
        {
            String word = "scheuen";
            int wiktionaryID = 123860;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"scheue"},
                Präsens_Du = new List<string>(){"scheust"},
                Präsens_ErSieEs = new List<string>(){"scheut"},
                Präteritum_ich = new List<string>(){"scheute"},
                KonjunktivII_Ich = new List<string>(){"scheute"},
                ImperativSingular = new List<string>(){"scheue!"},
                ImperativPlural = new List<string>(){"scheut!","scheuet!"},
                PartizipII = new List<string>(){"gescheut"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void hereinkommen()
        {
            String word = "hereinkommen";
            int wiktionaryID = 38586;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"komme herein"},
                Präsens_Du = new List<string>(){"kommst herein"},
                Präsens_ErSieEs = new List<string>(){"kommt herein"},
                Präteritum_ich = new List<string>(){"kam herein"},
                KonjunktivII_Ich = new List<string>(){"käme herein"},
                ImperativSingular = new List<string>(){"komm herein!","Herein!"},
                ImperativPlural = new List<string>(){"kommt herein!","Herein!"},
                PartizipII = new List<string>(){"hereingekommen"},
                Hilfsverb = "sein",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<Models.Word>(expectedWords[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<Models.Word>((Models.Word)words[0], System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void fladern()
        {
            String word = "fladern";
            int wiktionaryID = 23990;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"fladere"},
                Präsens_Du = new List<string>(){"fladerst"},
                Präsens_ErSieEs = new List<string>(){"fladert"},
                Präteritum_ich = new List<string>(){"fladerte"},
                KonjunktivII_Ich = new List<string>(){"fladerte"},
                ImperativSingular = new List<string>(){"flader!"},
                ImperativPlural = new List<string>(){"fladert!"},
                PartizipII = new List<string>(){"gefladert", "g'fladert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"flader"},
                Präsens_Du = new List<string>(){"fladersd","fladerschd"},
                Präsens_ErSieEs = new List<string>(){"fladerd"},
                KonjunktivII_Ich = new List<string>(){"dad fladern"},
                ImperativSingular = new List<string>(){"flader!"},
                ImperativPlural = new List<string>(){"fladerd!"},
                PartizipII = new List<string>(){"gefladerd", "g'fladerd"},
                Hilfsverb = "homm",
                POS = Models.POS.Verb
             }
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void abbröckeln()
        {
            String word = "abbröckeln";
            int wiktionaryID = 19632;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"bröckele ab","bröckle ab"},
                Präsens_Du = new List<string>(){"bröckelst ab"},
                Präsens_ErSieEs = new List<string>(){"bröckelt ab"},
                Präteritum_ich = new List<string>(){"bröckelte ab"},
                KonjunktivII_Ich = new List<string>(){"bröckelte ab"},
                ImperativSingular = new List<string>(){"bröckele ab!","bröckle ab!"},
                ImperativPlural = new List<string>(){"bröckelt ab!"},
                PartizipII = new List<string>(){"abgebröckelt"},
                Hilfsverb = "haben",
                Hilfsverb2="sein",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void salzen()
        {
            String word = "salzen";
            int wiktionaryID = 105842;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"salze"},
                Präsens_Du = new List<string>(){"salzt"},
                Präsens_ErSieEs = new List<string>(){"salzt"},
                Präteritum_ich = new List<string>(){"salzte"},
                KonjunktivII_Ich = new List<string>(){"salzte"},
                ImperativSingular = new List<string>(){"salz!","salze!"},
                ImperativPlural = new List<string>(){"salzt!"},
                PartizipII = new List<string>(){"gesalzen","gesalzt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void blinzeln()
        {
            String word = "blinzeln";
            int wiktionaryID = 131259;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"blinzle","blinzele"},
                Präsens_Du = new List<string>(){"blinzelst"},
                Präsens_ErSieEs = new List<string>(){"blinzelt"},
                Präteritum_ich = new List<string>(){"blinzelte"},
                KonjunktivII_Ich = new List<string>(){"blinzelte"},
                ImperativSingular = new List<string>(){"blinzele!","blinzle!","blinzel!"},
                ImperativPlural = new List<string>(){"blinzelt!"},
                PartizipII = new List<string>(){"geblinzelt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void stiefeln()
        {
            String word = "stiefeln";
            int wiktionaryID = 267216;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"stiefele","stiefle"},
                Präsens_Du = new List<string>(){"stiefelst"},
                Präsens_ErSieEs = new List<string>(){"stiefelt"},
                Präteritum_ich = new List<string>(){"stiefelte"},
                KonjunktivII_Ich = new List<string>(){"stiefelte"},
                ImperativSingular = new List<string>(){"stiefele!","stiefle!"},
                ImperativPlural = new List<string>(){"stiefelt!"},
                PartizipII = new List<string>(){"gestiefelt"},
                Hilfsverb = "sein",
                Hilfsverb2="haben",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"stiefele","stiefle"},
                Präsens_Du = new List<string>(){"stiefelst"},
                Präsens_ErSieEs = new List<string>(){"stiefelt"},
                Präteritum_ich = new List<string>(){"stiefelte"},
                KonjunktivII_Ich = new List<string>(){"stiefelte"},
                ImperativSingular = new List<string>(){"stiefele!","stiefle!"},
                ImperativPlural = new List<string>(){"stiefelt!"},
                PartizipII = new List<string>(){"gestiefelt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             }
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void kriegen()
        {
            String word = "kriegen";
            int wiktionaryID = 4154;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"kriege","krich"},
                Präsens_Du = new List<string>(){"kriegst"},
                Präsens_ErSieEs = new List<string>(){"kriegt"},
                Präteritum_ich = new List<string>(){"kriegte"},
                KonjunktivII_Ich = new List<string>(){"kriegte"},
                ImperativSingular = new List<string>(){"krieg!","kriege!"},
                ImperativPlural = new List<string>(){"kriegt!"},
                PartizipII = new List<string>(){"gekriegt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void fragen()
        {
            String word = "fragen";
            int wiktionaryID = 26753;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"frage"},
                Präsens_Du = new List<string>(){"fragst","frägst"},
                Präsens_ErSieEs = new List<string>(){"fragt","frägt"},
                Präteritum_ich = new List<string>(){"fragte","frug"},
                KonjunktivII_Ich = new List<string>(){"fragte","früge"},
                ImperativSingular = new List<string>(){"frag!","frage!"},
                ImperativPlural = new List<string>(){"fragt!"},
                PartizipII = new List<string>(){"gefragt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void leiden()
        {
            String word = "leiden";
            int wiktionaryID = 35996;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"leide"},
                Präsens_Du = new List<string>(){"leidest"},
                Präsens_ErSieEs = new List<string>(){"leidet"},
                Präteritum_ich = new List<string>(){"litt"},
                KonjunktivII_Ich = new List<string>(){"litte"},
                ImperativSingular = new List<string>(){"leide!","leid!"},
                ImperativPlural = new List<string>(){"leidet!"},
                PartizipII = new List<string>(){"gelitten"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void küren()
        {
            String word = "küren";
            int wiktionaryID = 49173;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"küre"},
                Präsens_Du = new List<string>(){"kürst"},
                Präsens_ErSieEs = new List<string>(){"kürt"},
                Präteritum_ich = new List<string>(){"kürte","kor"},
                KonjunktivII_Ich = new List<string>(){"kürte"},
                ImperativSingular = new List<string>(){"kür!","küre!"},
                ImperativPlural = new List<string>(){"kürt!"},
                PartizipII = new List<string>(){"gekürt","gekoren"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void reinpfeifen()
        {
            String word = "reinpfeifen";
            int wiktionaryID = 70422;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void werden()
        {
            String word = "werden";
            int wiktionaryID = 19432;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"werde"},
                Präsens_Du = new List<string>(){"wirst"},
                Präsens_ErSieEs = new List<string>(){"wird"},
                Präteritum_ich = new List<string>(){"wurde","ward"},
                KonjunktivII_Ich = new List<string>(){"würde"},
                ImperativSingular = new List<string>(){"werde!"},
                ImperativPlural = new List<string>(){"werdet!"},
                PartizipII = new List<string>(){"worden","geworden"},
                Hilfsverb = "sein",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void helfen()
        {
            String word = "helfen";
            int wiktionaryID = 20629;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"helfe"},
                Präsens_Du = new List<string>(){"hilfst"},
                Präsens_ErSieEs = new List<string>(){"hilft"},
                Präteritum_ich = new List<string>(){"half"},
                KonjunktivII_Ich = new List<string>(){"hülfe","hälfe"},
                ImperativSingular = new List<string>(){"hilf!"},
                ImperativPlural = new List<string>(){"helft!"},
                PartizipII = new List<string>(){"geholfen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void menstruieren()
        {
            String word = "menstruieren";
            int wiktionaryID = 278455;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"menstruiere"},
                Präsens_Du = new List<string>(){"menstruierst"},
                Präsens_ErSieEs = new List<string>(){"menstruiert"},
                Präteritum_ich = new List<string>(){"menstruierte"},
                KonjunktivII_Ich = new List<string>(){"menstruierte"},
                ImperativSingular = new List<string>(){"menstruiere!","menstruier!"},
                ImperativPlural = new List<string>(){"menstruiert!"},
                PartizipII = new List<string>(){"menstruiert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void weiterhelfen()
        {
            String word = "weiterhelfen";
            int wiktionaryID = 419694;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"helfe weiter"},
                Präsens_Du = new List<string>(){"hilfst weiter"},
                Präsens_ErSieEs = new List<string>(){"hilft weiter"},
                Präteritum_ich = new List<string>(){"half weiter"},
                KonjunktivII_Ich = new List<string>(){"hülfe weiter","hälfe weiter"},
                ImperativSingular = new List<string>(){"hilf weiter!"},
                ImperativPlural = new List<string>(){"helft weiter!"},
                PartizipII = new List<string>(){"weitergeholfen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void nachsalzen()
        {
            String word = "nachsalzen";
            int wiktionaryID = 443127;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"salze nach"},
                Präsens_Du = new List<string>(){"salzt nach"},
                Präsens_ErSieEs = new List<string>(){"salzt nach"},
                Präteritum_ich = new List<string>(){"salzte nach"},
                KonjunktivII_Ich = new List<string>(){"salzte nach"},
                ImperativSingular = new List<string>(){"salz nach!","salze nach!"},
                ImperativPlural = new List<string>(){"salzt nach!"},
                PartizipII = new List<string>(){"nachgesalzen","nachgesalzt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void saugen()
        {
            String word = "saugen";
            int wiktionaryID = 11720;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"sauge"},
                Präsens_Du = new List<string>(){"saugst"},
                Präsens_ErSieEs = new List<string>(){"saugt"},
                Präteritum_ich = new List<string>(){"saugte","sog"},
                KonjunktivII_Ich = new List<string>(){"saugte","söge"},
                ImperativSingular = new List<string>(){"saug!"},
                ImperativPlural = new List<string>(){"saugt!"},
                PartizipII = new List<string>(){"gesaugt","gesogen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void schwören()
        {
            String word = "schwören";
            int wiktionaryID = 116807;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"schwöre"},
                Präsens_Du = new List<string>(){"schwörst"},
                Präsens_ErSieEs = new List<string>(){"schwört"},
                Präteritum_ich = new List<string>(){"schwor","schwur","schwörte"},
                KonjunktivII_Ich = new List<string>(){"schwüre"},
                ImperativSingular = new List<string>(){"schwöre!"},
                ImperativPlural = new List<string>(){"schwört!"},
                PartizipII = new List<string>(){"geschworen"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void aussaugen()
        {
            String word = "aussaugen";
            int wiktionaryID = 60336;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"sauge aus"},
                Präsens_Du = new List<string>(){"saugst aus"},
                Präsens_ErSieEs = new List<string>(){"saugt aus"},
                Präteritum_ich = new List<string>(){"sog aus","saugte aus"},
                KonjunktivII_Ich = new List<string>(){"söge aus","saugte aus"},
                ImperativSingular = new List<string>(){"sauge aus!"},
                ImperativPlural = new List<string>(){"sauget aus!","saugt aus!"},
                PartizipII = new List<string>(){"ausgesogen","ausgesaugt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void angrenzen()
        {
            String word = "angrenzen";
            int wiktionaryID = 135797;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"grenze an"},
                Präsens_Du = new List<string>(){"grenzt an"},
                Präsens_ErSieEs = new List<string>(){"grenzt an"},
                Präteritum_ich = new List<string>(){"grenzte an"},
                KonjunktivII_Ich = new List<string>(){"grenzte an"},
                ImperativSingular = new List<string>(){"grenze an!"},
                ImperativPlural = new List<string>(){"grenzt an!"},
                PartizipII = new List<string>(){"angegrenzt"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void verheeren()
        {
            String word = "verheeren";
            int wiktionaryID = 494402;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_ErSieEs = new List<string>(){"verheert"},
                PartizipII = new List<string>(){"verheert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void erfoltern()
        {
            String word = "erfoltern";
            int wiktionaryID = 498182;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Präsens_Ich = new List<string>(){"erfoltere"},
                Präsens_Du = new List<string>(){"erfolterst"},
                Präsens_ErSieEs = new List<string>(){"erfoltert"},
                Präteritum_ich = new List<string>(){"erfolterte"},
                KonjunktivII_Ich = new List<string>(){"erfolterte"},
                ImperativSingular = new List<string>(){"erfolter!","erfoltere!"},
                ImperativPlural = new List<string>(){"erfoltert!"},
                PartizipII = new List<string>(){"erfoltert"},
                Hilfsverb = "haben",
                POS = Models.POS.Verb
             },
            };
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
