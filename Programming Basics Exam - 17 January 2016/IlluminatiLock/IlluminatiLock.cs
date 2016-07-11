

namespace Namespace
{
    using System;

    class ProgramIlluminatiLock
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int height = n + 1;
            int width = 3 * n;

            Console.WriteLine("{0}{1}{0}",new string('.',n), new string('#', n));
            for (int i = 0; i < n/2; i++)
            {
                string d1 = new string('.', n - (2 * (i+1)));
                string d2 = new string('.', 2 * i);
                string d3 = new string('.', n-2);
                Console.WriteLine("{0}##{1}#{2}#{1}##{0}", d1,d2,d3);
            }
            for (int i = (n / 2)-1; i >=0; i--)
            {
                string d1 = new string('.', n - (2 * (i + 1)));
                string d2 = new string('.', 2 * i);
                string d3 = new string('.', n - 2);
                Console.WriteLine("{0}##{1}#{2}#{1}##{0}", d1, d2, d3);
            }
            Console.WriteLine("{0}{1}{0}", new string('.', n), new string('#', n));
        }
    }
}
