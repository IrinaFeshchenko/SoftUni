namespace _02.Upper_Strings
{
    using System;    using System.Linq;

    public class Startup    {        public static void Main()        {
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x=>x.ToUpper())
                                    .ToArray();

            Console.WriteLine(string.Join(" ", names));        }    }
}
