namespace _6.Add_Address_and_Update_Employee
{
    using SoftUni_Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            Address addr = new Address
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            context.Addresses.Add(addr);
            context.SaveChanges();

            var addressId = context.Addresses.Where(a => a.AddressText == "Vitoshka 15").Select(a => a.AddressID).FirstOrDefault();
            Employee employe = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
            employe.AddressID = addressId;
            context.SaveChanges();

            var emps = context.Employees
                            .OrderByDescending(e => e.AddressID)
                            .Take(10)
                            .Select(e => e.Address.AddressText);

            foreach (var e in emps)
            {
                Console.WriteLine(e);
            }
        }
    }
}
