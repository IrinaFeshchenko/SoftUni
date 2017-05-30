
namespace _5.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(123);
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

            while ((command = Console.ReadLine()) != "stop")
            {
                string name = command;

                if (phonebook.ContainsKey(name))
                {
                    //Console.WriteLine($"{name.key} -> {name.value}");
                }
                else
	            {
                    Console.WriteLine("Contact simo does not exist.");
	            }

            }
        }
    }
}
