namespace _03.Series_of_Letters
{
    using System;    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            string input = Console.ReadLine();

            Regex regex = new Regex(@"([A-Za-z])\1+");

            string result = regex.Replace(input, "$1");

            Console.WriteLine(result);
        }    }
}
