namespace _01.Match_Full_Name
{
    using System;    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            Regex regex = new Regex(@"\b(([A-Z][a-z]+) ([A-Z][a-z]+))\b");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[1].Value);
                }
            }
        }    }
}
