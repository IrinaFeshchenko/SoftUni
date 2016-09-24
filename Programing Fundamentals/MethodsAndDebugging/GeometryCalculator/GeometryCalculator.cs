

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GeometryCalculator
    {
        static void Main()
        {
            string figureType = Console.ReadLine().ToLower();

            if (figureType == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = GetTriangleArea(side, height);
                Console.WriteLine($"{area:f2}");
            }
            else if (figureType == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = GetRectangleArea(width, height);
                Console.WriteLine($"{area:f2}");
            }
            else if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = GetSquareArea(side);
                Console.WriteLine($"{area:f2}");
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = GetCircleArea(radius);
                Console.WriteLine($"{area:f2}");
            }
        }

        private static double GetTriangleArea(double side, double height)
        {
            return (side * height) / 2;
        }
        private static double GetSquareArea(double side)
        {
            return side * side;
        }
        private static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }
        private static double GetCircleArea(double radius)
        {
            return Math.PI * radius*radius;
        }
    }
}
