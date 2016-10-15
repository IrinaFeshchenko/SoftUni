namespace MultiplyTargetedCell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cell
    {
        public long Row { get; set; }
        public long Col { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            const long radius = 1;
            long[,] matrix = ReadMatrixDiimentions();

            Cell position = ReadPosition();

            matrix = MultiplyCells(matrix,position,radius);

            PrintResult(matrix);
        }

        private static void PrintResult(long[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                    if (j<matrix.GetLength(1)-1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static long[,] MultiplyCells(long[,] matrix, Cell position, long radius)
        {
            long rowStart = Math.Max(position.Row - radius, 0);
            long colStart = Math.Max(position.Col - radius, 0);
            long rowEnd = Math.Min(position.Row+radius,matrix.GetLength(0));
            long colEnd = Math.Min(position.Col+radius, matrix.GetLength(1));
            long rows = rowEnd - rowStart +1 ;
            long cols = colEnd - colStart +1 ;

            long neibhoringCellsSum = 0;
            //multiply neibhor cells by target cell
            for (long i = rowStart; i <= rowEnd; i++)
            {
                for (long j = colStart; j <= colEnd; j++)
                {
                    if ((i!=position.Row)||(j!=position.Col))
                    {
                        neibhoringCellsSum += matrix[i,j];
                        matrix[i, j] *= matrix[position.Row,position.Col];
                    }
                }
            }

            // multiply the targetCell
            matrix[position.Row, position.Col] *= neibhoringCellsSum;

            return matrix;
        }

        private static Cell ReadPosition()
        {
            long[] positionArgs = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(long.Parse)
                                    .ToArray();
            Cell position = new Cell();
            position.Row = positionArgs[0];
            position.Col = positionArgs[1];

            return position;
        }

        private static long[,] ReadMatrixDiimentions()
        {
            long[] dimentionArgs = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(long.Parse)
                                .ToArray();
            long rows = dimentionArgs[0];
            long cols = dimentionArgs[1];

            long[,] matrix = new long[rows,cols];

            for (long i = 0; i < rows; i++)
            {
                long[] lineArgs = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(long.Parse)
                                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = lineArgs[j];
                }
            }

            return matrix;
        }
    }
}
