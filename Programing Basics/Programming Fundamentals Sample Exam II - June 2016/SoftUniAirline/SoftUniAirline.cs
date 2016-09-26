

namespace Namespace
{
    using System;

    class SoftUniAirline
    {
        static void Main()
        {
            long numberOfFlights = long.Parse(Console.ReadLine());
            decimal[] profit = new decimal[numberOfFlights];
            decimal overalProfit = 0;

            for (int i = 0; i < numberOfFlights; i++)
            {
                long adultPassengersCount = long.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                long youthPassengersCount = long.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                long flightDuration = long.Parse(Console.ReadLine());

                decimal income = (adultPassengersCount * adultTicketPrice) +
                              (youthPassengersCount * youthTicketPrice);
                decimal expense = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;
                profit[i] = income - expense;
                overalProfit += profit[i];
            }

            for (int i = 0; i < numberOfFlights; i++)
            {
                if (profit[i]>=0)
                {
                    Console.WriteLine("You are ahead with {0:f3}$.", profit[i]);
                }
                else
                {
                    Console.WriteLine("We've got to sell more tickets! We've lost {0:f3}$.", profit[i]);
                }
            }

            Console.WriteLine("Overall profit -> {0:f3}$.",overalProfit);
            Console.WriteLine("Average profit -> {0:f3}$.",overalProfit/numberOfFlights);
        }
    }
}
