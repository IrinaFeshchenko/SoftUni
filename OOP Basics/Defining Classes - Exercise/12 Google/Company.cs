using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Google
{
    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
