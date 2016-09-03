

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumMinMaxFirstLastAverage
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
               nums.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"Sum = {nums.Sum()}");
            Console.WriteLine($"Min = {nums.Min()}");
            Console.WriteLine($"Max = {nums.Max()}");
            Console.WriteLine($"First = {nums.First()}");
            Console.WriteLine($"Last = {nums.Last()}");
            Console.WriteLine($"Average = {nums.Average()}");
        }
    }
}
