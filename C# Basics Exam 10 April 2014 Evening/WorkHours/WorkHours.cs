

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WorkHours
    {
        static void Main()
        {
            long h = long.Parse(Console.ReadLine());
            long d = long.Parse(Console.ReadLine());
            long p = long.Parse(Console.ReadLine());

            double productiveHours = Math.Floor(d * 10.8*p/100);

            double result = productiveHours - h;
            if (result>=0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine(result);
            }
        }
    }
}
