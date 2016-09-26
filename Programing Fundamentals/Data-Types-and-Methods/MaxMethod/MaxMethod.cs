

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxMethod
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int max = GetMax(a, GetMax(b,c));
            Console.WriteLine(max);
        }

        private static int GetMax(int a, int b)
        {
            return Math.Max(a,b);
        }
    }
}
