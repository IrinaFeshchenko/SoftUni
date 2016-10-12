

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public class Student
        {
            public Student(string facultyNumber, string fName, string lName)
            {
                this.FName = fName;
                this.LName = lName;
                this.FacultyNumber = facultyNumber;
            }
            public string FName { get; set; }
            public string LName { get; set; }
            public string FacultyNumber { get; set; }
        }

        public class StudentSpecialty
        {
            public StudentSpecialty(string spName, string fcNumber)
            {
                this.SpecialtyName = spName;
                this.FacultyNumber = fcNumber;
            }
            public string SpecialtyName { get; set; }
            public string FacultyNumber { get; set; }
        }

        public static void Main()
        {
            List<StudentSpecialty> specialties = ReadSpecialties();
            List<Student> students = ReadStudents();

            var studentsWithSpecialties = students
                .Join(
                    specialties,
                    st => st.FacultyNumber,
                    sp => sp.FacultyNumber,
                    (st, sp) => new
                    {
                        StudentName = st.FName + " " + st.LName,
                        FacNum = st.FacultyNumber,
                        Specialty = sp.SpecialtyName
                    })
                    .OrderBy(st=>st.StudentName);

            foreach (var item in studentsWithSpecialties)
            {
                Console.WriteLine($"{item.StudentName} {item.FacNum} {item.Specialty}");
            }
        }

        private static List<StudentSpecialty> ReadSpecialties()
        {
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Students:") break;

                specialties.Add(new StudentSpecialty(args[0] + " " + args[1],args[2]));
            }

            return specialties;
        }

        private static List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "END") break;

                students.Add(new Student(args[0], args[1], args[2]));
            }

            return students;
        }
    }
}
