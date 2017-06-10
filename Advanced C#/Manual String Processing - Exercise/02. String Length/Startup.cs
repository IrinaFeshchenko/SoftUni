namespace _02.String_Length
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine().PadRight(20,'*').Substring(0,20);

            Console.WriteLine(input);
        }
    }
}
