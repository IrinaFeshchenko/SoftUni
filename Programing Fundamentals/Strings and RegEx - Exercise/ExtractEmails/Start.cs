namespace ExtractEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            string s = Console.ReadLine();

            string email = @"(?:^|""|\s)([A-Za-z0-9][\w\.-]*\w@\w[\w\-\.]*\w\.\w[\w\-\.]*\w)";

            var matches = Regex.Matches(s,email);

            foreach (Match match in matches)
            {
                if (match.Groups[1].Value != "")
                {
                    Console.WriteLine(match.Groups[1].Value);
                }
            }
        }
    }
}
