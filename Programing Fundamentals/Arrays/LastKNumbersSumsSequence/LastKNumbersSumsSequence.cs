

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LastKNumbersSumsSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            List<long> seq = new List<long>();
            seq.Add(1);
            for (int i = 1; i < n; i++)
            {

                int from = Math.Max(0,i-k);
                int to = i;
                long sum = 0;
                for (int j = from; j <to; j++)
                {
                    sum += seq[j];
                }

                seq.Add(sum);
            }

            Console.WriteLine(string.Join(" ",seq));
        }
    }
}
