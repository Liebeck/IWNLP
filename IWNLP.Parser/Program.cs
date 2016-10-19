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
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong arguments passed:");
                Console.WriteLine("First argument: Input path to 'dewiktionary-XXX-pages-articles.xml'");
                Console.WriteLine("Second argument: Output path to 'parsedIWNLP_XXX.xml'");
            }
            String wiktionaryDumpPath = args[0];
            String parsedOutputPath = args[1];


            //Console.OutputEncoding = Encoding.UTF8;
            WiktionaryParser parser = new WiktionaryParser();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<String> titles = new List<string>();
            List<Entry> allWords = new List<Entry>();
            using (XmlReader myReader = XmlReader.Create(wiktionaryDumpPath))
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
            Console.WriteLine("Dump parsed in " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds");
            var stats = Stats.Instance;
            XMLSerializer.Serialize<List<Entry>>(allWords.Where(x => !x.ParserError).ToList(), parsedOutputPath);

        }
    }
}
