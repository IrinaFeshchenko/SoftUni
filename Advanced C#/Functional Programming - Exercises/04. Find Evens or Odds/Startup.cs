namespace _04.Find_Evens_or_Odds
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            string evenOrOdd = Console.ReadLine();

            Predicate<int> tester = TesterCreator(evenOrOdd);

            InvokePrint(numbers,tester);
        }

        private static void InvokePrint(int[] numbers, Predicate<int> tester)
        {
            List<int> result = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (tester(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }

        private static Predicate<int> TesterCreator(string evenOrOdd)
        {
            if (evenOrOdd == "even")
            {
                return x => x % 2 == 0;
            }
            else if (evenOrOdd == "odd")
            {
                return x => x % 2 != 0;
            }
            else
            {
                throw new ArgumentException("FilterCreator: argument format error");
            }
        }
    }
}
