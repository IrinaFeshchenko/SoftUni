

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FibonacciNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int nFib = Fib(n);

            Console.WriteLine(nFib);
        }

        private static int Fib(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else if (n<4)
            {
                return n;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }         
        }
    }
}
