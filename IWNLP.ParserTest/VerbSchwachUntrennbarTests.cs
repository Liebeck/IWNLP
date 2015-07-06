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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\normieren.txt";
            String text = Common.ReadFromFile(filename);
            String word = "normieren";
            int wikiID = 348925;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\schirmen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "schirmen";
            int wikiID = 156554;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\iahen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "iahen";
            int wikiID = 146715;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\bechern.txt";
            String text = Common.ReadFromFile(filename);
            String word = "bechern";
            int wikiID = 116585;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\verleumden.txt";
            String text = Common.ReadFromFile(filename);
            String word = "verleumden";
            int wikiID = 134193;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\oeffnen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "öffnen";
            int wikiID = 21954;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\schwaenzeln.txt";
            String text = Common.ReadFromFile(filename);
            String word = "schwänzeln";
            int wikiID = 93860;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\ueberlappen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "überlappen";
            int wikiID = 80740;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\kondolieren.txt";
            String text = Common.ReadFromFile(filename);
            String word = "kondolieren";
            int wikiID = 134196;

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
                    PartizipII = "kondoliert",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void altern()
        {
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\altern.txt";
            String text = Common.ReadFromFile(filename);
            String word = "altern";
            int wikiID = 116544;

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

        [TestMethod]
        public void mahlen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\mahlen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "mahlen";
            int wikiID = 71410;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\missachten.txt";
            String text = Common.ReadFromFile(filename);
            String word = "missachten";
            int wikiID = 148513;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\knien.txt";
            String text = Common.ReadFromFile(filename);
            String word = "knien";
            int wikiID = 295713;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\beknien.txt";
            String text = Common.ReadFromFile(filename);
            String word = "beknien";
            int wikiID = 295716;

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
            String filename = @"..\..\TestInput\VerbConjugation\schwachUntrennbar\recyclen.txt";
            String text = Common.ReadFromFile(filename);
            String word = "recyclen";
            int wikiID = 290128;

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
                    PartizipII = "recyclet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


    }
}
