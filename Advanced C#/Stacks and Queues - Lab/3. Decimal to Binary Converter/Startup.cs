
namespace _3.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (n==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (n>0)
                {
                    stack.Push(n % 2);
                    n /= 2;
                }
            }

            Console.WriteLine(string.Join("",stack));
        }
    }
}
