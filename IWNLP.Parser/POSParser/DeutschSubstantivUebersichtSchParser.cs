using IWNLP.Models;
using IWNLP.Models.Nouns;
using System.Collections.Generic;
using System.Linq;

namespace IWNLP.Parser.POSParser
{
    public class DeutschSubstantivUebersichtSchParser : ParserBase
    {
        public Word Parse(string word, string[] text)
        {
            List<string> cleanedTemplateBlock = this.GetCleanedTemplateBlock(word, text);
            if (cleanedTemplateBlock.Count > 0)
            {
                Common.PrintError(word, string.Format("DeutschSubstantivUebersichtParser: {0} contains additional parameters that are not implemented yet", word));
                return null;
            }
            Noun noun = new Models.Noun()
            {
                Text = word,
                POS = POS.Noun,
                Genus = new List<Genus>() { Genus.Neutrum },
                NominativSingular = new List<Inflection>(){ 
                    new Inflection(){ Article ="das", InflectedWord=word},
                    new Inflection(){ InflectedWord=word},
                    new Inflection(){ Article ="das", InflectedWord=string.Format("{0}e", word)},
                },
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord=word},
                    new Inflection(){ Article ="des", InflectedWord=string.Format("{0}s", word)},
                    new Inflection(){ InflectedWord=word},
                    new Inflection(){ InflectedWord=string.Format("{0}s", word)},
                    new Inflection(){ Article ="des", InflectedWord=string.Format("{0}en", word)}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="dem", InflectedWord=word},
                    new Inflection(){ InflectedWord=word},
                    new Inflection() { Article = "dem", InflectedWord = string.Format("{0}en", word)},
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="das", InflectedWord=word},
                    new Inflection(){ InflectedWord=word},
                    new Inflection(){ Article ="das", InflectedWord=string.Format("{0}e", word)}
                },
                AkkusativPlural = new List<Inflection>(),
            };
            Stats.Instance.NounsDeutschSubstantivUebersichtSchTotal++;
            return noun;
        }

        public List<string> GetCleanedTemplateBlock(string word, string[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Substantiv Übersicht -sch")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            string[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<string> cleanedLines = base.GetCleanedMultilineDefinitionBlock(definition, word, "DeutschSubstantivUebersichtParser");
            cleanedLines = cleanedLines.Where(x => !x.Equals("{{Deutsch Substantiv Übersicht -sch")).ToList();
            return cleanedLines;
        }

    }
}
