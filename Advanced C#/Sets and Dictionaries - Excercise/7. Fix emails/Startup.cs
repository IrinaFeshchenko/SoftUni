namespace _7.Fix_emails
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input.Trim();
                string email = Console.ReadLine().Trim();

                if (!email.EndsWith(".us", StringComparison.OrdinalIgnoreCase) &&
                    !email.EndsWith(".uk", StringComparison.OrdinalIgnoreCase))
                {
                    if (!emails.ContainsKey(name))
                    {
                        emails.Add(name, email);
                    }
                    else
                    {
                        emails[name] = email;
                    }
                }
            }

            foreach (var entry in emails)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
