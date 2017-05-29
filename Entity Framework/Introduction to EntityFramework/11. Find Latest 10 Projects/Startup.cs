namespace _11.Find_Latest_10_Projects
{
    using SoftUni_Database;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var proj = context.Projects
                .OrderByDescending(p=>p.StartDate)
                .Take(10)
                .OrderBy(p=>p.Name);

            foreach (var p in proj)
            {
                Console.WriteLine($"{p.Name} {p.Description} {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt")}");
            }
        }
    }
}
