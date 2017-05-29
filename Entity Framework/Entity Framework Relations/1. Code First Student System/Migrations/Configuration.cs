namespace _1.Code_First_Student_System.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1.Code_First_Student_System.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_1.Code_First_Student_System.StudentSystemContext context)
        {
            InitialSeed(context);
            SeedLicenses(context);
        }

        private void SeedLicenses(StudentSystemContext context)
        {
            if (context.Licenses.Any())
            {
                return;
            }

            var resources = context.Resources.ToList();

            foreach (var resource in resources)
            {
                resource.Licenses.Add(new License { Name = $"{resource.Name} Media License ", Resource = resource });
                resource.Licenses.Add(new License { Name = $"{resource.Name} Documents License ", Resource = resource });
            }

            context.SaveChanges();
        }

        private void InitialSeed(StudentSystemContext context)
        {
            if (context.Students.Any() || context.Cources.Any() || context.Homeworks.Any() || context.Resources.Any())
            {
                return;
            }

            // seed courses
            Course sql = new Course
            {
                CourseName = "SQL",
                Description = "procedures, triggers, transactions, views",
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddMonths(3),
                Price = 100m
            };

            Course csharp = new Course
            {
                CourseName = "C#",
                Description = "interfaces, delegates, events",
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddMonths(3),
                Price = 200m
            };

            Course js = new Course
            {
                CourseName = "JS",
                Description = "objects, prototypes, delegation",
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddMonths(3),
                Price = 300m
            };

            context.Cources.AddOrUpdate(sql, csharp, js);

            // seed students
            Student aPeters = new Student
            {
                Name = "Andrew Peters",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-26),
                Courses = new[] { sql, csharp }
            };

            Student bLambson = new Student
            {
                Name = "Brice Lambson",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-34),
                Courses = new[] { csharp }
            };

            Student rMiller = new Student
            {
                Name = "Rowan Miller",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-18),
                Courses = new[] { csharp, js }
            };

            context.Students.AddOrUpdate(aPeters, bLambson, rMiller);

            //seed Homework
            Homework aPetersHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = aPeters,
            };

            Homework aPetersHomeworkSQL = new Homework
            {
                Content = "sql homework",
                ContentType = ContentType.zip,
                SubmissionDate = DateTime.Now,
                Student = aPeters
            };

            Homework bLambsonHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = bLambson
            };

            Homework rMillerHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = rMiller
            };

            Homework rMillerHomeworkJS = new Homework
            {
                Content = "JS homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = rMiller
            };

            context.Homeworks.AddOrUpdate(aPetersHomeworkCS, aPetersHomeworkSQL, bLambsonHomeworkCS, rMillerHomeworkCS, rMillerHomeworkJS);

            //seed resouces
            Resource csharpPresentation = new Resource()
            {
                Name = "c# Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/csharp",
                Course = csharp
            };

            Resource csharpLecture = new Resource()
            {
                Name = "c# Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/csharp",
                Course = csharp
            };

            Resource sqlPresentation = new Resource()
            {
                Name = "sql Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/sql",
                Course = sql
            };

            Resource sqlLecture = new Resource()
            {
                Name = "sql Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/sql",
                Course = sql
            };

            Resource jsPresentation = new Resource()
            {
                Name = "js Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/js",
                Course = js
            };

            Resource jsLecture = new Resource()
            {
                Name = "js Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/js",
                Course = js
            };

            context.Resources.AddOrUpdate(csharpPresentation, csharpLecture, sqlPresentation, sqlLecture, jsPresentation, jsLecture);
        }
    }
}
