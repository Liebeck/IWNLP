using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models.Nouns
{
    public class Inflection
    {
        public String Article { get; set; }
        public String InflectedWord { get; set; }

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
            if (!String.IsNullOrEmpty(this.Article))
            {
                return String.Format("{0} {1}", this.Article, this.InflectedWord);
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
