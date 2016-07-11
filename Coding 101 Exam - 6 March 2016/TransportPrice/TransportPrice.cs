

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TransportPrice
    {
        static void Main()
        {
            double km = double.Parse(Console.ReadLine());
            string daytime = Console.ReadLine();
            double lowestPrice=0;

            if (km<20)
            {
                lowestPrice = 0.7 + (km * (daytime == "day" ? 0.79 : 0.9));
            }
            else if (20 <=km && km < 100)
            {
                lowestPrice = 0.09 * km;
            }
            else
            {
                lowestPrice = 0.06 * km;
            }
            
            Console.WriteLine(lowestPrice);
        }
    }
}
