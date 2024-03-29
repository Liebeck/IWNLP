﻿namespace IWNLP.Parser
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
        public int Nouns { get; set; }
        public int NounsDeutschSubstantivUebersichtSchTotal { get; set; }
        public int NounsDeutschNameUebersichtTotal { get; set; }
        public int AdjectivalDeclensionDeutschAdjektivischUebersichtTotal { get; set; }

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
