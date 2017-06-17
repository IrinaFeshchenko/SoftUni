namespace _02.Sum_Numbers
{
    using System;    using System.Linq;

    public class Startup    {        public static void Main()        {            int[] nums = Console.ReadLine()
                                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Console.WriteLine(nums.Count());
            Console.WriteLine(nums.Sum());
        }    }
}
