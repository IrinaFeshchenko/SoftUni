namespace LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class User
        {
            public User()
            {
                this.Ip = new HashSet<string>();
            }
            public HashSet<string> Ip { get; set; }
            public int TotalTime { get; set; }
        }

        public static void Main()
        {
            SortedDictionary<string, User> log = new SortedDictionary<string, User>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ip = args[0];
                string user = args[1];
                int time = int.Parse(args[2]);

                if (!log.ContainsKey(user))
                {
                    log.Add(user, new User());
                }

                log[user].Ip.Add(ip);
                log[user].TotalTime += time;
            }

            foreach (var user in log)
            {
                Console.Write($"{user.Key}: ");
                Console.Write($"{user.Value.TotalTime} ");
                string ipList = string.Join(", ",user.Value.Ip.OrderBy(x=>x));
                Console.WriteLine($"[{ipList}]");
            }
        }
    }
}
