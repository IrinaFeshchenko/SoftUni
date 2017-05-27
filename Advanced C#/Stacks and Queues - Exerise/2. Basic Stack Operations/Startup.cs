//Play around with a stack.You will be given an integer N representing the amount of elements to push onto the stack, an integer S representing the amount of elements to pop from the stack and finally an integer X, an element that you should check whether is present in the stack.If it is print true on the console, if it’s not print the smallest element currently present in the stack.
//Input Format: On the first line you will be given N, S and X separated by a single space. On the next line you will be given N amount of integers.
//Output Format: On a single line print either true if X is present in the stack otherwise print smallest element in the stack. If the stack is empty print 0.
//Examples
//Input   Output Comments
//5 2 13
//1 13 45 32 4	true	We have to push 5 elements.Then we pop 2 of them. Finally, we have to check whether 13 is present in the stack. Since it is we print true.
//4 1 666
//420 69 13 666	13	

namespace _2.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] inputArgs = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            if (inputArgs.Length!=3)
            {
                throw new ArgumentException("arguments count is not equal to 3");
            }

            int toPushOnStack = inputArgs[0];
            int toPopFromStack = inputArgs[1];
            int numberToBeChecked= inputArgs[2];

            int[] numbers = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Stack<int> stack = new Stack<int>();

            int count = toPushOnStack < numbers.Length ? toPushOnStack : numbers.Length;

            for (int i = 0; i < count; i++)
            {
                stack.Push(numbers[i]);
            }

            count = toPopFromStack < stack.Count ? toPopFromStack : stack.Count;

            for (int i = 0; i < count; i++)
            {
                stack.Pop();
            }

            string result = string.Empty;

            if (stack.Contains(numberToBeChecked))
            {
                result = "true";
            }
            else if (stack.Count == 0)
            {
                result = "0";
            }
            else
            {
                result = stack.Min(x=>x).ToString();
            }

            Console.WriteLine(result);
        }
    }
}
