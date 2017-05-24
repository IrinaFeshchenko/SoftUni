
namespace _2.Simple_Calculator
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<int> digits = new Stack<int>();
            Stack<string> operators = new Stack<string>();

            foreach (var ch in input)
            {
                if (ch == "+")
                {
                    operators.Push(ch);
                }
                else if (ch == "-")
                {
                    operators.Push(ch);
                }
                else
                {
                    if (operators.Count != 0)
                    {
                        int num1 = digits.Pop();
                        int num2 = int.Parse(ch);

                        if (operators.Peek() == "+")
                        {
                            operators.Pop();
                            digits.Push(num1 + num2);
                        }
                        else
                        {
                            operators.Pop();
                            digits.Push(num1 - num2);
                        }
                    }
                    else
                    {
                        digits.Push(int.Parse(ch));
                    }
                }
            }

            Console.WriteLine(digits.Peek());
        }
    }
}
