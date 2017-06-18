namespace _09.List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            Predicate<int> isDivisible = CreateTester(dividers);

            List<int> result = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                if (isDivisible(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static Predicate<int> CreateTester(IEnumerable<int> dividers)
        {
            return x =>
            {
                foreach (var divider in dividers)
                {
                    if (x % divider != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> numbers, Predicate<T> isDivisible)
        {
            foreach (var number in numbers)
            {
                if (isDivisible(number))
                {
                    yield return number;
                }
            }
        }
    }
}
