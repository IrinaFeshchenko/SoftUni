namespace GameOfNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            int numberOfPlayers = int.Parse(Console.ReadLine());
            List<Player> players = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player();
                player.Name = Console.ReadLine();
                player.Points = int.Parse(Console.ReadLine());

                foreach (var letter in player.Name)
                {
                    if (letter%2 == 0)
                    {
                        player.Points += (int)letter;
                    }
                    else
                    {
                        player.Points -= (int)letter;
                    }
                }
                players.Add(player);
            }

            var winner = players.Where(p => p.Points == players.Select(x => x.Points).Max()).FirstOrDefault();

            Console.WriteLine($"The winner is {winner.Name} - {winner.Points} points");
        }
    }
}
