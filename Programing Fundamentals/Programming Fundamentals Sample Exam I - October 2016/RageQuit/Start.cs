namespace RageQuit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            string input = Console.ReadLine().ToUpper();

            string pattern = @"(.+?)(\d+)";
            var matches = Regex.Matches(input, pattern);
            StringBuilder message = new StringBuilder();

            foreach (Match match in matches)
            {
                string text = match.Groups[1].Value;
                int repeat = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeat; i++)
                {
                    message.Append(text);
                }
            }

            Console.WriteLine($"Unique symbols used: {message.ToString().Distinct().Count()}");
            Console.WriteLine(message);
        }
    }
}
