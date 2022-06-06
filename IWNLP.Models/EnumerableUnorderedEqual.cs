using System;
using System.Collections.Generic;
using System.Linq;

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

            Dictionary<object, int> expectedDictionary = CreateCountDictionary(enumerable1);
            Dictionary<object, int> resultDictionary = CreateCountDictionary(enumerable2);
            foreach (object key in expectedDictionary.Keys)
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

        private static Dictionary<object, int> CreateCountDictionary(System.Collections.IEnumerable collection)
        {
            Dictionary<object, int> dictionary = new Dictionary<object, int>();
            foreach (object obj in collection)
            {
                int objectCount;
                dictionary.TryGetValue(obj, out objectCount);
                dictionary[obj] = objectCount + 1;
            }
            return dictionary;
        } 
    }
}
