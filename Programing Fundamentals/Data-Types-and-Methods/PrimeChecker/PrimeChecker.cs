

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrimeChecker
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            bool isPrime = IsPrime(n);

            Console.WriteLine(isPrime);
        }

        private static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int lenght = (int)Math.Sqrt(number);
            for (int i = 3; i <= lenght; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
