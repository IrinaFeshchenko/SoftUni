namespace _6.A_miner_task
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
            SortedDictionary<string, string> emails = new SortedDictionary<string, string>();
            string input = string.Empty;

            while ((input = Console.ReadLine())!="stop")
            {
                string name = input;
                string email = Console.ReadLine();

                if (emails.ContainsKey(name))
                {
                    emails.Add(name,email);
                }
                else
                {

                }
            }
        }
    }
}
