namespace JediGalaxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            int[,] matrix = new int[rows, cols];

            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = count++;
                }
            }

            long sum = 0;
            string input;
            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                // ivo start cell
                int[] ivo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();
                // evil start cell
                int[] evil = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
                // evil diagonal
                int evilStartRow = evil[0];
                int evilStartCol = evil[1];

                for (int i = evilStartRow, j = evilStartCol; (i >= 0) && (j >= 0); i--, j--)
                {
                    if (i < rows && j < cols)
                    {
                        matrix[i, j] = 0;
                    }
                }


                // Ivo diagonal
                int ivoStartRow = ivo[0];
                int ivoStartCol = ivo[1];

                for (int i = ivoStartRow, j = ivoStartCol; (i >= 0) && (j < cols); i--, j++)
                {
                    if (i < rows && j >= 0)
                    {
                        sum += matrix[i, j];
                    }
                }

            }

            Console.WriteLine(sum);
        }
    }
}
