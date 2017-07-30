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
            //CardSuit();
            //CardRank();
            //CardPower();
            CardCompareTo();
        }

        private static void CardCompareTo()
        {
            var first = ReadCard();
            var second = ReadCard();

            if (first.CompareTo(second)>0)
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

        private static void CardPower()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            var card = new Card(rank,suit);
            Console.WriteLine(card.ToString());
        }

        private static void CardRank()
        {
            var input = Console.ReadLine();
            Console.WriteLine($"{input}:");

            foreach (var value in Enum.GetValues(typeof(Rank)))
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }

        public static void CardSuit()
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
