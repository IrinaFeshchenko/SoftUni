

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TorrentPirate
    {
        static void Main()
        {
            decimal d = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());
            decimal w = decimal.Parse(Console.ReadLine());

            decimal hrs = d / 2 / 60 / 60;

            decimal dPrice = hrs * w;

            decimal movies = d / 1500;

            decimal cPrice = movies * p;

            if (dPrice<=cPrice)
            {
                Console.WriteLine("mall -> {0:f2}lv",dPrice);
            }
            else
            {
                Console.WriteLine("cinema -> {0:f2}lv", cPrice);
            }
        }
    }
}
