﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    /// <summary>
    /// Singleton class for statistics
    /// </summary>
    public class Stats
    {
        public int VerbsConjugationTotal { get; set; }
        public int VerbsConjugationRegular { get; set; }
        public int VerbsConjugationIrregular { get; set; }
        public int VerbsConjugationWeakInseparable { get; set; }
        public int AdjectivalDeclension { get; set; }
        public int AdjectivalDeclensionM { get; set; }
        public int AdjectivalDeclensionN { get; set; }
        public int AdjectivalDeclensionF { get; set; }
        public int NounsTotal { get; set; }
        public int AdjectivesTotal { get; set; }
        public int VerbsTotal { get; set; }

        private static Stats instance; 

        private Stats() { }

        public static Stats Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Stats();
                }
                return instance;
            }
        }
    }
}
