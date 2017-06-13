namespace _04.Replace_tag
{
    using System;    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;

                Regex regex = new Regex(@"<a href=(.*?)>(.*?)<\/a>");

                string result = regex.Replace(input, "[URL href=$1]$2[/URL]");

                Console.WriteLine(result);
            }        }    }
}
