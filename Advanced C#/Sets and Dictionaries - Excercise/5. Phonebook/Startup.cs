namespace _5.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main()
        {
            Console.WriteLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string command = string.Empty;

            while ((command = Console.ReadLine())!="search")
            {
                string[] args = command.Split('-');
                string name = args[0];
                string telNum = args[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name,telNum);
                }
                else
                {
                    phonebook[name] = telNum;
                }
            }

            List<string> result = new List<string>();

            while ((command = Console.ReadLine()) != "stop")
            {
                string name = command;

                if (phonebook.ContainsKey(name))
                {
                    result.Add($"{name} -> {phonebook[name]}");
                }
                else
	            {
                    result.Add($"Contact {name} does not exist.");
	            }
            }

            foreach (var entry in result)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
