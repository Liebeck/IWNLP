using GenericXMLSerializer;
using IWNLP.Models.Flections;
using IWNLP.Parser;
using IWNLP.Parser.FlexParser.VerbTemplates.regelmaessig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class VerbRegelmaessigTests
    {
        [TestMethod]
        public void backen()
        {
            String word = "backen";
            int wikiID = 10394;
            String text = DumpTextCaching.GetTextFromPage(wikiID);
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"backe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"bäckst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"bäckt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"backen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"backt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"backen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"buk"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"bukst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"buk"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"buken"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"bukt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"buken"},
                    PartizipII = "gebacken"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"backe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"backst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"backt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"backen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"backt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"backen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"backte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"backtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"backte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"backten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"backtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"backten"},
                    PartizipII = "gebackt"
                 },

            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void fluten()
        {
            String word = "fluten";
            int wikiID = 38588;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"flute"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"flutest"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"flutet"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"fluten"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"flutet"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"fluten"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"flutete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"flutetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"flutete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"fluteten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"flutetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"fluteten"},
                    PartizipII = "geflutet"
                 },
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"flute"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"flutest"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"flutet"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"fluten"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"flutet"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"fluten"},     
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"flutete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"flutetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"flutete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"fluteten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"flutetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"fluteten"},
                    PartizipII = "geflutet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void abspeichern()
        {
            String word = "abspeichern";
            int wikiID = 116558;
            String text = DumpTextCaching.GetTextFromPage(wikiID);
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"speicher ab","speichere ab", "speichre ab"},
                     PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abspeicher", "abspeichere", "abspeichre"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"speicherst ab"},
                   PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abspeicherst"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"speichert ab"},
                   PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"abspeichert"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"speichern ab"},
                   PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"abspeichern"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"speichert ab"},
                   PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"abspeichert"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"speichern ab"},    
                   PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"abspeichern"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"speicherte ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abspeicherte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"speichertest ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abspeichertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"speicherte ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abspeicherte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"speicherten ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abspeicherten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"speichertet ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abspeichertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"speicherten ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abspeicherten"},
                    PartizipII = "abgespeichert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void wärmebehandeln()
        {
            String word = "wärmebehandeln";
            int wikiID = 132176;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                   WiktionaryID = wikiID,
                    PartizipII = "wärmebehandelt"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void regnen()
        {
            String word = "regnen";
            int wikiID = 427337;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                   WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"regnet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"regnen"},
                    PräteritumAktivIndikativ_Singular3Person = new List<string>(){"regnete"},
                    PräteritumAktivIndikativ_Plural3Person = new List<string>(){"regneten"},
                    PartizipII = "geregnet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void durchixen()
        {
            String word = "durchixen";
            int wikiID = 153011;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"ixe durch"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchixe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"ixst durch"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchixst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"ixt durch"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchixt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"ixen durch"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchixen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"ixt durch"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchixt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"ixen durch"},      
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchixen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"ixte durch"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchixte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"ixtest durch"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"durchixtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"ixte durch"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"durchixte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"ixten durch"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"durchixten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"ixtet durch"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"durchixtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"ixten durch"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"durchixten"},
                    PartizipII = "durchgeixt"
                 },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gewittern()
        {
            String word = "gewittern";
            int wikiID = 427338;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                   WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"gewittert"},
                    PräteritumAktivIndikativ_Singular3Person = new List<string>(){"gewitterte"},
                    PartizipII = "gewittert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gesundschrumpfen()
        {
            String word = "gesundschrumpfen";
            int wikiID = 348585;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schrumpfe gesund"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schrumpfst gesund","schrumpfest gesund"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfst","gesundschrumpfest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schrumpft gesund","schrumpfet gesund"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpft","gesundschrumpfet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schrumpfen gesund"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schrumpft gesund","schrumpfet gesund"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schrumpfen gesund"},      
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schrumpfte gesund","schrumpfete gesund"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfte","gesundschrumpfete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schrumpftest gesund","schrumpfetest gesund"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"gesundschrumpftest","gesundschrumpfetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schrumpfte gesund","schrumpfete gesund"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"gesundschrumpfte","gesundschrumpfete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schrumpften gesund","schrumpfeten gesund"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"gesundschrumpften","gesundschrumpfeten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schrumpftet gesund","schrumpfetet gesund"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"gesundschrumpftet","gesundschrumpfetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schrumpften gesund","schrumpfeten gesund"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"gesundschrumpften","gesundschrumpfeten"},
                    PartizipII = "gesundgeschrumpft"
                 },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void in_Stand_setzen()
        {
            String word = "in Stand setzen";
            int wikiID = 427336;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"setze in Stand"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"setzt in Stand"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"setzt in Stand","setzet in Stand"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"setzen in Stand"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"setzt in Stand","setzet in Stand"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"setzen in Stand"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"setzte in Stand","setzete in Stand"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"setztest in Stand","setzetest in Stand"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"setzte in Stand","setzete in Stand"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"setzten in Stand","setzeten in Stand"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"setztet in Stand","setzetet in Stand"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"setzten in Stand","setzeten in Stand"},
                    PartizipII = "in Stand gesetzt"
                 },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void zufriedenstellen()
        {
            String word = "zufriedenstellen ";
            int wikiID = 442128;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"stelle zufrieden"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstelle"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"stellst zufrieden"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"stellt zufrieden"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"stellen zufrieden"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"stellt zufrieden"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"stellen zufrieden"},      
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"stellte zufrieden"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"stelltest zufrieden"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"zufriedenstelltest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"stellte zufrieden"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"zufriedenstellte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"stellten zufrieden"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"zufriedenstellten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"stelltet zufrieden"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"zufriedenstelltet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"stellten zufrieden"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"zufriedenstellten"},
                    PartizipII = "zufriedengestellt"
                 },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


    }
}


