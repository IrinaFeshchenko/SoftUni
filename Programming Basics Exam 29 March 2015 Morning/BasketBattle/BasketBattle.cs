

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrBasketBattleogram
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = first == "Nakov" ? "Simeon" : "Nakov";
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int win = 0;

            int i = 0;
            for (; (i < n); i++)
            {
                int t1 = int.Parse(Console.ReadLine());
                string s1 = Console.ReadLine();
                if (s1 == "fail")
                {
                    t1 = 0;
                }

                if (i % 2 == 0)
                {
                    if (p1 + t1 <= 500)
                    {
                        p1 += t1;
                    }     
                }
                else
                {
                    if (p2+t1<=500)
                    {
                        p2 += t1;
                    }
                }
                if (p1 == 500)
                {
                    win = 1;
                    break;
                }
                if (p2 == 500)
                {
                    win = 2;
                    break;
                }

                int t2 = int.Parse(Console.ReadLine());
                string s2 = Console.ReadLine();
                if (s2 == "fail")
                {
                    t2 = 0;
                }
                if (i % 2 == 0)
                {
                    if (p2 + t2 <= 500)
                    {
                        p2 += t2;
                    }
                }
                else
                {
                    if (p1 + t2 <= 500)
                    {
                        p1 += t2;
                    }        
                }
                if (p1 == 500)
                {
                    win = 1;
                    break;
                }
                if (p2 == 500)
                {
                    win = 2;
                    break;
                }
            }

            if (win>0)
            {
                if (win==1)
                {
                    Console.WriteLine(first);
                    Console.WriteLine(i+1);
                    Console.WriteLine(p2);
                }
                else
                {
                    Console.WriteLine(second);
                    Console.WriteLine(i+1);
                    Console.WriteLine(p1);
                }
            }
            else
            {
                if (p1 > p2)
                {
                    Console.WriteLine(first);
                    Console.WriteLine(p1-p2);
                }
                else if (p2 > p1)
                {
                    Console.WriteLine(second);
                    Console.WriteLine(p2-p1);
                }
                else
                {
                    Console.WriteLine("DRAW");
                    Console.WriteLine(p1);
                }
            }

        }
    }
}
