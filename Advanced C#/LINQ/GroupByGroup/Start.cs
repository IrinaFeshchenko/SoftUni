

namespace GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string fName, string lName, string group)
            {
                this.FName = fName;
                this.LName = lName;
                this.Group = int.Parse(group);
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public int Group { get; set; }
        }

        public static void Main()
        {
            List<Student> Students = ReadInput();
            var result = Students.GroupBy(st=>st.Group).OrderBy(group=>group.Key);
            PrintStudents(result);
        }

        private static void PrintStudents(IEnumerable<IGrouping<int, Student>> studentsInGroupTwo)
        {
            foreach (var group in studentsInGroupTwo)
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ",group.Select(s=>$"{s.FName} {s.LName}"))}");
            }
        }

        private static List<Student> ReadInput()
        {
            List<Student> Students = new List<Student>();

            while (true)
            {
                string[] args = Console.ReadLine().Split();
                if (args[0] == "END") break;

                Students.Add(new Student(args[0], args[1],args[2]));
            }

            return Students;
        }
    }
}
