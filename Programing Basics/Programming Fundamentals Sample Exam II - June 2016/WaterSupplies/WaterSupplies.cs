

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WaterSupplies
    {
        static void Main()
        {
            decimal waterAmount = decimal.Parse(Console.ReadLine());
            decimal[] array = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            decimal bottleCappacity = decimal.Parse(Console.ReadLine());
            List<decimal> emptyBottles = new List<decimal>();

            if (waterAmount%2 == 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    waterAmount = waterAmount - (bottleCappacity - array[i]);
                    if (waterAmount < 0)
                    {
                        emptyBottles.Add(i);
                    }
                }
            }
            else
            {
                for (int i = array.Length-1; i >= 0; i--)
                {
                    waterAmount = waterAmount - (bottleCappacity - array[i]);
                    if (waterAmount < 0)
                    {
                        emptyBottles.Add(i);
                    }
                }
            }

            if (waterAmount<0)
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine("Bottles left: {0}", emptyBottles.Count);
                Console.WriteLine("With indexes: {0}", String.Join(", ",emptyBottles));
                Console.WriteLine("We need {0} more liters!", waterAmount*-1);

            }
            else
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine("Water left: {0}l.",waterAmount);
            }
        }
    }
}
