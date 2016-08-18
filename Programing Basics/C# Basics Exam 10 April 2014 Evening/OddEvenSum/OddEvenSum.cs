

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OddEvenSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int odd = 0;
            int even = 0;
            for (int i = 0; i < n; i++)
            {
                odd += int.Parse(Console.ReadLine());
                even += int.Parse(Console.ReadLine());

            }

            if (odd == even)
            {
                Console.WriteLine("Yes, sum=" + odd);
            }
            else
            {
                int diff = Math.Abs(odd - even);
                Console.WriteLine("No, diff=" + diff);
            }
        }
    }
}
