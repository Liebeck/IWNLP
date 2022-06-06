using IWNLP.Parser.POSParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IWNLP.ParserTest
{
    [TestClass]
    public class ParserFunctionsTests
    {

        [TestMethod]
        public void StrSubrev1()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 1, 1);
            string expected = "9";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev2()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 2, 1);
            string expected = "8";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev3()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 20, 1);
            string expected = string.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev4()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 2, 0);
            string expected = "8";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev5()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 2, 2);
            string expected = "89";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev6()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 2, 3);
            string expected = string.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev7()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("123456789", 5, 5);
            string expected = "56789";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev8()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSubrev("war", 5, 5);
            string expected = string.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub1()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 0);
            string expected = string.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub2()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 1);
            string expected = "A";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub3()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 2);
            string expected = "Au";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub4()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 3);
            string expected = "Aut";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub5()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", -1, 1);
            string expected = string.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub6()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 8);
            string expected = "Autobahn";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub7()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 0, 9);
            string expected = "AutobahnA";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub8()
        {
            ParserBase parserBase = new ParserBase();

            string result = parserBase.StrSub("Autobahn", 1, 2);
            string expected = "ut";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StrSub9()
        {
            ParserBase parserBase = new ParserBase();
            string result = parserBase.StrSub("Autobahn", 2, 10);

        }
        
    }
}
