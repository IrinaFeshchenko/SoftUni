using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Gringotts_Database
{
    class Startup
    {
        static void Main(string[] args)
        {
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false,
            };

            var context = new GringottsContext();
            context.wizardDeposits.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
