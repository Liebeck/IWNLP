using IWNLP.Models.Flections;
using IWNLP.Parser.FlexParser.VerbTemplates.regelmaessig;
using IWNLP.Parser.FlexParser.VerbTemplates.schwachUntrennbar;
using IWNLP.Parser.FlexParser.VerbTemplates.unregelmaessig;
using IWNLP.Parser.POSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser.FlexParser
{
    public class VerbFlexParser : ParserBase
    {
        List<String> blacklist = new List<string>() {
            "Flexion:anbaggern",
        };

        VerbRegelmaessigParser regelmaessigVerbParser = new VerbRegelmaessigParser();
        VerbSchwachUntrennbarParser schwachUntrennbarParser = new VerbSchwachUntrennbarParser();
        VerbUnregelmaessigParser unregelmaessigVerbParser = new VerbUnregelmaessigParser();
        public List<VerbConjugation> Parse(String word, String[] text)
        {
            if (blacklist.Contains(word))
            {
                return null;
            }
            Stats.Instance.VerbsTotal++;
            List<VerbConjugation> verbs = new List<VerbConjugation>();
            List<String> conjugationBeginText = new List<string>() { "{{Deutsch Verb regelmäßig|", "{{Deutsch Verb schwach untrennbar|", "{{Deutsch Verb unregelmäßig|" };
            List<int> conjugationBlockBeginIndices = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Content.StartsWith(conjugationBeginText[0]) || x.Content.StartsWith(conjugationBeginText[1]) || x.Content.StartsWith(conjugationBeginText[2])).Select(x => x.Index).ToList();

            for (int i = 0; i < conjugationBlockBeginIndices.Count; i++)
            {
                int conjugationBlockBeginIndex = conjugationBlockBeginIndices[i];
                int conjugationBlockEndIndex = text.Select((content, index) => new { Content = content.Trim(), Index = index }).Where(x => x.Index >= conjugationBlockBeginIndex && x.Content.EndsWith("}}")).Select(x => x.Index).First();
                String[] subArrayDefinitionBlock = Common.GetSubArray(text, conjugationBlockBeginIndex, conjugationBlockEndIndex);
                if (subArrayDefinitionBlock[0].Contains("{{Deutsch Verb regelmäßig|"))
                {
                    Stats.Instance.VerbsRegular++;
                    VerbConjugation conjugation = regelmaessigVerbParser.Parse(word, subArrayDefinitionBlock);
                    if (conjugation != null) // workaround blacklist
                    {
                        verbs.Add(conjugation);
                    }
                }
                else if (subArrayDefinitionBlock[0].Contains("{{Deutsch Verb schwach untrennbar|")) 
                {
                    Stats.Instance.VerbsWeakInseparable++;
                    VerbConjugation conjugation = schwachUntrennbarParser.Parse(word, subArrayDefinitionBlock);
                    if (conjugation != null) // workaround blacklist
                    {
                        verbs.Add(conjugation);
                    }
                }
                else if (subArrayDefinitionBlock[0].Contains("{{Deutsch Verb unregelmäßig|"))
                {
                    Stats.Instance.VerbsIrregular++;
                    VerbConjugation conjugation = unregelmaessigVerbParser.Parse(word, subArrayDefinitionBlock);
                    if (conjugation != null) // workaround blacklist
                    {
                        verbs.Add(conjugation);
                    }
                }
            }
            foreach (var verb in verbs) 
            {
                // There are some cases where a &nbsp; is present. We can't remove it earlier, because if {1} may be part of a main clause or a subordinate clause, which results in &nbsp; being trimmable or not
                // We are forced to replace it here (or at all .Add(..) calls)

                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular1Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular2Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular3Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural1Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural2Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural3Person);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Singular3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivIndikativ_Plural3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular1Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular2Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular3Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural1Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural2Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural3Person);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Singular3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräsensAktivKonjunktiv_Plural3Person_Nebensatzkonjugation);

                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular1Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular2Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular3Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural1Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural2Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural3Person);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Singular3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivIndikativ_Plural3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular1Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular2Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular3Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural1Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural2Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural3Person);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Singular3Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural1Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural2Person_Nebensatzkonjugation);
                RemoveNBSPandTrim(verb.PräteritumAktivKonjunktiv_Plural3Person_Nebensatzkonjugation);

                if (!String.IsNullOrEmpty(verb.PartizipII)) { verb.PartizipII = RemoveNBSPandTrim(verb.PartizipII); }
                if (!String.IsNullOrEmpty(verb.PartizipIIAlternativ)) { verb.PartizipIIAlternativ = RemoveNBSPandTrim(verb.PartizipIIAlternativ); }            
            }
            return verbs;
        }
        
    }
}
