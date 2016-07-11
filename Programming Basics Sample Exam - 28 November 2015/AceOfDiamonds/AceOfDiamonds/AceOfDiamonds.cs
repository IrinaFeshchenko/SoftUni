

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('*', n));
            for (int i = 1; i <= n/2; i++)
            {
                Console.WriteLine("*{0}{1}{0}*",new string('-', n/2-i), new string('@', i*2-1));
            }
            for (int i = n/2-1; i >0; i--)
            {
                Console.WriteLine("*{0}{1}{0}*", new string('-', n / 2 - i), new string('@', i * 2 - 1));
            }
            Console.WriteLine(new string('*', n));
        }
    }
}
