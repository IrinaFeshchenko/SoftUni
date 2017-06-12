namespace _04.Extract_Integer_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = "[0-9]+";

            var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
