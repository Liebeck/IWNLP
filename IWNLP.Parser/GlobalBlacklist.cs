using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    public class GlobalBlacklist
    {
        public static List<String> Blacklist = new List<string>()
        {
            "Oachkatzlschwoaf",
            "Flexion:anbaggern",
            "Flexion:husten",
            "Flexion:uzen",
            "Wirtschaftsforschungsinstitut", // fixed after 20170501 dump
            "einhalten", // fixed after 20170501 dump
            "Pflichtgefühl", // fixed after 20170501 dump
            "vollscheißen", // fixed after 20170501 dump
            "Flexion:raumhoch", // fixed after 20170501 dump
            "Flexion:reinwaschen",
            "Helles" // fixed after 20170501 dump
        };
    }
}
