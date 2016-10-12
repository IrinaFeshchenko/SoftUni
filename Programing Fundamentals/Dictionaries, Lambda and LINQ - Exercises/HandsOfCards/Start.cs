

namespace HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static Dictionary<string, int> powers = new Dictionary<string, int>()
        {
            { "2",2 },
            { "3",3 },
            { "4",4 },
            { "5",5 },
            { "6",6 },
            { "7",7 },
            { "8",8 },
            { "9",9 },
            { "10",10},
            { "J",11},
            { "Q",12},
            { "K",13},
            { "A",14},
        };

        static Dictionary<char, int> multiply = new Dictionary<char, int>()
        {
            { 'C',1 },
            { 'D',2 },
            { 'H',3 },
            { 'S',4 },
        };

        static void Main()
        {
            Dictionary<string, HashSet<string>> playersCards = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string[] args = Console.ReadLine()
                                       .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "JOKER") break;

                string name = args[0];
                string[] cards = args[1]
                                .Replace(",", string.Empty)
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!playersCards.ContainsKey(name))
                {
                    playersCards.Add(name, new HashSet<string>(cards));
                }
                else
                {
                    playersCards[name].UnionWith(new HashSet<string>(cards));
                }
            }

            foreach (var player in playersCards)
            {
                Console.WriteLine($"{player.Key}: {CadsPower(player.Value)}");
            }
        }

        private static int CadsPower(HashSet<string> value)
        {
            int cardsPower = value
                            .Select(CardPower)
                            .Sum();

            return cardsPower;
        }

        private static int CardPower(string card)
        {
            char suit = card[card.Length - 1];
            int multiplyer = multiply[suit];
            string value = card.Remove(card.Length - 1);
            int power = powers[value] * multiplyer;
            return power;
        }
    }
}
