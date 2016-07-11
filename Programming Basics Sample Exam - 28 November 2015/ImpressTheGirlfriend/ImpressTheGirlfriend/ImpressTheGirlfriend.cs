

namespace Namespace
{
    using System;

    class ImpressTheGirlfriend
    {
        static void Main()
        {
            double rubles = double.Parse(Console.ReadLine());
            double dolars = double.Parse(Console.ReadLine());
            double euro = double.Parse(Console.ReadLine());
            double levaB = double.Parse(Console.ReadLine());
            double levaM = double.Parse(Console.ReadLine());

            double rusianGame = (rubles / 100) * 3.5;
            double usGame = dolars * 1.5;
            double euGame = euro * 1.95;
            double bgBGame = levaB / 2;

            double r1 = rusianGame > usGame ? rusianGame : usGame;
            double r2 = euGame > r1 ? euGame : r1;
            double r3 = bgBGame > r2 ? bgBGame : r2;
            double result = levaM > r3 ? levaM : r3;

            Console.WriteLine("{0:f2}",Math.Ceiling(result));
        }
    }
}
