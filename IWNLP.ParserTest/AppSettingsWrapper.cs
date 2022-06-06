namespace IWNLP.ParserTest
{
    public class AppSettingsWrapper
    {
        public static string WiktionaryDumpPath
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["WiktionaryDumpPath"]; }
        }

        public static string UnitTestDumpDirectory
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["UnitTestDumpDirectory"]; }
        }

        public static bool SuppressDumps
        {
            get { return bool.Parse(System.Configuration.ConfigurationManager.AppSettings["SuppressDumps"].ToString()); }
        }
    }
}
