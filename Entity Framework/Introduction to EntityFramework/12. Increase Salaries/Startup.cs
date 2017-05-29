namespace _12.Increase_Salaries
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
            var emp = context.Employees.Where(e => e.Department.Name == "Engineering" || 
                                                e.Department.Name == "Tool Design" || 
                                                e.Department.Name == "Marketing" || 
                                                e.Department.Name == "Information services");
            foreach (var e in emp)
            {
                e.Salary *= 1.12m;
                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f6})");
            }

            context.SaveChanges();
        }
    }
}
