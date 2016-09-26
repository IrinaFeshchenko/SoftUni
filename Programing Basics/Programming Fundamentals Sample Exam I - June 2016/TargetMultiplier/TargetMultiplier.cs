

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TargetMultiplier
    {
        static void Main()
        {
            long[] dimentions = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();
            long rows = dimentions[0];
            long cols = dimentions[1];
            long[,] matrix = new long[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                long[] line = Console.ReadLine()
                                .Split()
                                .Select(long.Parse)
                                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            long[] pos = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            long neighborsSum = matrix[pos[0] - 1, pos[1] - 1] +
                                matrix[pos[0] - 1, pos[1]] +
                                matrix[pos[0] - 1, pos[1] + 1] +
                                matrix[pos[0], pos[1] + 1] +
                                matrix[pos[0] + 1, pos[1] - 1] +
                                matrix[pos[0] + 1, pos[1]] +
                                matrix[pos[0] + 1, pos[1] + 1] +
                                matrix[pos[0], pos[1] - 1];

            matrix[pos[0] - 1, pos[1] - 1] *= matrix[pos[0], pos[1]];
            matrix[pos[0] - 1, pos[1]] *= matrix[pos[0], pos[1]];
            matrix[pos[0] - 1, pos[1] + 1] *= matrix[pos[0], pos[1]];
            matrix[pos[0], pos[1] + 1] *= matrix[pos[0], pos[1]];
            matrix[pos[0] + 1, pos[1]-1] *= matrix[pos[0], pos[1]];
            matrix[pos[0] + 1, pos[1]] *= matrix[pos[0], pos[1]];
            matrix[pos[0] + 1, pos[1]+1] *= matrix[pos[0], pos[1]];
            matrix[pos[0], pos[1] - 1] *= matrix[pos[0], pos[1]];

            matrix[pos[0], pos[1]] *= neighborsSum;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(" {0}",matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
