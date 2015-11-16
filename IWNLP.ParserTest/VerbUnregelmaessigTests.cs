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
    public class VerbUnregelmaessigTests
    {
        [TestMethod]
        public void abmessen()
        {
            String word = "abmessen";
            int wikiID = 156284;
            String text = DumpTextCaching.GetTextFromPage(wikiID);
            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"messe ab"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abmesse"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"misst ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abmisst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"misst ab"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"abmisst"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"messen ab"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"abmessen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"messt ab"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"abmesst"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"messen ab"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"abmessen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"maß ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abmaß"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"maßest ab","maßt ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abmaßt"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"maß ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abmaß"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"maßen ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abmaßen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"maßt ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abmaßt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"maßen ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abmaßen"},
                    PartizipII = "abgemessen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bringen()
        {
            String word = "bringen";
            int wikiID = 14885;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"bringe"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"bringst"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"bringt"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"bringen"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"bringt"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"bringen"},
                   PräteritumAktivIndikativ_Singular1Person = new List<string>(){"brachte"},
                   PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"brachtest"},
                   PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"brachte"},
                   PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"brachten"},
                   PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"brachtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"brachten"},
                    PartizipII = "gebracht"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void stehen()
        {
            String word = "stehen";
            int wikiID = 81594;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"stehe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"stehst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"steht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"stehen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"steht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"stehen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"stand"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"standest","standst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"stand"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"standen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"standet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"standen"},
                    PartizipII = "gestanden"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"stehe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"stehst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"steht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"stehen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"steht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"stehen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"stand"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"standest","standst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"stand"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"standen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"standet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"standen"},
                    PartizipII = "gestanden"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void Radfahren()
        {
            String word = "Rad fahren";
            int wikiID = 162470;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"fahre Rad"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"Rad fahre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"fährst Rad"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"Rad fährst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"fährt Rad"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"Rad fährt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"fahren Rad"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"Rad fahren"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"fahrt Rad"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"Rad fahrt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"fahren Rad"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"Rad fahren"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"fuhr Rad"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"Rad fuhr"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"fuhrst Rad"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"Rad fuhrst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"fuhr Rad"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"Rad fuhr"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"fuhren Rad"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"Rad fuhren"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"fuhrt Rad"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"Rad fuhrt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"fuhren Rad"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"Rad fuhren"},
                    PartizipII = "Rad gefahren"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void antun()
        {
            String word = "antun";
            int wikiID = 132390;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"tue an"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"antue"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"tust an"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"antust"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"tut an"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"antut"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"tun an"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"antuen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"tut an"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"antut"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"tun an"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"antuen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"tat an"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"antat"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"tatest an", "tatst an"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"antatest", "antatst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"tat an"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"antat"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"taten an"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"antaten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"tatet an"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"antatet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"taten an"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"antaten"},
                    PartizipII = "angetan"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void ablassen()
        {
            String word = "ablassen";
            int wikiID = 81479;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"lasse ab"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"ablasse"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"lässt ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"ablässt"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"lässt ab"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"ablässt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"lassen ab"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"ablassen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"lasst ab"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"ablasst"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"lassen ab"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"ablassen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"ließ ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abließ"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"ließest ab","ließt ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abließt"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"ließ ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abließ"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"ließen ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abließen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"ließt ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abließt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"ließen ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abließen"},
                    PartizipII = "abgelassen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void abwaschen()
        {
            String word = "abwaschen";
            int wikiID = 156314;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"wasche ab"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abwasche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"wäschst ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abwäschst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"wäscht ab"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"abwäscht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"waschen ab"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"abwaschen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"wascht ab"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"abwascht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"waschen ab"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"abwaschen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"wusch ab"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"abwusch"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"wuschst ab"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"abwuschst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"wusch ab"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"abwusch"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"wuschen ab"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"abwuschen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"wuscht ab"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"abwuscht"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"wuschen ab"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"abwuschen"},
                    PartizipII = "abgewaschen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void beissen()
        {
            String word = "beißen";
            int wikiID = 15685;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"beiße"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"beißt"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"beißt"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"beißen"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"beißt"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"beißen"},
                   PräteritumAktivIndikativ_Singular1Person = new List<string>(){"biss"},
                   PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"bissest","bisst"},
                   PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"biss"},
                   PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"bissen"},
                   PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"bisst"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"bissen"},
                    PartizipII = "gebissen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bersten()
        {
            String word = "bersten";
            int wikiID = 71713;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"berste"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"birst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"birst"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"bersten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"berstet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"bersten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"barst"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"barst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"barst"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"barsten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"barstet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"barsten"},
                    PartizipII = "geborsten"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void muessen()
        {
            String word = "müssen";
            int wikiID = 63053;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"muss"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"musst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"muss"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"müssen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"müsst"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"müssen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"musste"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"musstest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"musste"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"mussten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"musstet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"mussten"},
                    PartizipII = "gemusst"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void sein()
        {
            String word = "sein";
            int wikiID = 861;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                   Text = word,
                    WiktionaryID = wikiID,
                   PräsensAktivIndikativ_Singular1Person = new List<string>(){"bin"},
                   PräsensAktivIndikativ_Singular2Person = new List<string>(){"bist"},
                   PräsensAktivIndikativ_Singular3Person = new List<string>(){"ist"},
                   PräsensAktivIndikativ_Plural1Person = new List<string>(){"sind"},
                   PräsensAktivIndikativ_Plural2Person = new List<string>(){"seid"},
                   PräsensAktivIndikativ_Plural3Person = new List<string>(){"sind"},
                   PräteritumAktivIndikativ_Singular1Person = new List<string>(){"war"},
                   PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"warst"},
                   PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"war"},
                   PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"waren"},
                   PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"wart"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"waren"},
                    PartizipII = "gewesen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void haben()
        {
            String word = "haben";
            int wikiID = 5544;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"habe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"hast"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"hat"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"haben"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"habt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"haben"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"hatte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"hattest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"hatte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"hatten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"hattet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"hatten"},
                    PartizipII = "gehabt"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void werden()
        {
            String word = "werden";
            int wikiID = 68273;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"werde"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"wirst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"wird"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"werden"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"werdet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"werden"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"wurde","ward"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"wurdest","wardst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"wurde","ward"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"wurden"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"wurdet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"wurden"},
                    PartizipII = "geworden"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void vortragen()
        {
            String word = "vortragen";
            int wikiID = 110380;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"trage vor"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"vortrage"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"trägst vor"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"vorträgst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"trägt vor"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"vorträgt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"tragen vor"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"vortragen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"tragt vor"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"vortragt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"tragen vor"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"vortragen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"trug vor"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"vortrug"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"trugst vor"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"vortrugst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"trug vor"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"vortrug"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"trugen vor"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"vortrugen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"trugt vor"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"vortrugt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"trugen vor"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"vortrugen"},
                    PartizipII = "vorgetragen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void meiden()
        {
            String word = "meiden";
            int wikiID = 72159;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"meide"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"meidest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"meidet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"meiden"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"meidet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"meiden"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"mied"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"miedst","miedest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"mied"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"mieden"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"miedet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"mieden"},
                    PartizipII = "gemieden"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bitten()
        {
            String word = "bitten";
            int wikiID = 15060;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"bitte"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"bittest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"bittet"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"bitten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"bittet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"bitten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"bat"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"batest","batst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"bat"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"baten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"batet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"baten"},
                    PartizipII = "gebeten"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void laden()
        {
            String word = "laden";
            int wikiID = 72156;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"lade"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"lädst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"lädt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"laden"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"ladet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"laden"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"lud"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"ludst","ludest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"lud"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"luden"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"ludet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"luden"},
                    PartizipII = "geladen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gebieten()
        {
            String word = "gebieten";
            int wikiID = 156341;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"gebiete"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"gebietest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"gebietet","gebeut"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"gebieten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"gebietet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"gebieten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"gebot"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"gebotest","gebotst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"gebot"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"geboten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"gebotet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"geboten"},
                    PartizipII = "geboten"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void dreschen()
        {
            String word = "dreschen";
            int wikiID = 71394;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"drischst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"drischt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"drescht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"drosch"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"droschst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"drosch"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"droschen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"droscht"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"droschen"},
                    PartizipII = "gedroschen"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"drischst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"drischt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"drescht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"drasch"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"draschst","draschest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"drasch"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"draschen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"drascht"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"draschen"},
                    PartizipII = "gedroschen"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void treten()
        {
            String word = "treten";
            int wikiID = 158680;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"trete"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"trittst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"tritt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"treten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"tretet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"treten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"trat"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"tratst","tratest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"trat"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"traten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"tratet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"traten"},
                    PartizipII = "getreten"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"trete"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"trittst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"tritt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"treten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"tretet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"treten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"trat"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"tratst","tratest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"trat"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"traten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"tratet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"traten"},
                    PartizipII = "getreten"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void tun()
        {
            String word = "tun";
            int wikiID = 17077;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"tue", "tu"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"tust"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"tut"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"tun"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"tut"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"tun"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"tat"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"tatest","tatst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"tat"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"taten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"tatet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"taten"},
                    PartizipII = "getan"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void bieten()
        {
            String word = "bieten";
            int wikiID = 15709;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"biete"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"bietest","beutst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"bietet","beut"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"bieten"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"bietet"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"bieten"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"bot"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"botest","botst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"bot"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"boten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"botet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"boten"},
                    PartizipII = "geboten"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void anschreien()
        {
            String word = "anschreien";
            int wikiID = 295715;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"schreie an"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"anschreie"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"schreist an"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"anschreist"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schreit an"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"anschreit"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"schreien an"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"anschreien"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"schreit an"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"anschreit"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"schreien an"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"anschreien"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"schrie an"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"anschrie"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"schriest an"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"anschriest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"schrie an"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"anschrie"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"schrien an"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"anschrien"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"schriet an"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"anschriet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"schrien an"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"anschrien"},
                    PartizipII = "angeschrien",
                    PartizipIIAlternativ="angeschrieen"
                 }
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
                    PartizipII = "geknöpft",
                    PartizipIIVeraltet="geknöpfet"
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void kiesen()
        {
            String word = "kiesen";
            int wikiID = 161331;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"kiese"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"kiesen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"kiesen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"kor"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"korest","korst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"kor"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"koren"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"kort"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"koren"},
                    PartizipII = "gekoren",
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"kiese"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"kiesen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"kiest"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"kiesen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"kieste"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"kiestest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"kieste"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"kiesten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"kiestet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"kiesten"},
                    PartizipII = "gekiest",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void gebären()
        {
            String word = "gebären";
            int wikiID = 71404;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"gebäre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"gebierst","gebärst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"gebiert","gebärt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"gebären"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"gebärt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"gebären"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"gebar"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"gebarst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"gebar"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"gebaren"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"gebart"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"gebaren"},
                    PartizipII = "geboren",
                 }
            };
            XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

    }
}

