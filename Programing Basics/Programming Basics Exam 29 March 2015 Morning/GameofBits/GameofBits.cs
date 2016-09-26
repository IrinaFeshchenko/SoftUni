


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GameofBits
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int lenght = 32;

            string command;
            while ((command = Console.ReadLine()) != "Game Over!")
            {
                if (command == "Odd")
                {
                    number = GetNewNumber(number,"Odd",lenght);
                }
                else if (command == "Even")
                {
                    number = GetNewNumber(number, "Even", lenght);
                }
            }

            int count = 0;
            for (int i = (32 - 1); i >= 0; i--)
            {
                if (((number >> i) & 1) == 1)
                {
                    count++;
                }
            }

            Console.WriteLine("{0} -> {1}", number, count);
        }

        private static ulong GetNewNumber(ulong number, string oddOrEven, int lenght)
        {
            ulong resultNumber = 0;

            int i = 0;
            if (oddOrEven == "Even")
            {
                i = 1;
            }

            for (int j = 0; i < lenght; i += 2, j++)
            {
                resultNumber |= ((number & (1UL << i)) >> i) << j;
            }

            return resultNumber;
        }
    }
}
