

namespace Namespace
{
    using System;

    class Division
    {
        static void Main()
        {
            double p1 = 0, p2 = 0, p3 = 0;
            int n = int.Parse(Console.ReadLine());
            int buffer;
            for (int i = 0; i < n; i++)
            {
                buffer = int.Parse(Console.ReadLine());
                if (buffer % 2 == 0)
                {
                    p1++;
                }
                if (buffer % 3 == 0)
                {
                    p2++;
                }
                if (buffer % 4 == 0)
                {
                    p3++;
                }
            }

            p1 = p1 / n * 100;
            p2 = p2 / n * 100;
            p3 = p3 / n * 100;

            Console.WriteLine("{0:f2}%", p1);
            Console.WriteLine("{0:f2}%", p2);
            Console.WriteLine("{0:f2}%", p3);
        }
    }
}
