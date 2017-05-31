namespace _11.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserInfo
    {
        public UserInfo()
        {
            this.Ip = new SortedSet<string>();
        }
        public int Duration { get; set; }
        public SortedSet<string> Ip { get; set; }
    }

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, UserInfo> users = new Dictionary<string, UserInfo>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = args[1];
                string ip = args[0];
                int duration = int.Parse(args[2]);

                if (!users.ContainsKey(name))
                {
                    users.Add(name, new UserInfo());
                }

                users[name].Duration += duration;
                users[name].Ip.Add(ip);
            }

            foreach (var user in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Duration} [{string.Join(", ", user.Value.Ip)}]");
            }
        }
    }
}
