

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Box
    {
        private double lenght;
        private double height;
        private double width;

        public Box(double lenght, double height, double width)
        {
            this.lenght = lenght;
            this.height = height;
            this.width = width;
        }

        public double Surface()
        {
            return LatSurface() + (width * lenght * 2);
        }
        public double LatSurface()
        {
            return (lenght * height * 2) + (width * height * 2);
        }
        public double volume()
        {
            return lenght * height * width;
        }

    }

    class ClassBox
    {
        static void Main()
        {

            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            Box myBox = new Box(lenght, height, width);
            Console.WriteLine($"Surface Area - {myBox.Surface():f2}");
            Console.WriteLine($"Lateral Surface Area - {myBox.LatSurface():f2}");
            Console.WriteLine($"Volume - {myBox.volume():f2}");
        }
    }
}
