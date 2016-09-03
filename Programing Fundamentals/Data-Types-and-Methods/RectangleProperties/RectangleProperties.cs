

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RectangleProperties
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double perimeter = 2 * width + 2 * height;
            Console.WriteLine(perimeter);

            double area = width * height;
            Console.WriteLine(area);

            double diagonal = Math.Sqrt(width*width+height*height);
            Console.WriteLine(diagonal);
        }
    }
}
