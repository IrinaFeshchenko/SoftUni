
namespace _4.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter students names on new lines:");
            List<Student> students = new List<Student>();
            string s;
            while ( (s = Console.ReadLine()).ToLower() != "End".ToLower())
            {
                Student student = new Student(s);
                students.Add(student);
            }

            Console.WriteLine($"{students.Count}");
        }
    }
}
