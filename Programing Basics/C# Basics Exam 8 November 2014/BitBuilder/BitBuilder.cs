

namespace Namespace
{
    using System;

    class BitBuilder
    {
        static void Main()
        {
            ulong n = ulong.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "quit")
            {
                int position = int.Parse(command);
                string order = Console.ReadLine();

                if (order == "skip")
                {
                    continue;
                }
                else if (order == "flip")
                {
                    n ^= 1UL << position;
                }
                else if (order == "insert")
                {
                    ulong m = 0;

                    for (int i = 0; i < position; i++)
                    {
                        m |= n & (1UL << i);
                    }
                    m |= 1UL << position;

                    for (int i = position; i < 63; i++)
                    {
                        m |= (n & (1UL << i)) << 1;
                    }
                    n = m;
                }
                else if (order == "remove")
                {
                    ulong m = 0;

                    for (int i = 0; i < position; i++)
                    {
                        m |= n & (1UL << i);
                    }

                    for (int i = position + 1; i < 64; i++)
                    {
                        m |= (n & (1UL << i)) >> 1;
                    }
                    n = m;
                }
            }

            Console.WriteLine(n);
        }
    }
}
