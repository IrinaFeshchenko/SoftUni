using System;
using System.Linq;
using System.Threading;

namespace Even_Numbers_Thread
{
    public class Program
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int start = nums[0];
            int end = nums[1];

            Thread evens = new Thread(() =>
            {
                PrintEvenNumbers(start, end);
            });
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work");
        }

        public static void PrintEvenNumbers(int start, int end)
        {
            if (start>end)
            {
                return;
            }

            for (int i = start; i <= end; i++)
            {
                if (i%2==0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
