
namespace _1.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            Console.WriteLine(string.Join("",stack));
        }
    }
}
