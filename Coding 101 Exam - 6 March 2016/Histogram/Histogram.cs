

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Histogram
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
            int digit;

            for (int i = 0; i < n; i++)
            {
                digit = int.Parse(Console.ReadLine());

                if (digit < 200)
                {
                    p1++;
                }
                else if (digit < 400)
                {
                    p2++;
                }
                else if (digit < 600)
                {
                    p3++;
                }
                else if (digit < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            
            double d1 = (double) p1 / n * 100;
            double d2 = (double) p2 / n * 100;
            double d3 = (double) p3 / n * 100;
            double d4 = (double) p4 / n * 100;
            double d5 = (double) p5 / n * 100;


            Console.WriteLine("{0:f2}%", d1);
            Console.WriteLine("{0:f2}%", d2);
            Console.WriteLine("{0:f2}%", d3);
            Console.WriteLine("{0:f2}%", d4);
            Console.WriteLine("{0:f2}%", d5);
        }
    }
}
