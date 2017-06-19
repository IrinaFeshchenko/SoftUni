namespace _03.First_Name
{
    using System;    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {            List<string> names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<char> letters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>char.Parse(x.ToLower())).ToList();

            var result = names.Where(x =>
            {
                foreach (var letter in letters)
                {
                    if (x.ToLower().First() == letter)
                    {
                        return true;
                    }
                }
                return false;
            })
            .OrderBy(x=>x)
            .ToList()
            .FirstOrDefault();

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(result);
            }
        }    }
}
