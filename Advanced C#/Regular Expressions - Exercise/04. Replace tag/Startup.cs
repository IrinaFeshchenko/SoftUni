﻿namespace _04.Replace_tag
{
    using System;

    public class Startup
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                Regex regex = new Regex(@"<a href=(.*?)>(.*?)<\/a>");

                string result = regex.Replace(input, "[URL href=$1]$2[/URL]");

                Console.WriteLine(result);
            }
}