namespace QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            while (true)
            {
                Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                string input = Console.ReadLine().Trim();

                if (input=="END")
                    break;

                string[] pairs = input.Split(new[] { '&','?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in pairs)
                {
                    string[] args = pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    if (args.Count() == 2)
                    {
                        string key = args[0].Trim();
                        string value = args[1].Trim();

                        key = Regex.Replace(key, @"\+|%20", " ");
                        key = Regex.Replace(key, @"\s+", " ").Trim();
                        value = Regex.Replace(value, @"\+|%20", " ");
                        value = Regex.Replace(value, @"\s+", " ").Trim();
                        
                        if (!dic.ContainsKey(key))
                        {
                            dic.Add(key, new List<string>());
                        }

                        dic[key].Add(value); 
                    }
                }

                foreach (var key in dic)
                {
                    Console.Write($"{key.Key}=[{string.Join($", ", key.Value)}]");
                }
                Console.WriteLine();
            }
        }
    }
}
