namespace _05.Filter_by_Age
{
    using System;    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {            int linesCount = int.Parse(Console.ReadLine());            Dictionary<string, int> people = new Dictionary<string, int>();            for (int i = 0; i < linesCount; i++)
            {
                string[] input = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(name, age);
            }            string condition = Console.ReadLine();
            int ageBoundary = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> ageChecker = GetAgeChecker(condition,ageBoundary);
            Func<KeyValuePair<string,int>,string> printFormater = GetPrintFormater(format);

            PrintResult(people, ageChecker,printFormater);
        }

        private static void PrintResult(Dictionary<string, int> people, Func<int, bool> ageChecker, Func<KeyValuePair<string, int>, string> printFormater)
        {
            foreach (var person in people)
            {
                if (ageChecker(person.Value))
                {
                    string result = printFormater(person);
                    Console.WriteLine(result);
                }
            }
        }

        private static Func<KeyValuePair<string, int>,string> GetPrintFormater(string format)
        {
            if (format == "name age")
            {
                return x => $"{x.Key} - {x.Value}";
            }
            else if (format == "name")
            {
                return x => $"{x.Key}";
            }
            else if (format == "age")
            {
                return x => $"{x.Value}";
            }
            else
            {
                throw new ArgumentException("GetPrintFormater: argument not in a proper format");
            }
        }        public static Func<int,bool> GetAgeChecker(string condition,int ageBoundary)
        {
            if (condition == "younger")
            {
                return x => x < ageBoundary;
            }
            else if (condition == "older")
            {
                return x => x >= ageBoundary;
            }
            else
            {
                throw new ArgumentException("GetAgeChecker: condition not in a proper format");
            }
        }    }
}
