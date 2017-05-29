
namespace _2.Advanced_Mapping
{
    using System.Collections.Generic;
    using System.Text;

    class ManagerDto
    {
        public ManagerDto()
        {
            Employees = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }

        public int EmployeesCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.LastName} | Employees:");

            foreach (var e in this.Employees)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString();
        }
    }
}
