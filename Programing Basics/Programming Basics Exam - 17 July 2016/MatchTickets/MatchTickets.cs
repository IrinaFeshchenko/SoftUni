

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatchTickets
    {
        static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            decimal people = decimal.Parse(Console.ReadLine());
            decimal vip = 499.99m;
            decimal normal = 249.99m;

            if (people <=4)
            {
                budget *= 0.25m;
            }
            else if (people<=9)
            {
                budget *= 0.40m;
            }
            else if (people <= 24)
            {
                budget *= 0.50m;
            }
            else if (people <= 49)
            {
                budget *= 0.60m;
            }
            else if (people > 50)
            {
                budget *= 0.75m;
            }

            decimal categoryPrice = (category == "VIP") ? vip : normal;
            decimal ticketPrice = categoryPrice * people;

            if (budget>=ticketPrice)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.",Math.Abs(budget-ticketPrice));
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", Math.Abs(budget - ticketPrice));
            }
        }
    }
}
