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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"messe ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abmesse"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"messest ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abmessest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"messe ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abmesse"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"messen ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abmessen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"messet ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abmesset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"messen ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abmessen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"mäße ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abmäße"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"mäßest ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abmäßest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"mäße ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abmäße"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"mäßen ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abmäßen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"mäßet ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abmäßet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"mäßen ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abmäßen"},
                    PartizipII = "abgemessen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"bringe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bringest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bringe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bringen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bringet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bringen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"brächte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"brächtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"brächte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"brächten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"brächtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"brächten"},
                    PartizipII = "gebracht"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"stehe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"stehest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"stehe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"stehen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"stehet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"stehen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"stände","stünde"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"ständest","stündest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"stände","stünde"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"ständen","stünden"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"ständet","stündet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"ständen","stünden"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"stehe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"stehest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"stehe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"stehen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"stehet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"stehen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"stände","stünde"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"ständest","stündest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"stände","stünde"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"ständen","stünden"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"ständet","stündet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"ständen","stünden"},
                    PartizipII = "gestanden"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"fahre Rad"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"Rad fahre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"fahrest Rad"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"Rad fahrest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"fahre Rad"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"Rad fahre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"fahren Rad"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"Rad fahren"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"fahret Rad"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"Rad fahret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"fahren Rad"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"Rad fahren"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"führe Rad"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"Rad führe"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"führest Rad","führst Rad"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"Rad führest","Rad führst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"führe Rad"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"Rad führe"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"führen Rad"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"Rad führen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"führet Rad","führt Rad"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"Rad führet","Rad führt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"führen Rad"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"Rad führen"},
                    PartizipII = "Rad gefahren"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"tue an"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"antue"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"tuest an"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"antuest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"tue an"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"antue"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"tuen an"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"antuen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"tuet an"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"antuet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"tuen an"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"antuen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"täte an"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"antäte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"tätest an"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"antätest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"täte an"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"antäte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"täten an"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"antäten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"tätet an"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"antätet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"täten an"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"antäten"},
                    PartizipII = "angetan"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"lasse ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"ablasse"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"lassest ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"ablassest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"lasse ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"ablasse"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"lassen ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"ablassen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"lasset ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"ablasset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"lassen ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"ablassen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"ließe ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abließe"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"ließest ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abließest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"ließe ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abließe"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"ließen ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abließen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"ließet ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abließet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"ließen ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abließen"},
 
                    PartizipII = "abgelassen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"wäschst ab", "wäscht ab"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"abwäschst", "abwäscht"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"wasche ab"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abwasche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"waschest ab"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abwaschest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"wasche ab"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abwasche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"waschen ab"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abwaschen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"waschet ab"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abwaschet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"waschen ab"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abwaschen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"wüsche ab"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"abwüsche"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"wüschest ab","wüschst ab"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"abwüschest","abwüschst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"wüsche ab"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"abwüsche"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"wüschen ab"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"abwüschen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"wüschet ab","wüscht ab"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"abwüschet","abwüscht"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"wüschen ab"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"abwüschen"},
                    PartizipII = "abgewaschen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"beiße"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"beißest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"beiße"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"beißen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"beißet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"beißen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bisse"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bissest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bisse"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"bissen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bisset"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"bissen"},
                    PartizipII = "gebissen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"berste"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"berstest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"berste"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bersten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"berstet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bersten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bärste"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bärstest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bärste"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"bärsten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bärstet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"bärsten"},
                    PartizipII = "geborsten"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"müsse"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"müssest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"müsse"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"müssen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"müsset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"müssen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"müsste"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"müsstest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"müsste"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"müssten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"müsstet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"müssten"},
                    PartizipII = "gemusst"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"sei"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"seiest","seist"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"sei"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"seien"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"seiet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"seien"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"wäre"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"wärest","wärst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"wäre"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"wären"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"wäret","wärt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"wären"},
                    PartizipII = "gewesen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"habe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"habest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"habe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"haben"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"habet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"haben"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"hätte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"hättest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"hätte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"hätten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"hättet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"hätten"},
                    PartizipII = "gehabt"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"werde"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"werdest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"werde"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"werden"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"werdet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"werden"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"würde"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"würdest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"würde"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"würden"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"würdet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"würden"},
                    PartizipII = "geworden"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"trage vor"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"vortrage"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"tragest vor"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"vortragest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"trage vor"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"vortrage"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"tragen vor"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"vortragen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"traget vor"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"vortraget"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"tragen vor"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"vortragen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"trüge vor"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"vortrüge"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"trügest vor","trügst vor"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"vortrügest","vortrügst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"trüge vor"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"vortrüge"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"trügen vor"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"vortrügen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"trüget vor","trügt vor"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"vortrüget","vortrügt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"trügen vor"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"vortrügen"},
                    PartizipII = "vorgetragen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"meide"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"meidest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"meide"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"meiden"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"meidet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"meiden"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"miede"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"miedest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"miede"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"mieden"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"miedet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"mieden"},
                    PartizipII = "gemieden"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"bitte"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bittest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"bitte"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bitten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bittet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bitten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"bäte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bätest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"bäte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"bäten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bätet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"bäten"},
                    PartizipII = "gebeten"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"lade"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"ladest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"lade"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"laden"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"ladet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"laden"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"lüde"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"lüdest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"lüde"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"lüden"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"lüdet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"lüden"},
                    PartizipII = "geladen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"gebiete"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"gebietest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"gebiete"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"gebieten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"gebietet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"gebieten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"geböte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"gebötest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"geböte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"geböten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"gebötet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"geböten"},
                    PartizipII = "geboten"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"drischst", "drischt"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"dreschest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"dreschet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"drösche"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"dröschest","dröschst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"drösche"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"dröschen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"dröschet","dröscht"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"dröschen"},
                    PartizipII = "gedroschen"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"drischst", "drischt"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"dreschest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"dreschet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"dräsche"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"dräschest","dräschst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"dräsche"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"dräschen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"dräschet","dräscht"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"dräschen"},
                    PartizipII = "gedroschen"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"dreschst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"drescht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"drescht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"dreschte"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"dreschtest"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"dreschte"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"dreschten"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"dreschtet"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"dreschten"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"dreschest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"dresche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"dreschen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"dreschet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"dreschen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"dreschte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"dreschtest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"dreschte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"dreschten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"dreschtet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"dreschten"},
                    PartizipII = "gedrescht"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"trete"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"tretest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"trete"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"treten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"tretet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"treten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"träte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"trätest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"träte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"träten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"trätet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"träten"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"trete"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"tretest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"trete"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"treten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"tretet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"treten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"träte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"trätest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"träte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"träten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"trätet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"träten"},
                    PartizipII = "getreten"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"tue"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"tuest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"tue"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"tuen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"tuet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"tuen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"täte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"tätest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"täte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"täten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"tätet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"täten"},
                    PartizipII = "getan"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"biete"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"bietest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"biete"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"bieten"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"bietet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"bieten"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"böte"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"bötest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"böte"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"böten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"bötet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"böten"},
                    PartizipII = "geboten"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"schreie an"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"anschreie"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"schreiest an"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"anschreiest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schreie an"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"anschreie"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"schreien an"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"anschreien"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"schreiet an"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"anschreiet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"schreien an"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"anschreien"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"schrie an"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"anschrie"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"schrieest an"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"anschrieest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schrie an"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"anschrie"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"schrien an"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"anschrien"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"schrieet an"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"anschrieet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"schrien an"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"anschrien"},
                    PartizipII = "angeschrien",
                    PartizipIIAlternativ="angeschrieen"
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"kiese"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"kiesest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"kiese"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"kiesen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"kieset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"kiesen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"köre"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"körest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"köre"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"kören"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"köret"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"kören"},
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"kiese"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"kiesest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"kiese"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"kiesen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"kieset"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"kiesen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"kieste"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"kiestest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"kieste"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"kiesten"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"kiestet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"kiesten"},
                    PartizipII = "gekiest",
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
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
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"gebäre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"gebärest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"gebäre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"gebären"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"gebäret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"gebären"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"gebäre"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"gebärest","gebärst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"gebäre"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"gebären"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"gebäret","gebärt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"gebären"},
                    PartizipII = "geboren",
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void treiben()
        {
            String word = "treiben";
            int wikiID = 71141;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

//            String newText = @"__TOC__ 
//== treiben (Konjugation), Hilfsverb haben ({{Verbkonjugation|Deutsch}}) ==
//{{Deutsch Verb unregelmäßig|2=treib|3=trieb|4=trieb|5=getrieben|Hilfsverb=haben|vp=ja|zp=ja|gerund=ja}}
//{{----}}
//== treiben (Konjugation), Hilfsverb sein ({{Verbkonjugation|Deutsch}}) ==
//{{Deutsch Verb unregelmäßig|2=treib|3=trieb|4=trieb|5=getrieben|Hilfsverb=sein|vp=nein|zp=nein|gerund=nein}}";
//            text = newText;

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"treibe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"treibst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"treibt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"treiben"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"treibt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"treiben"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"trieb"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"triebst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"trieb"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"trieben"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"triebt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"trieben"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"treibe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"treibest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"treibe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"treiben"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"treibet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"treiben"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"triebe"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"triebest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"triebe"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"trieben"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"triebet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"trieben"},
                    PartizipII = "getrieben",
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"treibe"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"treibst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"treibt"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"treiben"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"treibt"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"treiben"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"trieb"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"triebst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"trieb"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"trieben"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"triebt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"trieben"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"treibe"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"treibest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"treibe"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"treiben"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"treibet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"treiben"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"triebe"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"triebest"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"triebe"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"trieben"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"triebet"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"trieben"},
                    PartizipII = "getrieben",
                 }
            };
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt"));}
            if(!AppSettingsWrapper.SuppressDumps){XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt"));}
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        //[Ignore] // currently not fixed in Wiktionary as of 20170508
        [TestMethod]
        public void reinwaschen()
        {
            String word = "reinwaschen";
            int wikiID = 707715;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"wasche rein"},
                    PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"reinwasche"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"wäschst rein","wäscht rein"},
                    PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation = new List<string>(){"reinwäschst", "reinwäscht"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"wäscht rein"},
                    PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation = new List<string>(){"reinwäscht"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"waschen rein"},
                    PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation = new List<string>(){"reinwaschen"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"wascht rein"},
                    PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation = new List<string>(){"reinwascht"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"waschen rein"},
                    PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation = new List<string>(){"reinwaschen"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"wusch rein"},
                    PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation = new List<string>(){"reinwusch"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"wuschst rein"},
                    PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation  = new List<string>(){"reinwuschst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"wusch rein"},
                    PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation  = new List<string>(){"reinwusch"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"wuschen rein"},
                    PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation  = new List<string>(){"reinwuschen"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"wuscht rein"},
                    PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation =  new List<string>(){"reinwuscht"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"wuschen rein"},
                    PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation  = new List<string>(){"reinwuschen"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"wasche rein"},
                    PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"reinwasche"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"waschest rein"},
                    PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"reinwaschest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"wasche rein"},
                    PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"reinwasche"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"waschen rein"},
                    PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"reinwaschen"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"waschet rein"},
                    PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"reinwaschet"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"waschen rein"},
                    PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"reinwaschen"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"wüsche rein"},
                    PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation = new List<string>(){"reinwüsche"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"wüschest rein","wüschst rein"},
                    PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation = new List<string>(){"reinwüschest","reinwüschst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"wüsche rein"},
                    PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation = new List<string>(){"reinwüsche"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"wüschen rein"},
                    PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation = new List<string>(){"reinwüschen"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"wüschet rein","wüscht rein"},
                    PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation = new List<string>(){"reinwüschet","reinwüscht"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"wüschen rein"},
                    PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation = new List<string>(){"reinwüschen"},
                    PartizipII = "reingewaschen",
                 }
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void schwären()
        {
            String word = "schwären";
            int wikiID = 737670;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schwärt"},
                    PräteritumAktivIndikativ_Singular3Person = new List<string>(){"schwärte"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schwäre"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schwärte"},
                    PartizipII = "geschwärt"
                 },
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"schwiert","schwieret"},
                    PräteritumAktivIndikativ_Singular3Person = new List<string>(){"schwor"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"schwäre"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"schwöre"},
                    PartizipII = "geschworen"
                 }
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void beschwören()
        {
            String word = "beschwören";
            int wikiID = 703309;
            String text = DumpTextCaching.GetTextFromPage(wikiID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            List<VerbConjugation> expectedWords = new List<VerbConjugation>()
            {
                 new VerbConjugation()
                 {
                    Text = word,
                    WiktionaryID = wikiID,
                    PräsensAktivIndikativ_Singular1Person = new List<string>(){"beschwöre"},
                    PräsensAktivIndikativ_Singular2Person = new List<string>(){"beschwörst"},
                    PräsensAktivIndikativ_Singular3Person = new List<string>(){"beschwört"},
                    PräsensAktivIndikativ_Plural1Person = new List<string>(){"beschwören"},
                    PräsensAktivIndikativ_Plural2Person = new List<string>(){"beschwört"},
                    PräsensAktivIndikativ_Plural3Person = new List<string>(){"beschwören"},
                    PräteritumAktivIndikativ_Singular1Person = new List<string>(){"beschwor", "beschwur"},
                    PräteritumAktivIndikativ_Singular2Person  = new List<string>(){"beschworst", "beschwurst"},
                    PräteritumAktivIndikativ_Singular3Person  = new List<string>(){"beschwor", "beschwur"},
                    PräteritumAktivIndikativ_Plural1Person  = new List<string>(){"beschworen", "beschwuren"},
                    PräteritumAktivIndikativ_Plural2Person =  new List<string>(){"beschwort", "beschwurt"},
                    PräteritumAktivIndikativ_Plural3Person  = new List<string>(){"beschworen", "beschwuren"},
                    PräsensAktivKonjunktiv_Singular1Person = new List<string>(){"beschwöre"},
                    PräsensAktivKonjunktiv_Singular2Person = new List<string>(){"beschwörest"},
                    PräsensAktivKonjunktiv_Singular3Person = new List<string>(){"beschwöre"},
                    PräsensAktivKonjunktiv_Plural1Person = new List<string>(){"beschwören"},
                    PräsensAktivKonjunktiv_Plural2Person = new List<string>(){"beschwöret"},
                    PräsensAktivKonjunktiv_Plural3Person = new List<string>(){"beschwören"},
                    PräteritumAktivKonjunktiv_Singular1Person = new List<string>(){"beschwöre", "beschwüre"},
                    PräteritumAktivKonjunktiv_Singular2Person = new List<string>(){"beschwörest", "beschwörst", "beschwürest", "beschwürst"},
                    PräteritumAktivKonjunktiv_Singular3Person = new List<string>(){"beschwöre", "beschwüre"},
                    PräteritumAktivKonjunktiv_Plural1Person = new List<string>(){"beschwören", "beschwüren"},
                    PräteritumAktivKonjunktiv_Plural2Person = new List<string>(){"beschwöret", "beschwört", "beschwüret", "beschwürt"},
                    PräteritumAktivKonjunktiv_Plural3Person = new List<string>(){"beschwören", "beschwüren"},
                    PartizipII = "beschworen",
                 }
            };
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(expectedWords.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_1.txt")); }
            if (!AppSettingsWrapper.SuppressDumps) { XMLSerializer.Serialize<List<Models.Entry>>(words.Cast<Models.Entry>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "verb_2.txt")); }
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }
    }
}

