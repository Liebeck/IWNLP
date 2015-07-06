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
            String filename = @"..\..\TestInput\Verbs\abblättern.txt";
            int wiktionaryID = 19631;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text="abblättern",
                WiktionaryID = wiktionaryID,
                Gegenwart_Du = new List<string>(){"blätterst ab"},
                Gegenwart_ErSieEs = new List<string>(){"blättert ab"},
                Gegenwart_Ich = new List<string>(){"blättere ab", "blättre ab"},
                ImperativPlural = new List<string>(){"blättert ab!"},
                ImperativSingular = new List<string>(){"blättre ab!", "blättere ab!"},
                KonjunktivII_Ich = new List<string>(){"blätterte ab"},
                Vergangenheit1_Ich = new List<string>(){"blätterte ab"},
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
            String filename = @"..\..\TestInput\Verbs\erkälten.txt";
            int wiktionaryID = 119977;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text="erkälten",
                WiktionaryID = wiktionaryID,
                Gegenwart_Du = new List<string>(){"erkältest dich"},
                Gegenwart_ErSieEs = new List<string>(){"erkältet sich"},
                Gegenwart_Ich = new List<string>(){"erkälte mich"},
                ImperativPlural = new List<string>(){"erkältet euch!"},
                ImperativSingular = new List<string>(){"erkälte dich!"},
                KonjunktivII_Ich = new List<string>(){"erkältete mich"},
                Vergangenheit1_Ich = new List<string>(){"erkältete mich"},
                PartizipII = new List<string>(){"sich erkältet"},
                Hilfsverb = "haben",
                WeitereKonjugationen = "erkälten (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\rennen.txt";
            int wiktionaryID = 17667;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"renne"},
                Gegenwart_Du = new List<string>(){"rennst"},
                Gegenwart_ErSieEs = new List<string>(){"rennt"},
                Vergangenheit1_Ich = new List<string>(){"rannte"},
                KonjunktivII_Ich = new List<string>(){"rennte"},
                ImperativSingular = new List<string>(){"renn!", "renne!"},
                ImperativPlural = new List<string>(){"rennt!"},
                PartizipII = new List<string>(){"gerannt"},
                Hilfsverb = "sein",
                WeitereKonjugationen = "rennen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\aussortieren.txt";
            int wiktionaryID = 73284;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"sortiere aus", "aussortiere"},
                Gegenwart_Du = new List<string>(){"sortierst aus", "aussortierst"},
                Gegenwart_ErSieEs = new List<string>(){"sortiert aus", "aussortiert"},
                Vergangenheit1_Ich = new List<string>(){"sortierte aus", "aussortierte"},
                KonjunktivII_Ich = new List<string>(){"sortierte aus","aussortierte"},
                ImperativSingular = new List<string>(){"sortiere aus!", "sortier aus!"},
                ImperativPlural = new List<string>(){"sortiert aus!"},
                PartizipII = new List<string>(){"aussortiert"},
                Hilfsverb = "haben",
                WeitereKonjugationen = "aussortieren (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"sortiere aus", "aussortiere"},
                Gegenwart_Du = new List<string>(){"sortierst aus", "aussortierst"},
                Gegenwart_ErSieEs = new List<string>(){"sortiert aus", "aussortiert"},
                Vergangenheit1_Ich = new List<string>(){"sortierte aus", "aussortierte"},
                KonjunktivII_Ich = new List<string>(){"sortierte aus","aussortierte"},
                ImperativSingular = new List<string>(){"sortiere aus!", "sortier aus!"},
                ImperativPlural = new List<string>(){"sortiert aus!"},
                PartizipII = new List<string>(){"aussortiert"},
                Hilfsverb = "haben",
                WeitereKonjugationen = "aussortieren (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\versalzen.txt";
            int wiktionaryID = 15963;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"versalze"},
                Gegenwart_Du = new List<string>(){"versalzt"},
                Gegenwart_ErSieEs = new List<string>(){"versalzt"},
                Vergangenheit1_Ich = new List<string>(){"versalzte"},
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
            String filename = @"..\..\TestInput\Verbs\piken.txt";
            int wiktionaryID = 263014;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"pike"},
                Gegenwart_Du = new List<string>(){"pikst"},
                Gegenwart_ErSieEs = new List<string>(){"pikt"},
                Vergangenheit1_Ich = new List<string>(){"pikte"},
                KonjunktivII_Ich = new List<string>(){"pikte"},
                ImperativSingular = new List<string>(){"pik!","pike!"},
                ImperativPlural = new List<string>(){"pikt!"},
                PartizipII = new List<string>(){"gepikt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="piken (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\senden.txt";
            int wiktionaryID = 61867;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"sende"},
                Gegenwart_Du = new List<string>(){"sendest"},
                Gegenwart_ErSieEs = new List<string>(){"sendet"},
                Vergangenheit1_Ich = new List<string>(){"sendete","sandte"},
                KonjunktivII_Ich = new List<string>(){"sendete"},
                ImperativSingular = new List<string>(){"sende!","send!"},
                ImperativPlural = new List<string>(){"sendet!"},
                PartizipII = new List<string>(){"gesendet","gesandt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="senden (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\rinnen.txt";
            int wiktionaryID = 58429;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"rinne"},
                Gegenwart_Du = new List<string>(){"rinnst"},
                Gegenwart_ErSieEs = new List<string>(){"rinnt"},
                Vergangenheit1_Ich = new List<string>(){"rann"},
                KonjunktivII_Ich = new List<string>(){"ränne","rönne"},
                ImperativSingular = new List<string>(){"rinn!","rinne!"},
                ImperativPlural = new List<string>(){"rinnt!"},
                PartizipII = new List<string>(){"geronnen"},
                Hilfsverb = "haben",
                WeitereKonjugationen="rinnen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\fläzen.txt";
            int wiktionaryID = 198892;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"fläze"},
                Gegenwart_Du = new List<string>(){"fläzt","fläzest"},
                Gegenwart_ErSieEs = new List<string>(){"fläzt"},
                Vergangenheit1_Ich = new List<string>(){"fläzte"},
                KonjunktivII_Ich = new List<string>(){"fläzte"},
                ImperativSingular = new List<string>(){"fläz!","fläze!"},
                ImperativPlural = new List<string>(){"fläzt!"},
                PartizipII = new List<string>(){"gefläzt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="fläzen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\überführen.txt";
            int wiktionaryID = 170180;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"überführe"},
                Gegenwart_Du = new List<string>(){"überführst"},
                Gegenwart_ErSieEs = new List<string>(){"überführt"},
                Vergangenheit1_Ich = new List<string>(){"überführte"},
                KonjunktivII_Ich = new List<string>(){"überführte"},
                ImperativSingular = new List<string>(){"überführe!"},
                ImperativPlural = new List<string>(){"überführt!"},
                PartizipII = new List<string>(){"übergeführt","überführt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="überführen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\speisen.txt";
            int wiktionaryID = 89118;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"speise"},
                Gegenwart_Du = new List<string>(){"speist"},
                Gegenwart_ErSieEs = new List<string>(){"speist"},
                Vergangenheit1_Ich = new List<string>(){"speiste"},
                KonjunktivII_Ich = new List<string>(){"speiste"},
                ImperativSingular = new List<string>(){"speise!"},
                ImperativPlural = new List<string>(){"speiset!"},
                PartizipII = new List<string>(){"gespeist","gespiesen"},
                Hilfsverb = "haben",
                WeitereKonjugationen="speisen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\scheren.txt";
            int wiktionaryID = 133553;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schere"},
                Gegenwart_Du = new List<string>(){"scherst"},
                Gegenwart_ErSieEs = new List<string>(){"schert"},
                Vergangenheit1_Ich = new List<string>(){"schor","scherte"},
                KonjunktivII_Ich = new List<string>(){"schöre","scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschoren","geschert"},
                Hilfsverb = "haben",
                WeitereKonjugationen="scheren (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schere"},
                Gegenwart_Du = new List<string>(){"scherst"},
                Gegenwart_ErSieEs = new List<string>(){"schert","schiert"},
                Vergangenheit1_Ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                WeitereKonjugationen="scheren (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schere"},
                Gegenwart_Du = new List<string>(){"scherst"},
                Gegenwart_ErSieEs = new List<string>(){"schert"},
                Vergangenheit1_Ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                Hilfsverb2="sein",
                WeitereKonjugationen="scheren (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schere"},
                Gegenwart_Du = new List<string>(){"scherst"},
                Gegenwart_ErSieEs = new List<string>(){"schert"},
                Vergangenheit1_Ich = new List<string>(){"scherte"},
                KonjunktivII_Ich = new List<string>(){"scherte"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschert"},
                Hilfsverb = "haben",
                WeitereKonjugationen="scheren (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schere"},
                Gegenwart_Du = new List<string>(){"scherst"},
                Gegenwart_ErSieEs = new List<string>(){"schert"},
                Vergangenheit1_Ich = new List<string>(){"schor"},
                KonjunktivII_Ich = new List<string>(){"schöre"},
                ImperativSingular = new List<string>(){"schere!"},
                ImperativPlural = new List<string>(){"schert!"},
                PartizipII = new List<string>(){"geschoren"},
                Hilfsverb = "haben",
                WeitereKonjugationen="scheren (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\scheuen.txt";
            int wiktionaryID = 123860;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"scheue"},
                Gegenwart_Du = new List<string>(){"scheust"},
                Gegenwart_ErSieEs = new List<string>(){"scheut"},
                Vergangenheit1_Ich = new List<string>(){"scheute"},
                KonjunktivII_Ich = new List<string>(){"scheute"},
                ImperativSingular = new List<string>(){"scheue!"},
                ImperativPlural = new List<string>(){"scheut!","scheuet!"},
                PartizipII = new List<string>(){"gescheut"},
                Hilfsverb = "haben",
                WeitereKonjugationen="scheuen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\hereinkommen.txt";
            int wiktionaryID = 38586;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"komme herein"},
                Gegenwart_Du = new List<string>(){"kommst herein"},
                Gegenwart_ErSieEs = new List<string>(){"kommt herein"},
                Vergangenheit1_Ich = new List<string>(){"kam herein"},
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
            String filename = @"..\..\TestInput\Verbs\fladern.txt";
            int wiktionaryID = 23990;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"fladere"},
                Gegenwart_Du = new List<string>(){"fladerst"},
                Gegenwart_ErSieEs = new List<string>(){"fladert"},
                Vergangenheit1_Ich = new List<string>(){"fladerte"},
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
                Gegenwart_Ich = new List<string>(){"flader"},
                Gegenwart_Du = new List<string>(){"fladersd","fladerschd"},
                Gegenwart_ErSieEs = new List<string>(){"fladerd"},
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
            String filename = @"..\..\TestInput\Verbs\abbröckeln.txt";
            int wiktionaryID = 19632;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"bröckele ab","bröckle ab"},
                Gegenwart_Du = new List<string>(){"bröckelst ab"},
                Gegenwart_ErSieEs = new List<string>(){"bröckelt ab"},
                Vergangenheit1_Ich = new List<string>(){"bröckelte ab"},
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
            String filename = @"..\..\TestInput\Verbs\salzen.txt";
            int wiktionaryID = 105842;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"salze"},
                Gegenwart_Du = new List<string>(){"salzt"},
                Gegenwart_ErSieEs = new List<string>(){"salzt"},
                Vergangenheit1_Ich = new List<string>(){"salzte"},
                KonjunktivII_Ich = new List<string>(){"salzte"},
                ImperativSingular = new List<string>(){"salz!","salze!"},
                ImperativPlural = new List<string>(){"salzt!"},
                PartizipII = new List<string>(){"gesalzen","gesalzt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="salzen (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\blinzeln.txt";
            int wiktionaryID = 131259;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"blinzle","blinzele"},
                Gegenwart_Du = new List<string>(){"blinzelst"},
                Gegenwart_ErSieEs = new List<string>(){"blinzelt"},
                Vergangenheit1_Ich = new List<string>(){"blinzelte"},
                KonjunktivII_Ich = new List<string>(){"blinzelte"},
                ImperativSingular = new List<string>(){"blinzele!","blinzle!","blinzel!"},
                ImperativPlural = new List<string>(){"blinzelt!"},
                PartizipII = new List<string>(){"geblinzelt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="blinzeln (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\stiefeln.txt";
            int wiktionaryID = 267216;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"stiefele","stiefle"},
                Gegenwart_Du = new List<string>(){"stiefelst"},
                Gegenwart_ErSieEs = new List<string>(){"stiefelt"},
                Vergangenheit1_Ich = new List<string>(){"stiefelte"},
                KonjunktivII_Ich = new List<string>(){"stiefelte"},
                ImperativSingular = new List<string>(){"stiefele!","stiefle!"},
                ImperativPlural = new List<string>(){"stiefelt!"},
                PartizipII = new List<string>(){"gestiefelt"},
                Hilfsverb = "sein",
                Hilfsverb2="haben",
                WeitereKonjugationen="stiefeln (Konjugation)",
                POS = Models.POS.Verb
             },
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"stiefele","stiefle"},
                Gegenwart_Du = new List<string>(){"stiefelst"},
                Gegenwart_ErSieEs = new List<string>(){"stiefelt"},
                Vergangenheit1_Ich = new List<string>(){"stiefelte"},
                KonjunktivII_Ich = new List<string>(){"stiefelte"},
                ImperativSingular = new List<string>(){"stiefele!","stiefle!"},
                ImperativPlural = new List<string>(){"stiefelt!"},
                PartizipII = new List<string>(){"gestiefelt"},
                Hilfsverb = "haben",
                WeitereKonjugationen="stiefeln (Konjugation)",
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
            String filename = @"..\..\TestInput\Verbs\kriegen.txt";
            int wiktionaryID = 4154;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"kriege","krich"},
                Gegenwart_Du = new List<string>(){"kriegst"},
                Gegenwart_ErSieEs = new List<string>(){"kriegt"},
                Vergangenheit1_Ich = new List<string>(){"kriegte"},
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
            String filename = @"..\..\TestInput\Verbs\fragen.txt";
            int wiktionaryID = 26753;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"frage"},
                Gegenwart_Du = new List<string>(){"fragst","frägst"},
                Gegenwart_ErSieEs = new List<string>(){"fragt","frägt"},
                Vergangenheit1_Ich = new List<string>(){"fragte","frug"},
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
            String filename = @"..\..\TestInput\Verbs\leiden.txt";
            int wiktionaryID = 35996;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"leide"},
                Gegenwart_Du = new List<string>(){"leidest"},
                Gegenwart_ErSieEs = new List<string>(){"leidet"},
                Vergangenheit1_Ich = new List<string>(){"litt"},
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
            String filename = @"..\..\TestInput\Verbs\kueren.txt";
            int wiktionaryID = 35996;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"küre"},
                Gegenwart_Du = new List<string>(){"kürst"},
                Gegenwart_ErSieEs = new List<string>(){"kürt"},
                Vergangenheit1_Ich = new List<string>(){"kürte","kor"},
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
            String filename = @"..\..\TestInput\Verbs\reinpfeifen.txt";
            int wiktionaryID = 70422;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>();
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void werden()
        {
            String word = "werden";
            String filename = @"..\..\TestInput\Verbs\werden.txt";
            int wiktionaryID = 19432;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"werde"},
                Gegenwart_Du = new List<string>(){"wirst"},
                Gegenwart_ErSieEs = new List<string>(){"wird"},
                Vergangenheit1_Ich = new List<string>(){"wurde","ward"},
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
            String filename = @"..\..\TestInput\Verbs\helfen.txt";
            int wiktionaryID = 20629;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"helfe"},
                Gegenwart_Du = new List<string>(){"hilfst"},
                Gegenwart_ErSieEs = new List<string>(){"hilft"},
                Vergangenheit1_Ich = new List<string>(){"half"},
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
            String filename = @"..\..\TestInput\Verbs\menstruieren.txt";
            int wiktionaryID = 278455;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"menstruiere"},
                Gegenwart_Du = new List<string>(){"menstruierst"},
                Gegenwart_ErSieEs = new List<string>(){"menstruiert"},
                Vergangenheit1_Ich = new List<string>(){"menstruierte"},
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
            String filename = @"..\..\TestInput\Verbs\weiterhelfen.txt";
            int wiktionaryID = 419694;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"helfe weiter"},
                Gegenwart_Du = new List<string>(){"hilfst weiter"},
                Gegenwart_ErSieEs = new List<string>(){"hilft weiter"},
                Vergangenheit1_Ich = new List<string>(){"half weiter"},
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
            String filename = @"..\..\TestInput\Verbs\nachsalzen.txt";
            int wiktionaryID = 443127;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"salze nach"},
                Gegenwart_Du = new List<string>(){"salzt nach"},
                Gegenwart_ErSieEs = new List<string>(){"salzt nach"},
                Vergangenheit1_Ich = new List<string>(){"salzte nach"},
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
            String filename = @"..\..\TestInput\Verbs\saugen.txt";
            int wiktionaryID = 11720;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"sauge"},
                Gegenwart_Du = new List<string>(){"saugst"},
                Gegenwart_ErSieEs = new List<string>(){"saugt"},
                Vergangenheit1_Ich = new List<string>(){"saugte","sog"},
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
            String filename = @"..\..\TestInput\Verbs\schwoeren.txt";
            int wiktionaryID = 116807;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"schwöre"},
                Gegenwart_Du = new List<string>(){"schwörst"},
                Gegenwart_ErSieEs = new List<string>(){"schwört"},
                Vergangenheit1_Ich = new List<string>(){"schwor","schwur","schwörte"},
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
            String filename = @"..\..\TestInput\Verbs\aussaugen.txt";
            int wiktionaryID = 60336;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"sauge aus"},
                Gegenwart_Du = new List<string>(){"saugst aus"},
                Gegenwart_ErSieEs = new List<string>(){"saugt aus"},
                Vergangenheit1_Ich = new List<string>(){"sog aus","saugte aus"},
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
            String filename = @"..\..\TestInput\Verbs\angrenzen.txt";
            int wiktionaryID = 135797;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_Ich = new List<string>(){"grenze an"},
                Gegenwart_Du = new List<string>(){"grenzt an"},
                Gegenwart_ErSieEs = new List<string>(){"grenzt an"},
                Vergangenheit1_Ich = new List<string>(){"grenzte an"},
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
            String filename = @"..\..\TestInput\Verbs\verheeren.txt";
            int wiktionaryID = 494402;
            String text = Common.ReadFromFile(filename);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
             new Models.Verb()
             {
                Text=word,
                WiktionaryID = wiktionaryID,
                Gegenwart_ErSieEs = new List<string>(){"verheert"},
                PartizipII = new List<string>(){"verheert"},
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
