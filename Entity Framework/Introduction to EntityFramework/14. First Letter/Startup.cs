namespace _14.First_Letter
{
    using Gringotts_Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new GringottsContext();
            var wizz = context.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .Select(w=>w.FirstName.Substring(0,1))
                .Distinct()
                .OrderBy(w => w);

            foreach (var w in wizz)
            {
                Console.WriteLine($"{w}");
            }
        }
    }
}
