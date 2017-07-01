namespace _09_Rectangle_doubleersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            double[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToArray();

            double numberOfRectangles = nums[0];
            double numberOfdoubleersectionChecks = nums[1];

            Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

            for (double i = 0; i < numberOfRectangles; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var id = args[0];
                var width = double.Parse(args[1]);
                var height = double.Parse(args[2]);
                var top = double.Parse(args[3]);
                var left = double.Parse(args[4]);

                var rectangle = new Rectangle(id,width,height,new TopLeft(top,left));
                rectangles.Add(id,rectangle);
            }

            for (double i = 0; i < numberOfdoubleersectionChecks; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var id1 = args[0];
                var id2 = args[1];

                Console.WriteLine(rectangles[id1].doubleersect(rectangles[id2]).ToString().ToLower());
            }
        }
    }
}
