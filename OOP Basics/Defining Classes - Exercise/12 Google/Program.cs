namespace _12_Google
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "End") break;

                string personName = args[0];

                if (!persons.ContainsKey(personName))
                {
                    persons.Add(personName, new Person(personName));
                }

                string command = args[1];

                if (command == "company")
                {
                    var companyName = args[2];
                    var department = args[3];
                    var salary = decimal.Parse(args[4]);
                    persons[personName].company = new Company(companyName, department, salary);
                }
                else if (command == "pokemon")
                {
                    var pokemonName = args[2];
                    var pokemonType = args[3];
                    persons[personName].Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (command == "parents")
                {
                    var parentName = args[2];
                    var parentBirthday = args[3];
                    persons[personName].Parents.Add(new Parent(parentName, parentBirthday));
                }
                else if (command == "children")
                {
                    var childName = args[2];
                    var childBirthday = args[3];
                    persons[personName].Children.Add(new Child(childName, childBirthday));
                }
                else if (command == "car")
                {
                    var carName = args[2];
                    var carSpeed = int.Parse(args[3]);
                    persons[personName].Car = new Car(carName, carSpeed);
                }
            }

            string personToDisplay = Console.ReadLine();
            var p = persons[personToDisplay];

            Console.WriteLine(p.Name);

            Console.WriteLine("Company:");
            if (p.company != null)
            {
                Console.WriteLine($"{p.company.Name} {p.company.Department} {p.company.Salary:F2}");
            }

            Console.WriteLine("Car:");

            if (p.Car != null)
            {
                Console.WriteLine($"{p.Car.Model} {p.Car.Speed}");
            }

            Console.WriteLine("Pokemon:");
            foreach (var pmon in p.Pokemons)
            {
                Console.WriteLine($"{pmon.Name} {pmon.Type}");
            }

            Console.WriteLine("Parents:");
            foreach (var pers in p.Parents)
            {
                Console.WriteLine($"{pers.Name} {pers.birthday}");
            }

            Console.WriteLine("Children:");
            foreach (var c in p.Children)
            {
                Console.WriteLine($"{c.Name} {c.Birthday}");
            }
        }
    }
}
