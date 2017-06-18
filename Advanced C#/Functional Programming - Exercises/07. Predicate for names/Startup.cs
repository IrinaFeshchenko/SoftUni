namespace _07.Predicate_for_names
{
    using System;    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {
            int lengthRestriction = int.Parse(Console.ReadLine());            List<string> names = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            Predicate<string> isValid = x => x.Length <= lengthRestriction;

            Filter(names, isValid).ToList().ForEach(x => Console.WriteLine(x));
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> Condition)
        {
            foreach (var item in collection)
            {
                if (Condition(item))
                {
                    yield return item;
                }
            }
        }    }
}
