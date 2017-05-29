namespace _2.Create_Person_Constructors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter: name, age or coma separated name and age:");
            string[] args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (args.Length == 1)
            {
                if (char.IsDigit(args[0][0]))
                {
                    Person person = new Person(int.Parse(args[0]));
                    Console.WriteLine($"name: {person.Name} age: {person.Age}");
                }
                else
                {
                    Person person = new Person(args[0]);
                    Console.WriteLine($"name: {person.Name} age: {person.Age}");
                }
            }
            else if (args.Length == 2)
            {
                Person person = new Person(args[0], int.Parse(args[1]));
                Console.WriteLine($"name: {person.Name} age: {person.Age}");
            }
        }
    }
}
