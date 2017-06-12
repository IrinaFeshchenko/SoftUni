namespace _02.Vowel_Count
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = "[aeiouy]";

            int count = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            Console.WriteLine($"Vowels: {count}");
        }
    }
}
