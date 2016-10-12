

namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                string command = input[0];
                string name = input[1];              

                if (command == "A")
                {
                    string number = input[2];

                    if (!phoneBook.ContainsKey(name))
                    {
                        phoneBook.Add(name, number);
                    }
                    else
                    {
                        phoneBook[name] = number;
                    }
                }
                else if (command == "S")
                {
                    if (phoneBook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phoneBook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
            }
        }
    }
}
