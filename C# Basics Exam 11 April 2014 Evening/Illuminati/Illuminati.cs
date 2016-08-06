

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Illuminati
    {
        static void Main()
        {
            string input = Console.ReadLine().ToUpper() ;

            int sum = 0;
            int count = 0;
            foreach (var ch in input)
            {
                if (ch=='A'||ch=='E' || ch == 'I' || ch == 'O' || ch == 'U')
                {
                    sum += ch;
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}
