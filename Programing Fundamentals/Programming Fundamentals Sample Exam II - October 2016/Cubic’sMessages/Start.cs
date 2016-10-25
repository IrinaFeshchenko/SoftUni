namespace CubicsMessages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            List<string> messages = new List<string>();
            string input;

            while ((input = Console.ReadLine()) != "Over!")
            {
                int n = int.Parse(Console.ReadLine());
                string pattern = $"^\\d+([A-Za-z]{{{n}}})[^A-Za-z]";

                if (Regex.IsMatch(input, pattern))
                {
                    var message = Regex.Match(input,pattern).Groups[1].Value;
                    messages.Add(message);
                }
            }

            ;
        }
    }
}
