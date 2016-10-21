namespace MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Start
    {
        public static void Main()
        {
            string input = Console.ReadLine().Trim();

            if (input.All(x => x =='0'))
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }
            else
            {
                input = input.TrimStart('0');
            }

            char[] nums = input.ToCharArray();

            int n = int.Parse(Console.ReadLine().Trim());
            if (n==0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            string result = Multiply(nums, n);

            Console.WriteLine(result);
        }

        private static string Multiply(char[] nums, int n)
        {
            List<char> result = new List<char>();
            int carry = 0;

            for (int i = nums.Length -1; i >= 0 ; i--)
            {
                int num = (nums[i] - '0');
                int mult = (num * n) + carry;

                if (mult>9)
                {
                    result.Add((char)((mult%10)+'0'));
                    carry = mult / 10;
                }
                else
                {
                    result.Add((char)(mult + '0'));
                    carry = 0;
                }
            }

            if (carry>0)
            {
                result.Add((char)(carry+'0'));
            }

            result = result.ToArray().Reverse().ToList();
            return string.Join("",result);
        }
    }
}
