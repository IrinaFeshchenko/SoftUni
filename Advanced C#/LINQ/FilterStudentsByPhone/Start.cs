
namespace FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName, string phone)
            {
                this.FName = fName;
                this.LName = lName;
                this.Phone = phone;
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public string Phone { get; set; }
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students
                .Where(st => st.Phone.StartsWith("02") || st.Phone.StartsWith("+3592"));

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

                students.Add(new Student(args[0], args[1], args[2]));
            }

            return students;
        }
    }
}
