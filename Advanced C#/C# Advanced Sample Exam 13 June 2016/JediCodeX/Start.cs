namespace JediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                text.Append(inputLine);
            }

            string namePattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();

            Regex nameRegex = new Regex(Regex.Escape(namePattern) + @"([a-zA-Z]{" + namePattern.Length + @"})($|\W)");
            Regex messageRegex = new Regex(Regex.Escape(messagePattern) + @"([a-zA-Z0-9]{" + messagePattern.Length + @"})($|\W)");

            List<string> jedis = new List<string>();
            List<string> messages = new List<string>();

            MatchCollection jediMatches = nameRegex.Matches(text.ToString());
            foreach (Match jediMatch in jediMatches)
            {
                jedis.Add(jediMatch.Groups[1].Value);
            }
            jedis = jedis.Distinct().ToList();

            MatchCollection messageMatches = messageRegex.Matches(text.ToString());
            foreach (Match messageMatch in messageMatches)
            {
                messages.Add(messageMatch.Groups[1].Value);
            }

            List<string> output = new List<string>();

            int jedyIndex = 0;

            int[] messagesIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var index in messagesIndexes)
            {
                if (index >= 0 && index < messages.Count)
                {
                    output.Add(string.Format("{0} - {1}", jedis[jedyIndex++], messages[index]));
                }

                if (jedyIndex == jedis.Count)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("\n", output));
        }
    }
}
