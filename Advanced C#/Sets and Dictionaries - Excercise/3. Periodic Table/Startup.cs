namespace _3.Periodic_Table
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var arg in args)
                {
                    chemElements.Add(arg);
                }
            }

            foreach (var element in chemElements)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
