

namespace WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName, string mark1, string mark2, string mark3, string mark4)
            {
                this.FName = fName;
                this.LName = lName;
                this.Mark1 = int.Parse(mark1);
                this.Mark2 = int.Parse(mark2);
                this.Mark3 = int.Parse(mark3);
                this.Mark4 = int.Parse(mark4);
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public int Mark1 { get; set; }
            public int Mark2 { get; set; }
            public int Mark3 { get; set; }
            public int Mark4 { get; set; }
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students.Where(st => st.Mark1==6||st.Mark2==6||st.Mark3==6||st.Mark4==6);
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

                students.Add(new Student(args[0], args[1], args[2], args[3], args[4], args[5]));
            }

            return students;
        }
    }
}
