
namespace Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = args[0];
                decimal salary = decimal.Parse(args[1]);
                string position = args[2];
                string department = args[3];

                Employee employee= new Employee();

                if (args.Length == 4)
                {
                    employee = new Employee(name,salary,position,department);
                }
                else if (args.Length == 5)
                {
                    if (int.TryParse(args[4], out int age))
                    {
                        employee = new Employee(name, salary, position, department,age);
                    }
                    else
                    {
                        string email = args[4];
                        employee = new Employee(name, salary, position, department,email);
                    }
                }
                else if (args.Length == 6)
                {
                    string email = string.Empty;
                    int age=0;

                    if (int.TryParse(args[4], out age))
                    {
                        email = args[4];
                    }
                    else
                    {
                        email = args[4];
                        age = int.Parse(args[5]);
                    }

                    employee = new Employee(name, salary, position, department,age:age,email:email);

                }
                employees.Add(employee);
            }

            var result = employees.GroupBy(employee => employee.Department)
                                  .OrderByDescending(dep => dep.Average(employee => employee.Salary))
                                  .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Key}");
            foreach (var emp in result.Select(x => x).OrderByDescending(e=>e.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
            }
        }
    }
}
