

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SplitByWordCasing
    {
        static void Main()
        {
            char[] separators = ",;:.!()\"\'\\/[] ".ToCharArray();
            List<string> words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> upperCase = new List<string>();

            foreach (var word in words)
            {
                if ((word.ToLower() == word) && (Regex.IsMatch(word, @"^[a-zA-Z]+$")))
                {
                    lowerCase.Add(word);
                }
                else if ((word.ToUpper() == word) && (Regex.IsMatch(word, @"^[a-zA-Z]+$")))
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }

            Console.WriteLine($"Lower-case: { string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: { string.Join(", ", mixedCase)}");
            Console.WriteLine($"Upper-case: { string.Join(", ", upperCase)}");
        }
    }
}
