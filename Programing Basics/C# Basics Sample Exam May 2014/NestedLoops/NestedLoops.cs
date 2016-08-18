

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NestedLoops
    {
        static void Main()
        {
            string s = Console.ReadLine();
            int[] n1 = { s[0] - '0', s[1] - '0', s[2] - '0', s[3] - '0' };
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            List<string> res = new List<string>();
            for (int d1 = 1; d1 < 10; d1++)
            {
                for (int d2 = 1; d2 < 10; d2++)
                {
                    for (int d3 = 1; d3 < 10; d3++)
                    {
                        for (int d4 = 1; d4 < 10; d4++)
                        {
                            int bulls = 0;
                            int cows = 0;
                            int[] n2 = { d1, d2, d3, d4 };
                            bool[] first = { false, false, false, false };
                            bool[] second = { false, false, false, false };

                            // find bools
                            for (int i = 0; i < 4; i++)
                            {
                                if (n1[i] == n2[i])
                                {
                                    bulls++;
                                    first[i] = true;
                                    second[i] = true;
                                }
                            }
                            //find cows
                            for (int i = 3; i >= 0; i--)
                            {
                                for (int j = 3; j >= 0; j--)
                                {
                                    if (first[i] == false && second[j]==false)
                                    {
                                        if (n1[i]==n2[j])
                                        {
                                            cows++;
                                            first[i] = true;
                                            second[j] = true;
                                            break;
                                        }
                                    }

                                }
                            }

                            if (bulls == b && cows == c)
                            {
                                res.Add(string.Format("{0}{1}{2}{3}", d1, d2, d3, d4));
                            }
                        }
                    }
                }
            }
            if (res.Count==0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ",res));
            }
        }
    }
}
