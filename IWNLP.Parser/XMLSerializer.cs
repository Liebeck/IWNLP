using System.IO;
using System.Xml.Serialization;

namespace IWNLP.Parser
{
    public class XMLSerializer
    {
        public static void Serialize<T>(T data, string path) where T : class
        {
            Serialize<T>(data, path, "root");
        }

        public static void Serialize<T>(T data, string path, string xmlRootAttributeName) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));
                xmlSerializer.Serialize(stream, data);
            }
        }

        public static T Deserialize<T>(string path, string xmlRootAttributeName) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));
                return xmlSerializer.Deserialize(stream) as T;
            }
        }

        public static T Deserialize<T>(string path) where T : class
        {
            return Deserialize<T>(path, "root");
        }        
    }
}