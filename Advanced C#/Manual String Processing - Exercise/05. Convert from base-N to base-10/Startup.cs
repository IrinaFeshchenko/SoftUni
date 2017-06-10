namespace _05.Convert_from_base_N_to_base_10
{
    using System;
    using System.Numerics;

    public class Startup
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int nbase = int.Parse(tokens[0]);
            string number = tokens[1];

            Console.WriteLine(ToDecimal(nbase, number));
        }

        private static BigInteger ToDecimal(int nbase, string number)
        {
            BigInteger decimalNumber = 0;
            BigInteger power = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                decimalNumber += (number[i] - '0') * power;
                power = power * nbase;
            }

            return decimalNumber;
        }
    }
}


