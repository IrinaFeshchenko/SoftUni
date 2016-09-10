

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PairsByDifference
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int difference = int.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i+1; j < nums.Count; j++)
                {
                    int currentDifference = Math.Abs(nums[i] - nums[j]);
                    if ( currentDifference == difference)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
