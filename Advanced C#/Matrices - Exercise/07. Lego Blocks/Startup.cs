namespace _07.Lego_Blocks
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            char[,] matrix = new char[5,6];

            int startCol = 3;
            int colLength = 1;

            int startRow = 2 - 2;
            int endRow = 2 + 2;
            bool passedTheMiddle = false;

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j < startCol + colLength; j++)
                {
                    if (IsInMatrixBoundary(matrix, i, j))
                    {
                        matrix[i, j] = '#';
                    }
                }

                if (i == 2)
                {
                    passedTheMiddle = true;
                }

                if (passedTheMiddle)
                {
                    startCol++;
                    colLength -= 2;
                }
                else
                {
                    startCol--;
                    colLength += 2;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsInMatrixBoundary(char[,] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.GetLength(0))
            {
                return false;
            }

            if (j < 0 || j >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
