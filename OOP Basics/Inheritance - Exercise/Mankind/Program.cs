
namespace Mankind
{
    using System;

    class Program
    {
        static void Main()
        {
            try
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string studentFirstName = args[0];
            string studentLastName = args[1];
            string studentFacultyNumber = args[2];

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string workerFirstName = args[0];
            string workerLastName = args[1];
            decimal workerWeekSalary = decimal.Parse(args[2]);
            decimal workerWorkingHours = decimal.Parse(args[3]);

           
                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkingHours);

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
