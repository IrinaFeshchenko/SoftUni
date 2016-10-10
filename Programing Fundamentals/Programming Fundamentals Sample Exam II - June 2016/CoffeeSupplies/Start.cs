namespace CoffeeSupplies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        public string Name { get; set; }
        public string DrinksCofee { get; set; }
        public long CupsDrinked { get; set; }
    }

    public class Coffee
    {
        public Coffee()
        {
            this.Persons = new HashSet<Person>();
        }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public HashSet<Person> Persons { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length != 2)
            {
                throw new Exception();
            }
            string personsDelimiter = args[0];
            string coffeesDelimiter = args[1];

            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Coffee> coffees = new Dictionary<string, Coffee>();

            ReadInput(persons, coffees, personsDelimiter, coffeesDelimiter);

            PrintOutOfCofee(coffees);

            ReadWeekInfo(persons, coffees);

            PrintEndOfWeekReport(persons, coffees);
        }

        private static void PrintOutOfCofee(Dictionary<string, Coffee> coffees)
        {
            var orderedCoffees = coffees.OrderByDescending(x => x.Value.Quantity);

            foreach (var cofee in orderedCoffees)
            {
                if (cofee.Value.Quantity <= 0)
                {
                    Console.WriteLine($"Out of {cofee.Value.Name}");
                }
            }
        }

        private static void PrintEndOfWeekReport(Dictionary<string, Person> persons, Dictionary<string, Coffee> coffees)
        {
            var orderedCoffees = coffees.OrderByDescending(x => x.Value.Quantity);

            Console.WriteLine($"Coffee Left:");

            foreach (var cofee in orderedCoffees)
            {
                if (cofee.Value.Quantity > 0)
                {
                    Console.WriteLine($"{cofee.Value.Name} {cofee.Value.Quantity}");
                }
            }

            Console.WriteLine($"For:");

            var cofiesInOrder = orderedCoffees.OrderBy(x => x.Value.Name);

            foreach (var cofee in cofiesInOrder)
            {
                if (cofee.Value.Quantity > 0)
                {
                    var orderedPersons = cofee.Value.Persons.OrderByDescending(x => x.Name);

                    foreach (var person in orderedPersons)
                    {
                        Console.WriteLine($"{person.Name} {cofee.Value.Name}");
                    }
                }
            }
        }

        private static void ReadWeekInfo(Dictionary<string, Person> persons, Dictionary<string, Coffee> coffees)
        {
            while (true)
            {
                string line = Console.ReadLine().Trim();

                if (line.ToLower() == "end of week") break;

                var chunks = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = chunks[0];
                long cofeesDrinked = long.Parse(chunks[1]);
                string cofeeName = persons[name].DrinksCofee;

                coffees[cofeeName].Quantity -= cofeesDrinked;

                if (coffees[cofeeName].Quantity <= 0)
                {
                    Console.WriteLine($"Out of {cofeeName}");
                }
            }
        }

        private static void ReadInput(Dictionary<string, Person> persons, Dictionary<string, Coffee> coffees, string personsDelimiter, string coffeesDelimiter)
        {
            while (true)
            {
                string line = Console.ReadLine().Trim();
                if (line.ToLower() == "end of info") break;

                if (line.Contains(personsDelimiter))
                {
                    var chunks = line.Split(new[] { personsDelimiter }, StringSplitOptions.RemoveEmptyEntries);
                    if (chunks.Length != 2)
                    {
                        throw new ArgumentException();
                    }
                    string personName = chunks[0];
                    string cofeeName = chunks[1];

                    persons.Add(personName, new Person() { Name = personName, DrinksCofee = cofeeName });

                    if (!coffees.ContainsKey(cofeeName))
                    {
                        coffees.Add(cofeeName, new Coffee() { Name = cofeeName, Quantity = 0 });
                    }
                    coffees[cofeeName].Persons.Add(persons[personName]);
                }

                else if (line.Contains(coffeesDelimiter))
                {
                    var chunks = line.Split(new[] { coffeesDelimiter }, StringSplitOptions.RemoveEmptyEntries);
                    string cofeeName = chunks[0];
                    long quantity = long.Parse(chunks[1]);

                    if (!coffees.ContainsKey(cofeeName))
                    {
                        coffees.Add(cofeeName, new Coffee() { Name = cofeeName, Quantity = quantity });
                    }
                    else
                    {
                        coffees[cofeeName].Quantity += quantity;
                    }
                }
            }
        }
    }
}
