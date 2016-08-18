

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeleportPoints
    {
        static void Main()
        {
            double[] a = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] b = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] c = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] d = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double r = double.Parse(Console.ReadLine());
            double step = double.Parse(Console.ReadLine());

            double left = a[0];
            double right = b[0];
            double top = c[1];
            double bottom = a[1];

            long count = 0;

            // right
            for (double i = 0; i < r; i = i + step)
            {
                //right top
                for (double j = 0; j < r; j = j + step)
                {
                    if ((Math.Pow(i - 0, 2) + Math.Pow(j - 0, 2)) <= Math.Pow(r, 2) && (i < right && i > left) && (j < top && j > bottom))
                    {                 
                        count++;
                    }
                }

                // bottom right
                for (double j = -step; j > -r; j = j - step)
                {
                    if ((Math.Pow(i - 0, 2) + Math.Pow(j - 0, 2)) <= Math.Pow(r, 2) && (i < right && i > left) && (j < top && j > bottom))
                    {
                        count++;
                    }
                }
            }

            //left
            for (double i = -step; i > -r; i = i - step)
            {
                //left top
                for (double j = 0; j < top; j = j + step)
                {
                    if ((Math.Pow(i - 0, 2) + Math.Pow(j - 0, 2)) <= Math.Pow(r, 2) && (i < right && i > left) && (j < top && j > bottom))
                    {
                        count++;
                    }
                }

                //bottom left
                for (double j = -step; j > -r; j = j - step)
                {
                    if ((Math.Pow(i - 0, 2) + Math.Pow(j - 0, 2)) <= Math.Pow(r, 2) && (i < right && i > left) && (j < top && j > bottom))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}