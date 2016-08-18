

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MelonsandWatermelons
    {
        static void Main()
        {
            long day = long.Parse(Console.ReadLine());
            long melonDays = long.Parse(Console.ReadLine());
            long watermelons = 0;
            long melons = 0;
            for (int i = 0; i < melonDays; i++)
            {
                if (day%7==1)
                {
                    watermelons++;
                }
                else if (day%7==2)
                {
                    melons += 2;
                }
                else if (day % 7 == 3)
                {
                    watermelons++;
                    melons++;
                }
                else if (day % 7 == 4)
                {
                    watermelons += 2;
                }
                else if (day % 7 == 5)
                {
                    watermelons += 2;
                    melons += 2;
                }
                else if (day % 7 == 6)
                {
                    watermelons++;
                    melons += 2;
                }
                day++;
            }

            if (watermelons>melons)
            {
                Console.WriteLine("{0} more watermelons", watermelons-melons);
            }
            else if (melons > watermelons)
            {
                Console.WriteLine("{0} more melons",melons-watermelons);
            }
            else
            {
                Console.WriteLine("Equal amount: {0}",melons);
            }
        }
    }
}
