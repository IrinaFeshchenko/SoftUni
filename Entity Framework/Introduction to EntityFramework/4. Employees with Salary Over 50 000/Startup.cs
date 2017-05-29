namespace _4.Employees_with_Salary_Over_50_000
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var employeeNames = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);

            foreach (string name in employeeNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
