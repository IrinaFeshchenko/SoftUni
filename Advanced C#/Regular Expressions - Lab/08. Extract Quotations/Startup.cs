namespace _08.Extract_Quotations
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex regex = new Regex("('|\")(.*?)\\1");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
