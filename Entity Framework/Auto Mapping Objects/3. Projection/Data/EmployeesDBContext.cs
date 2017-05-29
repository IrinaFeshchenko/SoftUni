namespace _3.Projection
{
    using Models;
    using System.Data.Entity;

    public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext()
            : base("name=EmployeesDBContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}