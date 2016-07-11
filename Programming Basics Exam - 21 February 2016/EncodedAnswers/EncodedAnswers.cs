

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EncodedAnswers
    {
        static void Main()
        {
            Dictionary<int, char> toLetter = new Dictionary<int, char>()
            {
                { 0,'a'},
                { 1,'b'},
                { 2,'c'},
                { 3,'d'}
            };

            Dictionary<char, int> count = new Dictionary<char, int>()
            {
                {'a',0},
                {'b',0},
                {'c',0},
                {'d',0}
            };

            List<char> answers = new List<char>();
            int numberN = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberN; i++)
            {
                long reminder = (long.Parse(Console.ReadLine()) % 4);
                char answer = toLetter[(int)reminder];
                answers.Add(answer);
                count[answer]++;
            }

            Console.WriteLine(String.Join(" ", answers));

            Console.WriteLine("Answer A: {0}", count['a']);
            Console.WriteLine("Answer B: {0}", count['b']);
            Console.WriteLine("Answer C: {0}", count['c']);
            Console.WriteLine("Answer D: {0}", count['d']);
        }
    }
}
