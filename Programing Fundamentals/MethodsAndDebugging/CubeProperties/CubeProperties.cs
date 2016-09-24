


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Cube
    {
        private double Side { get; set; }

        public Cube(double side)
        {
            this.Side = side;
        }

        private double GetFaceDiagonal()
        {
            return Math.Sqrt(2*Side*Side);
        }

        private double GetSpaceDiagonal()
        {
            return Math.Sqrt(3 * Side * Side);
        }

        private double GetVolume()
        {
            return Math.Pow(Side,3);
        }

        private double GetSurfaceArea()
        {

            return 6 * Side * Side;
        }

        public double GetProperty(string propertyType)
        {
            if (propertyType == "face")
            {
                return this.GetFaceDiagonal();
            }
            else if (propertyType == "space")
            {
                return this.GetSpaceDiagonal();
            }
            else if (propertyType == "volume")
            {
                return this.GetVolume();
            }
            else if (propertyType == "area")
            {
                return this.GetSurfaceArea();
            }
            return 0;
        }
    }

    class CubeProperties
    {
        static void Main()
        {
            double CubeSideLenght = double.Parse(Console.ReadLine());
            Cube cube = new Cube(CubeSideLenght);
            string propertyType = Console.ReadLine();

            double result = cube.GetProperty(propertyType);
            Console.WriteLine($"{result:f2}");
        }
    }
}
