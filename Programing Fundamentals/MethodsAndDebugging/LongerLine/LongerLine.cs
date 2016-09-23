
namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    class CenterPrint
    {
        static void Main()
        {

            Point firstPoint = new Point();
            firstPoint.x = double.Parse(Console.ReadLine());
            firstPoint.y = double.Parse(Console.ReadLine());
            Point secondPoint = new Point();
            secondPoint.x = double.Parse(Console.ReadLine());
            secondPoint.y = double.Parse(Console.ReadLine());
            PrintThePoinCloserToZero(firstPoint, secondPoint);
        }

        private static void PrintThePoinCloserToZero(Point firstPoint, Point secondPoint)
        {
            double firstDistance = GetDistance(firstPoint);
            double secondDistance = GetDistance(secondPoint);

            if (firstDistance <= secondDistance)
            {
                Print(firstPoint);
            }
            else
            {
                Print(secondPoint);
            }
        }

        private static void Print(Point p)
        {
            Console.WriteLine($"({p.x}, {p.y})");
        }

        private static double GetDistance(Point p)
        {
            double distance = Math.Sqrt(p.x * p.x + p.y * p.y);
            return distance;
        }


    }
}