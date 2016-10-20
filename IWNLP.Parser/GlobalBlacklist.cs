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
            "Thüringisch-Obersächsisch",
            "Koprolith",
            "Finno-Ugrisch",
            "Schottisch-Gälisch",
            "Manx-Gälisch",
            "Irisch-Gälisch",
            "Ulster-Irisch",
            "Munster-Irisch",
            "Connacht-Irisch",
            "Judeo-Spanisch",
            "Neu-Norwegisch",
            "Pennsylvania-Deutsch",
            "Karatschai-Balkarisch",
            "Komi-Permjakisch",
            "Komi-Syrjänisch",
            "Marokkanisch-Arabisch",
            "Ägyptisch-Arabisch",
            "Proto-Germanisch",
            "Algerisch-Arabisch",
            "Libysch-Arabisch",
            "Karbadisch-Tscherkessisch",
            "Arkadisch-Kyprisch",
            "Launa-Deutsch",
            "Tunesisch-Arabisch",
            "Brast",
            "Avis",
            "Arabischer Frühling", // contains Lautschrift template
            "einige",
            "Flexion:anbaggern",
            "Flexion:husten",
            "Flexion:verweigern",
            "Flexion:uzen",
            "Flexion:wischen",           
        };

        public static List<String> SuppressError = new List<string>()
        {
            // fixed after 20161001 dump
            "Brandschutzgitter",
            "Seiner Majestät Schiff",
            "Glockenkurve",
            "dersaufen",
            "gestikulieren",
            "lobbyieren",
            "hereinbrechen",
            "verglimmen",
            "Flexion:butterig",
            "Flexion:unumstritten",
            "dersäufen",
        };
    }
}
