

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FourFactors
    {
        static void Main()
        {
            double fg = double.Parse(Console.ReadLine());
            double fga = double.Parse(Console.ReadLine());
            double threeP = double.Parse(Console.ReadLine());
            double tov = double.Parse(Console.ReadLine());
            double orb = double.Parse(Console.ReadLine());
            double opDrb = double.Parse(Console.ReadLine());
            double ft = double.Parse(Console.ReadLine());
            double fta = double.Parse(Console.ReadLine());

            double efg = (fg + (0.5 * threeP)) / fga;
            double tovP = tov / (fga + 0.44 * fta + tov);
            double orp = orb / (orb + opDrb);
            double ftp = ft / fga;

            Console.WriteLine("eFG% {0:f3}", efg);
            Console.WriteLine("TOV% {0:f3}", tovP);
            Console.WriteLine("ORB% {0:f3}", orp);
            Console.WriteLine("FT% {0:f3}", ftp);
        }
    }
}
