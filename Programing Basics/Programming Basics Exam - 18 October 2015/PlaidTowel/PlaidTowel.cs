

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PlaidTowel
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char bg = char.Parse(Console.ReadLine());
            char fg = char.Parse(Console.ReadLine());

            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine("{0}{2}{1}{2}{0}", new string(bg, n), new string(bg, n * 2 - 1),fg);
                for (int i = 1; i < n; i++)
                {//                     ..#..#.....#..#...   
                    Console.WriteLine("{0}{3}{1}{3}{2}{3}{1}{3}{0}", new string(bg, n - i), new string(bg, i * 2 - 1), new string(bg, (n * 2 - 1)- (i * 2)),fg);
                }
                Console.WriteLine("{1}{0}{1}{0}{1}", new string(bg, n * 2 - 1),fg);
                for (int i = n - 1; i >= 1; i--)
                {
                    Console.WriteLine("{0}{3}{1}{3}{2}{3}{1}{3}{0}", new string(bg, n - i), new string(bg, i * 2 - 1), new string(bg, (n * 2 - 1) - (i * 2)), fg);
                }
            }
            Console.WriteLine("{0}{2}{1}{2}{0}", new string(bg, n), new string(bg, n * 2 - 1), fg);
        }
    }
}
