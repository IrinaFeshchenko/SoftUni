

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixOfPalindromes
    {
        static void Main()
        {
            int[] param = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = param[0];
            int cols = param[1];
            char ch1 = 'a';
            char ch2 = 'a';
            char ch3 = 'a';

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{ch1}{ch2}{ch3} ");
                    ch2++;
                }
                ch1++;
                ch2 = ch1;
                ch3++;
                Console.WriteLine();
            }
        }
    }
}
