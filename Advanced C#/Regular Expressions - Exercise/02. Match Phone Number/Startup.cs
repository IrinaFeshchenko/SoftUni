﻿namespace _02.Match_Phone_Number
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                var matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }
            }
}