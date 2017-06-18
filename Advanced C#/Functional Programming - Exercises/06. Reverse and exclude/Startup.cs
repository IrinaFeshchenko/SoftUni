namespace _06.Reverse_and_exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IEnumerable<int> numbers = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % divider==0;
            
            var result = Filter(numbers, isDivisible);

            Console.WriteLine(string.Join(" ",result));
        }

        private static IEnumerable<int> Filter(IEnumerable<int> numbers, Predicate<int> isDivisible)
        {
            foreach (var number in numbers.Reverse())
            {
                if (!isDivisible(number))
                {
                    yield return number;
                }
            }
        }
    }
}
