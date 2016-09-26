

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HelloName
    {
        static void Main()
        {
            string name = Console.ReadLine();

            PrintName(name);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
