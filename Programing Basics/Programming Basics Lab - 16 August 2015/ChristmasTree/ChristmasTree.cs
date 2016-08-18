

namespace Namespace
{
    using System;

    class ChristmasTree
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < (n / 2) + 1; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('\'', n - i), new string('^', i * 2 + 1));
            }
            for (int i = 1; i < (n / 2) + 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('\'', n - i), new string('^', i * 2 + 1));
            }
            for (int i = 0; i < (n / 2) + 1; i++)
            {
                Console.WriteLine("{0}| |{0}", new string('\'', n - 1));
            }

            Console.WriteLine("{0}", new string('-', n*2 + 1));
        }
    }
}
