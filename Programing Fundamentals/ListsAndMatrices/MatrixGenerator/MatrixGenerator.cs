

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixGenerator
    {
        static void Main()
        {
            char[] param = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char matrixType = param[0];
            int rows = param[1] - '0';
            int cols = param[2] - '0';

            if (matrixType == 'A')
            {
                DrowA(rows, cols);
            }
            else if (matrixType == 'B')
            {
                DrowB(rows, cols);
            }
            else if (matrixType == 'C')
            {
                DrowC(rows, cols);
            }
            else if (matrixType == 'D')
            {
                DrowD(rows, cols);
            }
        }

        private static void DrowA(int rows, int cols)
        {
            decimal[,] matrx = new decimal[rows, cols];
            int digit = 1;

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrx[i, j] = digit;
                    digit++;
                }
            }

            PrintMatrix(matrx);
        }

        private static void DrowB(int rows, int cols)
        {
            decimal[,] matrx = new decimal[rows, cols];
            int digit = 1;

            for (int j = 0; j < cols; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        matrx[i, j] = digit;
                        digit++;
                    }
                }
                else
                {
                    for (int i = rows - 1; i >= 0; i--)
                    {
                        matrx[i, j] = digit;
                        digit++;
                    }
                }
            }

            PrintMatrix(matrx);
        }

        private static void DrowC(int rows, int cols)
        {
            decimal[,] matrx = new decimal[rows, cols];
            int digit = 1;
            int row = rows - 1;
            int col = 0;

            for (int i = 0; i < rows * cols; i++)
            {
                matrx[row, col] = digit;
                digit++;
                row++;
                col++;

                if (row == rows)
                {
                    row = (rows - 1 - col) >= 0 ? (rows - 1 - col) : 0;
                    col = (col - rows+1)<0 ? 0 : (col - rows+1);
                }

                if ((col == cols) && (row < rows))
                {
                    col = cols + 1 - row;
                    row = 0;
                }
            }

            PrintMatrix(matrx);
        }

        private static void DrowD(int rows, int cols)
        {
            throw new NotImplementedException();
        }

        private static void PrintMatrix(decimal[,] matrx)
        {
            int rows = matrx.GetLength(0);
            int cols = matrx.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrx[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
