namespace SumBigNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            char[] n1 = Console.ReadLine().Trim().ToArray();
            char[] n2 = Console.ReadLine().Trim().ToArray();

            string sum = Sum(n1, n2);

            Console.WriteLine(sum);
        }

        private static string Sum(char[] n1, char[] n2)
        {
            n1 = n1.Reverse().ToArray();
            n2 = n2.Reverse().ToArray();
            long lenght = Math.Max(n1.Length, n2.Length);
            List<char> result = new List<char>();
            long carry = 0;

            for (long i = 0; i < lenght|| carry!=0; i++)
            {
                long num1 = i < n1.Length ? n1[i] - '0' : 0;
                long num2 = i < n2.Length ? n2[i] - '0' : 0;
                long sum = num1 + num2 + carry;

                if (sum > 9)
                {
                    result.Add((char)((sum % 10 ) + '0') );
                    carry = 1;
                }
                else
                {
                    result.Add((char)(sum + '0'));
                    carry = 0;
                }
            }
            result = result.ToArray().Reverse().ToList();
            return string.Join("", result).TrimStart('0');
        }
    }
}
