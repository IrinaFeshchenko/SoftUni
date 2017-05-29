namespace _8.Addresses_by_Town_Name
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();

            var address = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Select(a=> new { a.AddressText,townName = a.Town.Name, eCount =  a.Employees.Count})
                .Take(10);

            foreach (var a in address)
            {
                Console.WriteLine($"{a.AddressText}, {a.townName} - {a.eCount} employees");
            }
        }
    }
}
