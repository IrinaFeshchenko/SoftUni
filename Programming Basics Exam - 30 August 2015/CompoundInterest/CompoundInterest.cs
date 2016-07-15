

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CompoundInterest
    {
        static void Main()
        {
            double tvPrice = double.Parse(Console.ReadLine());
            double years = double.Parse(Console.ReadLine());
            double bankInterest = double.Parse(Console.ReadLine());
            double friendInterest = double.Parse(Console.ReadLine());

            double bank = tvPrice * Math.Pow((1 + bankInterest),years);
            double friend = tvPrice * (1 + friendInterest);

            if (friend<=bank)
            {
                Console.WriteLine("{0:f2} Friend", friend);
            }
            else
            {
                Console.WriteLine("{0:f2} Bank", bank);
            }
        }
    }
}
