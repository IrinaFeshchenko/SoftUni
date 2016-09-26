

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Greeting
    {
        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string age = Console.ReadLine();

            Console.WriteLine($"Hello, {firstName} {lastName}. \r\nYou are {age} years old.");
        }
    }
}
