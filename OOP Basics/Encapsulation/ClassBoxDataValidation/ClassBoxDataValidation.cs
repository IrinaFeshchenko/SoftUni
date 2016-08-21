

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Box
    {
        private double length;
        private double width;
        private double heigth;     

        public Box(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            height = heigth;
        }


        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)}");
                }
                length = value;
            }
        }


        public double Width
        {
            get
            {
                return width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)}");
                }
                width = value;
            }
        }

        public double height
        {
            get
            {
                return height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(height)}");
                }
                heigth = value;
            }
        }

        public double Surface()
        {
            return LatSurface() + (Width * Length * 2);
        }
        public double LatSurface()
        {
            return ((Length * 2) + (Width * 2))* height;
        }
        public double volume()
        {
            return Length * height * Width;
        }
    }

    class ClassBoxDataValidation
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                Box myBox = new Box(length, width, heigth);

                Console.WriteLine($"Surface Area - {myBox.Surface():f2}");
                Console.WriteLine($"Lateral Surface Area - {myBox.LatSurface():f2}");
                Console.WriteLine($"Volume - {myBox.volume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + " cannot be zero or negative.");
            }
        }
    }
}
