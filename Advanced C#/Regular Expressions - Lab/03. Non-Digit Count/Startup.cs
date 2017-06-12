namespace _03.Non_Digit_Count
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = "[^0-9]";

            int count = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
