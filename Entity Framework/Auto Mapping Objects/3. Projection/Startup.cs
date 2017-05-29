
namespace _3.Projection
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            ConfigureAutomapping();
            //InitializeDatabase();
            //IEnumerable<Employee> employees = CreateEmployees();
            //SeedDatabase(employees);

            using (EmployeesDBContext db = new EmployeesDBContext())
            {
                var employeesDto = db.Employees
                    .Where(e=>e.Birthdate.Value.Year < 1990)
                    .ProjectTo<EmployeeDto>()
                    .ToList();

                foreach (var e in employeesDto)
                {
                    Console.WriteLine(e.ToString());
                }
            }


        }

        private static void SeedDatabase(IEnumerable<Employee> employees)
        {
            using (EmployeesDBContext db = new EmployeesDBContext())
            {
                db.Employees.AddRange(employees);
                db.SaveChanges();
            }
        }

        private static IEnumerable<Employee> CreateEmployees()
        {
            var emp1 = new Employee()
            {
                FirstName = "Gui",
                LastName = "Gilbert",
                Salary = 12500.00m,
                Birthdate = DateTime.ParseExact("01/01/1960", "d/M/yyyy", CultureInfo.InvariantCulture)
            };

            var emp2 = new Employee()
            {
                FirstName = "Kevin",
                LastName = "Brown",
                Salary = 13500.00m,
                Birthdate =  DateTime.ParseExact("01/01/1995", "d/M/yyyy", CultureInfo.InvariantCulture),
                Manager = emp1
            };

            var emp3 = new Employee()
            {
                FirstName = "Roberto",
                LastName = "Tamburello",
                Salary = 43300.00m,
                Birthdate = DateTime.ParseExact("01/01/1980", "d/M/yyyy", CultureInfo.InvariantCulture),
                Manager = emp1
            };

            return new [] { emp1, emp2, emp3};
        }

        private static void InitializeDatabase()
        {
            using (EmployeesDBContext db = new EmployeesDBContext())
            {
                db.Database.Initialize(true);
            }
        }

        private static void ConfigureAutomapping()
        {
            Mapper.Initialize(cfg =>
              {
                  cfg.CreateMap<Employee, EmployeeDto>();
              });
        }
    }
}
