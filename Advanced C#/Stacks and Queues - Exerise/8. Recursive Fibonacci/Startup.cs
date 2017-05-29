// The Fibonacci sequence is quite a famous sequence of numbers.Each member of the sequence is calculated from the sum of the two previous elements.The first two elements are 1, 1. Therefore the sequence goes as 1, 1, 2, 3, 5, 8, 13, 21, 34… 
// The following sequence can be generated with an array, but that’s easy, so your task is to implement recursively.
// So if the function getFibonacci(n) returns the n’th Fibonacci number we can express it using getFibonacci(n) = getFibonacci(n-1) + getFibonacci(n-2).
// However, this will never end and in a few seconds a StackOverflow Exception is thrown.In order for the recursion to stop it has to have a “bottom”. The bottom of the recursion is getFibonacci(2) should return 1 and getFibonacci(1) should return 1.
// Input Format: On the only line in the input the user should enter the wanted Fibonacci number.
// Output Format: The output should be the n’th Fibonacci number counting from 1. 
// Constraints: 
// 1 ≤ N ≤ 49

namespace _8.Recursive_Fibonacci
{
    using System;

    public class Startup
    {
        static long[] memoFib = new long[60];

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            memoFib[1] = 1;
            memoFib[2] = 1;

            if (n>2)
            {
                memoFib[n] = GetFib(n - 1) + GetFib(n - 2);
            } 

            Console.WriteLine(memoFib[n]);
        }

        private static long GetFib(int n)
        {
            if (memoFib[n]!=0)
            {
                return memoFib[n];
            }
            else
            {
                memoFib[n] = GetFib(n - 1) + GetFib(n - 2);
            }

            return memoFib[n];
        }
    }
}
