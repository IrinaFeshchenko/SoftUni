

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Line
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        public Line(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public Line()
        {
            startPoint = new Point();
            endPoint = new Point();
        }

        public double GetLenght()
        {
            double sideA = startPoint.X - endPoint.X;
            double sideB = startPoint.Y - endPoint.Y;

            double distance = Math.Sqrt(sideA * sideA + sideB * sideB);
            return distance;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point()
        {
        }
    }

    public class ClosestTwoPoints
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                int[] args = Console.ReadLine().Split().Select(int.Parse).ToArray();
                points[i] = new Point(args[0], args[1]);
            }

            Line minDistance = new Line(points[0], points[1]);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (GetDistance(points[i], points[j]) < minDistance.GetLenght())
                    {
                        minDistance.startPoint = points[i];
                        minDistance.endPoint = points[j];
                    }
                }
            }

            Console.WriteLine("{0:f3}", minDistance.GetLenght());
            Console.WriteLine("({0}, {1})", minDistance.startPoint.X, minDistance.startPoint.Y);
            Console.WriteLine("({0}, {1})", minDistance.endPoint.X, minDistance.endPoint.Y);
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
