using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    public class AppSettingsWrapper
    {
        public static String WiktionaryDumpPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["WiktionaryDumpPath"]; }
        }

        public static String ParsedOutputPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ParsedOutputPath"]; }
        }
    }
}
