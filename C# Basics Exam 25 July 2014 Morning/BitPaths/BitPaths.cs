

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitPaths
    {
        static void Main()
        {
            int[] rows = new int[8];

            long n = long.Parse(Console.ReadLine());

            // for each path
            for (int i = 0; i < n; i++)
            {
                int[] param = Console.ReadLine().Trim().Split(',').Select(int.Parse).ToArray();

                // for each row
                int mask = 1<<(3-param[0]);
                rows[0] ^= mask;
                for (int j = 1; j < param.Length; j++)
                {
                    if (param[j]==-1)
                    {
                        mask = mask << 1;
                    }
                    else if (param[j] == 1)
                    {
                        mask = mask >> 1;
                    }
                    
                    rows[j] ^= mask;
                }
            }

            int sum = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                sum += rows[i];
            }
            Console.WriteLine("{0}", Convert.ToString(sum, 2));
            Console.WriteLine("{0:X}",sum);
        }
    }
}
