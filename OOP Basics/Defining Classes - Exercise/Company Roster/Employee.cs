namespace Company_Roster
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string name, decimal salary, string position, string department)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = "n/a";
            Age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            : this(name, salary, position, department)
        {
            Email = email;
            Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
        {
            Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department)
        {
            Email = email;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
