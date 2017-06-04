namespace _03._2x2_Squares_in_Matrix
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

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Replace(" ","").ToCharArray();
            }

            int squareSizeToCheck = 2;
            int checkOffset = squareSizeToCheck - 1;
            int equalCount = 0;

            for (int i = 0; i < rows- checkOffset; i++)
            {
                for (int j = 0; j < cols- checkOffset; j++)
                {
                    if (AreEqualChars(matrix, i, j, squareSizeToCheck))
                    {
                        equalCount++;
                    }
                }
            }

            Console.WriteLine(equalCount);
        }

        private static bool AreEqualChars(char[][] matrix, int row, int col, int squareSizeToCheck)
        {
            char c = matrix[row][col];

            for (int i = row; i < row+squareSizeToCheck; i++)
            {
                for (int j = col; j < col+squareSizeToCheck; j++)
                {
                    if (matrix[i][j]!=c)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
