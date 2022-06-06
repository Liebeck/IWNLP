using IWNLP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            string wiktionaryDumpPath = args[0];
            string parsedOutputPath = args[1];

            //Console.OutputEncoding = Encoding.UTF8;
            WiktionaryParser parser = new WiktionaryParser();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> titles = new List<string>();
            List<Entry> allWords = new List<Entry>();
            using (XmlReader myReader = XmlReader.Create(wiktionaryDumpPath))
            {
                while (myReader.Read())
                {
                    if (myReader.NodeType == XmlNodeType.Element && myReader.Name == "page" && myReader.IsStartElement())
                    {
                        myReader.ReadToFollowing("title");
                        string title = myReader.ReadElementContentAsString();
                        titles.Add(title);
                        if (!title.Contains(":") || title.StartsWith("Flexion:"))
                        {
                            myReader.ReadToFollowing("id");
                            int id = myReader.ReadElementContentAsInt();
                            myReader.ReadToFollowing("revision");
                            myReader.ReadToFollowing("text");
                            string text = myReader.ReadElementContentAsString();
                            try
                            {
                                List<Entry> entries = parser.ParseText(title, text, id);
                                if (entries != null)
                                {
                                    allWords.AddRange(entries);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(string.Format("Exception for entry: {0}", title));
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        var value = myReader.Value;
                    }
                }
            }
            Console.WriteLine("Dump parsed in " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds");
            XMLSerializer.Serialize<List<Entry>>(allWords.Where(x => !x.ParserError).ToList(), parsedOutputPath);
            StatsWriter.Write(wiktionaryDumpPath, parsedOutputPath, string.Format("{0}.txt", parsedOutputPath));
        }
    }
}
