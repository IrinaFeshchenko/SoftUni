

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Elevator
    {
        static void Main()
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int result = (int)Math.Ceiling((double)persons / capacity);

            Console.WriteLine(result);
        }
    }
}
