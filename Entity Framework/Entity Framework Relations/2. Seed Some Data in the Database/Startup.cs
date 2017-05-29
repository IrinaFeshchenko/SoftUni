namespace _2.Seed_Some_Data_in_the_Database
{
    using _1.Code_First_Student_System;
    using _1.Code_First_Student_System.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            while (true)
            {
                Console.WriteLine("Choose opttion from the menu");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - List all Students");
                Console.WriteLine("2 - List All Courses");
                Console.WriteLine("3 - List All Courses with more than five resources");
                Console.WriteLine("4 - List All Courses active today");
                Console.WriteLine("5 - Show students status");
                string menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                else if (menu == "1")
                {
                    var students = context.Students.ToList();

                    foreach (Student student in students)
                    {
                        Console.WriteLine($"{student.Name}");
                        Console.WriteLine("Homeworks:");

                        foreach (var homework in student.Homeworks)
                        {
                            Console.WriteLine($"    --{homework.Content} {homework.ContentType}");
                        }

                        Console.WriteLine();
                    }
                }
                else if (menu == "2")
                {
                    var courses = context.Cources.ToList()
                                                 .OrderBy(c => c.StartDate)
                                                 .ThenByDescending(c => c.EndDate);

                    foreach (var course in courses)
                    {
                        Console.WriteLine($"{course.CourseName} {course.Description}");

                        foreach (var resource in course.Resources)
                        {
                            Console.WriteLine($"    --{resource.Name} {resource.ResourceType} {resource.Url}");
                        }
                    }
                }
                else if (menu == "3")
                {
                    var courses = context.Cources.Where(c => c.Resources.Count() > 5)
                                                 .ToList()
                                                 .OrderByDescending(c=>c.Resources.Count())
                                                 .ThenByDescending(c=>c.StartDate);
                    if (courses.Count() == 0)
                    {
                        Console.WriteLine("No match found");
                    }
                    else
                    {
                        foreach (var course in courses)
                        {
                            Console.WriteLine($"{course.CourseName} {course.Resources.Count}");
                        }
                    }
                }
                else if (menu == "4")
                {
                    var courses = context.Cources.ToList()
                                                 .Where(c => DateTime.Now.AddDays(-5)>c.StartDate && DateTime.Now.AddDays(-5)<c.EndDate)
                                                 .OrderByDescending(c => c.Students.Count())
                                                 .ThenByDescending(c => (c.EndDate - c.StartDate).Days);

                    foreach (var course in courses)
                    {
                        var duration = (course.EndDate.Month - course.StartDate.Month);

                        Console.WriteLine($@"
Course Name: {course.CourseName}
Start Date: {course.StartDate.ToShortDateString()}
End Date: { course.EndDate.ToShortDateString()}
Duration: {duration} months
Students Count: {course.Students.Count}");
                    }
                }
                else if (menu == "5")
                {
                    var students = context.Students.ToList()
                        .OrderByDescending(s => s.Courses.Select(c => c.Price).Sum())
                        .ThenByDescending(s => s.Courses.Count())
                        .ThenBy(s=>s.Name);

                    foreach (var student in students)
                    {
                        var totalPrice = student.Courses.Select(c => c.Price).Sum();
                        var averagePrice = student.Courses.Select(c => c.Price).Average();

                        Console.WriteLine($@"
Student Name: {student.Name}
Courses Count: {student.Courses.Count} 
Total Price: {totalPrice} 
Average Price: {averagePrice}" );
                    }
                }
            }
        }
    }
}
