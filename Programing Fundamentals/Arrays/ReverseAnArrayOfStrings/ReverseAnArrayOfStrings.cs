

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseAnArrayOfStrings
    {
        static void Main()
        {
            List<string> array = Console.ReadLine().Split().ToList();

            array.Reverse();

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
