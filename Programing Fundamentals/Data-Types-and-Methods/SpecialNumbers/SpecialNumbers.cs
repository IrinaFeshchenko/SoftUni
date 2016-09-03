

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<int> specialDigits = new List<int>() { 5,7,11};
            for (int i = 0; i <= n; i++)
            {
                bool numIsSpecial = false;
                if (specialDigits.Contains(Sum(i)))
                {
                    numIsSpecial = true;
                }
                Console.WriteLine($"{i} -> {numIsSpecial}");
            }
        }
        private static int Sum(int num)
        {
            int sum = 0;
            while (num>0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
