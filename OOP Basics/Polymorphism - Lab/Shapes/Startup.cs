using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        var circle = new Circle(5);

        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.CalculateArea());
    }
}

