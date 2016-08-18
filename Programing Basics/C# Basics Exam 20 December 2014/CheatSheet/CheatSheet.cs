

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CheatSheet
    {
        static void Main()
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            for (long i = 0; i < r; i++)
            {
                for (long j = 0; j < c; j++)
                {
                    Console.Write((v + i) * (h + j));

                    if (j!=c-1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
