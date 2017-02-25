namespace _10.Departments_with_more_than_5_employees
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();

            var dep = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count);

            foreach (var d in dep)
            {
                Console.WriteLine($"{d.Name } {(context.Employees.FirstOrDefault(e=>e.EmployeeID == d.ManagerID)).FirstName}");

                foreach (var e in d.Employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
                }
            }
        }
    }
}
