namespace Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            char[] delimiters = " ,.?!".ToCharArray();
            string[] words = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            foreach (var word in words)
            {
                if (word.SequenceEqual(word.Reverse()))
                {
                    result.Add(word);
                }
            }
            result.Sort();

            Console.WriteLine(string.Join(", ", result.Distinct()));
        }
    }
}
