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

        [TestMethod]
        public void StrSub1()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 0);
            String expected = String.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub2()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 1);
            String expected = "A";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub3()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 2);
            String expected = "Au";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub4()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 3);
            String expected = "Aut";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub5()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", -1, 1);
            String expected = String.Empty;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub6()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 8);
            String expected = "Autobahn";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub7()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 0, 9);
            String expected = "AutobahnA";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void StrSub8()
        {
            ParserBase parserBase = new ParserBase();

            String result = parserBase.StrSub("Autobahn", 1, 2);
            String expected = "ut";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StrSub9()
        {
            ParserBase parserBase = new ParserBase();
            String result = parserBase.StrSub("Autobahn", 2, 10);

        }
        
    }
}
