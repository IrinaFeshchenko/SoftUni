

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Firefighters
    {
        static void Main()
        {
            long K = 0, A = 0, S = 0;
            long firefighters = long.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "rain")
            {
                long k = 0, a = 0, s = 0;

                for (int i = 0; i < command.Length; i++)
                {
                    if (command[i] == 'K') k++;
                    else if (command[i] == 'A') a++;
                    else if (command[i] == 'S') s++;
                }

                if (firefighters <= k)
                {
                    K += firefighters;
                }
                else if (firefighters <= k + a)
                {
                    K += k;
                    A += firefighters - k;
                }
                else if (firefighters <= k + a + s)
                {
                    K += k;
                    A += a;
                    S += firefighters - a - k;
                }
                else
                {
                    K += k;
                    A += a;
                    S += s;
                }
            }

            Console.WriteLine("Kids: {0}", K);
            Console.WriteLine("Adults: {0}", A);
            Console.WriteLine("Seniors: {0}", S);
        }
    }
}
