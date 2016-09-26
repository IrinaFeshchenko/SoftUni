

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrcharPartOfTheAsciiTable
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int last = int.Parse(Console.ReadLine());

            for (int i = first; i <= last; i++)
            {
                Console.Write(((char)i).ToString()+" ");
            }
        }
    }
}
