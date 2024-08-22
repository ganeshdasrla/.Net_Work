using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHandsOn
{
    internal class SearchAString
    {
        static void Main()
        {
            string mainString = "Hello, welcome to the world of C#!";
            string searchString = "world1111";

            bool isFound = SearchString(mainString, searchString);

            if (isFound)
            {
                Console.WriteLine("Substring found!");
            }
            else
            {
                Console.WriteLine("Substring not found.");
            }
        }


        private static bool SearchString(string originalString, string findString)
        {
            int mainLen = originalString.Length;
            int subsLen = findString.Length;

            for (int i = 0; i < mainLen - subsLen; i++)
            {
                int j;
                for (j = 0; j < subsLen; j++)
                {
                    // Extract a substring from the main string
                    // string substring = originalString.Substring(i, searchLength);

                    if (originalString[i + j] != findString[j])
                    {
                        break;
                    }
                }
                if (j == subsLen)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
