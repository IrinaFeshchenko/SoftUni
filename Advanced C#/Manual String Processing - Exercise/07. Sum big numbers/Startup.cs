namespace _07.Sum_big_numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            string sum = SumNumbers(firstNumber, secondNumber);

            Console.WriteLine(sum);
        }

        private static string SumNumbers(string firstNumber, string secondNumber)
        {
            Stack<long> result = new Stack<long>();
            int carry = 0;
            int index = 0;
            long length = Math.Max(firstNumber.Length, secondNumber.Length);

            while (index < length || carry != 0)
            {
                int n1 = index >= firstNumber.Length ? 0 : firstNumber[firstNumber.Length - 1 - index] - '0';
                int n2 = index >= secondNumber.Length ? 0 : secondNumber[secondNumber.Length - 1 - index] - '0';

                int sum = n1 + n2 + carry;

                if (sum > 9)
                {
                    long reminder = sum % 10;
                    result.Push(reminder);
                    carry = 1;
                }
                else
                {
                    result.Push(sum);
                    carry = 0;
                }

                index++;
            }

            return string.Join("", result).TrimStart('0');
        }
    }
}
