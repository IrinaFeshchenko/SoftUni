

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CircleArea
    {
        static void Main()
        {
            double r = double.Parse(Console.ReadLine());

            Console.WriteLine($"{Math.PI*r*r:f12}");
        }
    }
}
