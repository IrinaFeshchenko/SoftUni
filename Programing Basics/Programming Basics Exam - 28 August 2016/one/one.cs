

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class one
    {
        static void Main()
        {
            decimal workDaysPerMonth = decimal.Parse(Console.ReadLine());
            decimal profitPerDay = decimal.Parse(Console.ReadLine());
            decimal exchangeRate = decimal.Parse(Console.ReadLine());

            decimal monthlySalary = workDaysPerMonth * profitPerDay;

            decimal yearlyIncome = (monthlySalary * 12m) + (monthlySalary * 2.5m);

            decimal tax = yearlyIncome * 0.25m;

            decimal netYearlyIncomeUSD = yearlyIncome - tax;
            decimal netYearlyIncomeBGN = netYearlyIncomeUSD * exchangeRate;

            decimal averageDayIncom = netYearlyIncomeBGN / 365;

            Console.WriteLine($"{averageDayIncom:f2}");
        }
    }
}
