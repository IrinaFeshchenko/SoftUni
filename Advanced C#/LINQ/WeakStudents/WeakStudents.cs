

namespace WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName, Dictionary<string, int> marks)
            {
                this.FName = fName;
                this.LName = lName;
                this.marks = marks;
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public Dictionary<string, int> marks;
        }

        public static void Main()
        {
            List<Student> students = ReadInput();
            var result = students
                .Where(st => (st.marks
                                .Where(m => m.Value <= 3)
                                .ToList()
                                .Count) >= 2);

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

                Dictionary<string, int> marks = new Dictionary<string, int>();
                marks.Add("Mark1", int.Parse(args[2]));
                marks.Add("Mark2", int.Parse(args[3]));
                marks.Add("Mark3", int.Parse(args[4]));
                marks.Add("Mark4", int.Parse(args[5]));

                students.Add(new Student(fName: args[0], lName: args[1], marks: marks));
            }

            return students;
        }
    }
}
