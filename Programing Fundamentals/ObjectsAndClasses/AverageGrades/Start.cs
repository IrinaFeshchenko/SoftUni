

namespace AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public Student()
        {
            this.Grades = new List<double>();
        }
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
    }

    public class Start
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var students = ReadInput(n).OrderBy(x=>x.Name).ThenByDescending(y=>y.AverageGrade);

            foreach (var student in students)
            {
                if (student.AverageGrade>=5.00)
                {
                    Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
                }
            }
        }

        private static IList<Student> ReadInput(int n)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                student.Name = args[0];
                var grades = args.Skip(1).Select(double.Parse).ToList();
                student.Grades.AddRange(grades);
                students.Add(student);               
            }

            return students;
        }
    }
}
