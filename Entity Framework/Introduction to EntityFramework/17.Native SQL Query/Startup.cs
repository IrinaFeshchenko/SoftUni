namespace _17.Native_SQL_Query
{
    using SoftUni_Database;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var timer = new Stopwatch();
            timer.Start();
            PrintNamesWithLinq(context);
            timer.Stop();
            Console.WriteLine($"Linq: {timer.Elapsed}");
            Console.WriteLine();

            timer.Restart();
            PrintNamesWithNativeQuery();
            timer.Stop();
            Console.WriteLine($"Native: {timer.Elapsed}");

        }

        static void PrintNamesWithNativeQuery()
        {
            SqlConnection connection = new SqlConnection(@"data source=.\SQLEXPRESS;initial catalog=SoftUni;integrated security=True;MultipleActiveResultSets=True");
            string query = @"
select distinct e.FirstName
from Employees e
join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID
join Projects p on p.ProjectID = ep.ProjectID
where DATEPART(year,p.StartDate) = '2002'
order by e.FirstName";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(((string)reader["FirstName"]));
                    }
                }
            }
        }

        static void PrintNamesWithLinq(SoftUniContext context)
        {
            var emps = context.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                            .Select(e => e.FirstName);

            foreach (var e in emps)
            {

                Console.WriteLine(e);
            }
        }
    }
}
