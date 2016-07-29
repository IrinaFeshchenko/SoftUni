

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MorseCodeNumbers
    {
        static void Main()
        {
            string n = Console.ReadLine().Trim();

            int nSum = (n[0] - '0') + (n[1] - '0') + (n[2] - '0') + (n[3] - '0');
            List<string> res = new List<string>();
            for (int d0 = 0; d0 < 6; d0++)
            {
                for (int d1 = 0; d1 < 6; d1++)
                {
                    for (int d2 = 0; d2 < 6; d2++)
                    {
                        for (int d3 = 0; d3 < 6; d3++)
                        {
                            for (int d4 = 0; d4 < 6; d4++)
                            {
                                for (int d5 = 0; d5 < 6; d5++)
                                {
                                    if (d0 * d1 * d2 * d3 * d4 * d5 == nSum)
                                    {
                                        string s0 = (new string('.', d0)) + (new string('-', 5 - d0));
                                        string s1 = (new string('.', d1)) + (new string('-', 5 - d1));
                                        string s2 = (new string('.', d2)) + (new string('-', 5 - d2));
                                        string s3 = (new string('.', d3)) + (new string('-', 5 - d3));
                                        string s4 = (new string('.', d4)) + (new string('-', 5 - d4));
                                        string s5 = (new string('.', d5)) + (new string('-', 5 - d5));

                                        res.Add(s0 + '|'+s1 + '|' + s2 + '|' + s3 + '|' + s4 + '|' + s5 + '|');
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (res.Count ==0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var num in res)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
