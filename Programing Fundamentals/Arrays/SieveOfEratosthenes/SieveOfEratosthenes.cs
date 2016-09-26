

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SieveOfEratosthenes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            n++;
            bool[] p = new bool[n];

            for (int i = 0; i < n; i++)
            {
                p[i] = true;
            }


            p[0] = p[1] = false;

            for (int i = 0; i < n; i++)
            {
                if (p[i] == true)
                {
                    Console.Write($"{i} ");

                    for (int j = 2; j * i < n; j++)
                    {
                        p[j * i] = false;
                    }
                }
            }
        }
    }
}
