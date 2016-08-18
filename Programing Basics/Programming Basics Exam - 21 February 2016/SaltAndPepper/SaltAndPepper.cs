

namespace Namespace
{
    using System;

    class SaltAndPepper
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();
                string spice = command[0];
                int step = int.Parse(command[1]);

                ulong mask = 0;
                for (int i = 0; i < 64; i += step)
                {
                    mask |= 1;
                    mask <<= step;
                }
                mask |= 1;

                if (spice == "pepper")
                {
                    number |= mask;
                }

                if (spice == "salt")
                {
                    mask ^= ulong.MaxValue;
                    number &= mask;
                }
            }

            //for (int i = 63; i >= 0; i--)
            //{
            //    ulong mask = 1;
            //    mask <<= i;
            //    mask &= number;
            //    mask >>= i;
            //    Console.Write(mask);
            //}
            Console.Pri
            Console.WriteLine(number);
        }
    }
}
