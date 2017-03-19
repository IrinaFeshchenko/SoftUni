using GringottsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Deposits_Sum_for_Ollivander_Family
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new GringottsDBContext();

            var depositGroups = ctx.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w=>w.DepositGroup)
                .Select(w=> new
                {
                    depositGroup = w.Key,
                    depositSum = w.Sum(s=>s.DepositAmount)
                })
                .OrderByDescending(d => d.depositSum)
                .ToList();

            foreach (var d in depositGroups)
            {
                Console.WriteLine($"{d.depositGroup} - {d.depositSum}");
            }
        }
    }
}
