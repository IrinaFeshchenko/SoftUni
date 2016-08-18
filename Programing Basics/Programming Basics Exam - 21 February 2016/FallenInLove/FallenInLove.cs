

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FallenInLove
    {
        static void Main()
        {
            int numberN = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberN; i++)
            {
                Console.Write('#');
                Console.Write(new string('~', i));
                Console.Write('#');
                Console.Write(new string('.', (numberN - i) * 2));
                Console.Write('#');
                Console.Write(new string('.', i * 2));
                Console.Write('#');
                Console.Write(new string('.', (numberN - i) * 2));
                Console.Write('#');
                Console.Write(new string('~', i));
                Console.Write('#');
                Console.WriteLine();
            }
            for (int i = 0; i < numberN+1; i++)
            {
                Console.Write(new string('.', (i * 2) + 1));
                Console.Write('#');
                Console.Write(new string('~', numberN - i));
                Console.Write('#');
                Console.Write(new string('.', (numberN - i) * 2));
                Console.Write('#');
                Console.Write(new string('~', numberN - i));
                Console.Write('#');
                Console.Write(new string('.', (i * 2) + 1));
                Console.WriteLine();
            }

            for (int i = 0; i < numberN; i++)
            {
                Console.Write(new string('.', numberN  * 2+2));
                Console.Write("##");
                Console.Write(new string('.', numberN * 2+2));
                Console.WriteLine();
            }
        }
    }
}
