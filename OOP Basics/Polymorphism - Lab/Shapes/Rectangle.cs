using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        private set { this.height = value; }
    }

    public override double CalculateArea()
    {
        return this.Width* this.Height;
    }

    public override double CalculatePerimeter()
    {
        return this.Width * 2 + this.Height * 2;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle" ;
    }
}
