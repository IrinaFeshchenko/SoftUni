namespace _3.Projection.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Manager: {this.ManagerLastName??"[no manager]"}";
        }
    }
}
