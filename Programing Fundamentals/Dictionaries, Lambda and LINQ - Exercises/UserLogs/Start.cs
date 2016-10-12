namespace UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> log = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] args = Console.ReadLine()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "end")
                {
                    break;
                }

                string ip = args[0].Replace("IP=", string.Empty);
                string user = args[2].Replace("user=", string.Empty);

                if (!log.ContainsKey(user))
                {
                    log.Add(user, new Dictionary<string, int>());
                }

                if (!log[user].ContainsKey(ip))
                {
                    log[user].Add(ip, 0);
                }

                log[user][ip]++;
            }

            foreach (var user in log)
            {
                Console.WriteLine($"{user.Key}:");
                string result = $"{string.Join(", ", user.Value.Select(x => $"{x.Key} => {x.Value}")) }.";
                Console.WriteLine(result);
            }
        }
    }
}
