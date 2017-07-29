using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{

    public class Startup
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "END")
                {
                    break;
                }

                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                var person = new Person(name, age, town);
                persons.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            try
            {
                if (!persons.Any(p => p.CompareTo(persons[n]) == 0))
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    int matches = persons.Where(p => p.CompareTo(persons[n]) == 0).Count();
                    int nonmatches = persons.Count - matches;
                    Console.WriteLine($"{matches} {nonmatches} {persons.Count}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
