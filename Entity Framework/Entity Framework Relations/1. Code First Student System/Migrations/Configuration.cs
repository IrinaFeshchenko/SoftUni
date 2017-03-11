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
            // seed courses
            Course sql = new Course
            {
                CourseName = "SQL",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
                Price = 100
            };

            Course csharp = new Course
            {
                CourseName = "C#",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
                Price = 200
            };

            Course js = new Course
            {
                CourseName = "JS",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
                Price = 300
            };

            context.Cources.AddOrUpdate(sql, csharp, js);

            // seed students
            Student aPeters = new Student
            {
                Name = "Andrew Peters",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-26),
                Courses = new []{ sql, csharp }
            };
            sql.Students.Add(aPeters);
            csharp.Students.Add(aPeters);

            Student bLambson = new Student 
            {
                Name = "Brice Lambson",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-34),
                Courses = new[] { csharp }
            };
            csharp.Students.Add(bLambson);

            Student rMiller = new Student
            {
                Name = "Rowan Miller",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now.AddYears(-18),
                Courses = new[] { csharp , js}
            };
            csharp.Students.Add(rMiller);
            js.Students.Add(rMiller);

            context.Students.AddOrUpdate(aPeters, bLambson, rMiller);

            //seed Homework
            Homework aPetersHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = aPeters
            };
            csharp.Homeworks.Add(aPetersHomeworkCS);

            Homework aPetersHomeworkSQL = new Homework
            {
                Content = "sql homework",
                ContentType = ContentType.zip,
                SubmissionDate = DateTime.Now,
                Student = aPeters
            };
            sql.Homeworks.Add(aPetersHomeworkSQL);

            Homework bLambsonHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = bLambson
            };
            csharp.Homeworks.Add(bLambsonHomeworkCS);

            Homework rMillerHomeworkCS = new Homework
            {
                Content = "c# homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = rMiller
            };
            csharp.Homeworks.Add(rMillerHomeworkCS);

            Homework rMillerHomeworkJS = new Homework
            {
                Content = "JS homework",
                ContentType = ContentType.application,
                SubmissionDate = DateTime.Now,
                Student = rMiller
            };
            js.Homeworks.Add(rMillerHomeworkJS);

            context.Homeworks.AddOrUpdate(aPetersHomeworkCS, aPetersHomeworkSQL, bLambsonHomeworkCS, rMillerHomeworkCS, rMillerHomeworkJS);

            //seed resouces
            Resource csharpPresentation = new Resource()
            {
                Name = "c# Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/csharp"
            };
            sql.Resources.Add(csharpPresentation);

            Resource csharpLecture = new Resource()
            {
                Name = "c# Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/csharp"
            };
            sql.Resources.Add(csharpLecture);

            Resource sqlPresentation = new Resource()
            {
                Name = "sql Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/sql"
            };
            sql.Resources.Add(sqlPresentation);

            Resource sqlLecture = new Resource()
            {
                Name = "sql Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/sql"
            };
            sql.Resources.Add(sqlLecture);

            Resource jsPresentation = new Resource()
            {
                Name = "js Presentation",
                ResourceType = ResourceType.presentation,
                Url = "www.uni.com/js"
            };
            sql.Resources.Add(jsPresentation);

            Resource jsLecture = new Resource()
            {
                Name = "js Lecture",
                ResourceType = ResourceType.video,
                Url = "www.uni.com/js"
            };
            sql.Resources.Add(jsLecture);

            context.Resources.AddOrUpdate(csharpPresentation, csharpLecture, sqlPresentation, sqlLecture, jsPresentation, jsLecture);

            context.SaveChanges();
        }
    }
}
