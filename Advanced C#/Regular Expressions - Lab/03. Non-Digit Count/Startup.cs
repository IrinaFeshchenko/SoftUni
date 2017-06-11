namespace _03.Non_Digit_Count
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main()
        {
            string text = "In 1519 Leonardo da Vinci died at the age of 67.";//Console.ReadLine();
            string pattern = "[^0-9]";

            int count = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;
            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
