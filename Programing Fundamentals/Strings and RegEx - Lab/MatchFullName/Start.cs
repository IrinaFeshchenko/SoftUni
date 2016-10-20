namespace MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            string names = Console.ReadLine();

            Regex nameRegex = new Regex($"\\b([A-Z]{{1}}[a-z]+\\s[A-Z]{{1}}[a-z]+)\\b");

            var match = nameRegex.Match(names);

            Console.WriteLine(match);
        }
    }
}
