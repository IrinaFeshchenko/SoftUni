

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EmployeeData
    {
        static void Main()
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long id = long.Parse(Console.ReadLine());
            long uen = long.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {fName}");
            Console.WriteLine($"Last name: {lName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {id}");
            Console.WriteLine($"Unique Employee number: {uen}");
        }
    }
}
