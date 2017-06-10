namespace _01.Students_Results
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Starup
    {
        static void Main()
        {
            int numberOfLinesToRead = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfLinesToRead; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = args[0];
                double[] grades = args[1]
                                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToArray();

                var student = new Student(name,grades);
                students.Add(student);
            }

            Console.WriteLine($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}|");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name,-10}|{student.Grades[0],7:F2}|{student.Grades[1],7:F2}|{student.Grades[2],7:F2}|{student.Grades.Average(),7:F4}|");
            }
        }
    }

    public class Student
    {
        public Student(string name, double[] grades)
        {
            this.Name = name;
            this.Grades = grades;
        }

        public string Name { get; set; }
        public double[] Grades { get; set; }
    }
}
