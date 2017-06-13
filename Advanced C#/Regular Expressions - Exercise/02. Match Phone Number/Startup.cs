namespace _02.Match_Phone_Number
{
    using System;    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            Regex regex = new Regex(@"^ *\+359( |-)[\d]\1[\d]{3}\1[\d]{4}\b");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }
            }        }    }
}
