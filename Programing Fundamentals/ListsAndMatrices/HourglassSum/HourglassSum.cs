

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HourglassSum
    {
        static void Main()
        {
            int rows = 6;
            int cols = 6;
            int platformSize = 3;
            decimal[,] m = new decimal[rows, cols];

            //read input matrix
            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    m[i, j] = line[j];
                }
            }

            int maxRow = 0;
            int maxCol = 0;
            decimal maxSum = GetSum(m, maxRow, maxCol, platformSize);
            decimal sum = maxSum;

            //traverse and compare sums
            for (int i = 0; i <= rows - platformSize; i++)
            {
                for (int j = 0; j <= cols - platformSize; j++)
                {
                    sum = GetSum(m, i, j, platformSize);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }

        private static decimal GetSum(decimal[,] m, int row, int col, int platformSize)
        {
            decimal sum = m[row ,col] + m[row, col+1] + m[row, col+2] +
                                       m[row+1, col+1] +
                        m[row+2, col] + m[row+2, col+1] + m[row+2, col+2];
            return sum;
        }
    }
}

