

namespace Namespace
{
    using System;
 
    class SweetDessert
    {
        static void Main()
        {
            double cash = double.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice= double.Parse(Console.ReadLine());
            double berriesPrice = double.Parse(Console.ReadLine());

            double portions = Math.Ceiling(guests/6.00);

            double neededMoney = 2 * portions * bananasPrice +
                                 4 * portions * eggsPrice +
                                 0.2 * portions * berriesPrice;

            if (neededMoney <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.",neededMoney);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.",neededMoney - cash);
            }
        }
    }
}
