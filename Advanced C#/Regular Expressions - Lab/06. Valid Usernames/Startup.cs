namespace _06.Valid_Usernames
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static void Main()
        {
            string input = string.Empty;
            Regex pattern = new Regex(@"^[a-zA-Z0-9@_]{3,16}$");

            while ((input = Console.ReadLine()) != "END")
            {
                if (pattern.IsMatch(input))
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
