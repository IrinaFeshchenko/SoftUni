// Given a sequence consisting of parentheses, determine whether the expression is balanced.A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closed parenthesis that occurs after the former.Also, the interval between them must be balanced.You will be given three types of parentheses: (, {, and[.
// {[()]} - This is a balanced parenthesis.
// {[(])} - This is not a balanced parenthesis.
// Input Format: Each input consists of a single line, S, the sequence of parentheses.
// Constraints: 
// 1 ≤ lens ≤ 1000, where lens is the length of the sequence.
// Each character of the sequence will be one of {, }, (, ), [,].
// Output Format: For each test case, print on a new line "YES" if the parentheses are balanced.Otherwise, print "NO". Do not print the quotes.

namespace _7.Balanced_Parentheses
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static char[] openParentheses = new[] { '{', '(', '[' };
        static Dictionary<char, char> coresponding = new Dictionary<char, char>()
        {
            {'}','{' },
            {')','(' },
            {']','[' }
        };

        static Stack<char> stack = new Stack<char>();

        static void Main()
        {
            string parentheses = Console.ReadLine().Replace(" ","");
            bool result = true;

            foreach (var parenthes in parentheses)
            {
                if (IsOpeningParentheses(parenthes))
                {
                    stack.Push(parenthes);
                }
                else
                {
                    if (IsProperClosingParentheses(parenthes))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (NotAllParenthesesAreClosed())
            {
                result = false;
            }

            Console.WriteLine(result?"YES":"NO");        
        }

        private static bool NotAllParenthesesAreClosed()
        {
            return stack.Count > 0;
        }

        private static bool IsProperClosingParentheses(char parenthes)
        {
            if (stack.Count==0)
            {
                return false;
            }

            return coresponding[parenthes] == stack.Peek();
        }

        static bool IsOpeningParentheses(char input)
        {
            foreach (var parenthes in openParentheses)
            {
                if (input == parenthes)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
