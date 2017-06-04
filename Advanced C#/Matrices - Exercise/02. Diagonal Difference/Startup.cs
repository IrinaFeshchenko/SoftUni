namespace _02.Diagonal_Difference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            }

            int primaryDiagSum = 0;
            int secondaryDiagSum = 0;

            for (int i = 0; i < n; i++)
            {
                primaryDiagSum += matrix[i][i];
                secondaryDiagSum += matrix[i][n-i-1];
            }

            Console.WriteLine(Math.Abs(primaryDiagSum-secondaryDiagSum));
        }
    }
}
