


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CurrencyCheck
    {
        static void Main()
        {
            decimal r = decimal.Parse(Console.ReadLine());
            decimal d = decimal.Parse(Console.ReadLine());
            decimal e = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());

            r = r / 100 * 3.5m;
            d = d * 1.5m;
            e = e * 1.95m;
            b = b / 2;

            decimal rd = r < d ? r : d;
            decimal rde = rd < e ? rd : e;
            decimal rdeb = rde < b ? rde : b;
            decimal result = rdeb < m ? rdeb : m;

            Console.WriteLine("{0:f2}",result);

        }
    }
}
