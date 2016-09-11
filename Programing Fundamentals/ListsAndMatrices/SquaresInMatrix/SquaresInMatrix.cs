

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main()
        {
            int[] param = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = param[0];
            int cols = param[1];
            int[,] m = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] num = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    m[i, j] = num[j];
                }
            }

            int counter = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if ((m[i, j] == m[i, j + 1]) && (m[i, j] == m[i + 1, j]) && (m[i, j] == m[i + 1, j + 1]))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
