namespace SoftUni_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            List<Employee> employees = context.Employees.ToList();

            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f4}");
            }
        }
    }
}
