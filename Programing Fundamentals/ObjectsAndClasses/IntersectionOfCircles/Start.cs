

namespace IntersectionOfCircles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            int[] c1 = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int[] c2 = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            Circle circle1 = new Circle()
            {
                Radius = c1[2],
                Center = new Point() { X = c1[0], Y = c1[1] }
            };
            Circle circle2 = new Circle()
            {
                Radius = c2[2],
                Center = new Point() { X = c2[0], Y = c2[1] }
            };

            bool intersect = Intersect(circle1, circle2);
            string result = intersect ? "Yes" : "No";
            Console.WriteLine($"{result}");
        }

        private static bool Intersect(Circle circle1, Circle circle2)
        {
            double distance = GetDistance(circle1.Center,circle2.Center);
            double radiusSum = circle1.Radius + circle2.Radius;

            if (distance>radiusSum)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static double GetDistance(Point startPoint, Point endPoint)
        {
            double sideA = startPoint.X - endPoint.X;
            double sideB = startPoint.Y - endPoint.Y;

            double distance = Math.Sqrt(sideA * sideA + sideB * sideB);
            return distance;
        }
    }
}
