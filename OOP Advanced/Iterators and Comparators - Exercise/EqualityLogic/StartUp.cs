using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EqualityLogic
{
    public class Startup
    {
        public static void Main()
        {
            SortedSet<Person> sortedPersons = new SortedSet<Person>();
            HashSet<Person> hashedPersons = new HashSet<Person>();

            int n = int.Parse(System.Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = System.Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(args[0], int.Parse(args[1]));

                if (!sortedPersons.Any(p=>p.Equals(person)))
                {
                    sortedPersons.Add(person);
                }
                hashedPersons.Add(person);
            }

            Console.WriteLine(sortedPersons.Count);
            Console.WriteLine(hashedPersons.Count);
        }
    }
}
