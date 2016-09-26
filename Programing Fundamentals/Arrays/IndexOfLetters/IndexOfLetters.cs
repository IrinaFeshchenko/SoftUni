

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        { 
            string s = Console.ReadLine();

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"{s[i]} -> {s[i]-'a'}");
            }
        }
    }
}
