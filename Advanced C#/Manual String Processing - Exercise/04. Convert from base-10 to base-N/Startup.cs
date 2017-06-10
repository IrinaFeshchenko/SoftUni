namespace _04.Convert_from_base_10_to_base_N
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine()
                                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int nbase = int.Parse(tokens[0]);
            BigInteger number = BigInteger.Parse(tokens[1]);

            Console.WriteLine(ToBaseN(nbase, number));
        }

        private static string ToBaseN(int nbase, BigInteger number)
        {
            Stack<char> result = new Stack<char>();

            while (number > 0)
            {
                var reminder = number % nbase;
                number /= nbase;
                result.Push((char)(reminder + 48));
            }

            return string.Join("", result).TrimStart('0');
        }
    }
}
