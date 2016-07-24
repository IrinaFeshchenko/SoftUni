

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WeirdCombinationsSolution
    {
        static void Main()
        {
            char[] c = Console.ReadLine().Trim().ToArray();
            ulong n = ulong.Parse(Console.ReadLine());
            char[] result = new char[5];

            ulong num = 0;
            for (int c1 = 0; c1 < 5; c1++)
            {
                result[0] = c[c1];
                for (int c2 = 0; c2 < 5; c2++)
                {
                    result[1] = c[c2];
                    for (int c3 = 0; c3 < 5; c3++)
                    {
                        result[2] = c[c3];
                        for (int c4 = 0; c4 < 5; c4++)
                        {
                            result[3] = c[c4];
                            for (int c5 = 0; c5 < 5; c5++)
                            {
                                result[4] = c[c5];
                                if (num == n)
                                {
                                    Console.WriteLine(string.Join("",result));
                                    return;
                                }
                                num++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("No");
        }
    }
}
