

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoundingNumbers
    {
        static void Main()
        {
            List<double> num = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 0; i < num.Count; i++)
            {
                int result=(int)Math.Round(num[i],MidpointRounding.AwayFromZero);

                Console.WriteLine($"{num[i]} => {result}");
            }
        }
    }
}
