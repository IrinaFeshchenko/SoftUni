

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TriplesOfLetters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int c1 = 0; c1 < n; c1++)
            {
                for (int c2 = 0; c2 < n; c2++)
                {
                    for (int c3 = 0; c3 < n; c3++)
                    {

                        Console.WriteLine($"{(char)(c1+'a')}{(char)(c2 + 'a')}{(char)(c3 + 'a')}");
                    }
                }
            }
        }
    }
}
