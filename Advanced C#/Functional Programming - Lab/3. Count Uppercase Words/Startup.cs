namespace _3.Count_Uppercase_Words
{
    using System;    using System.Linq;

    public class Startup    {        public static void Main()        {            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            words.Where(x => char.IsUpper(x.First()))
                            .ToList()
                            .ForEach(x => Console.WriteLine(x));
        }    }
}
