

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class IntegerToHexAndBinary
    {
        static void Main()
        {
            int i = int.Parse(Console.ReadLine());

            Console.WriteLine($"{i:X}");
            Console.WriteLine(Convert.ToString(i,2));
        }
    }
}
