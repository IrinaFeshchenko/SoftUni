namespace _05.Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {            IEnumerable<int> numbers = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            List<string> commands = new List<string>();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x=>x*2;
            Func<int, int> substract = x=>x-1;
            Action<IEnumerable<int>> printer = CreatePrinter();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;

                if (command == "add")
                {
                    numbers = Calculate(numbers,add);
                }
                else if (command == "subtract")
                {
                    numbers = Calculate(numbers,substract);
                }
                else if (command == "multiply")
                {
                    numbers = Calculate(numbers,multiply);
                }
                else if (command == "print")
                {
                    InvokePrint(numbers,printer);
                }
                else
                {
                    throw new ArgumentException("command not in the correct format");
                }
            }
        }

        private static IEnumerable<int> Calculate(IEnumerable<int> numbers, Func<int, int> math)
        {
            foreach (var number in numbers)
            {
                yield return math(number);
            }
        }

        private static void InvokePrint(IEnumerable<int> numbers, Action<IEnumerable<int>> printer)
        {
            printer(numbers);
        }

        private static Action<IEnumerable<int>> CreatePrinter()
        {
            return x => Console.WriteLine(string.Join(" ",x));
        }
    }
}
