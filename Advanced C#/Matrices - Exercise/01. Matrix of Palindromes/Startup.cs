namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Linq;

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
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = $"{chars[i]}{chars[i+j]}{chars[i]}";
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
