namespace _01.Reverse_String
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            var watch = Stopwatch.StartNew();

            int len = sb.Length;
            char c;

            for (int i = 0; i < len/2; i++)
            {
                c = sb[i];
                sb[i] = sb[len - i-1];
                sb[len - i - 1]=c;
            }

            Console.WriteLine(sb);
            Console.WriteLine(watch.Elapsed);
        }
    }
}
