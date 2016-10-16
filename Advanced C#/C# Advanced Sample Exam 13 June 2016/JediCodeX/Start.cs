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
                text.AppendLine(inputLine);
            }

            string namePattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();

            int[] messagesIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Regex nameRegex = new Regex(Regex.Escape(namePattern) + @"([a-zA-Z]{" + namePattern.Length + @"})(?![a-zA-Z])");
            Regex messageRegex = new Regex(Regex.Escape(messagePattern) + @"([a-zA-Z0-9]{" + messagePattern.Length + @"})(?![a-zA-Z0-9])");

            List<string> jedis = new List<string>();
            List<string> messages = new List<string>();

            MatchCollection jediMatches = nameRegex.Matches(text.ToString());
            foreach (Match jediMatch in jediMatches)
            {
                jedis.Add(jediMatch.Groups[1].Value);
            }

            MatchCollection messageMatches = messageRegex.Matches(text.ToString());
            foreach (Match messageMatch in messageMatches)
            {
                messages.Add(messageMatch.Groups[1].Value);
            }

            List<string> output = new List<string>();

            int curentJediIndex = 0;

            for (int i = 0; i < messagesIndexes.Length; i++)
            {
                if (messagesIndexes[i]-1 < messages.Count)
                {
                    output.Add(string.Format("{0} - {1}", jedis[curentJediIndex], messages[messagesIndexes[i] - 1]));
                    curentJediIndex++;
                }

                if (curentJediIndex >= jedis.Count)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("\n", output));
        }
    }
}
