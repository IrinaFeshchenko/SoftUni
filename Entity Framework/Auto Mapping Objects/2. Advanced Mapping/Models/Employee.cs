
namespace _2.Advanced_Mapping
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            Employees = new HashSet<Employee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }

        public bool IsOnHoliday { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
