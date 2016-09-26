

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KingofThieves
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            for (int i = 0; i <= (n / 2); i++)
            {
                string d1 = new string('-', (n/2) - i);
                string d2 = new string(c, 1 + (2*i));

                Console.WriteLine("{0}{1}{0}", d1, d2);
            }

            for (int i = (n/2-1); i >=0; i--)
            {
                string d1 = new string('-', (n / 2) - i);
                string d2 = new string(c, 1 + (2 * i));

                Console.WriteLine("{0}{1}{0}", d1, d2);
            }
        }
    }
}
