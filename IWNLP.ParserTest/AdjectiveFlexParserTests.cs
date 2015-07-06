using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IWNLP.Parser.FlexParser;
using IWNLP.Models.Flections;
using IWNLP.Parser;
using System.Collections.Generic;
using GenericXMLSerializer;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class AdjectiveFlexParserTests
    {
        [TestMethod]
        public void lecker()
        {
            String word = "lecker";
            String filename = @"..\..\TestInput\AdjectiveDeclination\lecker.txt";
            String text = Common.ReadFromFile(filename);
            int wikiID = 262980;

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);


            AdjectiveDeclination expected = new AdjectiveDeclination();
            expected.Text = word;
            expected.WiktionaryID = wikiID;
            expected.PositivStamm = "lecker";
            expected.KomparativStamm = "leckerer";
            expected.KomparativStammOhneE = "leckrer";
            expected.SuperlativStamm = "leckerst";

            expected.PositivMaskulinumNominativStark.Add("leckerer");
            expected.PositivMaskulinumNominativStark.Add("leckrer");
            expected.PositivMaskulinumGenitivStark.Add("leckeren");
            expected.PositivMaskulinumGenitivStark.Add("leckren");
            expected.PositivMaskulinumDativStark.Add("leckerem");
            expected.PositivMaskulinumDativStark.Add("leckrem");
            expected.PositivMaskulinumAkkusativStark.Add("leckeren");
            expected.PositivMaskulinumAkkusativStark.Add("leckren");
            expected.PositivFemininumNominativStark.Add("leckere");
            expected.PositivFemininumNominativStark.Add("leckre");
            expected.PositivFemininumGenitivStark.Add("leckerer");
            expected.PositivFemininumGenitivStark.Add("leckrer");
            expected.PositivFemininumDativStark.Add("leckerer");
            expected.PositivFemininumDativStark.Add("leckrer");
            expected.PositivFemininumAkkusativStark.Add("leckere");
            expected.PositivFemininumAkkusativStark.Add("leckre");
            expected.PositivNeutrumNominativStark.Add("leckeres");
            expected.PositivNeutrumNominativStark.Add("leckres");
            expected.PositivNeutrumGenitivStark.Add("leckeren");
            expected.PositivNeutrumGenitivStark.Add("leckren");
            expected.PositivNeutrumDativStark.Add("leckerem");
            expected.PositivNeutrumDativStark.Add("leckrem");
            expected.PositivNeutrumAkkusativStark.Add("leckeres");
            expected.PositivNeutrumAkkusativStark.Add("leckres");
            expected.PositivPluralNominativStark.Add("leckere");
            expected.PositivPluralNominativStark.Add("leckre");
            expected.PositivPluralGenitivStark.Add("leckerer");
            expected.PositivPluralGenitivStark.Add("leckrer");
            expected.PositivPluralDativStark.Add("leckeren");
            expected.PositivPluralDativStark.Add("leckren");
            expected.PositivPluralAkkusativStark.Add("leckere");
            expected.PositivPluralAkkusativStark.Add("leckre");

            expected.PositivMaskulinumNominativSchwach.Add("leckere");
            expected.PositivMaskulinumNominativSchwach.Add("leckre");
            expected.PositivMaskulinumGenitivSchwach.Add("leckeren");
            expected.PositivMaskulinumGenitivSchwach.Add("leckren");
            expected.PositivMaskulinumDativSchwach.Add("leckeren");
            expected.PositivMaskulinumDativSchwach.Add("leckren");
            expected.PositivMaskulinumAkkusativSchwach.Add("leckeren");
            expected.PositivMaskulinumAkkusativSchwach.Add("leckren");
            expected.PositivFemininumNominativSchwach.Add("leckere");
            expected.PositivFemininumNominativSchwach.Add("leckre");
            expected.PositivFemininumGenitivSchwach.Add("leckeren");
            expected.PositivFemininumGenitivSchwach.Add("leckren");
            expected.PositivFemininumDativSchwach.Add("leckeren");
            expected.PositivFemininumDativSchwach.Add("leckren");
            expected.PositivFemininumAkkusativSchwach.Add("leckere");
            expected.PositivFemininumAkkusativSchwach.Add("leckre");
            expected.PositivNeutrumNominativSchwach.Add("leckere");
            expected.PositivNeutrumNominativSchwach.Add("leckre");
            expected.PositivNeutrumGenitivSchwach.Add("leckeren");
            expected.PositivNeutrumGenitivSchwach.Add("leckren");
            expected.PositivNeutrumDativSchwach.Add("leckeren");
            expected.PositivNeutrumDativSchwach.Add("leckren");
            expected.PositivNeutrumAkkusativSchwach.Add("leckere");
            expected.PositivNeutrumAkkusativSchwach.Add("leckre");
            expected.PositivPluralNominativSchwach.Add("leckeren");
            expected.PositivPluralNominativSchwach.Add("leckren");
            expected.PositivPluralGenitivSchwach.Add("leckeren");
            expected.PositivPluralGenitivSchwach.Add("leckren");
            expected.PositivPluralDativSchwach.Add("leckeren");
            expected.PositivPluralDativSchwach.Add("leckren");
            expected.PositivPluralAkkusativSchwach.Add("leckeren");
            expected.PositivPluralAkkusativSchwach.Add("leckren");

            expected.PositivMaskulinumNominativGemischt.Add("leckerer");
            expected.PositivMaskulinumNominativGemischt.Add("leckrer");
            expected.PositivMaskulinumGenitivGemischt.Add("leckeren");
            expected.PositivMaskulinumGenitivGemischt.Add("leckren");
            expected.PositivMaskulinumDativGemischt.Add("leckeren");
            expected.PositivMaskulinumDativGemischt.Add("leckren");
            expected.PositivMaskulinumAkkusativGemischt.Add("leckeren");
            expected.PositivMaskulinumAkkusativGemischt.Add("leckren");
            expected.PositivFemininumNominativGemischt.Add("leckere");
            expected.PositivFemininumNominativGemischt.Add("leckre");
            expected.PositivFemininumGenitivGemischt.Add("leckeren");
            expected.PositivFemininumGenitivGemischt.Add("leckren");
            expected.PositivFemininumDativGemischt.Add("leckeren");
            expected.PositivFemininumDativGemischt.Add("leckren");
            expected.PositivFemininumAkkusativGemischt.Add("leckere");
            expected.PositivFemininumAkkusativGemischt.Add("leckre");
            expected.PositivNeutrumNominativGemischt.Add("leckeres");
            expected.PositivNeutrumNominativGemischt.Add("leckres");
            expected.PositivNeutrumGenitivGemischt.Add("leckeren");
            expected.PositivNeutrumGenitivGemischt.Add("leckren");
            expected.PositivNeutrumDativGemischt.Add("leckeren");
            expected.PositivNeutrumDativGemischt.Add("leckren");
            expected.PositivNeutrumAkkusativGemischt.Add("leckeres");
            expected.PositivNeutrumAkkusativGemischt.Add("leckres");
            expected.PositivPluralNominativGemischt.Add("leckeren");
            expected.PositivPluralNominativGemischt.Add("leckren");
            expected.PositivPluralGenitivGemischt.Add("leckeren");
            expected.PositivPluralGenitivGemischt.Add("leckren");
            expected.PositivPluralDativGemischt.Add("leckeren");
            expected.PositivPluralDativGemischt.Add("leckren");
            expected.PositivPluralAkkusativGemischt.Add("leckeren");
            expected.PositivPluralAkkusativGemischt.Add("leckren");

            // KOMPARATIV
            expected.KomparativMaskulinumNominativStark.Add("leckererer");
            expected.KomparativMaskulinumNominativStark.Add("leckrerer");
            expected.KomparativMaskulinumGenitivStark.Add("leckereren");
            expected.KomparativMaskulinumGenitivStark.Add("leckreren");
            expected.KomparativMaskulinumDativStark.Add("leckererem");
            expected.KomparativMaskulinumDativStark.Add("leckrerem");
            expected.KomparativMaskulinumAkkusativStark.Add("leckereren");
            expected.KomparativMaskulinumAkkusativStark.Add("leckreren");
            expected.KomparativFemininumNominativStark.Add("leckerere");
            expected.KomparativFemininumNominativStark.Add("leckrere");
            expected.KomparativFemininumGenitivStark.Add("leckererer");
            expected.KomparativFemininumGenitivStark.Add("leckrerer");
            expected.KomparativFemininumDativStark.Add("leckererer");
            expected.KomparativFemininumDativStark.Add("leckrerer");
            expected.KomparativFemininumAkkusativStark.Add("leckerere");
            expected.KomparativFemininumAkkusativStark.Add("leckrere");
            expected.KomparativNeutrumNominativStark.Add("leckereres");
            expected.KomparativNeutrumNominativStark.Add("leckreres");
            expected.KomparativNeutrumGenitivStark.Add("leckereren");
            expected.KomparativNeutrumGenitivStark.Add("leckreren");
            expected.KomparativNeutrumDativStark.Add("leckererem");
            expected.KomparativNeutrumDativStark.Add("leckrerem");
            expected.KomparativNeutrumAkkusativStark.Add("leckereres");
            expected.KomparativNeutrumAkkusativStark.Add("leckreres");
            expected.KomparativPluralNominativStark.Add("leckerere");
            expected.KomparativPluralNominativStark.Add("leckrere");
            expected.KomparativPluralGenitivStark.Add("leckererer");
            expected.KomparativPluralGenitivStark.Add("leckrerer");
            expected.KomparativPluralDativStark.Add("leckereren");
            expected.KomparativPluralDativStark.Add("leckreren");
            expected.KomparativPluralAkkusativStark.Add("leckerere");
            expected.KomparativPluralAkkusativStark.Add("leckrere");

            expected.KomparativMaskulinumNominativSchwach.Add("leckerere");
            expected.KomparativMaskulinumNominativSchwach.Add("leckrere");
            expected.KomparativMaskulinumGenitivSchwach.Add("leckereren");
            expected.KomparativMaskulinumGenitivSchwach.Add("leckreren");
            expected.KomparativMaskulinumDativSchwach.Add("leckereren");
            expected.KomparativMaskulinumDativSchwach.Add("leckreren");
            expected.KomparativMaskulinumAkkusativSchwach.Add("leckereren");
            expected.KomparativMaskulinumAkkusativSchwach.Add("leckreren");
            expected.KomparativFemininumNominativSchwach.Add("leckerere");
            expected.KomparativFemininumNominativSchwach.Add("leckrere");
            expected.KomparativFemininumGenitivSchwach.Add("leckereren");
            expected.KomparativFemininumGenitivSchwach.Add("leckreren");
            expected.KomparativFemininumDativSchwach.Add("leckereren");
            expected.KomparativFemininumDativSchwach.Add("leckreren");
            expected.KomparativFemininumAkkusativSchwach.Add("leckerere");
            expected.KomparativFemininumAkkusativSchwach.Add("leckrere");
            expected.KomparativNeutrumNominativSchwach.Add("leckerere");
            expected.KomparativNeutrumNominativSchwach.Add("leckrere");
            expected.KomparativNeutrumGenitivSchwach.Add("leckereren");
            expected.KomparativNeutrumGenitivSchwach.Add("leckreren");
            expected.KomparativNeutrumDativSchwach.Add("leckereren");
            expected.KomparativNeutrumDativSchwach.Add("leckreren");
            expected.KomparativNeutrumAkkusativSchwach.Add("leckerere");
            expected.KomparativNeutrumAkkusativSchwach.Add("leckrere");
            expected.KomparativPluralNominativSchwach.Add("leckereren");
            expected.KomparativPluralNominativSchwach.Add("leckreren");
            expected.KomparativPluralGenitivSchwach.Add("leckereren");
            expected.KomparativPluralGenitivSchwach.Add("leckreren");
            expected.KomparativPluralDativSchwach.Add("leckereren");
            expected.KomparativPluralDativSchwach.Add("leckreren");
            expected.KomparativPluralAkkusativSchwach.Add("leckereren");
            expected.KomparativPluralAkkusativSchwach.Add("leckreren");

            expected.KomparativMaskulinumNominativGemischt.Add("leckererer");
            expected.KomparativMaskulinumNominativGemischt.Add("leckrerer");
            expected.KomparativMaskulinumGenitivGemischt.Add("leckereren");
            expected.KomparativMaskulinumGenitivGemischt.Add("leckreren");
            expected.KomparativMaskulinumDativGemischt.Add("leckereren");
            expected.KomparativMaskulinumDativGemischt.Add("leckreren");
            expected.KomparativMaskulinumAkkusativGemischt.Add("leckereren");
            expected.KomparativMaskulinumAkkusativGemischt.Add("leckreren");
            expected.KomparativFemininumNominativGemischt.Add("leckerere");
            expected.KomparativFemininumNominativGemischt.Add("leckrere");
            expected.KomparativFemininumGenitivGemischt.Add("leckereren");
            expected.KomparativFemininumGenitivGemischt.Add("leckreren");
            expected.KomparativFemininumDativGemischt.Add("leckereren");
            expected.KomparativFemininumDativGemischt.Add("leckreren");
            expected.KomparativFemininumAkkusativGemischt.Add("leckerere");
            expected.KomparativFemininumAkkusativGemischt.Add("leckrere");
            expected.KomparativNeutrumNominativGemischt.Add("leckereres");
            expected.KomparativNeutrumNominativGemischt.Add("leckreres");
            expected.KomparativNeutrumGenitivGemischt.Add("leckereren");
            expected.KomparativNeutrumGenitivGemischt.Add("leckreren");
            expected.KomparativNeutrumDativGemischt.Add("leckereren");
            expected.KomparativNeutrumDativGemischt.Add("leckreren");
            expected.KomparativNeutrumAkkusativGemischt.Add("leckereres");
            expected.KomparativNeutrumAkkusativGemischt.Add("leckreres");
            expected.KomparativPluralNominativGemischt.Add("leckereren");
            expected.KomparativPluralNominativGemischt.Add("leckreren");
            expected.KomparativPluralGenitivGemischt.Add("leckereren");
            expected.KomparativPluralGenitivGemischt.Add("leckreren");
            expected.KomparativPluralDativGemischt.Add("leckereren");
            expected.KomparativPluralDativGemischt.Add("leckreren");
            expected.KomparativPluralAkkusativGemischt.Add("leckereren");
            expected.KomparativPluralAkkusativGemischt.Add("leckreren");

            // SUPERLATIV
            expected.SuperlativMaskulinumNominativStark.Add("leckerster");
            expected.SuperlativMaskulinumGenitivStark.Add("leckersten");
            expected.SuperlativMaskulinumDativStark.Add("leckerstem");
            expected.SuperlativMaskulinumAkkusativStark.Add("leckersten");
            expected.SuperlativFemininumNominativStark.Add("leckerste");
            expected.SuperlativFemininumGenitivStark.Add("leckerster");
            expected.SuperlativFemininumDativStark.Add("leckerster");
            expected.SuperlativFemininumAkkusativStark.Add("leckerste");
            expected.SuperlativNeutrumNominativStark.Add("leckerstes");
            expected.SuperlativNeutrumGenitivStark.Add("leckersten");
            expected.SuperlativNeutrumDativStark.Add("leckerstem");
            expected.SuperlativNeutrumAkkusativStark.Add("leckerstes");
            expected.SuperlativPluralNominativStark.Add("leckerste");
            expected.SuperlativPluralGenitivStark.Add("leckerster");
            expected.SuperlativPluralDativStark.Add("leckersten");
            expected.SuperlativPluralAkkusativStark.Add("leckerste");

            expected.SuperlativMaskulinumNominativSchwach.Add("leckerste");
            expected.SuperlativMaskulinumGenitivSchwach.Add("leckersten");
            expected.SuperlativMaskulinumDativSchwach.Add("leckersten");
            expected.SuperlativMaskulinumAkkusativSchwach.Add("leckersten");
            expected.SuperlativFemininumNominativSchwach.Add("leckerste");
            expected.SuperlativFemininumGenitivSchwach.Add("leckersten");
            expected.SuperlativFemininumDativSchwach.Add("leckersten");
            expected.SuperlativFemininumAkkusativSchwach.Add("leckerste");
            expected.SuperlativNeutrumNominativSchwach.Add("leckerste");
            expected.SuperlativNeutrumGenitivSchwach.Add("leckersten");
            expected.SuperlativNeutrumDativSchwach.Add("leckersten");
            expected.SuperlativNeutrumAkkusativSchwach.Add("leckerste");
            expected.SuperlativPluralNominativSchwach.Add("leckersten");
            expected.SuperlativPluralGenitivSchwach.Add("leckersten");
            expected.SuperlativPluralDativSchwach.Add("leckersten");
            expected.SuperlativPluralAkkusativSchwach.Add("leckersten");

            expected.SuperlativMaskulinumNominativGemischt.Add("leckerster");
            expected.SuperlativMaskulinumGenitivGemischt.Add("leckersten");
            expected.SuperlativMaskulinumDativGemischt.Add("leckersten");
            expected.SuperlativMaskulinumAkkusativGemischt.Add("leckersten");
            expected.SuperlativFemininumNominativGemischt.Add("leckerste");
            expected.SuperlativFemininumGenitivGemischt.Add("leckersten");
            expected.SuperlativFemininumDativGemischt.Add("leckersten");
            expected.SuperlativFemininumAkkusativGemischt.Add("leckerste");
            expected.SuperlativNeutrumNominativGemischt.Add("leckerstes");
            expected.SuperlativNeutrumGenitivGemischt.Add("leckersten");
            expected.SuperlativNeutrumDativGemischt.Add("leckersten");
            expected.SuperlativNeutrumAkkusativGemischt.Add("leckerstes");
            expected.SuperlativPluralNominativGemischt.Add("leckersten");
            expected.SuperlativPluralGenitivGemischt.Add("leckersten");
            expected.SuperlativPluralDativGemischt.Add("leckersten");
            expected.SuperlativPluralAkkusativGemischt.Add("leckersten");

            List<Models.Entry> expectedList = new List<Models.Entry>();
            expectedList.Add(expected);

            XMLSerializer.Serialize<List<Models.Entry>>(words, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_result.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(expectedList, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_expected.txt"));
            CollectionAssert.AreEqual(expectedList, words, "failed");
        }

        [TestMethod]
        public void rot()
        {
            String word = "rot";
            String filename = @"..\..\TestInput\AdjectiveDeclination\rot.txt";
            String text = Common.ReadFromFile(filename);
            int wikiID = 301714;

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);
            AdjectiveDeclination expected = new AdjectiveDeclination();
            expected.Text = word;
            expected.WiktionaryID = wikiID;
            expected.PositivStamm = "rot";
            expected.KomparativStamm = "röter";
            expected.KomparativStammAlternative = "roter";
            expected.SuperlativStamm = "rötest";
            expected.SuperlativStammAlternative = "rotest";

            expected.PositivMaskulinumNominativStark.Add("roter");
            expected.PositivMaskulinumGenitivStark.Add("roten");
            expected.PositivMaskulinumDativStark.Add("rotem");
            expected.PositivMaskulinumAkkusativStark.Add("roten");
            expected.PositivFemininumNominativStark.Add("rote");
            expected.PositivFemininumGenitivStark.Add("roter");
            expected.PositivFemininumDativStark.Add("roter");
            expected.PositivFemininumAkkusativStark.Add("rote");
            expected.PositivNeutrumNominativStark.Add("rotes");
            expected.PositivNeutrumGenitivStark.Add("roten");
            expected.PositivNeutrumDativStark.Add("rotem");
            expected.PositivNeutrumAkkusativStark.Add("rotes");
            expected.PositivPluralNominativStark.Add("rote");
            expected.PositivPluralGenitivStark.Add("roter");
            expected.PositivPluralDativStark.Add("roten");
            expected.PositivPluralAkkusativStark.Add("rote");

            expected.PositivMaskulinumNominativSchwach.Add("rote");
            expected.PositivMaskulinumGenitivSchwach.Add("roten");
            expected.PositivMaskulinumDativSchwach.Add("roten");
            expected.PositivMaskulinumAkkusativSchwach.Add("roten");
            expected.PositivFemininumNominativSchwach.Add("rote");
            expected.PositivFemininumGenitivSchwach.Add("roten");
            expected.PositivFemininumDativSchwach.Add("roten");
            expected.PositivFemininumAkkusativSchwach.Add("rote");
            expected.PositivNeutrumNominativSchwach.Add("rote");
            expected.PositivNeutrumGenitivSchwach.Add("roten");
            expected.PositivNeutrumDativSchwach.Add("roten");
            expected.PositivNeutrumAkkusativSchwach.Add("rote");
            expected.PositivPluralNominativSchwach.Add("roten");
            expected.PositivPluralGenitivSchwach.Add("roten");
            expected.PositivPluralDativSchwach.Add("roten");
            expected.PositivPluralAkkusativSchwach.Add("roten");

            expected.PositivMaskulinumNominativGemischt.Add("roter");
            expected.PositivMaskulinumGenitivGemischt.Add("roten");
            expected.PositivMaskulinumDativGemischt.Add("roten");
            expected.PositivMaskulinumAkkusativGemischt.Add("roten");
            expected.PositivFemininumNominativGemischt.Add("rote");
            expected.PositivFemininumGenitivGemischt.Add("roten");
            expected.PositivFemininumDativGemischt.Add("roten");
            expected.PositivFemininumAkkusativGemischt.Add("rote");
            expected.PositivNeutrumNominativGemischt.Add("rotes");
            expected.PositivNeutrumGenitivGemischt.Add("roten");
            expected.PositivNeutrumDativGemischt.Add("roten");
            expected.PositivNeutrumAkkusativGemischt.Add("rotes");
            expected.PositivPluralNominativGemischt.Add("roten");
            expected.PositivPluralGenitivGemischt.Add("roten");
            expected.PositivPluralDativGemischt.Add("roten");
            expected.PositivPluralAkkusativGemischt.Add("roten");

            // KOMPARATIV
            expected.KomparativMaskulinumNominativStark.Add("röterer");
            expected.KomparativMaskulinumNominativStark.Add("roterer");
            expected.KomparativMaskulinumGenitivStark.Add("röteren");
            expected.KomparativMaskulinumGenitivStark.Add("roteren");
            expected.KomparativMaskulinumDativStark.Add("röterem");
            expected.KomparativMaskulinumDativStark.Add("roterem");
            expected.KomparativMaskulinumAkkusativStark.Add("röteren");
            expected.KomparativMaskulinumAkkusativStark.Add("roteren");
            expected.KomparativFemininumNominativStark.Add("rötere");
            expected.KomparativFemininumNominativStark.Add("rotere");
            expected.KomparativFemininumGenitivStark.Add("röterer");
            expected.KomparativFemininumGenitivStark.Add("roterer");
            expected.KomparativFemininumDativStark.Add("röterer");
            expected.KomparativFemininumDativStark.Add("roterer");
            expected.KomparativFemininumAkkusativStark.Add("rötere");
            expected.KomparativFemininumAkkusativStark.Add("rotere");
            expected.KomparativNeutrumNominativStark.Add("röteres");
            expected.KomparativNeutrumNominativStark.Add("roteres");
            expected.KomparativNeutrumGenitivStark.Add("röteren");
            expected.KomparativNeutrumGenitivStark.Add("roteren");
            expected.KomparativNeutrumDativStark.Add("röterem");
            expected.KomparativNeutrumDativStark.Add("roterem");
            expected.KomparativNeutrumAkkusativStark.Add("röteres");
            expected.KomparativNeutrumAkkusativStark.Add("roteres");
            expected.KomparativPluralNominativStark.Add("rötere");
            expected.KomparativPluralNominativStark.Add("rotere");
            expected.KomparativPluralGenitivStark.Add("röterer");
            expected.KomparativPluralGenitivStark.Add("roterer");
            expected.KomparativPluralDativStark.Add("röteren");
            expected.KomparativPluralDativStark.Add("roteren");
            expected.KomparativPluralAkkusativStark.Add("rötere");
            expected.KomparativPluralAkkusativStark.Add("rotere");

            expected.KomparativMaskulinumNominativSchwach.Add("rötere");
            expected.KomparativMaskulinumNominativSchwach.Add("rotere");
            expected.KomparativMaskulinumGenitivSchwach.Add("röteren");
            expected.KomparativMaskulinumGenitivSchwach.Add("roteren");
            expected.KomparativMaskulinumDativSchwach.Add("röteren");
            expected.KomparativMaskulinumDativSchwach.Add("roteren");
            expected.KomparativMaskulinumAkkusativSchwach.Add("röteren");
            expected.KomparativMaskulinumAkkusativSchwach.Add("roteren");
            expected.KomparativFemininumNominativSchwach.Add("rötere");
            expected.KomparativFemininumNominativSchwach.Add("rotere");
            expected.KomparativFemininumGenitivSchwach.Add("röteren");
            expected.KomparativFemininumGenitivSchwach.Add("roteren");
            expected.KomparativFemininumDativSchwach.Add("röteren");
            expected.KomparativFemininumDativSchwach.Add("roteren");
            expected.KomparativFemininumAkkusativSchwach.Add("rötere");
            expected.KomparativFemininumAkkusativSchwach.Add("rotere");
            expected.KomparativNeutrumNominativSchwach.Add("rötere");
            expected.KomparativNeutrumNominativSchwach.Add("rotere");
            expected.KomparativNeutrumGenitivSchwach.Add("röteren");
            expected.KomparativNeutrumGenitivSchwach.Add("roteren");
            expected.KomparativNeutrumDativSchwach.Add("röteren");
            expected.KomparativNeutrumDativSchwach.Add("roteren");
            expected.KomparativNeutrumAkkusativSchwach.Add("rötere");
            expected.KomparativNeutrumAkkusativSchwach.Add("rotere");
            expected.KomparativPluralNominativSchwach.Add("röteren");
            expected.KomparativPluralNominativSchwach.Add("roteren");
            expected.KomparativPluralGenitivSchwach.Add("röteren");
            expected.KomparativPluralGenitivSchwach.Add("roteren");
            expected.KomparativPluralDativSchwach.Add("röteren");
            expected.KomparativPluralDativSchwach.Add("roteren");
            expected.KomparativPluralAkkusativSchwach.Add("röteren");
            expected.KomparativPluralAkkusativSchwach.Add("roteren");

            expected.KomparativMaskulinumNominativGemischt.Add("röterer");
            expected.KomparativMaskulinumNominativGemischt.Add("roterer");
            expected.KomparativMaskulinumGenitivGemischt.Add("röteren");
            expected.KomparativMaskulinumGenitivGemischt.Add("roteren");
            expected.KomparativMaskulinumDativGemischt.Add("röteren");
            expected.KomparativMaskulinumDativGemischt.Add("roteren");
            expected.KomparativMaskulinumAkkusativGemischt.Add("röteren");
            expected.KomparativMaskulinumAkkusativGemischt.Add("roteren");
            expected.KomparativFemininumNominativGemischt.Add("rötere");
            expected.KomparativFemininumNominativGemischt.Add("rotere");
            expected.KomparativFemininumGenitivGemischt.Add("röteren");
            expected.KomparativFemininumGenitivGemischt.Add("roteren");
            expected.KomparativFemininumDativGemischt.Add("röteren");
            expected.KomparativFemininumDativGemischt.Add("roteren");
            expected.KomparativFemininumAkkusativGemischt.Add("rötere");
            expected.KomparativFemininumAkkusativGemischt.Add("rotere");
            expected.KomparativNeutrumNominativGemischt.Add("röteres");
            expected.KomparativNeutrumNominativGemischt.Add("roteres");
            expected.KomparativNeutrumGenitivGemischt.Add("röteren");
            expected.KomparativNeutrumGenitivGemischt.Add("roteren");
            expected.KomparativNeutrumDativGemischt.Add("röteren");
            expected.KomparativNeutrumDativGemischt.Add("roteren");
            expected.KomparativNeutrumAkkusativGemischt.Add("röteres");
            expected.KomparativNeutrumAkkusativGemischt.Add("roteres");
            expected.KomparativPluralNominativGemischt.Add("röteren");
            expected.KomparativPluralNominativGemischt.Add("roteren");
            expected.KomparativPluralGenitivGemischt.Add("röteren");
            expected.KomparativPluralGenitivGemischt.Add("roteren");
            expected.KomparativPluralDativGemischt.Add("röteren");
            expected.KomparativPluralDativGemischt.Add("roteren");
            expected.KomparativPluralAkkusativGemischt.Add("röteren");
            expected.KomparativPluralAkkusativGemischt.Add("roteren");

            // SUPERLATIV
            expected.SuperlativMaskulinumNominativStark.Add("rötester");
            expected.SuperlativMaskulinumNominativStark.Add("rotester");
            expected.SuperlativMaskulinumGenitivStark.Add("rötesten");
            expected.SuperlativMaskulinumGenitivStark.Add("rotesten");
            expected.SuperlativMaskulinumDativStark.Add("rötestem");
            expected.SuperlativMaskulinumDativStark.Add("rotestem");
            expected.SuperlativMaskulinumAkkusativStark.Add("rötesten");
            expected.SuperlativMaskulinumAkkusativStark.Add("rotesten");
            expected.SuperlativFemininumNominativStark.Add("röteste");
            expected.SuperlativFemininumNominativStark.Add("roteste");
            expected.SuperlativFemininumGenitivStark.Add("rötester");
            expected.SuperlativFemininumGenitivStark.Add("rotester");
            expected.SuperlativFemininumDativStark.Add("rötester");
            expected.SuperlativFemininumDativStark.Add("rotester");
            expected.SuperlativFemininumAkkusativStark.Add("röteste");
            expected.SuperlativFemininumAkkusativStark.Add("roteste");
            expected.SuperlativNeutrumNominativStark.Add("rötestes");
            expected.SuperlativNeutrumNominativStark.Add("rotestes");
            expected.SuperlativNeutrumGenitivStark.Add("rötesten");
            expected.SuperlativNeutrumGenitivStark.Add("rotesten");
            expected.SuperlativNeutrumDativStark.Add("rötestem");
            expected.SuperlativNeutrumDativStark.Add("rotestem");
            expected.SuperlativNeutrumAkkusativStark.Add("rötestes");
            expected.SuperlativNeutrumAkkusativStark.Add("rotestes");
            expected.SuperlativPluralNominativStark.Add("röteste");
            expected.SuperlativPluralNominativStark.Add("roteste");
            expected.SuperlativPluralGenitivStark.Add("rötester");
            expected.SuperlativPluralGenitivStark.Add("rotester");
            expected.SuperlativPluralDativStark.Add("rötesten");
            expected.SuperlativPluralDativStark.Add("rotesten");
            expected.SuperlativPluralAkkusativStark.Add("röteste");
            expected.SuperlativPluralAkkusativStark.Add("roteste");

            expected.SuperlativMaskulinumNominativSchwach.Add("röteste");
            expected.SuperlativMaskulinumNominativSchwach.Add("roteste");
            expected.SuperlativMaskulinumGenitivSchwach.Add("rötesten");
            expected.SuperlativMaskulinumGenitivSchwach.Add("rotesten");
            expected.SuperlativMaskulinumDativSchwach.Add("rötesten");
            expected.SuperlativMaskulinumDativSchwach.Add("rotesten");
            expected.SuperlativMaskulinumAkkusativSchwach.Add("rötesten");
            expected.SuperlativMaskulinumAkkusativSchwach.Add("rotesten");
            expected.SuperlativFemininumNominativSchwach.Add("röteste");
            expected.SuperlativFemininumNominativSchwach.Add("roteste");
            expected.SuperlativFemininumGenitivSchwach.Add("rötesten");
            expected.SuperlativFemininumGenitivSchwach.Add("rotesten");
            expected.SuperlativFemininumDativSchwach.Add("rötesten");
            expected.SuperlativFemininumDativSchwach.Add("rotesten");
            expected.SuperlativFemininumAkkusativSchwach.Add("röteste");
            expected.SuperlativFemininumAkkusativSchwach.Add("roteste");
            expected.SuperlativNeutrumNominativSchwach.Add("röteste");
            expected.SuperlativNeutrumNominativSchwach.Add("roteste");
            expected.SuperlativNeutrumGenitivSchwach.Add("rötesten");
            expected.SuperlativNeutrumGenitivSchwach.Add("rotesten");
            expected.SuperlativNeutrumDativSchwach.Add("rötesten");
            expected.SuperlativNeutrumDativSchwach.Add("rotesten");
            expected.SuperlativNeutrumAkkusativSchwach.Add("röteste");
            expected.SuperlativNeutrumAkkusativSchwach.Add("roteste");
            expected.SuperlativPluralNominativSchwach.Add("rötesten");
            expected.SuperlativPluralNominativSchwach.Add("rotesten");
            expected.SuperlativPluralGenitivSchwach.Add("rötesten");
            expected.SuperlativPluralGenitivSchwach.Add("rotesten");
            expected.SuperlativPluralDativSchwach.Add("rötesten");
            expected.SuperlativPluralDativSchwach.Add("rotesten");
            expected.SuperlativPluralAkkusativSchwach.Add("rötesten");
            expected.SuperlativPluralAkkusativSchwach.Add("rotesten");

            expected.SuperlativMaskulinumNominativGemischt.Add("rötester");
            expected.SuperlativMaskulinumNominativGemischt.Add("rotester");
            expected.SuperlativMaskulinumGenitivGemischt.Add("rötesten");
            expected.SuperlativMaskulinumGenitivGemischt.Add("rotesten");
            expected.SuperlativMaskulinumDativGemischt.Add("rötesten");
            expected.SuperlativMaskulinumDativGemischt.Add("rotesten");
            expected.SuperlativMaskulinumAkkusativGemischt.Add("rötesten");
            expected.SuperlativMaskulinumAkkusativGemischt.Add("rotesten");
            expected.SuperlativFemininumNominativGemischt.Add("röteste");
            expected.SuperlativFemininumNominativGemischt.Add("roteste");
            expected.SuperlativFemininumGenitivGemischt.Add("rötesten");
            expected.SuperlativFemininumGenitivGemischt.Add("rotesten");
            expected.SuperlativFemininumDativGemischt.Add("rötesten");
            expected.SuperlativFemininumDativGemischt.Add("rotesten");
            expected.SuperlativFemininumAkkusativGemischt.Add("röteste");
            expected.SuperlativFemininumAkkusativGemischt.Add("roteste");
            expected.SuperlativNeutrumNominativGemischt.Add("rötestes");
            expected.SuperlativNeutrumNominativGemischt.Add("rotestes");
            expected.SuperlativNeutrumGenitivGemischt.Add("rötesten");
            expected.SuperlativNeutrumGenitivGemischt.Add("rotesten");
            expected.SuperlativNeutrumDativGemischt.Add("rötesten");
            expected.SuperlativNeutrumDativGemischt.Add("rotesten");
            expected.SuperlativNeutrumAkkusativGemischt.Add("rötestes");
            expected.SuperlativNeutrumAkkusativGemischt.Add("rotestes");
            expected.SuperlativPluralNominativGemischt.Add("rötesten");
            expected.SuperlativPluralNominativGemischt.Add("rotesten");
            expected.SuperlativPluralGenitivGemischt.Add("rötesten");
            expected.SuperlativPluralGenitivGemischt.Add("rotesten");
            expected.SuperlativPluralDativGemischt.Add("rötesten");
            expected.SuperlativPluralDativGemischt.Add("rotesten");
            expected.SuperlativPluralAkkusativGemischt.Add("rötesten");
            expected.SuperlativPluralAkkusativGemischt.Add("rotesten");

            List<Models.Entry> expectedList = new List<Models.Entry>();
            expectedList.Add(expected);

            XMLSerializer.Serialize<List<Models.Entry>>(words, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_result.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(expectedList, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_expected.txt"));
            CollectionAssert.AreEqual(expectedList, words, "failed");

        }

        [TestMethod]
        public void traumlos()
        {
            String word = "traumlos";
            String filename = @"..\..\TestInput\AdjectiveDeclination\traumlos.txt";
            String text = Common.ReadFromFile(filename);
            int wikiID = 117700;

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);

            AdjectiveDeclination expected = new AdjectiveDeclination();
            expected.Text = word;
            expected.WiktionaryID = wikiID;
            expected.PositivStamm = "traumlos";


            expected.PositivMaskulinumNominativStark.Add("traumloser");
            expected.PositivMaskulinumGenitivStark.Add("traumlosen");
            expected.PositivMaskulinumDativStark.Add("traumlosem");
            expected.PositivMaskulinumAkkusativStark.Add("traumlosen");
            expected.PositivFemininumNominativStark.Add("traumlose");
            expected.PositivFemininumGenitivStark.Add("traumloser");
            expected.PositivFemininumDativStark.Add("traumloser");
            expected.PositivFemininumAkkusativStark.Add("traumlose");
            expected.PositivNeutrumNominativStark.Add("traumloses");
            expected.PositivNeutrumGenitivStark.Add("traumlosen");
            expected.PositivNeutrumDativStark.Add("traumlosem");
            expected.PositivNeutrumAkkusativStark.Add("traumloses");
            expected.PositivPluralNominativStark.Add("traumlose");
            expected.PositivPluralGenitivStark.Add("traumloser");
            expected.PositivPluralDativStark.Add("traumlosen");
            expected.PositivPluralAkkusativStark.Add("traumlose");


            expected.PositivMaskulinumNominativSchwach.Add("traumlose");
            expected.PositivMaskulinumGenitivSchwach.Add("traumlosen");
            expected.PositivMaskulinumDativSchwach.Add("traumlosen");
            expected.PositivMaskulinumAkkusativSchwach.Add("traumlosen");
            expected.PositivFemininumNominativSchwach.Add("traumlose");
            expected.PositivFemininumGenitivSchwach.Add("traumlosen");
            expected.PositivFemininumDativSchwach.Add("traumlosen");
            expected.PositivFemininumAkkusativSchwach.Add("traumlose");
            expected.PositivNeutrumNominativSchwach.Add("traumlose");
            expected.PositivNeutrumGenitivSchwach.Add("traumlosen");
            expected.PositivNeutrumDativSchwach.Add("traumlosen");
            expected.PositivNeutrumAkkusativSchwach.Add("traumlose");
            expected.PositivPluralNominativSchwach.Add("traumlosen");
            expected.PositivPluralGenitivSchwach.Add("traumlosen");
            expected.PositivPluralDativSchwach.Add("traumlosen");
            expected.PositivPluralAkkusativSchwach.Add("traumlosen");


            expected.PositivMaskulinumNominativGemischt.Add("traumloser");
            expected.PositivMaskulinumGenitivGemischt.Add("traumlosen");
            expected.PositivMaskulinumDativGemischt.Add("traumlosen");
            expected.PositivMaskulinumAkkusativGemischt.Add("traumlosen");
            expected.PositivFemininumNominativGemischt.Add("traumlose");
            expected.PositivFemininumGenitivGemischt.Add("traumlosen");
            expected.PositivFemininumDativGemischt.Add("traumlosen");
            expected.PositivFemininumAkkusativGemischt.Add("traumlose");
            expected.PositivNeutrumNominativGemischt.Add("traumloses");
            expected.PositivNeutrumGenitivGemischt.Add("traumlosen");
            expected.PositivNeutrumDativGemischt.Add("traumlosen");
            expected.PositivNeutrumAkkusativGemischt.Add("traumloses");
            expected.PositivPluralNominativGemischt.Add("traumlosen");
            expected.PositivPluralGenitivGemischt.Add("traumlosen");
            expected.PositivPluralDativGemischt.Add("traumlosen");
            expected.PositivPluralAkkusativGemischt.Add("traumlosen");



            List<Models.Entry> expectedList = new List<Models.Entry>();
            expectedList.Add(expected);

            XMLSerializer.Serialize<List<Models.Entry>>(words, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_result.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(expectedList, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"flex_expected.txt"));
            CollectionAssert.AreEqual(expectedList, words, "failed");

        }

        [TestMethod]
        public void mittel()
        {
            String word = "mittel";
            String filename = @"..\..\TestInput\AdjectiveDeclination\mittel.txt";
            String text = Common.ReadFromFile(filename);
            int wikiID = 267415;

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wikiID);

            AdjectiveDeclination expected = new AdjectiveDeclination();
            expected.Text = word;
            expected.WiktionaryID = wikiID;
            expected.Positiv = "mittel";
            expected.KomparativStamm = "mittler";
            expected.SuperlativStamm = "mittelst";



            // Komparativ
            expected.KomparativMaskulinumNominativStark.Add("mittlerer");
            expected.KomparativMaskulinumGenitivStark.Add("mittleren");
            expected.KomparativMaskulinumDativStark.Add("mittlerem");
            expected.KomparativMaskulinumAkkusativStark.Add("mittleren");
            expected.KomparativFemininumNominativStark.Add("mittlere");
            expected.KomparativFemininumGenitivStark.Add("mittlerer");
            expected.KomparativFemininumDativStark.Add("mittlerer");
            expected.KomparativFemininumAkkusativStark.Add("mittlere");
            expected.KomparativNeutrumNominativStark.Add("mittleres");
            expected.KomparativNeutrumGenitivStark.Add("mittleren");
            expected.KomparativNeutrumDativStark.Add("mittlerem");
            expected.KomparativNeutrumAkkusativStark.Add("mittleres");
            expected.KomparativPluralNominativStark.Add("mittlere");
            expected.KomparativPluralGenitivStark.Add("mittlerer");
            expected.KomparativPluralDativStark.Add("mittleren");
            expected.KomparativPluralAkkusativStark.Add("mittlere");


            expected.KomparativMaskulinumNominativSchwach.Add("mittlere");
            expected.KomparativMaskulinumGenitivSchwach.Add("mittleren");
            expected.KomparativMaskulinumDativSchwach.Add("mittleren");
            expected.KomparativMaskulinumAkkusativSchwach.Add("mittleren");
            expected.KomparativFemininumNominativSchwach.Add("mittlere");
            expected.KomparativFemininumGenitivSchwach.Add("mittleren");
            expected.KomparativFemininumDativSchwach.Add("mittleren");
            expected.KomparativFemininumAkkusativSchwach.Add("mittlere");
            expected.KomparativNeutrumNominativSchwach.Add("mittlere");
            expected.KomparativNeutrumGenitivSchwach.Add("mittleren");
            expected.KomparativNeutrumDativSchwach.Add("mittleren");
            expected.KomparativNeutrumAkkusativSchwach.Add("mittlere");
            expected.KomparativPluralNominativSchwach.Add("mittleren");
            expected.KomparativPluralGenitivSchwach.Add("mittleren");
            expected.KomparativPluralDativSchwach.Add("mittleren");
            expected.KomparativPluralAkkusativSchwach.Add("mittleren");


            expected.KomparativMaskulinumNominativGemischt.Add("mittlerer");
            expected.KomparativMaskulinumGenitivGemischt.Add("mittleren");
            expected.KomparativMaskulinumDativGemischt.Add("mittleren");
            expected.KomparativMaskulinumAkkusativGemischt.Add("mittleren");
            expected.KomparativFemininumNominativGemischt.Add("mittlere");
            expected.KomparativFemininumGenitivGemischt.Add("mittleren");
            expected.KomparativFemininumDativGemischt.Add("mittleren");
            expected.KomparativFemininumAkkusativGemischt.Add("mittlere");
            expected.KomparativNeutrumNominativGemischt.Add("mittleres");
            expected.KomparativNeutrumGenitivGemischt.Add("mittleren");
            expected.KomparativNeutrumDativGemischt.Add("mittleren");
            expected.KomparativNeutrumAkkusativGemischt.Add("mittleres");
            expected.KomparativPluralNominativGemischt.Add("mittleren");
            expected.KomparativPluralGenitivGemischt.Add("mittleren");
            expected.KomparativPluralDativGemischt.Add("mittleren");
            expected.KomparativPluralAkkusativGemischt.Add("mittleren");

            // Superlativ
            expected.SuperlativMaskulinumNominativStark.Add("mittelster");
            expected.SuperlativMaskulinumGenitivStark.Add("mittelsten");
            expected.SuperlativMaskulinumDativStark.Add("mittelstem");
            expected.SuperlativMaskulinumAkkusativStark.Add("mittelsten");
            expected.SuperlativFemininumNominativStark.Add("mittelste");
            expected.SuperlativFemininumGenitivStark.Add("mittelster");
            expected.SuperlativFemininumDativStark.Add("mittelster");
            expected.SuperlativFemininumAkkusativStark.Add("mittelste");
            expected.SuperlativNeutrumNominativStark.Add("mittelstes");
            expected.SuperlativNeutrumGenitivStark.Add("mittelsten");
            expected.SuperlativNeutrumDativStark.Add("mittelstem");
            expected.SuperlativNeutrumAkkusativStark.Add("mittelstes");
            expected.SuperlativPluralNominativStark.Add("mittelste");
            expected.SuperlativPluralGenitivStark.Add("mittelster");
            expected.SuperlativPluralDativStark.Add("mittelsten");
            expected.SuperlativPluralAkkusativStark.Add("mittelste");


            expected.SuperlativMaskulinumNominativSchwach.Add("mittelste");
            expected.SuperlativMaskulinumGenitivSchwach.Add("mittelsten");
            expected.SuperlativMaskulinumDativSchwach.Add("mittelsten");
            expected.SuperlativMaskulinumAkkusativSchwach.Add("mittelsten");
            expected.SuperlativFemininumNominativSchwach.Add("mittelste");
            expected.SuperlativFemininumGenitivSchwach.Add("mittelsten");
            expected.SuperlativFemininumDativSchwach.Add("mittelsten");
            expected.SuperlativFemininumAkkusativSchwach.Add("mittelste");
            expected.SuperlativNeutrumNominativSchwach.Add("mittelste");
            expected.SuperlativNeutrumGenitivSchwach.Add("mittelsten");
            expected.SuperlativNeutrumDativSchwach.Add("mittelsten");
            expected.SuperlativNeutrumAkkusativSchwach.Add("mittelste");
            expected.SuperlativPluralNominativSchwach.Add("mittelsten");
            expected.SuperlativPluralGenitivSchwach.Add("mittelsten");
            expected.SuperlativPluralDativSchwach.Add("mittelsten");
            expected.SuperlativPluralAkkusativSchwach.Add("mittelsten");


            expected.SuperlativMaskulinumNominativGemischt.Add("mittelster");
            expected.SuperlativMaskulinumGenitivGemischt.Add("mittelsten");
            expected.SuperlativMaskulinumDativGemischt.Add("mittelsten");
            expected.SuperlativMaskulinumAkkusativGemischt.Add("mittelsten");
            expected.SuperlativFemininumNominativGemischt.Add("mittelste");
            expected.SuperlativFemininumGenitivGemischt.Add("mittelsten");
            expected.SuperlativFemininumDativGemischt.Add("mittelsten");
            expected.SuperlativFemininumAkkusativGemischt.Add("mittelste");
            expected.SuperlativNeutrumNominativGemischt.Add("mittelstes");
            expected.SuperlativNeutrumGenitivGemischt.Add("mittelsten");
            expected.SuperlativNeutrumDativGemischt.Add("mittelsten");
            expected.SuperlativNeutrumAkkusativGemischt.Add("mittelstes");
            expected.SuperlativPluralNominativGemischt.Add("mittelsten");
            expected.SuperlativPluralGenitivGemischt.Add("mittelsten");
            expected.SuperlativPluralDativGemischt.Add("mittelsten");
            expected.SuperlativPluralAkkusativGemischt.Add("mittelsten");

            List<Models.Entry> expectedList = new List<Models.Entry>();
            expectedList.Add(expected);

            XMLSerializer.Serialize<List<Models.Entry>>(words, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "flex_result.txt"));
            XMLSerializer.Serialize<List<Models.Entry>>(expectedList, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "flex_expected.txt"));
            CollectionAssert.AreEqual(expectedList, words, "failed");

        }
    }
}
