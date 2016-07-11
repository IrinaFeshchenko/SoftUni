

namespace Namespace
{
    using System;

    class EmergencyRepairs
    {
        static ulong wall;
        static void Main()
        {
            wall = ulong.Parse(Console.ReadLine());
            int kits = int.Parse(Console.ReadLine());
            int attacks = int.Parse(Console.ReadLine());

            for (int i = 0; i < attacks; i++)
            {
                int bit = int.Parse(Console.ReadLine());
                wall = wall & ~((ulong)1 << bit);
            }

            for (int i = 0; i < 63; i++)
            {
                if (isZero(i) && isZero(i + 1))
                {
                    while ((kits > 0) && (i < 64) && isZero(i))
                    {
                        fix(i);
                        i++;
                        kits--;
                    }
                }
            }

            Console.WriteLine(wall);
        }
        private static bool isZero(int bit)
        {
            return ((wall >> bit) & 1) == 0; ;
        }
        private static void fix(int bit)
        {
            wall = wall | ((ulong)1 << bit);
        }
    }
}
