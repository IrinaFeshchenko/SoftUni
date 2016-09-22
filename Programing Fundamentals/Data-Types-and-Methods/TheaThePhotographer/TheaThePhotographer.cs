

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class TheaThePhotographer
    {
        static void Main()
        {
            double totalPictures = double.Parse(Console.ReadLine());
            double ftSeconds = double.Parse(Console.ReadLine());
            double ffPercent = double.Parse(Console.ReadLine());
            double ut = double.Parse(Console.ReadLine());

            double filteredPictures = Math.Ceiling(totalPictures * (ffPercent / 100));
            BigInteger totalTime = (BigInteger)(totalPictures * ftSeconds + filteredPictures * ut);

            int days = (int)Math.Floor((double)(totalTime /( 60 * 60 * 24)));
            int hours = (int)Math.Floor((double)((totalTime / (60 * 60)) % 24));
            int min = (int)Math.Floor((double)((totalTime / 60) % 60));
            int sec = (int)(totalTime % 60);

            Console.WriteLine($"{days:d1}:{hours:d2}:{min:d2}:{sec:d2}");
        }
    }
}
