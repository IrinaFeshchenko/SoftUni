

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DreamItem
    {
        static void Main()
        {
            string s = Console.ReadLine();
            string[] param = s.Split('\\');

            string month = param[0];
            decimal money = decimal.Parse(param[1]);
            int hours = int.Parse(param[2]);
            decimal price = decimal.Parse(param[3]);

            int workingDays = 20;
            if (month == "Feb")
            {
                workingDays -= 2;
            }

            if ((month=="Jan")|| (month == "March") || (month == "May") || (month == "July")
                || (month == "Aug") || (month == "Oct") || (month == "Dec"))
            {
                workingDays++;
            }

            decimal moneyPerMonth = workingDays * hours * money;

            if (moneyPerMonth>700)
            {
                moneyPerMonth *= 1.1m;
            }

            if (moneyPerMonth>=price)
            {
                Console.WriteLine("Money left = {0:f2} leva.",moneyPerMonth-price);
            }
            else
            {
                Console.WriteLine("Not enough money. {0:f2} leva needed.",price-moneyPerMonth);
            }
        }
    }
}
