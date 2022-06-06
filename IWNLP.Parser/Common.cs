using System;
using System.Linq;

namespace IWNLP.Parser
{
    public class Common
    {
        public static string[] GetSubArray(string[] input, int startIndex, int lastLineIndex)
        {
            int length = lastLineIndex - startIndex + 1;
            return input.Skip(startIndex).Take(length).ToArray();
        }

        public static void PrintError(string word, string message)
        {
            if (!GlobalBlacklist.Blacklist.Contains(word))
            {
                Console.WriteLine(message);
            }
        }

        public static void PrintError(string message)
        {
            Console.WriteLine(message);

        }
    }
}
