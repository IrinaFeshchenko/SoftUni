

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Line
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        public Line(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public double GetLenght()
        {
            double sideA = startPoint.X - endPoint.X;
            double sideB = startPoint.Y - endPoint.Y;

            double distance = Math.Sqrt(sideA * sideA + sideB * sideB);
            return distance;
        }
    }

    class DistanceBetweenPoints
    {
        static void Main()
        {
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Line line = new Line(new Point(a[0], a[1]), new Point(b[0], b[1]));
            Console.WriteLine("{0:f3}",line.GetLenght());
        }
    }
}
