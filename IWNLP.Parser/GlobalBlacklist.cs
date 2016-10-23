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
            "Arabischer Frühling", // contains Lautschrift template
            "Flexion:anbaggern",
            "Flexion:husten",
            "Flexion:verweigern",
            "Flexion:uzen",
            "Flexion:wischen",           
            "Seiner Majestät Schiff", // fixed after 20161020 dump
            "chemisches Element", // fixed after 20161020 dump
            "Wunderbares", // fixed after 20161020 dump
            "Brauner Knollenblätterpilz", // fixed after 20161020 dump
            "Neues", // fixed after 20161020 dump
            "Unparteiischer", // fixed after 20161020 dump
            "Schutzbefohlener", // fixed after 20161020 dump
            "Weiße", // fixed after 20161020 dump
            "Tadig", // fixed after 20161020 dump
            "Unserdeutsch", // fixed after 20161020 dump
            "Hessisch",// fixed after 20161020 dump
            "Portokosten", // fixed after 20161020 dump
            "Abokosten", // fixed after 20161020 dump
            "Rocky Mountains", // fixed after 20161020 dump
            "Shetlandinseln", // fixed after 20161020 dump
            "Manx", // fixed after 20161020 dump
        };
    }
}
