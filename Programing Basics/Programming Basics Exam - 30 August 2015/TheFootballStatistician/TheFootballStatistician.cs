namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TheFootballStatistician
    {
        static void Main()
        {
            decimal amount = decimal.Parse(Console.ReadLine())*1.94m;

            Dictionary<string, long> teams = new Dictionary<string, long>();
            teams.Add("Arsenal",0);
            teams.Add("Chelsea", 0);
            teams.Add("Everton", 0);
            teams.Add("Liverpool", 0);
            teams.Add("ManchesterCity", 0);
            teams.Add("ManchesterUnited", 0);
            teams.Add("Southampton", 0);
            teams.Add("Tottenham", 0);
            decimal profit = 0;
            string command;
			
            while ((command = Console.ReadLine()) != "End of the league.")
            {
                string[] param = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string team1 = param[0];
                string team2 = param[2];
                string result = param[1];

                if (result == "X")
                {
                    teams[team1]++;
                    teams[team2]++;
                }
                else if (result == "1")
                {
                    teams[team1] += 3;
                }
                else if (result == "2")
                {
                    teams[team2] += 3;
                }

                profit += amount;
            }

            Console.WriteLine("{0:f2}lv.",profit);

            foreach (var team in teams)
            {
                string t = team.Key;
                if (team.Key == "ManchesterCity")
                {
                    t = "Manchester City";
                }
                if (team.Key == "ManchesterUnited")
                {
                    t = "Manchester United";
                }

                Console.WriteLine("{0} - {1} points.",t,team.Value);
            }
        }
    }
}
