

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BiggestTriple
    {
        static void Main()
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int>maxSum = new List<int>();
            List<int> sum = new List<int>();

            for (int i = 0; i < num.Length; i++)
            {
                if (sum.Count == 3)
                {
                    if (sum.Sum() > maxSum.Sum())
                    {
                        maxSum = new List<int>( sum );
                    }
                    sum.Clear();
                    sum.Add(num[i]);
                }
                else
                {
                    sum.Add(num[i]);
                }
                if (i < 3)
                {
                    maxSum.Add(num[i]);
                }
            }

            if (sum.Sum() > maxSum.Sum())
            {
                maxSum = new List<int>(sum);
            }

            Console.WriteLine(string.Join(" ",maxSum));
        }
    }
}
