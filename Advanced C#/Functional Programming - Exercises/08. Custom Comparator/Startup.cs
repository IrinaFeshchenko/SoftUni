namespace _08.Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Array.Sort(numbers, (x, y) =>
            {
                if (IsEven(x) && !IsEven(y))
                {
                    return -1;
                }
                if (!IsEven(x) && IsEven(y))
                {
                    return 1;
                }
                if (x < y)
                {
                    return -1;
                }
                if (x > y)
                {
                    return 1;
                }
                return 0;
            });

            Console.WriteLine(string.Join(" ",numbers));
        }

        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
    }
}
