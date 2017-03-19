using GringottsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Deposits_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new GringottsDBContext();

            var depositGroups = ctx.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(w => new
                {
                    depositGroup = w.Key,
                    depositSum = w.Sum(s => s.DepositAmount)
                })
                .Where(d=>d.depositSum<150000)
                .OrderByDescending(d=>d.depositSum)
                .ToList();

            foreach (var d in depositGroups)
            {
                Console.WriteLine($"{d.depositGroup} - {d.depositSum}");
            }
        }
    }
}
