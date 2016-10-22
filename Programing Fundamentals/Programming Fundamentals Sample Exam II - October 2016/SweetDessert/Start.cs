namespace SweetDessert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            decimal guests = decimal.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal berryPrice = decimal.Parse(Console.ReadLine());

            long portionSets = (long)Math.Floor(guests / 6m);
            if (guests%6!=0)
            {
                portionSets++;
            }

            decimal totalPrice = (portionSets*2 * bananaPrice) + (portionSets*4 * eggPrice) + (portionSets* 0.2m * berryPrice);

            decimal balance = cash - totalPrice;

            if (balance>=0)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {Math.Abs(balance):f2}lv more.");
            }
        }
    }
}
