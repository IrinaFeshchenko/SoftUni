

namespace StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName, string Age)
            {
                this.FName = fName;
                this.LName = lName;
                this.Age = int.Parse(Age);
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public int Age { get; set; }
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students.Where(student => student.Age >= 18 && student.Age <= 24);
            PrintStudents(result);
        }

        private static void PrintStudents(IEnumerable<Student> result)
        {
            foreach (var student in result)
            {
                Console.WriteLine($"{student.FName} {student.LName} {student.Age}");
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
