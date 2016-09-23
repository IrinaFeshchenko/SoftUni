

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SignOfIntegerNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintSigh(n);
        }

        private static void PrintSigh(int n)
        {
            if (n>0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
            else if (n<0)
            {
                Console.WriteLine($"The number {n} is negative.");
            }
            else if (n==0)
            {
                Console.WriteLine($"The number {n} is zero.");
            }
        }
    }
}
