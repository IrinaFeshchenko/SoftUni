

namespace StudentsEnrolledIn2014or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string enrolled, string mark1, string mark2, string mark3, string mark4)
            {
                this.Enrolled = enrolled;
                this.Mark1 = int.Parse(mark1);
                this.Mark2 = int.Parse(mark2);
                this.Mark3 = int.Parse(mark3);
                this.Mark4 = int.Parse(mark4);
            }
            public string Enrolled { get; set; }
            public int Mark1 { get; set; }
            public int Mark2 { get; set; }
            public int Mark3 { get; set; }
            public int Mark4 { get; set; }
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students.Where(st => st.Enrolled.EndsWith("14") || st.Enrolled.EndsWith("15"));
            PrintStudents(result);
        }

        private static void PrintStudents(IEnumerable<Student> studentsInGroupTwo)
        {
            foreach (var student in studentsInGroupTwo)
            {
                Console.WriteLine($"{student.Mark1} {student.Mark2} {student.Mark3} {student.Mark4}");
            }
        }

        private static List<Student> ReadInput()
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] args = Console.ReadLine().Split();
                if (args[0] == "END")
                {
                    break;
                }

                students.Add(new Student(args[0], args[1], args[2], args[3], args[4]));
            }

            return students;
        }
    }
}
