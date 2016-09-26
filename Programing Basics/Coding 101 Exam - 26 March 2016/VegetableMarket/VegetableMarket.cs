

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VegetableMarket
    {
        static void Main()
        {
            var vegiesKgPrice = double.Parse(Console.ReadLine());
            var fruitsKgPrice = double.Parse(Console.ReadLine());
            var kgVegies = int.Parse(Console.ReadLine());
            var kgFruits = int.Parse(Console.ReadLine());

            double vegiesCost = (double)vegiesKgPrice * kgVegies;
            double fruitsCost = (double)fruitsKgPrice * kgFruits;

            double totalCost = vegiesCost + fruitsCost;
            double result = totalCost / 1.94;
            Console.WriteLine(result);
        }
    }
}
