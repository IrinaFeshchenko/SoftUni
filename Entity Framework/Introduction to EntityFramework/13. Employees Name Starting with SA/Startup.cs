namespace _13.Employees_Name_Starting_with_SA
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var emp = context.Employees.Where(e => e.FirstName.Substring(0, 2).ToUpper() == "SA");

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
            }
        }
    }
}
