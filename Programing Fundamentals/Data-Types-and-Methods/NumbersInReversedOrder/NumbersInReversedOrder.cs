

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NumbersInReversedOrder
    {
        static void Main()
        {
            string s = Console.ReadLine();

            s = string.Join("",s.ToArray().Reverse());

            Console.WriteLine(s);
        }
    }
}
