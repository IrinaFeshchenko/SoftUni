

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            int rightDiagSum = 0;
            for (int i = 0; i < n; i++)
            {
                rightDiagSum += matrix[i, i];
            }

            int leftDiagSum = 0;
            for (int i = 0; i < n; i++)
            {
                leftDiagSum += matrix[i, n-1-i];
            }

            int result = Math.Abs(leftDiagSum-rightDiagSum);
            Console.WriteLine(result);
        }
    }
}
