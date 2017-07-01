using System;

namespace _09_Rectangle_doubleersection
{
    public struct TopLeft
    {
        public TopLeft(double top, double left) : this()
        {
            this.top = top;
            this.left = left;
        }

        public double top { get; set; }
        public double left { get; set; }
    }
    public class Rectangle
    {
        public Rectangle(string iD, double width, double height, TopLeft topLeft)
        {
            ID = iD;
            Width = width;
            Height = height;
            TopLeft = topLeft;
        }

        public string ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public TopLeft TopLeft { get; set; }

        public bool doubleersect(Rectangle rectangle)
        {
            if (IsInside(rectangle))
            {
                return false;
            }

            if (HorizontalOverlap(rectangle) && VerticalOverlap(rectangle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsInside(Rectangle rectangle)
        {
            var r1Top = this.TopLeft.top;
            var r1Bottom = r1Top + this.Height;
            var r1Left = this.TopLeft.left;
            var r1Right = r1Left + this.Width;

            var r2Top = rectangle.TopLeft.top;
            var r2Bottom = r2Top + rectangle.Height;
            var r2Left = rectangle.TopLeft.left;
            var r2Right = r2Left + rectangle.Width;

            // r1 is in r2
            if (r1Top > r2Top && r1Top < r2Bottom &&
                r1Bottom > r2Top && r1Bottom < r2Bottom &&
                r1Left> r2Left&&r1Left<r2Right &&
                r1Right >r2Left && r1Right <r2Right)
            {
                return true;
            };

            // r2 is in r1
            if (r2Top > r1Top && r2Top < r1Bottom &&
                r2Bottom > r1Top && r2Bottom < r1Bottom &&
                r2Left > r1Left && r2Left < r1Right &&
                r2Right > r1Left && r2Right < r1Right)
            {
                return true;
            };

            return false;
        }

        private bool VerticalOverlap(Rectangle rectangle)
        {
            var r1Top = this.TopLeft.top;
            var r1Bottom = r1Top + this.Height;

            var r2Top = rectangle.TopLeft.top;
            var r2Bottom = r2Top + rectangle.Height;


            if (r1Top >= r2Top &&
                r1Top <= r2Bottom)
            {
                return true;
            };

            if (r1Bottom >= r2Top &&
                r1Bottom <= r2Bottom)
            {
                return true;
            };

            if (r2Top >= r1Top &&
                r2Top <= r1Bottom)
            {
                return true;
            };
            if (r2Bottom >= r1Top &&
                r2Bottom <= r1Bottom)
            {
                return true;
            };

            return false;
        }

        private bool HorizontalOverlap(Rectangle rectangle)
        {
            var r1Left = this.TopLeft.left;
            var r1Right = r1Left + this.Width;

            var r2Left = rectangle.TopLeft.left;
            var r2Right = r2Left + rectangle.Width;


            if (r1Left >= r2Left &&
                r1Left <= r2Right)
            {
                return true;
            };
            if (r1Right >= r2Left &&
                r1Right <= r2Right)
            {
                return true;
            };

            if (r2Left >= r1Left &&
                r2Left <= r1Right)
            {
                return true;
            };
            if (r2Right >= r1Left &&
                r2Right <= r1Right)
            {
                return true;
            };

            return false;
        }
    }
}
