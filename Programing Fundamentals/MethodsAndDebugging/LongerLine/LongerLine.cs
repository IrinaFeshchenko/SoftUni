
namespace LongerLine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point()
        {
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetDistanceToCentre()
        {
            double distance = (double)Math.Sqrt(this.x * this.x + this.y * this.y);
            return distance;
        }
    }

    public class Line
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        public Line()
        {
            this.startPoint = new Point();
            this.endPoint = new Point();
        }

        public Line(Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public double GetLenght()
        {
            double x1 = this.startPoint.x;
            double x2 = this.endPoint.x;
            double y1 = this.startPoint.y;
            double y2 = this.endPoint.y;

            double lenght = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return lenght;
        }
    }

    class LongerLine
    {
        static void Main()
        {
            Line firstLine = ReadLine();
            Line secondLine = ReadLine();

            if (firstLine.GetLenght() >= secondLine.GetLenght())
            {
                Print(firstLine);
            }
            else
            {
                Print(secondLine);
            }
        }

        private static Line ReadLine()
        {
            Line line = new Line();
            line.startPoint.x = double.Parse(Console.ReadLine());
            line.startPoint.y = double.Parse(Console.ReadLine());
            line.endPoint.x = double.Parse(Console.ReadLine());
            line.endPoint.y = double.Parse(Console.ReadLine());
            return line;
        }

        private static void Print(Line line)
        {
            Point p1 = new Point(line.startPoint.x, line.startPoint.y);
            Point p2 = new Point(line.endPoint.x, line.endPoint.y);

            if (p1.GetDistanceToCentre() <= p2.GetDistanceToCentre())
            {
                Console.WriteLine($"({p1.x}, {p1.y})({p2.x}, {p2.y})");
            }
            else
            {
                Console.WriteLine($"({p2.x}, {p2.y})({p1.x}, {p1.y})");
            }
        }
    }
}