namespace _01.Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int rows = nums[0];
            int cols = nums[1];

            long matrixSum = 0;
            for (int i = 0; i < rows; i++)
            {

                long rowSum = Console.ReadLine()
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(long.Parse)
                                    .ToArray()
                                    .Sum();

                matrixSum += rowSum;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(matrixSum);
        }
    }
}
