

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
            decimal[,] matrix = new decimal[rows, cols];
            int digit = 1;
            int row = rows - 1;
            int col = 0;

            for (int i = 0; i < rows * cols; i++)
            {
                matrix[row++, col++] = digit++;

                if (row == rows)
                {
                    row = (rows - 1 - col) >= 0 ? (rows - 1 - col) : 0;
                    col = (col - rows + 1) < 0 ? 0 : (col - rows + 1);
                }

                if ((col == cols) && (row < rows))
                {
                    col = cols + 1 - row;
                    row = 0;
                }
            }

            PrintMatrix(matrix);
        }

        enum Direction { down, right, up, left };
        private static void DrowD(int rows, int cols)
        {
            decimal[,] matrix = new decimal[rows, cols];
            int digit = 1;
            int row = 0;
            int col = 0;
            int left = 0;
            int right = cols - 1;
            int top = 0;
            int bottom = rows - 1;
            Direction direction = Direction.down;

            while (digit <= rows * cols)
            {
                if (direction == Direction.down)  //move down
                {
                    for (row = top; row <= bottom; row++)
                    {
                        matrix[row, col] = digit++;
                    }
                    row--;
                    direction = Direction.right;
                    left++;
                }
                else if (direction == Direction.right) //move right
                {
                    for (col = left; col <= right; col++)
                    {
                        matrix[row, col] = digit++;
                    }
                    col--;
                    direction = Direction.up;
                    bottom--;
                }
                else if (direction == Direction.up) // move up
                {
                    for (row = bottom; row >= top; row--)
                    {
                        matrix[row, col] = digit++;
                    }
                    row++;
                    direction = Direction.left;
                    right--;
                }
                else if (direction == Direction.left) // move left
                {
                    for (col = right; col >= left; col--)
                    {
                        matrix[row, col] = digit++;
                    }
                    col++;
                    direction = Direction.down;
                    top++;
                }
            }

            PrintMatrix(matrix);
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
