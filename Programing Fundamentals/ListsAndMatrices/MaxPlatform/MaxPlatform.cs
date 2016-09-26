

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxPlatform
    {
        static void Main()
        {
            int[] par = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = par[0];
            int cols = par[1];
            int platformSize = 3;
            decimal[,] m = new decimal[rows, cols];

            //read input matrix
            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
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
            for (int i = maxRow; i < maxRow + platformSize; i++)
            {
                for (int j = maxCol; j < maxCol + platformSize; j++)
                {
                    Console.Write(m[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static decimal GetSum(decimal[,] m, int row, int col, int platformSize)
        {
            decimal sum = 0;
            for (int i = row; i < row + platformSize; i++)
            {
                for (int j = col; j < col + platformSize; j++)
                {
                    sum += m[i, j];
                }
            }
            return sum;
        }
    }
}
