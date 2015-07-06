using IWNLP.Parser.FlexParser.VerbTemplates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWNLP.Parser.FlexParser;
using IWNLP.Parser.FlexParser.VerbTemplates.regelmaessig;
using IWNLP.Parser.FlexParser.VerbTemplates.schwachUntrennbar;
using IWNLP.Parser.FlexParser.VerbTemplates.unregelmaessig;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class VerbConjugationSyntaxTests
    {
        [TestMethod]
        public void behaupten()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\behaupten.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text,"behaupten");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterRegelmaessig.Parameter1,"behau"},
              {ParameterRegelmaessig.Parameter2, "p"},
              {ParameterRegelmaessig.Parameter3, "t"},
              {ParameterRegelmaessig.Parameter4, "e"},
              {ParameterRegelmaessig.Parameter5, "n"},
              {ParameterRegelmaessig.Parameter6,"behauptet"},
              {ParameterRegelmaessig.ZP,"zp3"},
              {ParameterRegelmaessig.VP, "vp3"}
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void infundieren()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\infundieren.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text,"infundieren");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterRegelmaessig.Parameter1,"infundi"},
              {ParameterRegelmaessig.Parameter2, "e"},
              {ParameterRegelmaessig.Parameter3, "r"},
              {ParameterRegelmaessig.Parameter4, "e"},
              {ParameterRegelmaessig.Parameter5, "n"},
              {ParameterRegelmaessig.Parameter6,"infundiert"},
              {ParameterRegelmaessig.ZP,"zp3"},
              {ParameterRegelmaessig.VP, "vp3"},
              {ParameterRegelmaessig.veraltet, "0"}
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void regnen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\regnen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text,"regnen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterRegelmaessig.Parameter1,"re"},
              {ParameterRegelmaessig.Parameter2, "g"},
              {ParameterRegelmaessig.Parameter3, "n"},
              {ParameterRegelmaessig.Parameter4, "e"},
              {ParameterRegelmaessig.Parameter5, "n"},
              {ParameterRegelmaessig.Parameter6,"geregnet"},
              {ParameterRegelmaessig.Unpersönlich,"sie"},
              {ParameterRegelmaessig.ZP,"0"},
              {ParameterRegelmaessig.VP, "0"},
              {ParameterRegelmaessig.gerund, "0"},
              {ParameterRegelmaessig.Imperativ, "0"}
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void gesundschrumpfen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\gesundschrumpfen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text,"gesundschrumpfen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Infinitiv, "einteilig"},
                {ParameterRegelmaessig.Nebensatzkonjugation,"einteilig"},
                {ParameterRegelmaessig.Teil1, "gesund"},
                {ParameterRegelmaessig.Parameter1,"schrum"},
                {ParameterRegelmaessig.Parameter2, "p"},
                {ParameterRegelmaessig.Parameter3, "f"},
                {ParameterRegelmaessig.Parameter4, "e"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"gesundgeschrumpft"},
                {ParameterRegelmaessig.ZP,"zp3"},
                {ParameterRegelmaessig.VP, "vp3"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void inStandSetzen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\inStandSetzen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "in Stand setzen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Infinitiv, "dreiteilig"},
                {ParameterRegelmaessig.Nebensatzkonjugation,"dreiteilig"},
                {ParameterRegelmaessig.Teil1, "in"},
                {ParameterRegelmaessig.Teil2, "Stand"},
                {ParameterRegelmaessig.Parameter1,"se"},
                {ParameterRegelmaessig.Parameter2, "t"},
                {ParameterRegelmaessig.Parameter3, "z"},
                {ParameterRegelmaessig.Parameter4, "e"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"in Stand gesetzt"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void gewittern()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\gewittern.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "gewittern");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Unpersönlich, "es"},
                {ParameterRegelmaessig.gerund,"0"},
                {ParameterRegelmaessig.Imperativ, "0"},
                {ParameterRegelmaessig.ZP, "0"},
                {ParameterRegelmaessig.VP, "0"},
                {ParameterRegelmaessig.Parameter1,"gewit"},
                {ParameterRegelmaessig.Parameter2, "t"},
                {ParameterRegelmaessig.Parameter3, "e"},
                {ParameterRegelmaessig.Parameter4, "r"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"gewittert"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void generalueberholen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\generalueberholen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "generalüberholen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Infinitiv, "einteilig"},
                {ParameterRegelmaessig.Teil1,"general"},
                {ParameterRegelmaessig.ZP, "zp3"},
                {ParameterRegelmaessig.VP, "vp3"},
                {ParameterRegelmaessig.Parameter1,"überh"},
                {ParameterRegelmaessig.Parameter2, "o"},
                {ParameterRegelmaessig.Parameter3, "l"},
                {ParameterRegelmaessig.Parameter4, "e"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"generalüberholt"},
                {ParameterRegelmaessig.ImperativPräsensAktiv, "0"},
                {ParameterRegelmaessig.PräsensAktiv, "0"},
                {ParameterRegelmaessig.PräteritumAktiv, "0"},
                {ParameterRegelmaessig.PartizipI, "0"},
                {ParameterRegelmaessig.gerund, "0"}
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void wiederaufbereiten()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\wiederaufbereiten.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "wiederaufbereiten");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Teil1,"wieder"},
                {ParameterRegelmaessig.Teil2,"auf"},
                {ParameterRegelmaessig.ZP, "zp3"},
                {ParameterRegelmaessig.VP, "vp3"},
                {ParameterRegelmaessig.Parameter1,"bere"},
                {ParameterRegelmaessig.Parameter2, "i"},
                {ParameterRegelmaessig.Parameter3, "t"},
                {ParameterRegelmaessig.Parameter4, "e"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"wiederaufbereitet"},
                {ParameterRegelmaessig.Infinitiv, "einteilig"},
                {ParameterRegelmaessig.Nebensatzkonjugation, "einteilig"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void durchixen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\durchixen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbRegelmaessigParser verbConjugationParser = new VerbRegelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "durchixen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterRegelmaessig.Teil1,"durch"},
                {ParameterRegelmaessig.veraltet,"0"},
                {ParameterRegelmaessig.ZP, "zp3"},
                {ParameterRegelmaessig.VP, "vp3"},
                {ParameterRegelmaessig.Parameter1,"i"},
                {ParameterRegelmaessig.Parameter2, "x"},
                {ParameterRegelmaessig.Parameter3, ""},
                {ParameterRegelmaessig.Parameter4, "e"},
                {ParameterRegelmaessig.Parameter5, "n"},
                {ParameterRegelmaessig.Parameter6,"durchgeixt"},
                {ParameterRegelmaessig.Infinitiv, "einteilig"},
                {ParameterRegelmaessig.Nebensatzkonjugation, "einteilig"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void üben()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\ueben.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbSchwachUntrennbarParser verbConjugationParser = new VerbSchwachUntrennbarParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "üben");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
                {ParameterSchwachUntrennbar.ZP, "0"},
                {ParameterSchwachUntrennbar.VP, "vp3"},
                {"1","ü"},
                {"2", "b"},
                {"3", ""},
                {"4", "e"},
                {"5", "n"},
                {ParameterSchwachUntrennbar.PartizipII, "geübt"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void mahlen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\mahlen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbSchwachUntrennbarParser verbConjugationParser = new VerbSchwachUntrennbarParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "mahlen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {

                {ParameterSchwachUntrennbar.ZP, "zp3"},
                {ParameterSchwachUntrennbar.VP, "vp3"},
                {"1","ma"},
                {"2", "h"},
                {"3", "l"},
                {"4", "e"},
                {"5", "n"},
                {ParameterSchwachUntrennbar.PartizipII, "gemahlen"},
                {ParameterSchwachUntrennbar.Unregelmäßig, "1"}

            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }


        [TestMethod]
        public void abmessen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\abmessen.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "abmessen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,"ab"},
              {ParameterUnregelmaessig.Parameter2, "mess"},
              {ParameterUnregelmaessig.Parameter3, "maß"},
              {ParameterUnregelmaessig.Parameter4, "mäß"},
              {ParameterUnregelmaessig.Parameter5, "gemessen"},
              {ParameterUnregelmaessig.Parameter6,"miss"},
              {ParameterUnregelmaessig.Parameter7,"-s"},
              {ParameterUnregelmaessig.Parameter8,"i"},
              {ParameterUnregelmaessig.ZP,"ja"},
              {ParameterUnregelmaessig.VP, "ja"},
              {ParameterUnregelmaessig.gerund, "ja"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void abschieben1()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\abschieben1.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "abschieben");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,"ab"},
              {ParameterUnregelmaessig.Parameter2, "schieb"},
              {ParameterUnregelmaessig.Parameter3, "schob"},
              {ParameterUnregelmaessig.Parameter4, "schöb"},
              {ParameterUnregelmaessig.Parameter5, "geschoben"},
              {ParameterUnregelmaessig.ZP,"ja"},
              {ParameterUnregelmaessig.VP, "ja"},
              {ParameterUnregelmaessig.gerund, "ja"}
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void abschieben2()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\abschieben2.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "abschieben");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,"ab"},
              {ParameterUnregelmaessig.Parameter2, "schieb"},
              {ParameterUnregelmaessig.Parameter3, "schob"},
              {ParameterUnregelmaessig.Parameter4, "schöb"},
              {ParameterUnregelmaessig.Parameter5, "geschoben"},
              {ParameterUnregelmaessig.ZP,"nein"},
              {ParameterUnregelmaessig.VP, "es_wird"},
              {ParameterUnregelmaessig.gerund, "nein"},
              {ParameterUnregelmaessig.Hilfsverb, "sein"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void eingeben()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\eingeben.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "eingeben");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,"ein"},
              {ParameterUnregelmaessig.Parameter2, "geb"},
              {ParameterUnregelmaessig.Parameter3, "gab"},
              {ParameterUnregelmaessig.Parameter4, "gäb"},
              {ParameterUnregelmaessig.Parameter5, "gegeben"},
              {ParameterUnregelmaessig.Parameter6, "gib"},
              {ParameterUnregelmaessig.Parameter8, "i"},
              {ParameterUnregelmaessig.ZP,"sie_sind"},
              {ParameterUnregelmaessig.VP, "sie_werden"},
              {ParameterUnregelmaessig.gerund, "ja"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void auskommen()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\auskommen.txt";
            String[] text = Common.ReadLinesFromFile(filename);

            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "auskommen");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,"aus"},
              {ParameterUnregelmaessig.Parameter2, "komm"},
              {ParameterUnregelmaessig.Parameter3, "kam"},
              {ParameterUnregelmaessig.Parameter4, "käm"},
              {ParameterUnregelmaessig.Parameter5, "gekommen"},
              {ParameterUnregelmaessig.Hilfsverb, "sein"},
              {ParameterUnregelmaessig.ZP,"nein"},
              {ParameterUnregelmaessig.VP, "nein"},
              {ParameterUnregelmaessig.gerund, "nein"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }

        [TestMethod]
        public void überschreiten()
        {
            String filename = @"..\..\TestInput\VerbConjugation\Syntax\ueberschreiten.txt";
            String[] text = Common.ReadLinesFromFile(filename);


            VerbUnregelmaessigParser verbConjugationParser = new VerbUnregelmaessigParser();
            Dictionary<String, String> parsedParameters = verbConjugationParser.ParseParameters(text, "überschreiten");
            Dictionary<String, String> expectedParameters = new Dictionary<string, string>() 
            {
              {ParameterUnregelmaessig.Parameter1,""},
              {ParameterUnregelmaessig.Parameter2, "überschreit"},
              {ParameterUnregelmaessig.Parameter3, "überschritt"},
              {ParameterUnregelmaessig.Parameter4, "überschritt"},
              {ParameterUnregelmaessig.Parameter5, "überschritten"},
              {ParameterUnregelmaessig.Parameter7, "e"},
              {ParameterUnregelmaessig.Hilfsverb, "haben"},
              {ParameterUnregelmaessig.ZP,"sie_sind"},
              {ParameterUnregelmaessig.VP, "sie_werden"},
              {ParameterUnregelmaessig.gerund, "ja"},
            };
            Assert.IsTrue(expectedParameters.DictionaryEqual<String, String>(parsedParameters));
        }
    }
}
