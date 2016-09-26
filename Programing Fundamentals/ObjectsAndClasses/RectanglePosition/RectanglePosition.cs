

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Rectangle
    {
        public Rectangle(int[] args)
        {
            this.Left = args[0];
            this.Top = args[1];
            this.Width = args[2];
            this.Height = args[3];
            CalculateRight();
            CalculateBottom();
        }

        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        private void CalculateRight()
        {
            this.Right = Left + Width;   
        }

        private void CalculateBottom()
        {
            this.Bottom = Top + Height;
        }
    }

    class RectanglePosition
    {
        static void Main()
        {
            Rectangle rectangle1 = ReadRectangle();
            Rectangle rectangle2 = ReadRectangle();

            if (isInside(rectangle1,rectangle2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        static Rectangle ReadRectangle()
        {
            int[] args = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Rectangle rect = new Rectangle(args);
            return rect;
        }

        static bool isInside(Rectangle r1, Rectangle r2)
        {
            if (r1.Left>=r2.Left &&
                r1.Right<=r2.Right &&
                r1.Top >= r2.Top &&
                r1.Bottom <= r2.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
