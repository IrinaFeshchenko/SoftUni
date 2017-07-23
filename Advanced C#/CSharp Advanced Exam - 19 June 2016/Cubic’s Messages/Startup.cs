namespace Cubic_s_Messages
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Startup
    {
        static void Main()
        {
            Dictionary<string,string> validMessages = new Dictionary<string, string>();
            string message;
            while ((message = Console.ReadLine()).Trim() != "Over!")
            {
                int expectedLength = int.Parse(Console.ReadLine());

                string ValidMessagePattern = @"^\d*([A-Za-z]+)[^A-Za-z]*$";

                if (!Regex.IsMatch(message, ValidMessagePattern))
                {
                    continue;
                }

                string msg = Regex.Match(message, ValidMessagePattern).Groups[1].Value;

                if (msg.Length != expectedLength)
                {
                    continue;
                }

                List<char> result = new List<char>();

                foreach (var ch in message)
                {
                    if (char.IsDigit(ch))
                    {
                        int d = ch - '0';

                        if (d >= 0 && d < msg.Length)
                        {
                            result.Add(msg[d]);
                        }
                        else
                        {
                            result.Add(' ');
                        }
                    }
                }

                validMessages.Add(msg,string.Join("",result));
            }

            foreach (var item in validMessages)
            {
                Console.WriteLine($"{item.Key} == {item.Value}");
            }
        }
    }
}
