namespace BlurFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cell
    {
        public long Row { get; set; }
        public long Col { get; set; }
    }

    public class Start
    {
        const long BlurRadius = 1;

        public static void Main()
        {
            long blurAmount = long.Parse(Console.ReadLine());

            long[,] matrix = ReadMatrix();

            Cell cell = ReadLocation();

            matrix = ApplyBlur(matrix, cell, blurAmount);

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(long[,] matrix)
        {
            long rows = matrix.GetLength(0);
            long cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                char[] result = new char[cols];

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);

                    if (j < cols - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static long[,] ApplyBlur(long[,] matrix, Cell blurCell, long blurAmount)
        {

            long matrixRows = matrix.GetLength(0);
            long matrixCols = matrix.GetLength(1);

            long startRow = Math.Max(blurCell.Row - BlurRadius, 0);
            long startCol = Math.Max(blurCell.Col - BlurRadius, 0);
            long endRow = Math.Min(blurCell.Row + BlurRadius, matrixRows - 1);
            long endCol = Math.Min(blurCell.Col + BlurRadius, matrixCols - 1);

            for (long i = startRow; i <= endRow; i++)
            {
                for (long j = startCol; j <= endCol; j++)
                {
                    matrix[i, j] += blurAmount;
                }
            }

            return matrix;
        }

        private static Cell ReadLocation()
        {
            long[] args = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(long.Parse)
                                .ToArray();

            Cell cell = new Cell();
            cell.Row = args[0];
            cell.Col = args[1];
            return cell;
        }

        private static long[,] ReadMatrix()
        {

            long[] args = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();
            var rows = args[0];
            var cols = args[1];

            long[,] matrix = new long[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                long[] line = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(long.Parse)
                                     .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}
