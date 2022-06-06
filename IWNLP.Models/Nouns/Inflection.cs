using System;

namespace IWNLP.Models.Nouns
{
    public class Inflection
    {
        public string Article { get; set; }
        public string InflectedWord { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Inflection obj2 = (Inflection)obj;
            return this.Article == obj2.Article && this.InflectedWord == obj2.InflectedWord;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Article))
            {
                return string.Format("{0} {1}", this.Article, this.InflectedWord);
            }
            else
            {
                return this.InflectedWord;
            }

        }

        public override int GetHashCode()
        {
            if (this.Article != null)
            {
                unchecked
                {
                    int hash = this.Article.GetHashCode();
                    return 31 * hash + this.InflectedWord.GetHashCode();
                }
            }
            else
            {
                return this.InflectedWord.GetHashCode();
            }

        }

    }
}
