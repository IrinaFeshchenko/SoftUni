

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Podouble
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    class CenterPodouble
    {
        static void Main()
        {
            Podouble firstPodouble = new Podouble();
            firstPodouble.x = double.Parse(Console.ReadLine());
            firstPodouble.y = double.Parse(Console.ReadLine());
            Podouble secondPodouble = new Podouble();
            secondPodouble.x = double.Parse(Console.ReadLine());
            secondPodouble.y = double.Parse(Console.ReadLine());
            PrdoubleThePoinCloserToZero(firstPodouble,secondPodouble);
        }

        private static void PrdoubleThePoinCloserToZero(Podouble firstPodouble, Podouble secondPodouble)
        {
            double firstDistance = GetDistance(firstPodouble);
            double secondDistance = GetDistance(secondPodouble);

            if (firstDistance<=secondDistance)
            {
                Prdouble(firstPodouble);
            }
            else
            {
                Prdouble(secondPodouble);
            }
        }

        private static void Prdouble(Podouble p)
        {
            Console.WriteLine($"({p.x}, {p.y})");
        }

        private static double GetDistance(Podouble p)
        {
            double distance = Math.Sqrt(p.x*p.x + p.y*p.y);
            return distance;
        }


    }
}
