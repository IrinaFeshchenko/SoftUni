namespace Opinion_Poll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(name, age);
                persons.Add(person);
            }
            var result = persons.Where(x => x.age > 30)
                                .OrderBy(x=>x.name);

            foreach (var person in result)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
