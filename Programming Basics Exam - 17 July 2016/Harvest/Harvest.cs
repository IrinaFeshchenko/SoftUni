

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Harvest
    {
        static void Main()
        {
            decimal kvM = decimal.Parse(Console.ReadLine());
            decimal grapesPerKvM = decimal.Parse(Console.ReadLine());
            decimal wineRequired = decimal.Parse(Console.ReadLine());
            decimal workers = decimal.Parse(Console.ReadLine());

            decimal grapesTotal = kvM * grapesPerKvM;
            decimal grapesForWine = grapesTotal * 0.4m;
            decimal litersOfWine = grapesForWine / 2.5m;

            decimal litersLeft = litersOfWine - wineRequired;
            if (litersLeft>=0)
            {
                decimal litersPerWorker = litersLeft / workers;

                Console.WriteLine("Good harvest this year! Total wine: {0} liters.",Math.Floor(litersOfWine));
                Console.WriteLine("{0} liters left -> {1} liters per person.",Math.Ceiling(litersLeft),Math.Ceiling(litersPerWorker));
            }
            else
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",Math.Floor(Math.Abs(litersLeft)));
            }
        }
    }
}
