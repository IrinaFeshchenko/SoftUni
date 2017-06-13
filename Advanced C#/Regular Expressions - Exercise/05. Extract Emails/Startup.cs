namespace _05.Extract_Emails
{
    using System;    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            string input = Console.ReadLine();

            Regex regex = new Regex(@"(?<=^| )[a-z0-9]+\.*?-*?_*?[a-z0-9]+@[a-z]+-*?[a-z]+(\.[a-z]+-*?[a-z])+");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }    }
}
