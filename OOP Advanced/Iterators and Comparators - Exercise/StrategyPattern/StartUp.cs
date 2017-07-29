using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class Startup
    {
        public static void Main()
        {
            var persons1 = new SortedSet<Person>(new NameComparator());
            var persons2 = new SortedSet<Person>(new AgeComparator());

            int n = int.Parse(System.Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = System.Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(args[0],int.Parse(args[1]));

                persons1.Add(person);
                persons2.Add(person);
            }

            foreach (var person in persons1)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in persons2)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
