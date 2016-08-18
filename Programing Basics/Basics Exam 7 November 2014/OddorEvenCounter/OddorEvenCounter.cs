


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OddorEvenCounter
    {
        public delegate bool parity(long n);

        static void Main()
        {
            long sets = long.Parse(Console.ReadLine());
            long nums = long.Parse(Console.ReadLine());
            string s = Console.ReadLine().Trim();

            long[,] arr = new long[sets, nums];
            for (int i = 0; i < sets; i++)
            {
                for (int j = 0; j < nums; j++)
                {
                    arr[i, j] = long.Parse(Console.ReadLine());
                }
            }

            long maxCount = 0;
            long maxIndex = -1;
            parity odd = n => n % 2 != 0;
            parity even = n => n % 2 == 0;

            if (s == "odd")
            {
                FindMax(arr, sets, nums, out maxCount, out maxIndex, odd);
            }
            else if (s == "even")
            {
                FindMax(arr, sets, nums, out maxCount, out maxIndex, even);
            }

            if (maxCount==0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("{0} set has the most {1} numbers: {2}", DigitToWord((maxIndex + 1).ToString()), s, maxCount);

            }
        }

        private static void FindMax(long[,] arr, long sets, long nums, out long maxCount, out long maxIndex, parity parity)
        {
            maxCount = 0;
            maxIndex = -1;
            long currentCount = 0;
            for (int i = 0; i < sets; i++)
            {
                for (int j = 0; j < nums; j++)
                {
                    if (parity(arr[i, j]))
                    {
                        currentCount++;
                    }
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxIndex = i;
                }
                currentCount = 0;
            }
        }

        private static string DigitToWord(string digit)
        {
            switch (digit)
            {
                case "1": return "First";
                case "2": return "Second";
                case "3": return "Third";
                case "4": return "Fourth";
                case "5": return "Fifth";
                case "6": return "Sixth";
                case "7": return "Seventh";
                case "8": return "Eigth";
                case "9": return "Nineth";
                default: return "Tenth";
            }
        }
    }
}
