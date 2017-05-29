using AutoMapper;
using System.Collections.Generic;

namespace _2.Advanced_Mapping
{
    class Startup
    {
        static void Main()
        {
            InitialiseMapper();

            var managers = CreateManagers();

            var managerDtos = Mapper.Map<IEnumerable<Employee>, IEnumerable<ManagerDto>>(managers);

            foreach (var manager in managerDtos)
            {
                System.Console.WriteLine(manager.ToString());
            }
        }

        public static void InitialiseMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                .ForMember(m => m.EmployeesCount, src => src.MapFrom(e => e.Employees.Count));
            });
        }


        public static List<Employee> CreateManagers()
        {
            List<Employee> managers = new List<Employee>();

            for (int i = 0; i < 3; i++)
            {
                var emp1 = new Employee()
                {
                    FirstName = "Gui",
                    LastName = "Gilbert",
                    Salary = 12500.00m,
                };

                var emp2 = new Employee()
                {
                    FirstName = "Kevin",
                    LastName = "Brown",
                    Salary = 13500.00m
                };

                var emp3 = new Employee()
                {
                    FirstName = "Roberto",
                    LastName = "Tamburello",
                    Salary = 43300.00m
                };

                var manager = new Employee()
                {
                    FirstName = "Jo",
                    LastName = "Brown",
                    Salary = 43300.00m,
                    Employees = new[] { emp1, emp2, emp3 }
                };

                emp1.Manager = manager;
                emp2.Manager = manager;
                emp3.Manager = manager;
                managers.Add(manager); 
            }

            return managers;
        }
    }
}
