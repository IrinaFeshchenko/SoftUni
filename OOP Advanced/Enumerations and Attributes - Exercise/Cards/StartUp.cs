using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Cards
{
    public class StartUp
    {
        public static void Main()
        {
            //PrintCardSuit();
            //PrintCardRank();
            //PrintCardPower();
            //PrintCardCompareTo();
            //PrintAttribute();
            //PrintDeckOfCards();

            Game();
        }

        private static void Game()
        {
            Player first = new Player(Console.ReadLine());
            Player second = new Player(Console.ReadLine());

            while (first.CardsCount() < 5)
            {
                try
                {
                    first.AddCard(GetCard(first, second));
                }
                catch (InvalidOperationException io)
                {
                    Console.WriteLine(io.Message);
                }
            }

            while (second.CardsCount() < 5)
            {
                try
                {
                    second.AddCard(GetCard(first,second));
                }
                catch (InvalidOperationException io)
                {
                    Console.WriteLine(io.Message);
                }
            }
            int firstHighest = first.GetHighestCard().Power;
            int secondHighest = second.GetHighestCard().Power;
            Console.WriteLine(firstHighest > secondHighest ? first : second);
        }

        private static Card GetCard(Player first, Player second)
        {
            var args = Console.ReadLine().Split(' ');
            if (args.Length != 3)
            {
                throw new InvalidOperationException("No such card exists.");
            }
            string rank = args[0];
            string suit = args[2];

            Card card;
            try
            {
                card = new Card(rank, suit);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("No such card exists.");
            }
            if (first.ContainsCard(card)||second.ContainsCard(card))
            {
                throw new InvalidOperationException($"Card is not in the deck.");
            }
            return card;
        }

        private static void PrintDeckOfCards()
        {
            var deck = new List<Card>();

            foreach (var suit in Enum.GetNames(typeof(Suit)))
            {
                foreach (var rank in Enum.GetNames(typeof(Rank)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }

            foreach (var card in deck)
            {
                Console.WriteLine(card.Name);
            }
        }

        private static void PrintAttribute()
        {
            var input = Console.ReadLine();
            Type type = null;

            if (input == "Rank")
            {
                type = typeof(Rank);
                var attributes = type.GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }
            else
            {
                type = typeof(Suit);
                var attributes = type.GetCustomAttributes(false);
                Console.WriteLine(attributes[0]);
            }
        }

        private static void PrintCardCompareTo()
        {
            var first = ReadCard();
            var second = ReadCard();

            if (first.CompareTo(second) > 0)
            {
                Console.WriteLine(first);
            }
            else
            {
                Console.WriteLine(second);
            }
        }

        private static Card ReadCard()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            return new Card(rank, suit);
        }

        private static void PrintCardPower()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            var card = new Card(rank, suit);
            Console.WriteLine(card.ToString());
        }

        private static void PrintCardRank()
        {
            var input = Console.ReadLine();
            Console.WriteLine($"{input}:");

            foreach (var value in Enum.GetValues(typeof(Rank)))
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }

        public static void PrintCardSuit()
        {
            var input = Console.ReadLine();

            Console.WriteLine($"{input}:");

            foreach (var value in Enum.GetValues(typeof(Suit)))
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }
    }
}
