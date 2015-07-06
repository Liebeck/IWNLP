using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Models
{
    public class EnumerableUnorderedEqual
    {
        public static bool IsUnorderedEnumerableEqual<T>(IEnumerable<T> enumerable1, IEnumerable<T> enumerable2)
        {
            if (enumerable1 == null && enumerable2 == null)
            {
                return true;
            }
            if (!(enumerable1 != null && enumerable2 != null))
            {
                return false;
            }
            if (enumerable1.Count() != enumerable2.Count())
            {
                return false;
            }

            Dictionary<Object, int> expectedDictionary = CreateCountDictionary(enumerable1);
            Dictionary<Object, int> resultDictionary = CreateCountDictionary(enumerable2);
            foreach (Object key in expectedDictionary.Keys)
            {
                int expectedCount;
                expectedDictionary.TryGetValue(key, out expectedCount);
                int resultCount;
                resultDictionary.TryGetValue(key, out resultCount);
                if (expectedCount != resultCount)
                {
                    return false;
                }
            }
            return true;
        }

        private static Dictionary<Object, int> CreateCountDictionary(System.Collections.IEnumerable collection)
        {
            Dictionary<Object, int> dictionary = new Dictionary<object, int>();
            foreach (Object obj in collection)
            {
                int objectCount;
                dictionary.TryGetValue(obj, out objectCount);
                dictionary[obj] = objectCount + 1;
            }
            return dictionary;
        } 
    }
}
