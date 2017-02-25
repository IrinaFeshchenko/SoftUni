namespace _7.Find_Employees_in_Period
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            var emps = context.Employees
                .Where(e=> e.Projects.Any(p=>p.StartDate.Year >= 2001 && p.EndDate.Value.Year <= 2003))
                .Take(30)
                .Select(e=> new { e.FirstName,e.LastName,mName = e.Manager.FirstName ,e.Projects});

            foreach (var e in emps)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.mName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} { p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt")}");
                }
            }
        }
    }
}
