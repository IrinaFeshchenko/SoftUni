using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Class_Box
{
    public class Box
    {
        private double length;
        private double width;
        private double heigth;

        public Box()
        {
        }

        public Box(double length, double width, double heigth)
        {
            Length = length;
            Width = width;
            Heigth = heigth;
        }

        private double Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        private double Heigth
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.heigth = value;
            }
        }

        public double GetSurface()
        {
            return 2 * length * width + 2 * length * heigth + 2 * width * heigth;
        }

        public double GetLateralSurface()
        {
            return 2 * length * heigth + 2 * width * heigth;
        }

        public double GetVolume()
        {
            return length * width * heigth;
        }
    }
}
