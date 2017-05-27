//You will be given an integer N representing the amount of elements to enqueue(add), an integer S representing the amount of elements to dequeue(remove/poll) from the queue and finally an integer X, an element that you should check whether is present in the queue.If it is print true on the console, if it’s not print the smallest element currently present in the queue.

namespace _4.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        public static void Main()
        {
            int[] args = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int toEnqueue = args[0];
            int toDequeue = args[1];
            int toCheck = args[2];

            int[] numbers = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < toEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count==0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(toCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
