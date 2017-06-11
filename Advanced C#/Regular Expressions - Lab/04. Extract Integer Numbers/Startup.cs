namespace _04.Extract_Integer_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main()
        {
            string text = "In 1519 Leonardo da Vinci died at the age of 67.";
            string pattern = "[0-9]+";

            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
