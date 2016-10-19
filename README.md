# IWNLP
IWNLP is a dictionary-based lemmatizer for the German language. It is based on the German edition of Wiktionary. IWNLP consists of two parts:
* IWNLP: A parser for the German edition of Wiktionary
* [IWNLP.Lemmatizer](https://github.com/Liebeck/IWNLP.Lemmatizer): A German lemmatizer that uses the output from IWNLP to produce a mapping from an inflected form to a lemma.

More details can be found at www.iwnlp.com

# How to run IWNLP
* Clone the project and build it
* Download https://dumps.wikimedia.org/dewiktionary/latest/dewiktionary-latest-pages-articles.xml.bz2
* Unpack dewiktionary-latest-pages-articles.xml.bz2
* Start IWNLP.Parser.exe with two parameters: Path to the unzipped file, path to the export file. For instance
``` bash
IWNLP.Parser.exe "c:\\dewiktionary-latest-pages-articles.xml" "c:\\parsedIWNLP_latest.xml"
```
* Follow the steps from [IWNLP.Lemmatizer](https://github.com/Liebeck/IWNLP.Lemmatizer) to create the lemmatization mapping 

# Citation
Please include the following reference if you use IWNLP in your work:
``` bash
@InProceedings{liebeck-conrad:2015:ACL-IJCNLP,
  author    = {Liebeck, Matthias  and  Conrad, Stefan},
  title     = {IWNLP: Inverse Wiktionary for Natural Language Processing},
  booktitle = {Proceedings of the 53rd Annual Meeting of the Association for Computational Linguistics and the 7th International Joint Conference on Natural Language Processing (Volume 2: Short Papers)},
  year      = {2015},
  publisher = {Association for Computational Linguistics},
  pages     = {414--418},
  url       = {http://www.aclweb.org/anthology/P15-2068}
}
```