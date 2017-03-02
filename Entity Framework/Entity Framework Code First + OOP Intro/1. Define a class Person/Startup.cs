namespace _1.Define_a_class_Person
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
            Person pesho = new Person("Pesho",23);
            Console.WriteLine($"name: {pesho.Name} age: {pesho.Age}");

            Person gosho = new Person("Gosho", 28);
            Console.WriteLine($"name: {gosho.Name} age: {gosho.Age}");

            Person stamat = new Person("Stamat", 18);
            Console.WriteLine($"name: {stamat.Name} age: {stamat.Age}");
        }
    }
}
