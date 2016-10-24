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
        public string Name { get; set; }
        public List<string> Methods{ get; set; }
    }

    public class Start
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = ReadInput(n);
            List<MethodInfo> methods = ExtractMethods(input);
            PrintResult(methods);
        }

        private static void PrintResult(List<MethodInfo> methods)
        {
            var orderedMethods = methods.OrderByDescending(x => x.Methods.Count).ThenBy(x=>x.Name);
            foreach (MethodInfo methodInfo in orderedMethods)
            {
                var orderedIntMethods = methodInfo.Methods.OrderBy(x => x);
                Console.WriteLine($"{methodInfo.Name} -> {methodInfo.Methods.Count} -> {string.Join(", ", orderedIntMethods)}");
            }
        }

        private static List<MethodInfo> ExtractMethods(string input)
        {
            string[] parts = input.Split(new string[] { "static" }, StringSplitOptions.RemoveEmptyEntries);
            List<MethodInfo> methods = new List<MethodInfo>();
            string pattern = @"([A-Z]\w*)\s*\(";

            foreach (var part in parts)
            {
                MethodInfo methodInfo = new MethodInfo();
                var matches = Regex.Matches(part, pattern);

                methodInfo.Name = matches[0].Groups[1].Value;
                for (int i = 1; i < matches.Count; i++)
                {
                    methodInfo.Methods.Add(matches[i].Groups[1].Value);
                }

                methods.Add(methodInfo);
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
