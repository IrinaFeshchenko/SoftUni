

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PiggyBank
    {
        static void Main()
        {
            int price = int.Parse(Console.ReadLine());
            int partyDays = int.Parse(Console.ReadLine());

            int monthIncome = 2 * (30-partyDays);
            int monthExpense = partyDays * 5;

            int monthSavings = monthIncome - monthExpense;

            int monthsToBuy = (int)Math.Ceiling((double)price / monthSavings);

            if (monthsToBuy <=0)
            {
                Console.WriteLine("never");
            }
            else
            {
                Console.WriteLine("{0} years, {1} months",monthsToBuy/12,monthsToBuy%12);
            }
        }
    }
}
