namespace _2.SoftUni_Party
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            SortedSet<string> guests = new SortedSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }

                guests.Add(input);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                guests.Remove(input);
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
