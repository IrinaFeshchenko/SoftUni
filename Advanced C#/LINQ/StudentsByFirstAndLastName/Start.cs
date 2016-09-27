

namespace StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName)
            {
                this.FName = fName;
                this.LName = lName;
            }
            public string FName { get; set; }
            public string LName { get; set; }
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students.Where(student => student.FName.CompareTo(student.LName) < 0);
            PrintStudents(result);
        }

        private static void PrintStudents(IEnumerable<Student> studentsInGroupTwo)
        {
            foreach (var student in studentsInGroupTwo)
            {
                Console.WriteLine($"{student.FName} {student.LName}");
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

                students.Add(new Student(args[0], args[1]));
            }

            return students;
        }
    }
}
