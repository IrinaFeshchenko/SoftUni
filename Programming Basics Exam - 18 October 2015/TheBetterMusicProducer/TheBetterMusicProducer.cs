

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TheBetterMusicProducer
    {
        static void Main()
        {
            int inEurope = int.Parse(Console.ReadLine());
            decimal priceEuro = decimal.Parse(Console.ReadLine());
            int inNortAmerica = int.Parse(Console.ReadLine());
            decimal priceUSD = decimal.Parse(Console.ReadLine());
            int inSouthAmerica = int.Parse(Console.ReadLine());
            decimal pricePesos = decimal.Parse(Console.ReadLine());
            int concerts = int.Parse(Console.ReadLine());
            decimal singleConcertProfit = decimal.Parse(Console.ReadLine());

            decimal euProfit = inEurope * priceEuro * 1.94m;
            decimal usProfit = inNortAmerica * priceUSD *1.72m;
            decimal mexProfit = (inSouthAmerica * pricePesos) / 332.74m;

            decimal albumsProfit = euProfit + usProfit + mexProfit;
            decimal afterProducerPayProfit = albumsProfit * 0.65m;
            decimal afterTaxProfit = afterProducerPayProfit * 0.8m;


            decimal concertsProfit = concerts * singleConcertProfit * 1.94m;

            if (concertsProfit>100000)
            {
                concertsProfit = concertsProfit * 0.85m;
            }

            if (concertsProfit >= afterTaxProfit)
            {
                Console.WriteLine("On the road again! We'll see the world and earn {0:f2}lv.", concertsProfit);
            }
            else
            {
                Console.WriteLine("Let's record some songs! They'll bring us {0:f2}lv.", afterTaxProfit);
            }
        }
    }
}
