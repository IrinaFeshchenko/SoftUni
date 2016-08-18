

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ShuffleBits
    {
        static void Main()
        {
            uint n1 = uint.Parse(Console.ReadLine());
            uint n2 = uint.Parse(Console.ReadLine());
            ulong result = 0;

            if (n1 >= n2)
            {
                for (int i = 0, bit = 0; i < 32; i++)
                {
                    if (((n2 >> i) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }
                    bit++;

                    if (((n1 >> i) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }
                    bit++;
                }
            }
            else
            {
                for (int i = 0, bit = 0; i < 31; i+=2)
                {
                    if (((n2 >> i) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }

                    bit++;
                    if (((n2 >> i+1) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }
                    bit++;

                    if (((n1 >> i) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }
                    bit++;

                    if (((n1 >> i+1) & 1) != 0)
                    {
                        result = result | ((ulong)1 << bit);
                    }
                    bit++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
