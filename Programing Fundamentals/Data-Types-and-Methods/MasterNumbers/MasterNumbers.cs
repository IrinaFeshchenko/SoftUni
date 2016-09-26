

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MasterNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsPalindrome(i) & SumOfDigits(i) & HoldEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HoldEvenDigit(int n)
        {
            while (n > 0)
            {
                int digit = n % 10;
                if (digit % 2 == 0)
                {
                    return true;
                }
                n /= 10;
            };
            return false;
        }

        private static bool SumOfDigits(int n)
        {
            int sum = 0;
            while (n>0)
            {
                sum += n % 10;
                n /= 10;
            }

            if (sum % 7== 0)
            {
                return true;
            }
            return false;
        }

        private static bool IsPalindrome(int n)
        {
            if (n % 10 == 0) return false;
            int r = 0;
            while (r < n)
            {
                r = 10 * r + n % 10;
                n /= 10;
            }
            return n == r || n == r / 10;
        }
    }
}
