

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrimesInGivenRange
    {
        static void Main()
        {
            long start = long.Parse(Console.ReadLine());
            long end = long.Parse(Console.ReadLine());
            List<long> primes = new List<long>();

            for (long i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            Console.WriteLine(string.Join(", ", primes));
        }

        private static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            long lenght = (long)Math.Ceiling( Math.Sqrt(number));

            for (long i = 3; i <= lenght; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
