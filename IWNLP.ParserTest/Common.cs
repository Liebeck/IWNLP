using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.ParserTest
{
    public static class Common
    {
        public static String ReadFromFile(String relativePath)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            return File.ReadAllText(path);
        }

        public static String[] ReadLinesFromFile(String relativePath)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            return File.ReadAllLines(path);
        }


        // http://stackoverflow.com/a/3928856/225808
        // Code by http://stackoverflow.com/users/55847/lukeh
        // licensed under CC-BY-SA 3.0 , see http://blog.stackoverflow.com/2009/06/attribution-required/ , http://creativecommons.org/licenses/by-sa/3.0/
        public static bool DictionaryEqual<TKey, TValue>(
            this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            if (first == second) return true;
            if ((first == null) || (second == null)) return false;
            if (first.Count != second.Count) return false;

            var comparer = EqualityComparer<TValue>.Default;

            foreach (KeyValuePair<TKey, TValue> kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue)) return false;
                if (!comparer.Equals(kvp.Value, secondValue)) return false;
            }
            return true;
        }
    }
}
