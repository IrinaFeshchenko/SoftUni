

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CakeTycoon
    {
        static void Main()
        {
            ulong wanted = ulong.Parse(Console.ReadLine());
            decimal flourForOneCake = decimal.Parse(Console.ReadLine());
            ulong flourAvailable = ulong.Parse(Console.ReadLine());
            ulong availableTrufels = ulong.Parse(Console.ReadLine());
            ulong trufelPrice = ulong.Parse(Console.ReadLine());

            ulong canMake = (ulong)Math.Floor(flourAvailable / flourForOneCake);

            if (wanted>canMake)
            {
                decimal extraFlourNeeded = (wanted * flourForOneCake) - flourAvailable;
                Console.WriteLine("Can make only {0} cakes, need {1:f2} kg more flour",canMake,extraFlourNeeded);
            }
            else
            {
                decimal cakePrice = ((decimal)(trufelPrice*availableTrufels)/wanted)*1.25m;
                Console.WriteLine("All products available, price of a cake: {0:f2}",cakePrice);
            }
        }
    }
}
