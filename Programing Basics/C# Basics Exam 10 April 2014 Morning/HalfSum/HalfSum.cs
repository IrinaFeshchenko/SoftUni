

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HalfSum
    {
        static void Main()
        {
            int first = 0;
            int second = 0;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                first += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                second += int.Parse(Console.ReadLine());
            }

            if (first == second)
            {
                Console.WriteLine("Yes, sum={0}",first);
            }
            else
            {
                Console.WriteLine("No, diff={0}", Math.Abs(first-second));
            }
        }
    }
}
