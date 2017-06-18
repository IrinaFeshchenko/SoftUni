namespace _02.Knights_of_Honor
{
    using System;    using System.Collections.Generic;    public class Startup    {        public static void Main()        {            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printer = x => Console.WriteLine($"Sir {x}");

            foreach (var name in names)
            {
                printer(name);
            }
        }    }
}
