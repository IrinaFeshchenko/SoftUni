

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FitBoxinBox
    {
        static void Main()
        {
            int[] b1 = new int[3];
            b1[0] = int.Parse(Console.ReadLine());
            b1[1] = int.Parse(Console.ReadLine());
            b1[2] = int.Parse(Console.ReadLine());

            int[] b2 = new int[3];
            b2[0] = int.Parse(Console.ReadLine());
            b2[1] = int.Parse(Console.ReadLine());
            b2[2] = int.Parse(Console.ReadLine());

            for (int s1  = 0; s1 < 3; s1++)
            {
                for (int s2 = 0; s2 < 3; s2++)
                {
                    if (s2==s1)
                    {
                        continue;
                    }
                    for (int s3 = 0; s3 < 3; s3++)
                    {
                        if (s3==s2||s3==s1)
                        {
                            continue;
                        }
                        if (b1[0]<b2[s1]&&b1[1]<b2[s2]&&b1[2]<b2[s3])
                        {
                            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", b1[0], b1[1],b1[2],b2[s1], b2[s2], b2[s3]);
                        }
                        else if (b2[0] < b1[s1] && b2[1] < b1[s2] && b2[2] < b1[s3])
                        {
                            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", b2[0], b2[1], b2[2], b1[s1], b1[s2], b1[s3]);
                        }
                    }
                }
            }
        }
    }
}
