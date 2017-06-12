namespace _07.Valid_Time
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine())!="END")
            {
                Regex regex = new Regex(@"^((([0][0-9]|[1][0-2]):[0-5][0-9]:[0-5][0-9] [AP]M)|12:00:00 [PA]M)$");
                Match match= regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
