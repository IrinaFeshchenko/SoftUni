

namespace Namespace
{
    using System;

    class BitSifting
    {
        static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                num &= ~ulong.Parse(Console.ReadLine());
            }
            ulong count = 0;
            while (num > 0)
            {
                count += (num & 1);
                num >>= 1;
            }
            Console.WriteLine(count);
        }
    }
}
