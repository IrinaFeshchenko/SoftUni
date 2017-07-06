using System;

namespace _02_Salary_Increase
{
    public class Person
    {
        private double salary;
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
        public double Salary { get { return this.salary; }
                               set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than460 leva");
                }

                this.salary = value;
            }
        }

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
