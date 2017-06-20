namespace _06.Target_Practice
{
    using System;
    using System.Linq;

    enum Direction
    {
        left,right
    }

    public class Startup
    {
        static void Main()
        {
            int[] dimentions = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] matrix = new char[rows,cols];
            string text = Console.ReadLine();
            int count = 0;
            var direction = Direction.left;

            for (int i = rows-1; i >= 0; i--)
            {
                if (direction == Direction.left)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        matrix[i, j] = text[count % text.Length];
                        count++;
                    }
                    direction = Direction.right;
                }
                else if (direction == Direction.right)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = text[count % text.Length];
                        count++;
                    }
                    direction = Direction.left;
                }
            }

            int[] shotArgs = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int hitRow = shotArgs[0];
            int hitCol = shotArgs[1];
            int radius = shotArgs[2];

            Shot(matrix, hitRow, hitCol, radius);

            CharsFellDown(matrix);

            PrintMatrix(matrix);
        }

        private static void CharsFellDown(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char[] buffer = new char[matrix.GetLength(0)];
                int bufferIndex = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row,col]!= ' ')
                    {
                        buffer[bufferIndex++] = matrix[row, col];
                    }
                }
            }
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

        private static void Shot(char[,] matrix, int hitRow, int hitCol, int rad)
        {
            int startCol = hitCol;
            int colLength = 1;

            int startRow = hitRow - rad;
            int endRow = hitRow + rad;
            bool passedTheMiddle = false;         

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j < startCol+colLength; j++)
                {
                    if (IsInMatrixBoundary(matrix,i,j))
                    {
                        matrix[i, j] = ' ';
                    }
                }


                if (i == hitRow)
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
        }

        private static bool IsInMatrixBoundary(char[,] matrix, int i, int j)
        {
            if (i<0||i>=matrix.GetLength(0))
            {
                return false;
            }

            if (j <0 || j >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
