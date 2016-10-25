namespace RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class EventInfo
    {
        public EventInfo()
        {
            participants = new HashSet<string>();
        }
        public string eventName { get; set; }
        public HashSet<string> participants { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            Dictionary<string, EventInfo> events = new Dictionary<string, EventInfo>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Time for Code")
                {
                    break;
                }

                if (line == "" || line == null)
                {
                    continue;
                }

                if (!IsValidEvent(line))
                {
                    continue;
                }

                string[] args = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                string id = args[0];
                string eventName = args[1].TrimStart('#');

                List<string> participants = new List<string>();

                for (long i = 2; i < args.Count(); i++)
                {
                    if (args[i][0] == '@')
                    {
                        participants.Add(args[i].TrimStart('@'));
                    }
                }

                if (!events.ContainsKey(id))
                {
                    if (true)
                    {

                    }
                    events.Add(id, new EventInfo());
                    events[id].eventName = eventName;
                }

                if (events[id].eventName == eventName)
                {
                    foreach (var participant in participants)
                    {
                        events[id].participants.Add(participant);
                    }
                }
            }

            var sortedEvents = events
                                .OrderByDescending(x => x.Value.participants.Count())
                                .ThenBy(x => x.Value.eventName);

            foreach (var item in sortedEvents)
            {
                var sortedParticipants = item.Value.participants.OrderBy(x => x);

                Console.WriteLine($"{item.Value.eventName} - {item.Value.participants.Count}");

                foreach (var participant in sortedParticipants)
                {
                    Console.WriteLine("@" + participant);
                }
            }
        }

        private static bool IsValidEvent(string line)
        {
            bool isValidEvent = true;
            string[] args = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (args[1][0] != '#') 
            {
                isValidEvent = false;
            }

            if (!line.Contains('#'))
            {
                isValidEvent = false;
            }

            for (long i = 2; i < args.Count(); i++)
            {
                if (args[i][0] != '@')
                {
                    isValidEvent = false;
                }
                if (args[i].Where(x => x == '@').Count() > 1)
                {
                    isValidEvent = false;
                }
            }

            foreach (var ch in args[0])
            {
                if (!char.IsDigit(ch))
                {
                    isValidEvent = false;
                }
            }

            if (line.Where(x => x == '#').Count() > 1)
            {
                isValidEvent = false;
            }
            return isValidEvent;
        }
    }
}
