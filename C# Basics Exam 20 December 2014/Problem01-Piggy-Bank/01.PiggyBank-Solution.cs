using System;

class PiggyBank
{
    static void Main()
    {
        int price = int.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine());
        if (partyDays > 8)
        {
            Console.WriteLine("never");
        }
        else
        {
            int normalDays = 30 - partyDays;

            int monthlySavings = normalDays * 2;
            int monthlyExpenses = partyDays * 5;
            int monthlyBalance = monthlySavings - monthlyExpenses;

            double totalMonthsRequired = (double)price / monthlyBalance;
            int result = (int)Math.Ceiling(totalMonthsRequired);
            int years = result / 12;
            int months = result % 12;
            Console.WriteLine("{0} years, {1} months", years, months);
        }
    }
}
