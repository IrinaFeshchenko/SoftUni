namespace _02_Salary_Increase
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} get {this.Salary} leva";
        }

        public void IncreaseSalary(double percent)
        {
            if (this.Age>30)
            {
                this.Salary += this.Salary * percent / 100;
            }
            else
            {
                this.Salary += this.Salary * percent / 200;
            }
        }
    }
}
