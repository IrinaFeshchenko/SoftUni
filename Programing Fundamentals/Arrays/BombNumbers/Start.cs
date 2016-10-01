

namespace BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            string[] args = Console.ReadLine().Split().ToArray();
            string digit = args[0];
            int power = int.Parse(args[1]);

            int index = -1;
            while ((index = numbers.IndexOf(digit)) != -1)
            {
                numbers = bombDigit(numbers,index,power);
            }

            int sum = numbers.Select(x => int.Parse(x)).Sum();
            Console.WriteLine(sum);
        }

        private static List<string> bombDigit(List<string> numbers, int index, int power)
        {
            int start = Math.Max(0,index-power);
            int end = Math.Min(numbers.Count -1, index+power);
            int count = (end - start) + 1;
            numbers.RemoveRange(start, count);

            return numbers;
        }
    }
}
