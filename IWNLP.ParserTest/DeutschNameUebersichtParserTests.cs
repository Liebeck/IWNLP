using IWNLP.Parser.POSParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class DeutschNameUebersichtParserTests
    {
        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_TwoLines()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Maria vom Siege";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht",
                "|Genus=f",
                "|kein-s=1",
                "|Bild 1=Bermatingen Pfarrkirche Maria vom Siege 2.jpg|160px|2|“Maria vom Siege“ in der Pfarrkirche von Bermatingen",
                "|Bild 2=NtraSradelasVictorias0001.JPG|160px|2|“Maria vom Siege“ bei einer Prozession in Lima, Peru",
                "}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(2, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_OneLineTwoParameters()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Hindi";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht|Genus=n}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(1, cleanedTemplateBlock.Count);
        }

        [TestMethod]
        public void DeutschNameUebersichtParser_Parameter_OneLine()
        {
            DeutschNameUebersichtParser parser = new DeutschNameUebersichtParser();
            String word = "Hindi";
            String[] lines = new string[]
            {
                "{{Deutsch Name Übersicht",
                "|Genus=m",
                "}}"
            };
            List<String> cleanedTemplateBlock = parser.GetCleanedTemplateBlock(word, lines);
            Assert.AreEqual(1, cleanedTemplateBlock.Count);
        }
    }
}
