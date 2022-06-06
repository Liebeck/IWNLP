using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IWNLP.Parser
{
    public class StatsWriter
    {
        public static void Write(string wiktionaryDumpPath, string parsedOutputPath, string outputPath) 
        {
            StringBuilder sb = new StringBuilder();
            List<PropertyInfo> properties = typeof(Stats).GetProperties().Where(x => x.PropertyType == typeof(int)).ToList();
            sb.AppendLine(string.Format("Dump path: {0}", wiktionaryDumpPath));
            sb.AppendLine(string.Format("IWNLP path: {0}", parsedOutputPath));
            foreach (PropertyInfo property in properties.OrderBy(x => x.Name))
            {
                sb.AppendLine(string.Format("{0}: {1}", property.Name, property.GetValue(Stats.Instance)));
            }
            System.IO.File.WriteAllText(outputPath, sb.ToString());
        }
    }
}
