namespace _04.Pascal_Triangle
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new long[i+1];
            }

            matrix[0][0]= 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    matrix[i][j] = GetValue(matrix,i-1,j) + GetValue(matrix, i-1, j-1);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static long GetValue(long[][] matrix, long i, long j)
        {
            if (i<0)
            {
                return 0;
            }

            if (j >= matrix[i].GetLength(0))
            {
                return 0;
            }

            if (j<0)
            {
                return 0;
            }

            return matrix[i][j];
        }
    }
}
