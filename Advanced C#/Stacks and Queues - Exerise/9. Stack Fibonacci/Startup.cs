// There is another way of calculating the Fibonacci sequence using a stack.It is non recursive, so it does not make any unnecessary calculations.Try implementing it.This time set the Fibonacci sequence to start from 0, i.e. 0, 1, 1, 2, 3, 5, 8… and so on.First push 0 and 1 and then use popping, peeking and pushing to generate every consecutive number.

namespace _9.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fib = new Stack<long>();

            fib.Push(0);
            fib.Push(1);

            while(fib.Count<=n)
            {
                long fib1 = fib.Pop();
                long fib2 = fib.Peek();
                fib.Push(fib1);
                fib.Push(fib1+fib2);
            }

            Console.WriteLine(fib.Peek());
        }
    }
}
