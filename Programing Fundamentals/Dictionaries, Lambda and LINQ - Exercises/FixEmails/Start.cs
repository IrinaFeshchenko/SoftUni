

namespace FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            Dictionary<string, string> userData = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "stop") break;

                string email = Console.ReadLine();
                string domain = email.Split('.')[1];

                if (domain == "us" || domain == "uk")
                {
                    continue;
                }

                if (!userData.ContainsKey(name))
                {
                    userData.Add(name, email);
                }
                else
                {
                    userData[name] = email;
                }
            }

            foreach (var item in userData)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
