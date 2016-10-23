using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWNLP.Parser
{
    public class Common
    {
        public static String[] GetSubArray(String[] input, int startIndex, int lastLineIndex)
        {
            int length = lastLineIndex - startIndex + 1;
            return input.Skip(startIndex).Take(length).ToArray();
        }

        public static void PrintError(String word, String message)
        {
            if (!GlobalBlacklist.Blacklist.Contains(word))
            {
                Console.WriteLine(message);
            }
        }

        public static void PrintError(String message)
        {
            Console.WriteLine(message);

        }
    }
}
