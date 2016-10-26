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
        public List<string> Methods{ get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = ReadInput(n);
            Dictionary<string,MethodInfo> methods = ExtractMethods(input);
            PrintResult(methods);
        }

        private static void PrintResult(Dictionary<string,MethodInfo> methods)
        {
            var orderedMethods = methods.OrderByDescending(x => x.Value.Methods.Count).ThenBy(x=>x.Key);
            foreach (var methodInfo in orderedMethods)
            {
                var orderedIntMethods = methodInfo.Value.Methods.OrderBy(x => x);
                Console.WriteLine($"{methodInfo.Key} -> {methodInfo.Value.Methods.Count} -> {string.Join(", ", orderedIntMethods)}");
            }
        }

        private static Dictionary<string,MethodInfo> ExtractMethods(string input)
        {
            string[] parts = input.Split(new string[] { "static" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string,MethodInfo> methods = new Dictionary<string, MethodInfo>();
            string pattern = @"([A-Za-z]*[A-Z]+[A-Za-z]*)\s*\(";

            foreach (var part in parts)
            {
                if (Regex.IsMatch(part,pattern))
                {
                    var matches = Regex.Matches(part, pattern);
                    string staticName = matches[0].Groups[1].Value;

                    if (!methods.ContainsKey(staticName))
                    {
                        methods.Add(staticName, new MethodInfo());
                    }

                    for (int i = 1; i < matches.Count; i++)
                    {
                        methods[staticName].Methods.Add(matches[i].Groups[1].Value);// ????????????????
                    }
                }
            }

            return methods;
        }

        private static string ReadInput(int n)
        {
            StringBuilder input = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                input.Append(Console.ReadLine());
            }
            return input.ToString();
        }
    }
}
