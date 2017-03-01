namespace _16.Remove_Towns
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

            Console.Write("Enter town name: ");
            string inputTownName = Console.ReadLine();

            var town = context.Towns.FirstOrDefault(t => t.Name == inputTownName);
            var addresses = town.Addresses;

            int count = 0;
            foreach (var a in addresses)
            {
                var emp = a.Employees;

                foreach (var e in emp)
                {
                    e.Address = null;
                }             
                count++;
            }

            context.Addresses.RemoveRange(addresses);
            context.SaveChanges();

            if (count == 0)
            {
                Console.WriteLine("No susch an address was found");
            }
            else if (count == 1)
            {
                Console.WriteLine($"1 address in {inputTownName} was deleted");
            }
            else if (count > 1)
            {
                Console.WriteLine($"{count} addresses in {inputTownName} were deleted");
            }
        }
    }
}
