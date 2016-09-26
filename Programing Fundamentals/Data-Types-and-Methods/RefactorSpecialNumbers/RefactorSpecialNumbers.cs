

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RefactorSpecialNumbers
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            for (int i = 1; i <= range; i++)
            {
                int digit = i;
                int num = 0;

                while (i > 0)
                {
                    num += i % 10;
                    i = i / 10;
                }

                bool isSpecial = (num == 5) || (num == 7) || (num == 11);
                Console.WriteLine($"{digit} -> {isSpecial}");
                i = digit;
            }

        }
    }
}
