

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargestIncreasingSubsequence
    {
        public class cell
        {
            public int Value { get; set; }
            public int Count { get; set; }
            public int PrevNode { get; set; }
            public int Index { get; set; }
            public cell(int value, int index)
            {
                Value = value;
                Count = 1;
                PrevNode = -1;
                Index = index;
            }
        }

        static void Main()
        {
            List<int> inputNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<cell> nums = new List<cell>();
            for (int i = 0; i < inputNums.Count; i++)
            {
                int n = inputNums[i];
                nums.Add((new cell(n,i)));
            }

            for (int currentNode = 1; currentNode < nums.Count; currentNode++)
            {
                int longestSequence = GetLongestSequence(nums, currentNode);
                if (longestSequence!=-1)
                {
                    nums[currentNode].PrevNode = longestSequence;
                    nums[currentNode].Count += nums[longestSequence].Count;
                }
            }

            int node = nums
                        .Where(x => x.Count == nums
                                        .Select(y => y.Count)
                                        .Max())
                                        .Select(z=>z.Index)
                                        .FirstOrDefault();
                                        

            Stack<int> stack = new Stack<int>();
            do
            {
                stack.Push(nums[node].Value);
                node = nums[node].PrevNode;
            }
            while (node != -1);
            Console.WriteLine( string.Join(" ",stack));
        }

        private static int GetLongestSequence(List<cell> nums, int nodePosition)
        {
            int longestSequence = -1;
            int maxCount = 0;
            for (int currentPosition = 0; currentPosition < nodePosition; currentPosition++)
            {
                if (nums[currentPosition].Value < nums[nodePosition].Value &&
                    nums[currentPosition].Count > maxCount)
                {
                    longestSequence = currentPosition;
                    maxCount = nums[currentPosition].Count;
                }
            }
            return longestSequence;
        }
    }
}
