

namespace TrophonTheGrumpyCat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static int startIndexValue;
        static void Main()
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startIndex = int.Parse(Console.ReadLine());
            startIndexValue = num[startIndex];
            string itemType = Console.ReadLine();
            string priceRating = Console.ReadLine();


            int start = 0;
            int end = startIndex;
            long leftSum = CalculateSum(num, start, end, itemType, priceRating);

            start = startIndex + 1;
            end = num.Length;
            long rigtSum = CalculateSum(num, start, end, itemType, priceRating);

            if (leftSum >= rigtSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rigtSum}");
            }
        }

        private static long CalculateSum(int[] num, int start, int end, string itemType, string priceRating)
        {
            checked
            {
                long sum = 0;
                for (int i = start; i < end; i++)
                {
                    if (ConditionIsMet(num[i], itemType, priceRating))
                    {
                        sum += num[i];
                    }
                }
                return sum;
            }
        }

        private static bool ConditionIsMet(int digit, string itemType, string priceRating)
        {
            bool conditionIsMet = true;

            if ((itemType == "cheap") && (digit >= startIndexValue))
            {
                conditionIsMet = false;
            }
            else if ((itemType == "expensive") && (digit < startIndexValue))
            {
                conditionIsMet = false;
            }

            if ((priceRating == "positive") && (digit < 0))
            {
                conditionIsMet = false;
            }
            else if ((priceRating == "negative") && (digit > 0))
            {
                conditionIsMet = false;
            }
            return conditionIsMet;
        }
    }
}
