

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyRoster
    {
        public class Employee
        {
            private string name;
            private decimal salary;
            private string position;
            private string departament;
            private string email;
            private int age;

            public Employee(string name, decimal salary, string position, string departament)
            {
                this.name = name;
                this.salary = salary;
                this.position = position;
                this.departament = departament;
                this.email = "n/a";
                this.age = -1;
            }

            public string Name => this.name;
            public decimal Salary => this.salary;
            public string Position => this.position;
            public string Departament => this.departament;
            public string Email { get { return this.email; } set { this.email = value; } }
            public int Age { get { return this.age; } set { this.age = value; } }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var employeeInfo = Console.ReadLine().Trim().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries);

                Employee employee = new Employee(
                    employeeInfo[0],
                    decimal.Parse(employeeInfo[1]),
                    employeeInfo[2],
                    employeeInfo[3]);

                if (employeeInfo.Length > 4)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.Email = ageOrEmail;
                        if (employeeInfo.Length > 5)
                        {
                            employee.Age = int.Parse(employeeInfo[5]);
                        }
                    }
                    else
                    {
                        employee.Age = int.Parse(ageOrEmail);
                        if (employeeInfo.Length > 5)
                        {
                            employee.Email = employeeInfo[5];
                        }
                    }
                }

                employees.Add(employee);
            }


            var result = employees
                .GroupBy(e => e.Departament)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employees = e.OrderByDescending(emp => emp.Salary)
                })
                .OrderByDescending(dep => dep.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}
