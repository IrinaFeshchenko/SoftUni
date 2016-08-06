

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CrossingSequences
    {
        static void Main()
        {
            HashSet<int> set = new HashSet<int>();
            int t1 = int.Parse(Console.ReadLine());
            int t2 = int.Parse(Console.ReadLine());
            int t3 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int counter = 0;
            bool found = false;
            set.Add(t1);
            set.Add(t2);
            set.Add(t3);

            while (true)
            {
                if (t1 + t2 + t3<=1000000)
                {
                    int tmp = t3;
                    t3 = t1 + t2 + t3;
                    t1 = t2;
                    t2 = tmp;
                    set.Add(t3);
                }

                n += step*counter;
                if (n>1000000)
                {
                    break;
                }
                else if (set.Contains(n))
                {
                    Console.WriteLine(n);
                    found = true;
                    break;
                }

                n += step*counter;
                if (n > 1000000)
                {
                    break;
                }
                if (set.Contains(n))
                {
                    Console.WriteLine(n);
                    found = true;
                    break;
                }
                counter++;
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}
