namespace _01.Take_Two
{
    using System;    using System.Linq;

    public class Startup    {        public static void Main()        {            int[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .Where(x => x >= 10 && x <= 20)
                                    .Distinct()
                                    .Take(2)
                                    .ToArray();

            Console.WriteLine(string.Join(" ",nums));
        }    }
}
