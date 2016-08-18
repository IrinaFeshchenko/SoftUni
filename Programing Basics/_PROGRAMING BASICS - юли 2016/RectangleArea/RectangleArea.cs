

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RectangleArea
    {
        static void Main()
        {
            var a = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', a));
            for (int i = 0; i < a-2; i++)
            {
                Console.WriteLine("*{0}*",new string(' ', a-2));
            }
            Console.WriteLine(new string('*', a));
        }
    }
}
