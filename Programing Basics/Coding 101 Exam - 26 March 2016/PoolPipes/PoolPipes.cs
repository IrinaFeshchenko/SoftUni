

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PoolPipes
    {
        static void Main()
        {
            int v = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());

            var t1 = p1 * n;
            var t2 = p2 * n;
            var t = t1 + t2;

            if (t > v)
            {
                double overflow = t - v;

                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",n ,overflow);
            }
            else
            {
                double per = t/v * 100;
                double per1 = t1 / t * 100;
                double per2 = t2 / t * 100;

                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", Math.Truncate( per), Math.Truncate(per1), Math.Truncate(per2));
            }
        }
    }
}
