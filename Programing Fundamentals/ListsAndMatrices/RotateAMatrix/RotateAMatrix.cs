

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                List<string> line = Console.ReadLine().Split().ToList();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            for (int j = 0; j < cols; j++)
            {
                for (int i = rows-1; i >= 0; i--)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
