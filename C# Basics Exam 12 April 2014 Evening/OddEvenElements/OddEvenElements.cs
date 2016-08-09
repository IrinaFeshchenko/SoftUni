

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class evenoddElements
    {
        private static int inputLenght;

        public static void Main()
        {
            decimal oddSum = 0;
            decimal oddMin = decimal.MaxValue;
            decimal oddMax = decimal.MinValue;
            decimal evenSum = 0;
            decimal evenMin = decimal.MaxValue;
            decimal evenMax = decimal.MinValue;
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                decimal[] num = input.Split().Select(decimal.Parse).ToArray();
                inputLenght = num.Length;

                bool odd = false;
                for (int i = 0; i < num.Length; i++, odd=!odd)
                {
                    decimal currentNumber = num[i];
                    if (odd)
                    {
                        evenSum += num[i];
                        evenMax = Math.Max(currentNumber,evenMax);
                        evenMin = Math.Min(currentNumber, evenMin);
                    }
                    else
                    {
                        oddSum += num[i];
                        oddMin = Math.Min(currentNumber,oddMin);
                        oddMax = Math.Max(currentNumber, oddMax);
                    }
                }
            }

            Console.WriteLine("OddSum={3}, OddMin={4}, OddMax={5}, EvenSum={0:}, EvenMin={1}, EvenMax={2}",
                GetEven(evenSum), GetEven(evenMin), GetEven(evenMax), GetOdd(oddSum), GetOdd(oddMin), GetOdd(oddMax));
        }

        private static string GetEven(decimal number )
        {
            return (inputLenght < 2) ? "No" : number.ToString("0.##########");
        }
        private static string GetOdd( decimal number )
        {
            return (inputLenght < 1) ? "No" : number.ToString("0.##########");
        }
    }
}
