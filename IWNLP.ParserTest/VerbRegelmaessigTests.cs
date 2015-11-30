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
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpft","gesundschrumpfet"},
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

        [TestMethod]
        public void verwässern()
        {
            String word = "verwässern";
            int wikiID = 427849;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"verwässer","verwässere","verwässre"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"verwässerst"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"verwässert"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"verwässern"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"verwässert"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"verwässern"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"verwässerte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"verwässertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"verwässerte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"verwässerten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"verwässertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"verwässerten"},
                    PartizipII = "verwässert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void einschleppen()
        {
            String word = "einschleppen";
            int wikiID = 428120;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schleppe ein"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"einschleppe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schleppst ein","schleppest ein"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"einschleppst","einschleppest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schleppt ein","schleppet ein"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"einschleppt","einschleppet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schleppen ein"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"einschleppen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schleppt ein","schleppet ein"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"einschleppt","einschleppet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schleppen ein"},     
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"einschleppen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schleppte ein"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"einschleppte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schlepptest ein"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"einschlepptest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schleppte ein"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"einschleppte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schleppten ein"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"einschleppten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schlepptet ein"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"einschlepptet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schleppten ein"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"einschleppten"},
                    PartizipII = "eingeschleppt"
                },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bestrafen()
        {
            String word = "bestrafen";
            int wikiID = 429126;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"bestrafe"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"bestrafst"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"bestraft"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"bestrafen"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"bestraft"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"bestrafen"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"bestrafte"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"bestraftest"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"bestrafte"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"bestraften"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"bestraftet"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"bestraften"},
                        PartizipII = "bestraft"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void stelzen()
        {
            String word = "stelzen";
            int wikiID = 430348;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"stelze"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"stelzt"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"stelzt"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"stelzen"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"stelzt"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"stelzen"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"stelzte"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"stelztest"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"stelzte"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"stelzten"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"stelztet"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"stelzten"},
                        PartizipII = "gestelzt"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void zu_Grunde_richten()
        {
            String word = "zu Grunde richten";
            int wikiID = 430782;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"richte zu Grunde"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"richtest zu Grunde"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"richtet zu Grunde"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"richten zu Grunde"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"richtet zu Grunde"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"richten zu Grunde"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"richtete zu Grunde"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"richtetest zu Grunde"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"richtete zu Grunde"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"richteten zu Grunde"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"richtetet zu Grunde"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"richteten zu Grunde"},
                        PartizipII = "zu Grunde gerichtet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void durchsickern()
        {
            String word = "durchsickern";
            int wikiID = 433338;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"sicker durch","sickere durch","sickre durch"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchsicker","durchsickere","durchsickre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"sickerst durch"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchsickerst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"sickert durch"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchsickert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"sickern durch"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchsickern"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"sickert durch"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchsickert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"sickern durch"},     
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchsickern"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"sickerte durch"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchsickerte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"sickertest durch"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"durchsickertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"sickerte durch"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"durchsickerte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"sickerten durch"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"durchsickerten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"sickertet durch"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"durchsickertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"sickerten durch"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"durchsickerten"},
                    PartizipII = "durchgesickert"
                },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bewaffnen()
        {
            String word = "bewaffnen";
            int wikiID = 433536;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"bewaffne"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"bewaffnest"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"bewaffnet"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"bewaffnen"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"bewaffnet"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"bewaffnen"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"bewaffnete"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"bewaffnetest"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"bewaffnete"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"bewaffneten"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"bewaffnetet"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"bewaffneten"},
                        PartizipII = "bewaffnet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gliedern()
        {
            String word = "gliedern";
            int wikiID = 436909;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"glieder","gliedere","gliedre"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"gliederst"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"gliedert"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"gliedern"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"gliedert"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"gliedern"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"gliederte"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"gliedertest"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"gliederte"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"gliederten"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"gliedertet"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"gliederten"},
                        PartizipII = "gegliedert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void enteisenen()
        {
            String word = "enteisenen";
            int wikiID = 461339;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                        Text = word,
                        WiktionaryID = wikiID,
                        PräsensAktivIndikativ_Singular1Person = new List<string>(){"enteisene"},
                        PräsensAktivIndikativ_Singular2Person = new List<string>(){"enteisenst"},
                        PräsensAktivIndikativ_Singular3Person = new List<string>(){"enteisent"},
                        PräsensAktivIndikativ_Plural1Person = new List<string>(){"enteisenen"},
                        PräsensAktivIndikativ_Plural2Person = new List<string>(){"enteisent"},
                        PräsensAktivIndikativ_Plural3Person = new List<string>(){"enteisenen"},      
                        PräteritumAktivIndikativ_Singular1Person = new List<string>(){"enteisente"},
                        PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"enteisentest"},
                        PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"enteisente"},
                        PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"enteisenten"},
                        PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"enteisentet"},
                        PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"enteisenten"},
                        PartizipII = "enteisent"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void aufatmen()
        {
            String word = "aufatmen";
            int wikiID = 499037;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"atme auf"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"aufatme"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"atmest auf"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"aufatmest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"atmet auf"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"aufatmet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"atmen auf"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"aufatmen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"atmet auf"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"aufatmet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"atmen auf"},     
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"aufatmen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"atmete auf"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"aufatmete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"atmetest auf"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"aufatmetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"atmete auf"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"aufatmete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"atmeten auf"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"aufatmeten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"atmetet auf"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"aufatmetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"atmeten auf"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"aufatmeten"},
                    PartizipII = "aufgeatmet"
                },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void abschmieren()
        {
            String word = "abschmieren";
            int wikiID = 33866;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schmiere ab"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schmierst ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmierst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schmiert ab"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmiert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schmieren ab"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schmiert ab"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmiert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schmieren ab"},     
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schmiertest ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abschmiertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schmierte ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abschmierte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schmierten ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abschmierten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schmiertet ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abschmiertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schmierten ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abschmierten"},
                    PartizipII = "abgeschmiert"
                },
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schmiere ab"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schmierst ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmierst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schmiert ab"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmiert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schmieren ab"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schmiert ab"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmiert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schmieren ab"},     
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schmiertest ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abschmiertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schmierte ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abschmierte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schmierten ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abschmierten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schmiertet ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abschmiertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schmierten ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abschmierten"},
                    PartizipII = "abgeschmiert"
                },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void äsen()
        {
            String word = "äsen";
            int wikiID = 447400;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                new VerbConjugation()
                {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"äse"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"äst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"äst"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"äsen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"äst"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"äsen"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"äste"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"ästest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"äste"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"ästen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"ästet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"ästen"},
                    PartizipII = "geäst"
                },
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void knöpfen()
        {
            String word = "knöpfen";
            int wikiID = 474830;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"knöpfe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"knöpfst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"knöpft"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"knöpfen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"knöpft"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"knöpfen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"knöpfte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"knöpftest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"knöpfte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"knöpften"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"knöpftet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"knöpften"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"knöpfe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"knöpfest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"knöpfe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"knöpfen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"knöpfet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"knöpfen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"knöpfte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"knöpftest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"knöpfte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"knöpften"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"knöpftet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"knöpften"},
                    PartizipII = "geknöpft",
                    PartizipIIVeraltet="geknöpfet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void altern()
        {
            String word = "altern";
            int wikiID = 116544;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"alter","altere","altre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"alterst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"altert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"altern"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"altert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"altern"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"alterte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"altertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"alterte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"alterten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"altertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"alterten"},
                    PartizipII = "gealtert",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}


