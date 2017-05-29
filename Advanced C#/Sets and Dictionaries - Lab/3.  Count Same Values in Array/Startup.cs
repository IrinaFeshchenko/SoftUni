namespace _3.Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            double[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToArray();

            SortedDictionary<double, int> dic = new SortedDictionary<double, int>();

            foreach (var n in nums)
            {
                if (!dic.ContainsKey(n))
                {
                    dic.Add(n,0);
                }

                dic[n]++;
            }

            foreach (var num in dic)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
