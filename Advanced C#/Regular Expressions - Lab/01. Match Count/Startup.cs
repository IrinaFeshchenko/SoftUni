namespace _01.Match_Count
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            int count = regex.Matches(text).Count;
            Console.WriteLine(count);
        }
    }
}
