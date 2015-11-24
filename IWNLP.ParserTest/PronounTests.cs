using GenericXMLSerializer;
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
    public class PronounTests
    {
        [TestMethod]
        public void der()
        {
            String word = "der";
            int wiktionaryID = 6453;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.DET,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"der"},
                    WerEinzahlF = new List<string>(){"die"},
                    WerEinzahlN = new List<string>(){"das"},
                    WerEinzahlMehrzahl = new List<string>(){"die"},
                    WessenEinzahlM = new List<string>(){"des"},
                    WessenEinzahlF = new List<string>(){"der"},
                    WessenEinzahlN = new List<string>(){"des"},
                    WessenEinzahlMehrzahl = new List<string>(){"der"},
                    WemEinzahlM = new List<string>(){"dem"},
                    WemEinzahlF = new List<string>(){"der"},
                    WemEinzahlN = new List<string>(){"dem"},
                    WemEinzahlMehrzahl = new List<string>(){"den"},
                    WenEinzahlM = new List<string>(){"den"},
                    WenEinzahlF = new List<string>(){"die"},
                    WenEinzahlN = new List<string>(){"das"},
                    WenEinzahlMehrzahl = new List<string>(){"die"},
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"der"},
                    WerEinzahlF = new List<string>(){"die"},
                    WerEinzahlN = new List<string>(){"das"},
                    WerEinzahlMehrzahl = new List<string>(){"die"},
                    WessenEinzahlM = new List<string>(){"dessen"},
                    WessenEinzahlF = new List<string>(){"deren"},
                    WessenEinzahlN = new List<string>(){"dessen"},
                    WessenEinzahlMehrzahl = new List<string>(){"deren"},
                    WemEinzahlM = new List<string>(){"dem"},
                    WemEinzahlF = new List<string>(){"der"},
                    WemEinzahlN = new List<string>(){"dem"},
                    WemEinzahlMehrzahl = new List<string>(){"denen"},
                    WenEinzahlM = new List<string>(){"den"},
                    WenEinzahlF = new List<string>(){"die"},
                    WenEinzahlN = new List<string>(){"das"},
                    WenEinzahlMehrzahl = new List<string>(){"die"},
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"der"},
                    WerEinzahlF = new List<string>(){"die"},
                    WerEinzahlN = new List<string>(){"das"},
                    WerEinzahlMehrzahl = new List<string>(){"die"},
                    WessenEinzahlM = new List<string>(){"dessen"},
                    WessenEinzahlF = new List<string>(){"deren","derer"},
                    WessenEinzahlN = new List<string>(){"dessen"},
                    WessenEinzahlMehrzahl = new List<string>(){"deren","derer"},
                    WemEinzahlM = new List<string>(){"dem"},
                    WemEinzahlF = new List<string>(){"der"},
                    WemEinzahlN = new List<string>(){"dem"},
                    WemEinzahlMehrzahl = new List<string>(){"denen"},
                    WenEinzahlM = new List<string>(){"den"},
                    WenEinzahlF = new List<string>(){"die"},
                    WenEinzahlN = new List<string>(){"das"},
                    WenEinzahlMehrzahl = new List<string>(){"die"},
                }
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void das()
        {
            String word = "das";
            int wiktionaryID = 11658;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.DET,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"der"},
                    WerEinzahlF = new List<string>(){"die"},
                    WerEinzahlN = new List<string>(){"das"},
                    WerEinzahlMehrzahl = new List<string>(){"die"},
                    WessenEinzahlM = new List<string>(){"des"},
                    WessenEinzahlF = new List<string>(){"der"},
                    WessenEinzahlN = new List<string>(){"des"},
                    WessenEinzahlMehrzahl = new List<string>(){"der"},
                    WemEinzahlM = new List<string>(){"dem"},
                    WemEinzahlF = new List<string>(){"der"},
                    WemEinzahlN = new List<string>(){"dem"},
                    WemEinzahlMehrzahl = new List<string>(){"den"},
                    WenEinzahlM = new List<string>(){"den"},
                    WenEinzahlF = new List<string>(){"die"},
                    WenEinzahlN = new List<string>(){"das"},
                    WenEinzahlMehrzahl = new List<string>(){"die"},
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"der"},
                    WerEinzahlF = new List<string>(){"die"},
                    WerEinzahlN = new List<string>(){"das"},
                    WerEinzahlMehrzahl = new List<string>(){"die"},
                    WessenEinzahlM = new List<string>(){"dessen"},
                    WessenEinzahlF = new List<string>(){"deren"},
                    WessenEinzahlN = new List<string>(){"dessen"},
                    WessenEinzahlMehrzahl = new List<string>(){"deren"},
                    WemEinzahlM = new List<string>(){"dem"},
                    WemEinzahlF = new List<string>(){"der"},
                    WemEinzahlN = new List<string>(){"dem"},
                    WemEinzahlMehrzahl = new List<string>(){"denen"},
                    WenEinzahlM = new List<string>(){"den"},
                    WenEinzahlF = new List<string>(){"die"},
                    WenEinzahlN = new List<string>(){"das"},
                    WenEinzahlMehrzahl = new List<string>(){"die"},
                }
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


        [TestMethod]
        public void kein()
        {
            String word = "kein";
            int wiktionaryID = 17169;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"kein"},
                    WerEinzahlF = new List<string>(){"keine"},
                    WerEinzahlN = new List<string>(){"kein"},
                    WerEinzahlMehrzahl = new List<string>(){"keine"},
                    WessenEinzahlM = new List<string>(){"keines"},
                    WessenEinzahlF = new List<string>(){"keiner"},
                    WessenEinzahlN = new List<string>(){"keines"},
                    WessenEinzahlMehrzahl = new List<string>(){"keiner"},
                    WemEinzahlM = new List<string>(){"keinem"},
                    WemEinzahlF = new List<string>(){"keiner"},
                    WemEinzahlN = new List<string>(){"keinem"},
                    WemEinzahlMehrzahl = new List<string>(){"keinen"},
                    WenEinzahlM = new List<string>(){"keinen"},
                    WenEinzahlF = new List<string>(){"keine"},
                    WenEinzahlN = new List<string>(){"kein"},
                    WenEinzahlMehrzahl = new List<string>(){"keine"},
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void demjenigen()
        {
            String word = "demjenigen";
            int wiktionaryID = 76995;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"derjenige"},
                    WerEinzahlF = new List<string>(){"diejenige"},
                    WerEinzahlN = new List<string>(){"dasjenige"},
                    WerEinzahlMehrzahl = new List<string>(){"diejenigen"},
                    WessenEinzahlM = new List<string>(){"desjenigen"},
                    WessenEinzahlF = new List<string>(){"derjenigen"},
                    WessenEinzahlN = new List<string>(){"desjenigen"},
                    WessenEinzahlMehrzahl = new List<string>(){"derjenigen"},
                    WemEinzahlM = new List<string>(){"demjenigen"},
                    WemEinzahlF = new List<string>(){"derjenigen"},
                    WemEinzahlN = new List<string>(){"demjenigen"},
                    WemEinzahlMehrzahl = new List<string>(){"denjenigen"},
                    WenEinzahlM = new List<string>(){"denjenigen"},
                    WenEinzahlF = new List<string>(){"diejenige"},
                    WenEinzahlN = new List<string>(){"dasjenige"},
                    WenEinzahlMehrzahl = new List<string>(){"diejenigen"},
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void welcher()
        {
            String word = "welcher";
            int wiktionaryID = 21492;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"welcher"},
                    WerEinzahlF = new List<string>(){"welche"},
                    WerEinzahlN = new List<string>(){"welches"},
                    WerEinzahlMehrzahl = new List<string>(){"welche"},
                    WessenEinzahlM = new List<string>(){"welches","welchen"},
                    WessenEinzahlF = new List<string>(){"welcher"},
                    WessenEinzahlN = new List<string>(){"welches","welchen"},
                    WessenEinzahlMehrzahl = new List<string>(){"welcher"},
                    WemEinzahlM = new List<string>(){"welchem"},
                    WemEinzahlF = new List<string>(){"welcher"},
                    WemEinzahlN = new List<string>(){"welchem"},
                    WemEinzahlMehrzahl = new List<string>(){"welchen"},
                    WenEinzahlM = new List<string>(){"welchen"},
                    WenEinzahlF = new List<string>(){"welche"},
                    WenEinzahlN = new List<string>(){"welches"},
                    WenEinzahlMehrzahl = new List<string>(){"welche"},
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"welcher"},
                    WerEinzahlF = new List<string>(){"welche"},
                    WerEinzahlN = new List<string>(){"welches"},
                    WerEinzahlMehrzahl = new List<string>(){"welche"},
                    WessenEinzahlM = new List<string>(){"welches"},
                    WessenEinzahlF = new List<string>(){"welcher"},
                    WessenEinzahlN = new List<string>(){"welches"},
                    WessenEinzahlMehrzahl = new List<string>(){"welcher"},
                    WemEinzahlM = new List<string>(){"welchem"},
                    WemEinzahlF = new List<string>(){"welcher"},
                    WemEinzahlN = new List<string>(){"welchem"},
                    WemEinzahlMehrzahl = new List<string>(){"welchen"},
                    WenEinzahlM = new List<string>(){"welchen"},
                    WenEinzahlF = new List<string>(){"welche"},
                    WenEinzahlN = new List<string>(){"welches"},
                    WenEinzahlMehrzahl = new List<string>(){"welche"},
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"welcher"},
                    WerEinzahlF = new List<string>(){"welche"},
                    WerEinzahlN = new List<string>(){"welches"},
                    WerEinzahlMehrzahl = new List<string>(){"welche"},
                    WessenEinzahlM = new List<string>(){"welches"},
                    WessenEinzahlF = new List<string>(){"welcher"},
                    WessenEinzahlN = new List<string>(){"welches"},
                    WessenEinzahlMehrzahl = new List<string>(){"welcher"},
                    WemEinzahlM = new List<string>(){"welchem"},
                    WemEinzahlF = new List<string>(){"welcher"},
                    WemEinzahlN = new List<string>(){"welchem"},
                    WemEinzahlMehrzahl = new List<string>(){"welchen"},
                    WenEinzahlM = new List<string>(){"welchen"},
                    WenEinzahlF = new List<string>(){"welche"},
                    WenEinzahlN = new List<string>(){"welches"},
                    WenEinzahlMehrzahl = new List<string>(){"welche"},
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void irgendwelche()
        {
            String word = "irgendwelche";
            int wiktionaryID = 281507;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>(){"irgendwelcher"},
                    WerEinzahlF = new List<string>(){"irgendwelche"},
                    WerEinzahlN = new List<string>(){"irgendwelches"},
                    WerEinzahlMehrzahl = new List<string>(){"irgendwelche"},
                    WessenEinzahlM = new List<string>(){"irgendwelches","irgendwelchen"},
                    WessenEinzahlF = new List<string>(){"irgendwelcher"},
                    WessenEinzahlN = new List<string>(){"irgendwelches","irgendwelchen"},
                    WessenEinzahlMehrzahl = new List<string>(){"irgendwelcher"},
                    WemEinzahlM = new List<string>(){"irgendwelchem"},
                    WemEinzahlF = new List<string>(){"irgendwelcher"},
                    WemEinzahlN = new List<string>(){"irgendwelchem"},
                    WemEinzahlMehrzahl = new List<string>(){"irgendwelchen"},
                    WenEinzahlM = new List<string>(){"irgendwelchen"},
                    WenEinzahlF = new List<string>(){"irgendwelche"},
                    WenEinzahlN = new List<string>(){"irgendwelches"},
                    WenEinzahlMehrzahl = new List<string>(){"irgendwelche"},
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void er()
        {
            String word = "er";
            int wiktionaryID = 802;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>() { "er" },
                    WerEinzahlF = new List<string>() { "sie" },
                    WerEinzahlN = new List<string>() { "es" },
                    WerEinzahlMehrzahl = new List<string>() { "sie" },
                    WessenEinzahlM = new List<string>() { "seiner" },
                    WessenEinzahlF = new List<string>() { "ihrer" },
                    WessenEinzahlN = new List<string>() { "seiner" },
                    WessenEinzahlMehrzahl = new List<string>() { "ihrer" },
                    WemEinzahlM = new List<string>() { "ihm" },
                    WemEinzahlF = new List<string>() { "ihr" },
                    WemEinzahlN = new List<string>() { "ihm" },
                    WemEinzahlMehrzahl = new List<string>() { "ihnen" },
                    WenEinzahlM = new List<string>() { "ihn" },
                    WenEinzahlF = new List<string>() { "sie" },
                    WenEinzahlN = new List<string>() { "es" },
                    WenEinzahlMehrzahl = new List<string>() { "sie" }
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void sie()
        {
            String word = "sie";
            int wiktionaryID = 19433;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>() { "er" },
                    WerEinzahlF = new List<string>() { "sie" },
                    WerEinzahlN = new List<string>() { "es" },
                    WerEinzahlMehrzahl = new List<string>() { "sie" },
                    WessenEinzahlM = new List<string>() { "seiner" },
                    WessenEinzahlF = new List<string>() { "ihrer" },
                    WessenEinzahlN = new List<string>() { "seiner" },
                    WessenEinzahlMehrzahl = new List<string>() { "ihrer" },
                    WemEinzahlM = new List<string>() { "ihm" },
                    WemEinzahlF = new List<string>() { "ihr" },
                    WemEinzahlN = new List<string>() { "ihm" },
                    WemEinzahlMehrzahl = new List<string>() { "ihnen" },
                    WenEinzahlM = new List<string>() { "ihn" },
                    WenEinzahlF = new List<string>() { "sie" },
                    WenEinzahlN = new List<string>() { "es" },
                    WenEinzahlMehrzahl = new List<string>() { "sie" }
                },

            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory,"4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }

        [TestMethod]
        public void welche()
        {
            String word = "welche";
            int wiktionaryID = 65693;
            String text = DumpTextCaching.GetTextFromPage(wiktionaryID);

            WiktionaryParser parser = new WiktionaryParser();
            List<Models.Entry> words = parser.ParseText(word, text, wiktionaryID);
            List<Models.Word> expectedWords = new List<Models.Word>() 
            {
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>() { "welcher" },
                    WerEinzahlF = new List<string>() { "welche" },
                    WerEinzahlN = new List<string>() { "welches" },
                    WerEinzahlMehrzahl = new List<string>() { "welche" },
                    WessenEinzahlM = new List<string>() { "welches" },
                    WessenEinzahlF = new List<string>() { "welcher" },
                    WessenEinzahlN = new List<string>() { "welches" },
                    WessenEinzahlMehrzahl = new List<string>() { "welcher" },
                    WemEinzahlM = new List<string>() { "welchem" },
                    WemEinzahlF = new List<string>() { "welcher" },
                    WemEinzahlN = new List<string>() { "welchem" },
                    WemEinzahlMehrzahl = new List<string>() { "welchen" },
                    WenEinzahlM = new List<string>() { "welchen" },
                    WenEinzahlF = new List<string>() { "welche" },
                    WenEinzahlN = new List<string>() { "welches" },
                    WenEinzahlMehrzahl = new List<string>() { "welche" }
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>() { "welcher" },
                    WerEinzahlF = new List<string>() { "welche" },
                    WerEinzahlN = new List<string>() { "welches" },
                    WerEinzahlMehrzahl = new List<string>() { "welche" },
                    WessenEinzahlM = new List<string>() { "welches" },
                    WessenEinzahlF = new List<string>() { "welcher" },
                    WessenEinzahlN = new List<string>() { "welches" },
                    WessenEinzahlMehrzahl = new List<string>() { "welcher" },
                    WemEinzahlM = new List<string>() { "welchem" },
                    WemEinzahlF = new List<string>() { "welcher" },
                    WemEinzahlN = new List<string>() { "welchem" },
                    WemEinzahlMehrzahl = new List<string>() { "welchen" },
                    WenEinzahlM = new List<string>() { "welchen" },
                    WenEinzahlF = new List<string>() { "welche" },
                    WenEinzahlN = new List<string>() { "welches" },
                    WenEinzahlMehrzahl = new List<string>() { "welche" }
                },
                new Models.Pronoun()
                {
                    POS = Models.POS.Pronoun,
                    Text = word,
                    WiktionaryID = wiktionaryID,
                    WerEinzahlM = new List<string>() { "welcher" },
                    WerEinzahlF = new List<string>() { "welche" },
                    WerEinzahlN = new List<string>() { "welches" },
                    WerEinzahlMehrzahl = new List<string>() { "welche" },
                    WessenEinzahlM = new List<string>() { "welches" },
                    WessenEinzahlF = new List<string>() { "welcher" },
                    WessenEinzahlN = new List<string>() { "welches" },
                    WessenEinzahlMehrzahl = new List<string>() { "welcher" },
                    WemEinzahlM = new List<string>() { "welchem" },
                    WemEinzahlF = new List<string>() { "welcher" },
                    WemEinzahlN = new List<string>() { "welchem" },
                    WemEinzahlMehrzahl = new List<string>() { "welchen" },
                    WenEinzahlM = new List<string>() { "welchen" },
                    WenEinzahlF = new List<string>() { "welche" },
                    WenEinzahlN = new List<string>() { "welches" },
                    WenEinzahlMehrzahl = new List<string>() { "welche" }
                },
            };
            XMLSerializer.Serialize<List<Models.Word>>(words.Cast<Models.Word>().ToList(), System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "3.txt"));
            XMLSerializer.Serialize<List<Models.Word>>(expectedWords, System.IO.Path.Combine(AppSettingsWrapper.UnitTestDumpDirectory, "4.txt"));
            CollectionAssert.AreEqual(expectedWords, words, "failed");
        }


    }
}
