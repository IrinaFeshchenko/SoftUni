

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VowelOrDigit
    {
        static void Main()
        {
            char c = char.Parse(Console.ReadLine());
            List<char> wovels = "aeiou".ToList();
            if (wovels.Contains(c))
            {
                Console.WriteLine("vowel");
            }
            else if (char.IsDigit(c))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
