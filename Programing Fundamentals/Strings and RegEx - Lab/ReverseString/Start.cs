namespace ReverseString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = string.Join("",input.ToArray().Reverse());
            Console.WriteLine(result);
        }
    }
}
