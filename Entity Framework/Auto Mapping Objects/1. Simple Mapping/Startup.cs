
namespace _1.Simple_Mapping
{
    using AutoMapper;
    using System;
    using System.Globalization;

    class Startup
    {
        static void Main()
        {
            var employee = new Employee()
            {
                FirstName = "Bill",
                LastName = "Gates",
                Salary = 50000m,
                Birthdate = DateTime.ParseExact("01/01/1960", "d/M/yyyy", CultureInfo.InvariantCulture),
                Address = "Main str. Los Angeles"
            };

            Mapper.Initialize(cfg => cfg.CreateMap<Employee,EmployeeDto>());

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            Console.WriteLine($"{employee.FirstName} - {employee.LastName} - {employee.Salary}");
        }
    }
}
