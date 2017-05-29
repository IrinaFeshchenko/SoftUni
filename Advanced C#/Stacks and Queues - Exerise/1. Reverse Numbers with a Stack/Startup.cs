//Write a program that reads N integers from the console and reverses them using a stack.Use the Stack<int> class. Just put the input numbers in the stack and pop them.

namespace _1.Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
