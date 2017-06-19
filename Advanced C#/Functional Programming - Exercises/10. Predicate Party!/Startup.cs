namespace _10.Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Party!") break;

                Predicate<string> test = CreateTester(args);
                names = Filter(names, test, args[0]).ToList();
            }

            if (names.Count>0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static IEnumerable<string> Filter(List<string> names, Predicate<string> test, string command)
        {
            if (command == "Double")
            {
                List<string> doubled = new List<string>();

                foreach (var name in names)
                {
                    if (test(name))
                    {
                        doubled.Add(name);
                    }
                }

                names.AddRange(doubled);
            }
            else if (command == "Remove")
            {
                names.RemoveAll(x => test(x));
            }
            else
            {
                throw new ArgumentException("command not in the correct format");
            }

            return names;
        }

        private static Predicate<string> CreateTester(string[] args)
        {

            if (args[1] == "StartsWith")
            {
                return x => x.StartsWith(args[2]);
            }
            else if (args[1] == "EndsWith")
            {
                return x => x.EndsWith(args[2]);
            }
            else if (args[1] == "Length")
            {
                return x => x.Length == int.Parse(args[2]);
            }
            return null;
        }
    }
}
