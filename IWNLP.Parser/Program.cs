using GenericXMLSerializer;
using IWNLP.Models;
using IWNLP.Parser.POSParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IWNLP.Parser
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.OutputEncoding = Encoding.UTF8;
            WiktionaryParser parser = new WiktionaryParser();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<String> titles = new List<string>();

            List<Entry> allWords = new List<Entry>();
            using (XmlReader myReader = XmlReader.Create(AppSettingsWrapper.WiktionaryDumpPath))
            {
                while (myReader.Read())
                {
                    if (myReader.NodeType == XmlNodeType.Element && myReader.Name == "page" && myReader.IsStartElement())
                    {
                        myReader.ReadToFollowing("title");
                        String title = myReader.ReadElementContentAsString();
                        titles.Add(title);
                        if (!title.Contains(":") || title.StartsWith("Flexion:"))
                        {
                            myReader.ReadToFollowing("id");
                            int id = myReader.ReadElementContentAsInt();
                            myReader.ReadToFollowing("revision");
                            myReader.ReadToFollowing("text");
                            String text = myReader.ReadElementContentAsString();

                            List<Entry> entries = parser.ParseText(title, text, id);
                            if (entries != null)
                            {
                                allWords.AddRange(entries);
                            }

                        }

                        var value = myReader.Value;
                    }
                }
            }

            //var countVerbs = allWords.OfType<Verb>().Count();
            //var countNouns = allWords.OfType<Noun>().Count();
            //var countAdjectives = allWords.OfType<Adjective>().Count();

            //var breakpoint = 5;
            Console.WriteLine("Dump parsed in " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds");

            //var stats = Stats.Instance;

            XMLSerializer.Serialize<List<Entry>>(allWords.Where(x => !x.ParserError).ToList(), AppSettingsWrapper.ParsedOutputPath);
            
        }
    }
}
