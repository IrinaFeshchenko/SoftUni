

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RepairingTheTiles
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileLength = double.Parse(Console.ReadLine());
            int benchWidth = int.Parse(Console.ReadLine());
            int benchLength = int.Parse(Console.ReadLine());

            int totalArea = lenght * lenght;
            int benchArea = benchWidth * benchLength;
            int areaToCover = totalArea - benchArea;
            double tileArea = tileWidth * tileLength;
            double tilesRequired = (double)areaToCover / tileArea;
            double timeRequired = (double)tilesRequired * 0.2;

            Console.WriteLine(tilesRequired);
            Console.WriteLine(timeRequired);
        }
    }
}
