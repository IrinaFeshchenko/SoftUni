namespace ConvertFromBaseNToDecimal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int inputBase = int.Parse(args[0]);
            string inputNumber = args[1];

            var resultNumber = NToDecimal(inputNumber, inputBase);

            Console.WriteLine(resultNumber);
        }

        private static BigInteger NToDecimal(string number, int numBase)
        {
            BigInteger result = 0;
            BigInteger power = 1;

            for (int i = 0; i < number.Length; i++)
            {
                char digit = number[number.Length - 1 - i];
                result = result + hexDecVal[digit] * power;
                power = power * numBase;
            }

            return result;
        }

        private static Dictionary<char, int> hexDecVal = new Dictionary<char, int>
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15},
        };
    }
}
