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
                string pattern = @"^(\d+)([A-Za-z]{" + n + "})([^a-zA-Z]*)$";

                if (Regex.IsMatch(input, pattern))
                {
                    var match = Regex.Match(input, pattern);
                    var message = match.Groups[2].Value;
                    var part1 = match.Groups[1].Value;
                    var part2 = string.Join("",match.Groups[3].Value.Where(x=>char.IsDigit(x)));
                    var indexes = part1 + part2;
                    messages.Add(message);

                    string result = string.Empty;
                    foreach (var index in indexes.Select(x=>int.Parse(x.ToString())))
                    {
                        if (isValidIndex(index,message.Length))
                        {
                            result += message[index];
                        }
                        else
                        {
                            result += " ";
                        }
                    }

                    Console.WriteLine($"{message} == {result}");
                }
            }
        }

        private static bool isValidIndex(int index, int len)
        {
            bool isValidIndex = true;

            if (index<0 || index >= len )
            {
                isValidIndex = false;
            }

            return isValidIndex;
        }
    }
}
