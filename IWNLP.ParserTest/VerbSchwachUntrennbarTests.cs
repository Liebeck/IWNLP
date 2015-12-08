using GenericXMLSerializer;
using IWNLP.Models.Flections;
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
    public class VerbSchwachUntrennbarTests
    {
        [TestMethod]
        public void normieren()
        {
            String word = "normieren";
            int wikiID = 348925;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"normiere"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"normierst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"normiert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"normieren"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"normiert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"normieren"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"normierte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"normiertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"normierte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"normierten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"normiertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"normierten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"normiere"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"normierest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"normiere"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"normieren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"normieret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"normieren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"normierte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"normiertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"normierte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"normierten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"normiertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"normierten"},
                    PartizipII = "normiert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void schirmen()
        {
            String word = "schirmen";
            int wikiID = 156554;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schirm","schirme"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schirmst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schirmt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schirmen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schirmt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schirmen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schirmte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schirmtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schirmte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schirmten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schirmtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schirmten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schirme"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schirmest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schirme"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schirmen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schirmet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schirmen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schirmte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schirmtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schirmte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schirmten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schirmtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schirmten"},
                    PartizipII = "geschirmt"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void iahen()
        {
            String word = "iahen";
            int wikiID = 146715;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"iahe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"iahst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"iaht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"iahen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"iaht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"iahen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"iahte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"iahtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"iahte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"iahten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"iahtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"iahten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"iahe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"iahest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"iahe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"iahen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"iahet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"iahen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"iahte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"iahtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"iahte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"iahten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"iahtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"iahten"},
                    PartizipII = "geiaht",
                    PartizipIIAlternativ = "iaht"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bechern()
        {
            String word = "bechern";
            int wikiID = 116585;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"becher","bechere","bechre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"becherst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"bechert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"bechern"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"bechert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"bechern"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"becherte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"bechertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"becherte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"becherten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"bechertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"becherten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"bechere","bechre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"becherest","bechrest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bechere","bechre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bechern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"becheret","bechret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bechern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"becherte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bechertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"becherte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"becherten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bechertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"becherten"},
                    PartizipII = "gebechert",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void verleumden()
        {
            String word = "verleumden";
            int wikiID = 134193;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"verleumde"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"verleumdest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"verleumdet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"verleumden"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"verleumdet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"verleumden"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"verleumdete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"verleumdetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"verleumdete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"verleumdeten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"verleumdetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"verleumdeten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"verleumde"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"verleumdest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"verleumde"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"verleumden"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"verleumdet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"verleumden"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"verleumdete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"verleumdetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"verleumdete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"verleumdeten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"verleumdetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"verleumdeten"},
                    PartizipII = "verleumdet",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void öffnen()
        {
            String word = "öffnen";
            int wikiID = 21954;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"öffne"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"öffnest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"öffnet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"öffnen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"öffnet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"öffnen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"öffnete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"öffnetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"öffnete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"öffneten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"öffnetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"öffneten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"öffne"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"öffnest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"öffne"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"öffnen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"öffnet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"öffnen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"öffnete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"öffnetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"öffnete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"öffneten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"öffnetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"öffneten"},
                    PartizipII = "geöffnet",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void schwänzeln()
        {
            String word = "schwänzeln";
            int wikiID = 93860;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schwänzle","schwänzel","schwänzele"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schwänzelst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schwänzelt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schwänzeln"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schwänzelt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schwänzeln"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schwänzelte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schwänzeltest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schwänzelte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schwänzelten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schwänzeltet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schwänzelten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schwänzele","schwänzle"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schwänzelest","schwänzlest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schwänzele","schwänzle"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schwänzeln"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schwänzelet","schwänzlet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schwänzeln"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schwänzelte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schwänzeltest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schwänzelte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schwänzelten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schwänzeltet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schwänzelten"},
                    PartizipII = "geschwänzelt",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void überlappen()
        {
            String word = "überlappen";
            int wikiID = 80740;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"überlappe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"überlappst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"überlappt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"überlappen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"überlappt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"überlappen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"überlappte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"überlapptest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"überlappte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"überlappten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"überlapptet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"überlappten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"überlappe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"überlappest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"überlappe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"überlappen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"überlappet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"überlappen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"überlappte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"überlapptest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"überlappte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"überlappten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"überlapptet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"überlappten"},
                    PartizipII = "überlappt",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void kondolieren()
        {
            String word = "kondolieren";
            int wikiID = 134196;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"kondoliere"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"kondolierst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"kondoliert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"kondolieren"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"kondoliert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"kondolieren"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"kondolierte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"kondoliertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"kondolierte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"kondolierten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"kondoliertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"kondolierten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"kondoliere"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"kondolierest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"kondoliere"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"kondolieren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"kondolieret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"kondolieren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"kondolierte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"kondoliertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"kondolierte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"kondolierten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"kondoliertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"kondolierten"},
                    PartizipII = "kondoliert",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }



        [TestMethod]
        public void mahlen()
        {
            String word = "mahlen";
            int wikiID = 71410;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"mahle"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"mahlst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"mahlt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"mahlen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"mahlt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"mahlen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"mahlte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"mahltest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"mahlte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"mahlten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"mahltet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"mahlten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"mahle"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"mahlest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"mahle"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"mahlen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"mahlet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"mahlen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"mahlte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"mahltest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"mahlte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"mahlten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"mahltet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"mahlten"},
                    PartizipII = "gemahlen",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void missachten()
        {
            String word = "missachten";
            int wikiID = 148513;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"missachte"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"missachtest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"missachtet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"missachten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"missachtet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"missachten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"missachtete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"missachtetest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"missachtete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"missachteten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"missachtetet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"missachteten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"missachte"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"missachtest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"missachte"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"missachten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"missachtet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"missachten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"missachtete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"missachtetest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"missachtete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"missachteten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"missachtetet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"missachteten"},
                    PartizipII = "missachtet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void knien()
        {
            String word = "knien";
            int wikiID = 295713;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"knie"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"kniest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"kniet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"knien"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"kniet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"knien"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"kniete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"knietest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"kniete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"knieten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"knietet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"knieten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"knie"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"kniest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"kniet"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"knien"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"kniet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"knien"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"kniete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"knietest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"kniete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"knieten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"knietet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"knieten"},
                    PartizipII = "gekniet"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"knie"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"kniest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"kniet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"knien"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"kniet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"knien"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"kniete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"knietest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"kniete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"knieten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"knietet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"knieten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"knie"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"kniest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"kniet"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"knien"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"kniet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"knien"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"kniete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"knietest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"kniete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"knieten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"knietet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"knieten"},
                    PartizipII = "gekniet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void beknien()
        {
            String word = "beknien";
            int wikiID = 295716;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"beknie"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"bekniest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"bekniet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"beknien"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"bekniet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"beknien"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"bekniete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"beknietest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"bekniete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"beknieten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"beknietet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"beknieten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"beknie"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bekniest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bekniet"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"beknien"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bekniet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"beknien"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bekniete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"beknietest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bekniete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"beknieten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"beknietet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"beknieten"},
                    PartizipII = "bekniet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void recyclen()
        {
            String word = "recyclen";
            int wikiID = 290128;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"recycle"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"recyclest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"recyclet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"recyclen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"recyclet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"recyclen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"recyclete"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"recycletest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"recyclete"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"recycleten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"recycletet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"recycleten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"recycle"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"recyclest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"recycle"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"recyclen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"recyclet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"recyclen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"recyclete"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"recycletest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"recyclete"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"recycleten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"recycletet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"recycleten"},
                    PartizipII = "recyclet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void liebkosen()
        {
            String word = "liebkosen";
            int wikiID = 433737;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"liebkose"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"liebkost"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"liebkost"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"liebkosen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"liebkost"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"liebkosen"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"liebkoste"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"liebkostest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"liebkoste"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"liebkosten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"liebkostet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"liebkosten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"liebkose"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"liebkosest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"liebkose"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"liebkosen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"liebkoset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"liebkosen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"liebkoste"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"liebkostest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"liebkoste"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"liebkosten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"liebkostet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"liebkosten"},
                    PartizipII = "liebkost",
                    PartizipIIAlternativ = "geliebkost"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void lästern()
        {
            String word = "lästern";
            int wikiID = 423951;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"läster","lästere","lästre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"lästerst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"lästert"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"lästern"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"lästert"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"lästern"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"lästerte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"lästertest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"lästerte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"lästerten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"lästertet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"lästerten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"lästere","lästre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"lästerest","lästrest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"lästere","lästre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"lästern"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"lästeret","lästret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"lästern"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"lästerte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"lästertest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"lästerte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"lästerten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"lästertet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"lästerten"},
                    PartizipII = "gelästert"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void brauchen()
        {
            String word = "gebraucht";
            int wikiID = 158652;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"brauche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"brauchst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"braucht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"brauchen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"braucht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"brauchen"},      
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"brauchte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"brauchtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"brauchte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"brauchten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"brauchtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"brauchten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"brauche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"brauchest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"brauche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"brauchen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"brauchet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"brauchen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"brauchte","bräuchte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"brauchtest","bräuchtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"brauchte","bräuchte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"brauchten","bräuchten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"brauchtet","bräuchtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"brauchten","bräuchten"},
                    PartizipII = "gebraucht",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}
