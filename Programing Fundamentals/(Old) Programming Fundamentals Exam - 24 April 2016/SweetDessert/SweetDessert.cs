namespace SweetDessert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            decimal availableCash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal kgBerriesPrice = decimal.Parse(Console.ReadLine());

            // sets of portions
            int setOfPortions = (int)Math.Ceiling(guests / 6.0);

            // products for set of 6 portions
            int bananasPerSet = 2;
            int eggsPerSet = 4;
            decimal kgBerriesPerSet = 0.2m;

            //needed products
            int totalBananas = setOfPortions * bananasPerSet;
            int totalEggs = setOfPortions * eggsPerSet;
            decimal totalKgBerries = setOfPortions * kgBerriesPerSet;

            //money required
            decimal bananasCost = totalBananas * bananaPrice;
            decimal eggsCost = totalEggs * eggPrice;
            decimal berriesCost = totalKgBerries * kgBerriesPrice;
            decimal totalCost = bananasCost + eggsCost + berriesCost;

            decimal balance = availableCash - totalCost;
            if (balance>=0)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {Math.Abs(balance):f2}lv more.");
            }
        }
    }
}
