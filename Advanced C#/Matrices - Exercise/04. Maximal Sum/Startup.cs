namespace _04.Maximal_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] n = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int rows = n[0];
            int cols = n[1];

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            }


            long maxSum = 0;
            int maxRow = 0, maxCol = 0;
            int submatrixSide = 3;
            int offset = submatrixSide - 1;

            for (int i = 0; i < rows - offset; i++)
            {
                for (int j = 0; j < cols - offset; j++)
                {
                    int sum = GetMatrixSum(matrix, i, j, submatrixSide);

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i < maxRow + submatrixSide; i++)
            {
                for (int j = maxCol; j < maxCol + submatrixSide; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        struct MaxSubmatrixLocation
        {
            public int row;
            public int col;
        }

        private static int GetMatrixSum(int[][] matrix, int row, int col, int submatrixSide)
        {
            int sum = 0;
            for (int i = row; i < row + submatrixSide; i++)
            {
                for (int j = col; j < col + submatrixSide; j++)
                {
                    sum += matrix[i][j];
                }
            }

            return sum;
        }
    }
}
