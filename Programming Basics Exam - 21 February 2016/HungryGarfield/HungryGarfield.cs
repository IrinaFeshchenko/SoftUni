

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HungryGarfield
    {
        static void Main()
        {
            decimal dolars = decimal.Parse(Console.ReadLine());
            decimal exchangeRate = decimal.Parse(Console.ReadLine());
            decimal pizzaPrice = decimal.Parse(Console.ReadLine());
            decimal lasagnaPrice = decimal.Parse(Console.ReadLine());
            decimal sandwitchPrice = decimal.Parse(Console.ReadLine());
            decimal pizzaQuantity = decimal.Parse(Console.ReadLine());
            decimal lasagnaQuantity = decimal.Parse(Console.ReadLine());
            decimal sandwichQuantity = decimal.Parse(Console.ReadLine());

            decimal required = (pizzaPrice / exchangeRate * pizzaQuantity )+
                               (lasagnaPrice / exchangeRate * lasagnaQuantity) +
                               (sandwitchPrice / exchangeRate * sandwichQuantity);

            if (dolars - required>=0)
            {
                Console.WriteLine("Garfield is well fed, John is awesome. Money left: ${0:f2}.", dolars - required);
            }
            else
            {
                Console.WriteLine("Garfield is hungry. John is a badass. Money needed: ${0:f2}.", (dolars - required)*-1);  
            }
        }
    }
}
