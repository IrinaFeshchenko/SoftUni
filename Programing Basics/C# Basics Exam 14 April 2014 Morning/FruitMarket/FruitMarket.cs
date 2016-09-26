

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FruitMarket
    {
        static void Main()
        {
            List<string> fruits = new List<string>();
            fruits.Add("banana");
            fruits.Add("orange");
            fruits.Add("apple");

            Dictionary<string, decimal> price = new Dictionary<string, decimal>();
            price.Add("banana",1.80m);
            price.Add("cucumber", 2.75m);
            price.Add("tomato", 3.20m);
            price.Add("orange", 1.60m);
            price.Add("apple", 0.86m);
            string day = Console.ReadLine();

            decimal c1 = decimal.Parse(Console.ReadLine());
            string f1 = Console.ReadLine();
            decimal price1 = c1 * price[f1];

            decimal c2 = decimal.Parse(Console.ReadLine());
            string f2 = Console.ReadLine();
            decimal price2 = c2 * price[f2];

            decimal c3 = decimal.Parse(Console.ReadLine());
            string f3 = Console.ReadLine();
            decimal price3 = c3 * price[f3];



            if (day == "Friday")
            {
                price1 *= 0.9m;
                price2 *= 0.9m;
                price3 *= 0.9m;
            }
            else if (day == "Sunday")
            {
                price1 *= 0.95m;
                price2 *= 0.95m;
                price3 *= 0.95m;
            }
            else if (day == "Tuesday")
            {
                if (fruits.Contains(f1))
                {
                    price1 *= 0.8m;
                }
                if (fruits.Contains(f2))
                {
                    price2 *= 0.8m;
                }
                if (fruits.Contains(f3))
                {
                    price3*= 0.8m;
                }
            }
            else if (day == "Wednesday")
            {
                if (!fruits.Contains(f1))
                {
                    price1 *= 0.9m;
                }
                if (!fruits.Contains(f2))
                {
                    price2 *= 0.9m;
                }
                if (!fruits.Contains(f3))
                {
                    price3 *= 0.9m;
                }
            }
            else if (day == "Thursday")
            {
                if (f1=="banana")
                {
                    price1 *= 0.7m;
                }
                if (f2 == "banana")
                {
                    price2 *= 0.7m;
                }
                if (f3 == "banana")
                {
                    price3 *= 0.7m;
                }
            }

            decimal totalPrice = price1 + price2 + price3;

            Console.WriteLine("{0:f2}",totalPrice);
        }
    }
}
