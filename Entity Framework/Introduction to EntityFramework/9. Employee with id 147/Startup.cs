namespace _9.Employee_with_id_147
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var employee = context.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e=> new { e.FirstName, e.LastName, e.JobTitle, e.Projects})
                .FirstOrDefault();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            foreach (var p in employee.Projects)
            {
                Console.WriteLine($"");
            }
        }
    }
}
