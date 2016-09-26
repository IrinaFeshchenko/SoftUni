

namespace Namespace
{
    using System;

    class XBits
    {
        static void Main()
        {
            int rows = 8;
            int cols = 31;
            ulong[] num = new ulong[rows];
            for (int i = 0; i < rows; i++)
            {
                num[i] = ulong.Parse(Console.ReadLine());
            }

            int count = 0;
            for (int i = 0; i < rows-2; i++)
            {
                for (int j = 0; j < cols-2; j++)
                {
                    ulong r1 = (num[i] & (7ul << j)) >> j;
                    ulong r2 = (num[i+1] & (7ul << j)) >> j;
                    ulong r3 = (num[i+2] & (7ul << j)) >> j;

                    if (r1==5 && r2==2 && r3==5)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
