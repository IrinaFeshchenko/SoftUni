namespace _07.Bounded_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] boundary = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int lower = Math.Min(boundary[0], boundary[1]);
            int upper = Math.Max(boundary[0], boundary[1]);

            List<int> nums = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .Where(x => x >= lower && x <= upper)
                                        .ToList();

            if (nums.Count > 0)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}
