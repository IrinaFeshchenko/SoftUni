namespace ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            char[] separators = @" /\()".ToCharArray();

            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"^[A-Za-z]\w{2,24}$";


            int max = 0;
            int Maxsum = words[0].Length+words[1].Length;
            int sum = Maxsum;
            List<string> matches = new List<string>();

            foreach (var word in words)
            {
                if (Regex.IsMatch(word,pattern))
                {
                    matches.Add(word);
                }
            }

            for (int i = 1; i < matches.Count-1; i++)
            {
                sum = matches[i].Length + matches[i+1].Length;
                if (sum>Maxsum)
                {
                    Maxsum = sum;
                    max = i;
                }
            }

            Console.WriteLine(matches[max]);
            Console.WriteLine(matches[max+1]);
        }
    }
}
