namespace JediDreams
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Method
    {
        public Method()
        {
            this.InternalMethods = new List<string>();
        }
        public string Name { get; set; }
        public List<string> InternalMethods { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Method> methods = new List<Method>();
            Method method = new Method();

            bool inMethod = false;

            for (int i = 0; i < n; i++)
            {
                string textLine = Console.ReadLine();

                Regex staticMethodRegex = new Regex($"static\\s+.+\\s+(\\w+)\\(");

                if (staticMethodRegex.IsMatch(textLine))
                {
                    if (inMethod)
                    {
                        method.InternalMethods = method.InternalMethods.OrderBy(x=>x).ToList();
                        methods.Add(method);
                    }

                    method = new Method();

                    method.Name = staticMethodRegex.Match(textLine).Groups[1].Value;

                    inMethod = true;
                }
                else if (inMethod)
                {
                    Regex internalMethodRegex = new Regex($"[^n][^e][^w]\\W+([A-Z]{{1}}\\w+)\\s*\\(");

                    var matches = internalMethodRegex.Matches(textLine);

                    foreach (Match item in matches)
                    {
                        string match = item.Groups[1].Value;
                        if (match != "for" && match != "" && match!= "while" && match != "switch")
                        {
                            method.InternalMethods.Add(match);
                        }
                    }
                }
            }
            method.InternalMethods = method.InternalMethods.OrderBy(x => x).ToList();
            methods.Add(method);

            var ordereddMethods = methods.OrderByDescending(x=>x.InternalMethods.Count).ThenBy(x=>x.Name);

            foreach (var m in ordereddMethods)
            {
                Console.WriteLine($"{m.Name} -> {m.InternalMethods.Count} -> {string.Join(", ",m.InternalMethods)}");
            }
        }

        static void Ind1_23(string[] args)
        {

        }
    }
}
