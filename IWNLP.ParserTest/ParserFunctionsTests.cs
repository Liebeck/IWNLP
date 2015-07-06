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
    public class ParserFunctionsTests
    {

        [TestMethod]
        public void StrSubrev1()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 1, 1);
            String expected = "9";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev2()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 2, 1);
            String expected = "8";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev3()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 20, 1);
            String expected = String.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev4()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 2, 0);
            String expected = "8";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev5()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 2, 2);
            String expected = "89";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev6()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 2, 3);
            String expected = String.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev7()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("123456789", 5, 5);
            String expected = "56789";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSubrev8()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSubrev("war", 5, 5);
            String expected = String.Empty;
            Assert.AreEqual(result, expected);
        }
    }
}
