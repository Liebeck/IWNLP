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


    }
}


