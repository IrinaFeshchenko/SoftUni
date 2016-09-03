

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseAnArrayOfIntegers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            arr = arr.Reverse().ToArray();
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
