

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Comparingdoubles
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001;
            double difference = Math.Abs(a - b);

            if (difference<eps)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
