

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StripedTowel
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = n + (n / 2)-1; i >=0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j%3==0+(i%3))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    } 
                }
                Console.WriteLine();
            }
        }
    }
}
