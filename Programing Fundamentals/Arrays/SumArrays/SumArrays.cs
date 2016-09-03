

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumArrays
    {
        static void Main()
        {
            List<int> arr1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> arr2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int lenght = Math.Max(arr1.Count, arr2.Count);
            for (int i = 0; i <lenght ; i++)
            {
                int i1 = i;
                int i2 = i;

                if (i1>=arr1.Count)
                {
                    i1 %= arr1.Count;
                }

                if (i2 >= arr2.Count)
                {
                    i2 %= arr2.Count;
                }

                result.Add(arr1[i1]+arr2[i2]);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
