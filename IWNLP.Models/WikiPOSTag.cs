namespace IWNLP.Models
{

    public static class WikiPOSTagParser
    {
        public static WikiPOSTag ParsePOSTag(string posTag)
        {
            posTag = posTag.Trim();
            switch (posTag)
            {
                case "Deklinierte Form": return WikiPOSTag.DeklinierteForm;
                case "Substantiv": return WikiPOSTag.Substantiv;
                case "Konjugierte Form": return WikiPOSTag.KonjugierteForm;
                case "Adjektiv": return WikiPOSTag.Adjektiv;
                case "Verb": return WikiPOSTag.Verb;
                case "Toponym": return WikiPOSTag.Toponym;
                case "Abkürzung": return WikiPOSTag.Abkürzung;
                case "Wortverbindung": return WikiPOSTag.Wortverbindung;
                case "Partizip II": return WikiPOSTag.PartizipII;
                case "Redewendung": return WikiPOSTag.Redewendung;
                case "Vorname": return WikiPOSTag.Vorname;
                case "Adverb": return WikiPOSTag.Adverb;
                case "Partizip I": return WikiPOSTag.PartizipI;
                case "Erweiterter Infinitiv": return WikiPOSTag.ErweiterterInfinitiv;
                case "Nachname": return WikiPOSTag.Nachname;
                case "Eigenname": return WikiPOSTag.Eigenname;
                case "Interjektion": return WikiPOSTag.Interjektion;
                case "Gebundenes Lexem":
                case "gebundenes Lexem":
                    return WikiPOSTag.GebundenesLexem;
                case "Präfix": return WikiPOSTag.Präfix;
                case "Numerale": return WikiPOSTag.Numerale;
                case "Präposition": return WikiPOSTag.Präposition;
                case "Sprichwort": return WikiPOSTag.Sprichwort;
                case "Komparativ": return WikiPOSTag.Komparativ;
                case "Suffix": return WikiPOSTag.Suffix;
                case "Ortsnamengrundwort": return WikiPOSTag.Ortsnamengrundwort;
                case "Affix": return WikiPOSTag.Affix;
                case "Konjunktion": return WikiPOSTag.Konjunktion;
                case "Superlativ": return WikiPOSTag.Superlativ;
                case "Buchstabe": return WikiPOSTag.Buchstabe;
                case "Indefinitpronomen": return WikiPOSTag.Indefinitpronomen;
                case "Kontraktion": return WikiPOSTag.Kontraktion;
                case "Grußformel": return WikiPOSTag.Grußformel;
                case "Personalpronomen": return WikiPOSTag.Personalpronomen;
                case "Partikel": return WikiPOSTag.Partikel;
                case "Subjunktion": return WikiPOSTag.Subjunktion;
                case "Demonstrativpronomen": return WikiPOSTag.Demonstrativpronomen;
                case "Artikel": return WikiPOSTag.Artikel;
                case "Lokaladverb": return WikiPOSTag.Lokaladverb;
                case "Pronominaladverb": return WikiPOSTag.Pronominaladverb;
                case "Substantivierter Infinitiv": return WikiPOSTag.SubstantivierterInfinitiv;
                case "Geflügeltes Wort": return WikiPOSTag.GeflügeltesWort;
                case "Onomatopoetikum": return WikiPOSTag.Onomatopoetikum;
                case "Pronomen": return WikiPOSTag.Pronomen;
                case "Gradpartikel": return WikiPOSTag.Gradpartikel;
                case "Zahlzeichen": return WikiPOSTag.Zahlzeichen;
                case "Relativpronomen": return WikiPOSTag.Relativpronomen;
                case "Antwortpartikel": return WikiPOSTag.Antwortpartikel;
                case "Possessivpronomen": return WikiPOSTag.Possessivpronomen;
                case "Postposition": return WikiPOSTag.Postposition;
                case "Konjunktionaladverb": return WikiPOSTag.Konjunktionaladverb;
                case "Modalpartikel": return WikiPOSTag.Modalpartikel;
                case "Zahlklassifikator": return WikiPOSTag.Zahlklassifikator;
                case "Interrogativpronomen": return WikiPOSTag.Interrogativpronomen;
                case "Merkspruch": return WikiPOSTag.Merkspruch;
                case "Hilfsverb": return WikiPOSTag.Hilfsverb;
                case "Modaladverb": return WikiPOSTag.Modalpartikel;
                case "neoklassisches Formativ": return WikiPOSTag.neoklassischesFormativ;
                case "Temporaladverb": return WikiPOSTag.Temporaladverb;
                case "Reflexivpronomen": return WikiPOSTag.Reflexivpronomen;
                case "Fokuspartikel": return WikiPOSTag.Fokuspartikel;
                case "Präfixoid": return WikiPOSTag.Präfixoid;
                case "Negationspartikel": return WikiPOSTag.Negationspartikel;
                case "Enklitikon": return WikiPOSTag.Enklitikon;
                case "Interrogativadverb": return WikiPOSTag.Interrogativadverb;
                case "Reziprokpronomen": return WikiPOSTag.Reziprokpronomen;
                case "Klitikon": return WikiPOSTag.Klitikon;
                case "Vergleichspartikel": return WikiPOSTag.Vergleichspartikel;
                case "Zusammenbildung": return WikiPOSTag.Zusammenbildung;
                case "abtrennbare Verbpartikel": return WikiPOSTag.abtrennbareVerbpartikel;
                case "Formativ": return WikiPOSTag.Formativ;
                case "Suffixoid": return WikiPOSTag.Suffixoid;
                case "Mehrwortbenennung": return WikiPOSTag.Mehrwortbenennung;
                case "Symbol": return WikiPOSTag.Symbol;
                default: return WikiPOSTag.Other;
            }
        }
    }


    public enum WikiPOSTag
    {
        Substantiv = 1,
        Adjektiv = 2,
        Verb = 3,
        Adverb = 4,
        Interjektion = 5,
        Konjunktion = 6,
        Partikel = 7,
        Subjunktion = 8,
        Artikel = 9,
        Pronomen = 10,

        DeklinierteForm = 30,
        KonjugierteForm = 31,
        Toponym = 32,
        Abkürzung = 33,
        Wortverbindung = 34,
        PartizipII = 35,
        Redewendung = 36,
        Vorname = 37,
        PartizipI = 38,
        ErweiterterInfinitiv = 39,
        Nachname = 40,
        Eigenname = 41,
        GebundenesLexem = 42,
        Präfix = 43,
        Numerale = 44,
        Präposition = 45,
        Sprichwort = 46,
        Komparativ = 47,
        Suffix = 48,
        Ortsnamengrundwort = 49,
        Affix = 50,
        Superlativ = 51,
        Buchstabe = 52,
        Indefinitpronomen = 53,
        Kontraktion = 54,
        Grußformel = 55,
        Personalpronomen = 56,
        Demonstrativpronomen = 57,
        Lokaladverb = 58,
        Pronominaladverb = 59,
        SubstantivierterInfinitiv = 60,
        GeflügeltesWort = 61,
        Onomatopoetikum = 62,
        Gradpartikel = 63,
        Zahlzeichen = 64,
        Relativpronomen = 65,
        Antwortpartikel = 66,
        Possessivpronomen = 67,
        Postposition = 68,
        Konjunktionaladverb = 69,
        Modalpartikel = 70,
        Zahlklassifikator = 71,
        Interrogativpronomen = 72,
        Merkspruch = 73,
        Hilfsverb = 74,
        Modaladverb = 75,
        neoklassischesFormativ = 76,
        Temporaladverb = 77,
        Reflexivpronomen = 78,
        Fokuspartikel = 79,
        Präfixoid = 80,
        Negationspartikel = 81,
        Enklitikon = 82,
        Interrogativadverb = 83,
        Reziprokpronomen = 84,
        Klitikon = 85,
        Vergleichspartikel = 86,
        Zusammenbildung = 87,
        abtrennbareVerbpartikel = 88,
        Formativ = 89,
        Suffixoid = 90,
        Mehrwortbenennung = 91,
        Symbol = 92,

        Other = 200

    }
}
