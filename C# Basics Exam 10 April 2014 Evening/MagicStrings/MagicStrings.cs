

namespace Namespace
{
    using System;

    class MagicStrings
    {
        static void Main()
        {
            byte diff = byte.Parse(Console.ReadLine());

            int[] d = { 1,4,5,3};
            char[] c = { 'k', 'n', 'p', 's' };

            bool no = true;
            for (byte d1 = 0; d1 < 4; d1++)
            {
                for (byte d2 = 0; d2 < 4; d2++)
                {
                    for (byte d3 = 0; d3 < 4; d3++)
                    {
                        for (byte d4 = 0; d4 < 4; d4++)
                        {
                            for (byte d5 = 0; d5 < 4; d5++)
                            {
                                for (byte d6 = 0; d6 < 4; d6++)
                                {
                                    for (byte d7 = 0; d7 < 4; d7++)
                                    {
                                        for (byte d8 = 0; d8 < 4; d8++)
                                        {
                                            if (Math.Abs((d[d1] + d[d2] + d[d3] + d[d4]) - (d[d5] + d[d6] + d[d7] + d[d8])) == diff)
                                            {
                                                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}", c[d1], c[d2], c[d3], c[d4], c[d5], c[d6], c[d7], c[d8]);
                                                no = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (no)
            {
                Console.WriteLine("No");
            }
        }
    }
}
