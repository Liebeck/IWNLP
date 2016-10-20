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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"backe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"backest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"backe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"backen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"backet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"backen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"büke"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bükest","bükst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"büke"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"büken"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"büket","bükt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"büken"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"backe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"backest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"backe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"backen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"backet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"backen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"backte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"backtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"backte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"backten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"backtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"backten"},
                    PartizipII = "gebackt"
                 },

            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"flute"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"flutest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"flute"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"fluten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"flutet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"fluten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"flutete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"flutetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"flutete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"fluteten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"flutetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"fluteten"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"flute"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"flutest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"flute"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"fluten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"flutet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"fluten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"flutete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"flutetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"flutete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"fluteten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"flutetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"fluteten"},
                    PartizipII = "geflutet"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"speichere ab","speichre ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abspeichere","abspeichre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"speicherst ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abspeicherst"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"speichere ab","speichre ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abspeichere","abspeichre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"speichern ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abspeichern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"speichert ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abspeichert"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"speichern ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abspeichern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"speicherte ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abspeicherte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"speichertest ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abspeichertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"speicherte ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abspeicherte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"speicherten ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abspeicherten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"speichertet ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abspeichertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"speicherten ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abspeicherten"},
                    PartizipII = "abgespeichert"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"regne"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"regnen"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"regnete"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"regneten"},
                    PartizipII = "geregnet"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"ixt durch"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchixt"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"ixe durch"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchixe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"ixest durch"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchixest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"ixe durch"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchixe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"ixen durch"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchixen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"ixet durch"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchixet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"ixen durch"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchixen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"ixte durch"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchixte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"ixtest durch"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchixtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"ixte durch"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchixte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"ixten durch"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchixten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"ixtet durch"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchixtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"ixten durch"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchixten"},
                    PartizipII = "durchgeixt"
                 },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"gewittere","gewittre"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"gewitterte"},
                    PartizipII = "gewittert"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schrumpfe gesund"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schrumpfest gesund"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schrumpfe gesund"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schrumpfen gesund"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schrumpfet gesund"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schrumpfen gesund"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schrumpfte gesund","schrumpfete gesund"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfte","gesundschrumpfete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schrumpftest gesund","schrumpfetest gesund"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpftest","gesundschrumpfetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schrumpfte gesund","schrumpfete gesund"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpfte","gesundschrumpfete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schrumpften gesund","schrumpfeten gesund"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpften","gesundschrumpfeten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schrumpftet gesund","schrumpfetet gesund"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpftet","gesundschrumpfetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schrumpften gesund","schrumpfeten gesund"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"gesundschrumpften","gesundschrumpfeten"},
                    PartizipII = "gesundgeschrumpft"
                 },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"setze in Stand"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"setzest in Stand"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"setze in Stand"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"setzen in Stand"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"setzet in Stand"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"setzen in Stand"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"setzte in Stand","setzete in Stand"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"setztest in Stand","setzetest in Stand"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"setzte in Stand","setzete in Stand"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"setzten in Stand","setzeten in Stand"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"setztet in Stand","setzetet in Stand"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"setzten in Stand","setzeten in Stand"},
                    PartizipII = "in Stand gesetzt"
                 },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void zufriedenstellen()
        {
            String word = "zufriedenstellen";
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"stelle zufrieden"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstelle"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"stellest zufrieden"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"stelle zufrieden"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstelle"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"stellen zufrieden"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"stellet zufrieden"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"stellen zufrieden"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"stellte zufrieden"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"stelltest zufrieden"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstelltest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"stellte zufrieden"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"stellten zufrieden"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"stelltet zufrieden"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"zufriedenstelltet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"stellten zufrieden"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"zufriedenstellten"},
                    PartizipII = "zufriedengestellt"
                 },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"verwässere","verwässre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"verwässerst"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"verwässere","verwässre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"verwässern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"verwässert"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"verwässern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"verwässerte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"verwässertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"verwässerte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"verwässerten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"verwässertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"verwässerten"},
                    PartizipII = "verwässert"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schleppe ein"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"einschleppe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schleppest ein"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"einschleppest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schleppe ein"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"einschleppe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schleppen ein"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"einschleppen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schleppet ein"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"einschleppet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schleppen ein"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"einschleppen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schleppte ein"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"einschleppte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schlepptest ein"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"einschlepptest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schleppte ein"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"einschleppte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schleppten ein"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"einschleppten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schlepptet ein"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"einschlepptet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schleppten ein"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"einschleppten"},
                    PartizipII = "eingeschleppt"
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"bestrafe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bestrafest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bestrafe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bestrafen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bestrafet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bestrafen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bestrafte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bestraftest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bestrafte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"bestraften"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bestraftet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"bestraften"},
                    PartizipII = "bestraft"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"stelze"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"stelzest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"stelze"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"stelzen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"stelzet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"stelzen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"stelzte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"stelztest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"stelzte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"stelzten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"stelztet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"stelzten"},
                    PartizipII = "gestelzt"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"richte zu Grunde"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"richtest zu Grunde"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"richte zu Grunde"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"richten zu Grunde"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"richtet zu Grunde"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"richten zu Grunde"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"richtete zu Grunde"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"richtetest zu Grunde"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"richtete zu Grunde"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"richteten zu Grunde"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"richtetet zu Grunde"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"richteten zu Grunde"},
                    PartizipII = "zu Grunde gerichtet"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"sickere durch","sickre durch"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchsickere","durchsickre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"sickerst durch"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchsickerst"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"sickere durch","sickre durch"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchsickere","durchsickre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"sickern durch"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchsickern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"sickert durch"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchsickert"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"sickern durch"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchsickern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"sickerte durch"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"durchsickerte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"sickertest durch"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"durchsickertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"sickerte durch"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"durchsickerte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"sickerten durch"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"durchsickerten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"sickertet durch"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"durchsickertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"sickerten durch"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"durchsickerten"},
                    PartizipII = "durchgesickert"
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"bewaffne"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bewaffnest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bewaffne"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bewaffnen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bewaffnet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bewaffnen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bewaffnete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bewaffnetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bewaffnete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"bewaffneten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bewaffnetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"bewaffneten"},
                    PartizipII = "bewaffnet"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"gliedere","gliedre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"gliederst"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"gliedere","gliedre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"gliedern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"gliedert"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"gliedern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"gliederte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"gliedertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"gliederte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"gliederten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"gliedertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"gliederten"},
                    PartizipII = "gegliedert"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"enteisene"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"enteisenest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"enteisene"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"enteisenen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"enteisenet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"enteisenen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"enteisente"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"enteisentest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"enteisente"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"enteisenten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"enteisentet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"enteisenten"},
                    PartizipII = "enteisent"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"atme auf"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"aufatme"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"atmest auf"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"aufatmest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"atme auf"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"aufatme"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"atmen auf"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"aufatmen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"atmet auf"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"aufatmet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"atmen auf"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"aufatmen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"atmete auf"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"aufatmete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"atmetest auf"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"aufatmetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"atmete auf"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"aufatmete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"atmeten auf"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"aufatmeten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"atmetet auf"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"aufatmetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"atmeten auf"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"aufatmeten"},
                    PartizipII = "aufgeatmet"
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schmiere ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schmierest ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmierest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schmiere ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schmieren ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schmieret ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmieret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schmieren ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schmiertest ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmiertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schmierten ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmierten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schmiertet ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmiertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schmierten ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmierten"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schmiere ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schmierest ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmierest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schmiere ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmiere"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schmieren ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schmieret ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmieret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schmieren ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmieren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schmiertest ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abschmiertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schmierte ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abschmierte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schmierten ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abschmierten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schmiertet ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abschmiertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schmierten ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abschmierten"},
                    PartizipII = "abgeschmiert"
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"äse"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"äsest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"äse"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"äsen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"äset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"äsen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"äste"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"ästest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"äste"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"ästen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"ästet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"ästen"},
                    PartizipII = "geäst"
                },
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"altere","altre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"alterst","altrest","alterest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"altere","altre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"altern","altren","alteren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"altert","altret","alteret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"altern","altren","alteren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"alterte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"altertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"alterte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"alterten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"altertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"alterten"},
                    PartizipII = "gealtert",
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}


