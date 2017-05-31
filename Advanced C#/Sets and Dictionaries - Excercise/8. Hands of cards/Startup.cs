// You are given a sequence of people and for every person the cards he draws from the deck.The input will be separate lines in the format:
// {personName}: {PT, PT, PT,… PT}
// Where P(2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A) is the power of the card and T(S, H, D, C) is the type.The input ends when a "JOKER" is drawn.The name can contain any ASCII symbol except ':'. The input will always be valid and in the format described, there is no need to check it.
// A single person cannot have more than one card with the same power and type, if he draws such a card he discards it. The people are playing with multiple decks.Each card has a value that is calculated by the power multiplied by the type. Powers 2 to 10 have the same value and J to A are 11 to 14. Types are mapped to multipliers in the following way (S -> 4, H-> 3, D -> 2, C -> 1).
// Finally print out the total value each player has in his hand in the format: “{personName}: {value}”


namespace _8.Hands_of_cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> peopleCards = new Dictionary<string, HashSet<string>>();
            string input = string.Empty;

            Dictionary<char, int> cardsPower = new Dictionary<char, int>()
            {
                {'S',4},
                {'H',3},
                {'D',2},
                {'C',1}
            };

            Dictionary<string, int> cardsValue = new Dictionary<string, int>()
            {
                {"2",2},{"3",3},{"4",4},{"5",5},{"6",6},{"7",7},{"8",8},
                { "9",9},{"10",10},{"J",11},{"Q",12},{"K",13},{"A",14}
            };

            while ((input = Console.ReadLine()) != "JOKER")
            {
                string[] args = input.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();

                string name = args[0];
                string[] cards = args[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var setOfCards = new HashSet<string>(cards);

                if (!peopleCards.ContainsKey(name))
                {
                    peopleCards.Add(name, setOfCards);
                }
                else
                {
                    peopleCards[name].UnionWith(setOfCards);
                }
            }

            foreach (var person in peopleCards)
            {
                int totalPoints = 0;

                foreach (var card in person.Value)
                {
                    char type = card[card.Length - 1];
                    int power = cardsPower[type];

                    string num = card.Substring(0, card.Length - 1);
                    int value = cardsValue[num];

                    totalPoints += power * value;
                }

                Console.WriteLine($"{person.Key}: {totalPoints}");
            }
        }
    }
}
