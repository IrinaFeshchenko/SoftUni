namespace _15.Delete_Project_by_Id
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

            var prj = context.Projects.FirstOrDefault(p => p.ProjectID == 2);
            // context.Projects.Remove(prj);
            var pr = context.Projects.Take(10);
            foreach (var p in pr)
            {
                Console.WriteLine($"{p.Name}");
            }
        }
    }
}
