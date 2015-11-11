using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IWNLP.ParserTest
{

    /// <summary>
    /// Singleton class for storing the Dump 
    /// </summary>
    public class DumpTextCaching
    {
        protected Dictionary<int, String> wiktionaryPages = new Dictionary<int, string>();

        private static DumpTextCaching instance;

        private DumpTextCaching(String wiktionaryDumpPath)
        {
            using (XmlReader myReader = XmlReader.Create(wiktionaryDumpPath))
            {
                while (myReader.Read())
                {
                    if (myReader.NodeType == XmlNodeType.Element && myReader.Name == "page" && myReader.IsStartElement())
                    {
                        myReader.ReadToFollowing("title");
                        myReader.ReadToFollowing("id");
                        int id = myReader.ReadElementContentAsInt();
                        myReader.ReadToFollowing("revision");
                        myReader.ReadToFollowing("text");
                        String text = myReader.ReadElementContentAsString();
                        wiktionaryPages.Add(id, text);
                    }
                    //var value = myReader.Value;
                }
            }
        }

        public static String GetTextFromPage(int wiktionaryID) 
        {
            return DumpTextCaching.Instance.wiktionaryPages[wiktionaryID];
        }

        public static DumpTextCaching Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DumpTextCaching(AppSettingsWrapper.WiktionaryDumpPath);
                }
                return instance;
            }
        }
    }
}
