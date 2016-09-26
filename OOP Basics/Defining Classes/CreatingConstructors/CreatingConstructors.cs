

namespace Namespace
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Person
    {
        private string name;
        private int age;
        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public string Name => this.name;

        public int Age => this.age;
    }

    class CreatingConstructors
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine( ));
            var persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {

                var param = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = param[0];
                int age = int.Parse( param[1]);

                Person somePerson = new Person(age,name);
                persons.Add(somePerson);
            }

            persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}