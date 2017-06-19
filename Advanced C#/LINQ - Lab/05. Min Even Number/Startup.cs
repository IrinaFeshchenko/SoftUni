namespace _05.Min_Even_Number
{
    using System;    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {            var numbers = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse)
                                        .Where(x=>x%2==0);
            if (numbers.Count() > 0)
            {
                Console.WriteLine($"{numbers.Min():f2}");
            }            else
            {
                Console.WriteLine("No match");
            }        }    }
}
