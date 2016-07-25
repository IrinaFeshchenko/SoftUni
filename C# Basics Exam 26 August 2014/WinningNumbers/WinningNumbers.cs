

namespace Namespace
{
    using System;
    using System.Collections.Generic;

    class WinningNumbers
    {
        static void Main()
        {
            string s = Console.ReadLine().Trim();

            decimal chSum = 0;
            foreach (var ch in s)
            {
                chSum += char.IsUpper(ch) ? (ch - 'A' + 1) : (ch - 'a' + 1);
            }

            List<string> nums = new List<string>();
            for (decimal d1 = 0; d1 < 10; d1++)
            {
                for (decimal d2 = 0; d2 < 10; d2++)
                {
                    for (decimal d3 = 0; d3 < 10; d3++)
                    {
                        if (d1*d2*d3==chSum)
                        {
                            nums.Add(d1.ToString()+d2.ToString()+d3.ToString());
                        }
                    }
                }
            }

            if (nums.Count!=0)
            {
                foreach (var n1 in nums)
                {
                    foreach (var n2 in nums)
                    {
                        Console.WriteLine("{0}-{1}", n1, n2);
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
