namespace _03.Custom_Min_Function
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Func<int[], int> smallestNumberFinder = x => GetSmallest(x);

            PrintSmallestNumber(nums, smallestNumberFinder);
        }

        private static int GetSmallest(int[] nums)
        {
            int smallest = int.MaxValue;

            foreach (var number in nums)
            {
                if (number<smallest)
                {
                    smallest = number;
                }
            }

            return smallest;
        }

        private static void PrintSmallestNumber(int[] nums, Func<int[], int> smallestNumberFinder)
        {
            Console.WriteLine(smallestNumberFinder(nums));
        }
    }
}
