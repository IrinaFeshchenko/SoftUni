namespace _08.Multiply_big_number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            string bigNumber = Console.ReadLine();
            string smallNumber = Console.ReadLine();

            string product = MultiplyNumbers(bigNumber, smallNumber);

            Console.WriteLine(product);
        }

        private static string MultiplyNumbers(string n1, string n2)
        {
            // if one of the numbers is zero
            if ((n1.All(x => x == '0')) ||
               (n2 =="0"))
            {
                return "0";
            }

            Stack<int> result = new Stack<int>();
            int carry = 0;
            int index = 0;
            int length = n1.Length;

            while (index < length || carry != 0)
            {
                // if index is less than string lenght, get char on that position, else return zero
                int num1 = (index < length) ? (n1[n1.Length - 1 - index] - '0') : (0);
                int num2 = int.Parse(n2);

                int product = (num1 * num2) + carry;

                if (product < 10)
                {
                    carry = 0;
                    result.Push(product);
                }
                else
                {
                    int reminder = product % 10;
                    carry = product / 10;
                    result.Push(reminder);
                }

                index++;
            }

            return string.Join("",result).TrimStart('0');
        }
    }
}
