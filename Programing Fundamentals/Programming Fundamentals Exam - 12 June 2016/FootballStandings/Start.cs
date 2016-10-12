

namespace FootballStandings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Team
    {
        public string Name { get; set; }
        public long Points { get; set; }
        public long Scored { get; set; }
    }

    class GameResult
    {
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }
        public long FirstTeamScored { get; set; }
        public long SecondTeamScored { get; set; }
    }

    class Start
    {
        static void Main()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string key = Console.ReadLine().Trim();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "final")
                {
                    break;
                }

                GameResult game = DecriptInput(key, input);

                RecordGameResults(game, teams);

            }

            PrintResult(teams);
        }

        private static void PrintResult(Dictionary<string, Team> teams)
        {
            var leagueStandings = teams.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Value.Name);

            Console.WriteLine("League standings:");
            long place = 0;
            foreach (var team in leagueStandings)
            {
                place++;
                Console.WriteLine($"{place}. {team.Value.Name.ToUpper()} {team.Value.Points}");
            }

            Console.WriteLine("Top 3 scored goals:");
            var topThreeScored = teams.OrderByDescending(x => x.Value.Scored).ThenBy(x => x.Value.Name).Take(3);
            foreach (var team in topThreeScored)
            {
                Console.WriteLine($"- {team.Value.Name} -> {team.Value.Scored}");
            }
        }

        private static void RecordGameResults(GameResult game, Dictionary<string, Team> teams)
        {
            if (!teams.ContainsKey(game.FirstTeam))
            {
                teams.Add(game.FirstTeam,
                    new Team { Name = game.FirstTeam, Points = 0, Scored = 0 });
            }

            if (!teams.ContainsKey(game.SecondTeam))
            {
                teams.Add(game.SecondTeam,
                    new Team { Name = game.SecondTeam, Points = 0, Scored = 0 });
            }

            teams[game.FirstTeam].Scored += game.FirstTeamScored;
            teams[game.SecondTeam].Scored += game.SecondTeamScored;

            if (game.FirstTeamScored == game.SecondTeamScored)
            {
                teams[game.FirstTeam].Points += 1;
                teams[game.SecondTeam].Points += 1;
            }
            else if (game.FirstTeamScored > game.SecondTeamScored)
            {
                teams[game.FirstTeam].Points += 3;
            }
            else if (game.FirstTeamScored < game.SecondTeamScored)
            {
                teams[game.SecondTeam].Points += 3;
            }
        }

        private static GameResult DecriptInput(string key, string input)
        {
            GameResult gameResult = new GameResult();

            Regex regex = new Regex(Regex.Escape(key) + @"([\w]*)" + Regex.Escape(key));
            var v = regex.Matches(input);

            gameResult.FirstTeam = string.Join("", v[0].ToString().Replace(key, "").ToUpper().Reverse());
            gameResult.SecondTeam = string.Join("", v[1].ToString().Replace(key, "").ToUpper().Reverse());

            string[] tokens = input.Split(' ');
            long[] goals = tokens[2].Split(':').Select(long.Parse).ToArray();
            gameResult.FirstTeamScored = goals[0];
            gameResult.SecondTeamScored = goals[1];
            return gameResult;
        }
    }
}
