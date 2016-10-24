using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    public class StatsWriter
    {
        public static void Write(String wiktionaryDumpPath, String parsedOutputPath, String outputPath) 
        {
            StringBuilder sb = new StringBuilder();
            List<PropertyInfo> properties = typeof(Stats).GetProperties().Where(x => x.PropertyType == typeof(int)).ToList();
            sb.AppendLine(String.Format("Dump path: {0}", wiktionaryDumpPath));
            sb.AppendLine(String.Format("IWNLP path: {0}", parsedOutputPath));
            foreach (PropertyInfo property in properties.OrderBy(x => x.Name))
            {
                sb.AppendLine(String.Format("{0}: {1}", property.Name, property.GetValue(Stats.Instance)));
            }
            System.IO.File.WriteAllText(outputPath, sb.ToString());
        }
    }
}
