

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Gambling
    {
        static void Main()
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            string[] cards = Console.ReadLine().Split();

            Dictionary<char, long> cardValue = new Dictionary<char, long>();
            cardValue.Add('A', 14);
            cardValue.Add('K', 13);
            cardValue.Add('Q', 12);
            cardValue.Add('J', 11);
            List<string> c = new List<string>() { "A", "K", "Q", "J" };

            long houseStrength = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (!c.Contains(cards[i]))
                {
                    houseStrength += int.Parse(cards[i]);
                }
                else if (true)
                {
                    houseStrength += cardValue[char.Parse(cards[i])];
                }
            }

            decimal more = 0;
            decimal total = 0;
            for (int c1 = 2; c1 <= 14; c1++)
            {
                for (int c2 = 2; c2 <= 14; c2++)
                {
                    for (int c3 = 2; c3 <= 14; c3++)
                    {
                        for (int c4 = 2; c4 <= 14; c4++)
                        {
                            total++;
                            if (c1+c2+c3+c4 > houseStrength)
                            {
                                more++;
                            }
                        }
                    }
                }
            }

            decimal ratio = (more / total) * 100;          

            if (ratio<50)
            {
                Console.WriteLine("FOLD");
            }
            else
            {
                Console.WriteLine("DRAW");
            }

            decimal result = (cash * 2) * (more/total);
            Console.WriteLine("{0:f2}", result);
        }
    }
}
