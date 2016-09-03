

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VariableInHexadecimalFormat
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Before");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            int t = a;
            a = b;
            b = t;
            Console.WriteLine("After");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

        }
    }
}
