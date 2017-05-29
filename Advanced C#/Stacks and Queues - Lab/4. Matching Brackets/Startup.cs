
namespace _4.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            List<string> expressions = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i);
                }
                if (input[i]==')')
                {
                    int index = stack.Pop();

                    expressions.Add(input.Substring(index,i-index+1));
                }
            }

            foreach (var expression in expressions)
            {
                Console.WriteLine(expression);
            }
        }
    }
}
