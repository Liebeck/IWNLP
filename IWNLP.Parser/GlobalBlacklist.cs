﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    public class GlobalBlacklist
    {
        public static List<String> GlobalBlackList = new List<string>()
        {
           
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
            "dersäufen"
        };
    }
}
