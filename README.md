# IWNLP
IWNLP is a dictionary-based lemmatizer for the German language. It is based on the German edition of Wiktionary. IWNLP consists of two parts:
* IWNLP: A parser for the German edition of Wiktionary
* [IWNLP.Lemmatizer](https://github.com/Liebeck/IWNLP.Lemmatizer): A German lemmatizer that uses the output from IWNLP to produce a mapping from an inflected form to a lemma.

More details can be found at www.iwnlp.com

# How to run IWNLP
1. Clone the project and build it
2. Download https://dumps.wikimedia.org/dewiktionary/latest/dewiktionary-latest-pages-articles.xml.bz2
3. Unpack dewiktionary-latest-pages-articles.xml.bz2
4. Start IWNLP.Parser.exe with two parameters: Path to the unzipped file, path to the export file. For instance
``` bash
IWNLP.Parser.exe "c:\\dewiktionary-latest-pages-articles.xml" "c:\\parsedIWNLP_latest.xml"
--profiler=english-gender-profiler
```
5. Follow the steps from [IWNLP.Lemmatizer](https://github.com/Liebeck/IWNLP.Lemmatizer) to create the lemmatization mapping 