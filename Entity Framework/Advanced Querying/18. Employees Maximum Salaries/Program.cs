using _17.Call_a_Stored_Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Employees_Maximum_Salaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = context.Employees
                .GroupBy(e => e.Department)
                .Select(e => new { Salary = e.Max(d => d.Salary), e.FirstOrDefault().Department })
                .Where(e => e.Salary < 30000 || e.Salary > 70000)
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Department.Name} - {item.Salary:f2}");
            }
        }
    }
}
