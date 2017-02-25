namespace _5.Employees_from_Seattle
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .Select(e=> new { e.FirstName,e.LastName,e.Department.Name,e.Salary});

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }
        }
    }
}
