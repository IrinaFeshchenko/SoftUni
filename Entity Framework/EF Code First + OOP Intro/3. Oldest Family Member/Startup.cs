namespace _3.Oldest_Family_Member
{
    using _1.Define_a_class_Person;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter a number and then number of people Name and Age each on new line:");
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = args[0];
                int age = int.Parse(args[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine("\n result:");
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
