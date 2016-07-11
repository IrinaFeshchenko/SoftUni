

namespace Namespace
{
    using System;

    class ProspectInHospitality
    {
        static void Main()
        {
            decimal builders = decimal.Parse(Console.ReadLine());
            decimal receptionists = decimal.Parse(Console.ReadLine());
            decimal chambermades = decimal.Parse(Console.ReadLine());
            decimal technicians = decimal.Parse(Console.ReadLine());
            decimal others = decimal.Parse(Console.ReadLine());

            decimal nikiUsdSalary = decimal.Parse(Console.ReadLine());
            decimal usdExchangeRate = decimal.Parse(Console.ReadLine());
            decimal nikiBgnSalary = nikiUsdSalary * usdExchangeRate;

            decimal yourSalary = decimal.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());

            decimal tBuilders = builders * 1500.04m;
            decimal tReceptionists = receptionists * 2102.10m;
            decimal tChambermades = chambermades * 1465.46m;
            decimal tTechnicians = technicians * 2053.33m;
            decimal tOthers = others * 3010.98m;

            decimal moneyNeeded = tBuilders + tReceptionists + tChambermades + tTechnicians + tOthers + nikiBgnSalary + yourSalary;

            Console.WriteLine("The amount is: {0:f2} lv.",moneyNeeded);
            if (moneyNeeded>budget)
            {
                Console.WriteLine("NO \\ Need more: {0:f2} lv.",moneyNeeded - budget);
            }
            else
            {
                Console.WriteLine("YES \\ Left: {0:f2} lv.", budget - moneyNeeded);
            }
        }
    }
}
