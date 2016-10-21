using IWNLP.Models;
using IWNLP.Models.Nouns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.POSParser
{
    public class DeutschSubstantivUebersichtParser : ParserBase
    {
        public Word Parse(String word, String[] text)
        {
            List<String> cleanedTemplateBlock = this.GetCleanedTemplateBlock(word, text);
            cleanedTemplateBlock = cleanedTemplateBlock.Where(x => !x.Equals("{{Deutsch Substantiv Übersicht -sch")).ToList();
            if (cleanedTemplateBlock.Count > 0)
            {
                Common.PrintError(word, String.Format("DeutschSubstantivUebersichtParser: {0} contains additional parameters that are not implemented yet", word));
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
                    new Inflection(){ Article ="das", InflectedWord=String.Format("{0}e", word)},
                },
                NominativPlural = new List<Inflection>(),
                GenitivSingular = new List<Inflection>(){
                    new Inflection(){ Article ="des", InflectedWord=word},
                    new Inflection(){ Article ="des", InflectedWord=String.Format("{0}s", word)},
                    new Inflection(){ InflectedWord=word},
                    new Inflection(){ InflectedWord=String.Format("{0}s", word)},
                    new Inflection(){ Article ="des", InflectedWord=String.Format("{0}en", word)}
                },
                GenitivPlural = new List<Inflection>(),
                DativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="dem", InflectedWord=word},
                    new Inflection(){ InflectedWord=word},
                    new Inflection() { Article = "dem", InflectedWord = String.Format("{0}en", word)},
                },
                DativPlural = new List<Inflection>(),
                AkkusativSingular = new List<Inflection>(){
                    new Inflection(){ Article ="das", InflectedWord=word},
                    new Inflection(){ InflectedWord=word},
                    new Inflection(){ Article ="das", InflectedWord=String.Format("{0}e", word)}
                },
                AkkusativPlural = new List<Inflection>(),
            };
            Stats.Instance.NounsDeutschSubstantivUebersichtSchTotal++;
            return noun;
        }

        public List<String> GetCleanedTemplateBlock(String word, String[] text)
        {
            int flexionSubstantivStart = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.Contains("{{Deutsch Substantiv Übersicht -sch")).Select(x => x.Index).First();
            int flexionSubstantivEnd = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= flexionSubstantivStart && x.Content.EndsWith("}}")).Select(x => x.Index).First();
            String[] definition = Common.GetSubArray(text, flexionSubstantivStart, flexionSubstantivEnd);
            List<String> cleanedLines = base.GetCleanedMultilineDefintionBlock(definition, word, "DeutschSubstantivUebersichtParser");
            return cleanedLines;
        }

    }
}
