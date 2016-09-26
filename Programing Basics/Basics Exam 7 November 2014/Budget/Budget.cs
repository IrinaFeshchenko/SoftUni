

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Budget
    {
        static void Main()
        {
            decimal moneyPerMonth = decimal.Parse(Console.ReadLine());
            int goingOutDays = int.Parse(Console.ReadLine());
            int weekendsAtHometown = int.Parse(Console.ReadLine());
            int weekdays = 22;
            int weekendDays = 8;

            int homeTownWeekendDays = weekendsAtHometown * 2;
            int normalWeekenddays = weekendDays - homeTownWeekendDays;
            int weekendDaysExpense = normalWeekenddays * 20;

            int normalDays = 22 - goingOutDays;
            int normalDaysExpenses = 10*normalDays;
            int goingOutDaysExpenses =( (int)(moneyPerMonth *0.03m)+ 10)*goingOutDays;

            int total = weekendDaysExpense + normalDaysExpenses + goingOutDaysExpenses+150;

            if (total>moneyPerMonth)
            {
                Console.WriteLine("No, not enough {0}.",total-moneyPerMonth);
            }
            else if (moneyPerMonth>total)
            {
                Console.WriteLine("Yes, leftover {0}.", moneyPerMonth-total);
            }
            else if (total == moneyPerMonth)
            {
                Console.WriteLine("Exact Budget.");
            }
        }
    }
}
