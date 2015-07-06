using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    public class AppSettingsWrapper
    {
        public static String UnitTestDumpDirectory
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["UnitTestDumpDirectory"]; }
        }
    }
}
