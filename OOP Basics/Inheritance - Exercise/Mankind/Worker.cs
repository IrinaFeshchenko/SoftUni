
namespace Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            HoursPerDay = hoursPerDay;
        }

        public decimal SalaryPerHour
        {
            get { return weekSalary/5/hoursPerDay; }
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }

        public decimal HoursPerDay
        {
            get { return hoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                hoursPerDay = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.HoursPerDay:f2}");
            sb.AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

            return sb.ToString();
        }
    }
}
