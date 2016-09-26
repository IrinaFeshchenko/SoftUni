

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixOfLetters
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char letter = 'A';
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = letter;
                    letter = (letter == 'Z') ? 'A' : ++letter;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
