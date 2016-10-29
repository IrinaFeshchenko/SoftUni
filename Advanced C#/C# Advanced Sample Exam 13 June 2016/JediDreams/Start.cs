namespace JediDreams
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MethodInfo
    {
        public MethodInfo()
        {
            Methods = new List<string>();
        }
        public List<string> Methods { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input = ReadInput(n);
            Dictionary<string, MethodInfo> methods = ExtractMethods(input);
            PrintResult(methods);
        }

        private static void PrintResult(Dictionary<string, MethodInfo> methods)
        {
            var orderedMethods = methods.OrderByDescending(x => x.Value.Methods.Count).ThenBy(x => x.Key);
            foreach (var methodInfo in orderedMethods)
            {
                if (methodInfo.Value.Methods.Count != 0)
                {
                    var orderedIntMethods = methodInfo.Value.Methods.OrderBy(x => x);
                    Console.WriteLine($"{methodInfo.Key} -> {methodInfo.Value.Methods.Count} -> {string.Join(", ", orderedIntMethods)}");
                }
                else
                {
                    Console.WriteLine($"{methodInfo.Key} -> None");
                }
            }
        }

        public static Dictionary<string, MethodInfo> ExtractMethods(List<string> input)
        {
            Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();
            string mainPattern = @"static\s+.*?\s+([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(";
            string intPattern = @"([A-Za-z]*[A-Z]+[A-Za-z]*)\s*\(";

            string currentMethod = string.Empty;

            foreach (var line in input)
            {
                if (Regex.IsMatch(line, mainPattern))
                {
                    currentMethod = Regex.Match(line, mainPattern).Groups[1].Value;

                    if (!methods.ContainsKey(currentMethod))
                    {
                        methods.Add(currentMethod, new MethodInfo());
                    }
                }
                else if (Regex.IsMatch(line, intPattern) && currentMethod != string.Empty)
                {
                    var matches = Regex.Matches(line, intPattern);

                    foreach (Match match in matches)
                    {
                        methods[currentMethod].Methods.Add(match.Groups[1].Value);
                    }
                }
            }

            return methods;
        }

        private static List<string> ReadInput(int n)
        {
            List<string> input = new List<string>();
            for (int i = 0; i < n; i++)
            {
                input.Add(Console.ReadLine());
            }
            return input;
        }
    }
}
