


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BabaTincheAirlines
    {
        static void Main()
        {
            long[] first = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
            long[] business = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
            long[] economy = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();

            decimal fTicketPrice = 7000;
            decimal bTicketPrice = 3500;
            decimal eTicketPprice = 1000;

            decimal firstClassProfit = Profit(first[0], first[1], first[2], fTicketPrice);
            decimal businessClassProfit = Profit(business[0], business[1], business[2], bTicketPrice);
            decimal economyClassProfit = Profit(economy[0], economy[1], economy[2], eTicketPprice);

            int flightProfit = (int)(firstClassProfit + businessClassProfit + economyClassProfit);

            decimal maxFirstClassProfit = Profit(12, 0, 12, fTicketPrice);
            decimal maxBusinessClassProfit = Profit(28,0, 28, bTicketPrice);
            decimal maxEconomyClassProfit = Profit(50,0, 50, eTicketPprice);

            int maxflightProfit = (int)(maxFirstClassProfit + maxBusinessClassProfit + maxEconomyClassProfit);

            Console.WriteLine(flightProfit);
            Console.WriteLine(maxflightProfit-flightProfit);
        }

        private static decimal Profit(long totalPassengers, long friquentFliers, long measPurchased,decimal ticketPrice)
        { 
            long standardPassengrs = totalPassengers - friquentFliers;
            decimal mealPrice = 0.005m * ticketPrice;

            decimal profitStandartTikets = standardPassengrs * ticketPrice;
            decimal profitFriquentFliers = (friquentFliers * ticketPrice)*0.3m;
            decimal profitMeals = measPurchased * mealPrice;

            decimal profit = profitStandartTikets + profitFriquentFliers + profitMeals;

            return profit;
        }
    }
}
