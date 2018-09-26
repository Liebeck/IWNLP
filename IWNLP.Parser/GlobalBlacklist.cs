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
            "Flexion:reinwaschen",
            "Antonello",
            "Ackerschotendotter", // fixed after 20180920 dump
            "Flexion:watschen",// fixed after 20180920 dump
            "Mittelstadt",// fixed after 20180920 dump
            "Chassid",// fixed after 20180920 dump
            "entmilitarisiert",// fixed after 20180920 dump
            "Gams",
            "Flexion:weiterverwenden",
            "variatio delectat",
            "Flexion:an sein"
        };
    }
}
