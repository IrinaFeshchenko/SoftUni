using BashSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Course
{
    public const int NumberOfTasksOnExam = 5;
    public const int MaxScoreOnExamTask = 100;
    public Dictionary<string, Student> studentsByName;
    private string name;

    public Course(string name)
    {
        this.Name = name;
        this.studentsByName = new Dictionary<string, Student>();
    }

    public IReadOnlyDictionary<string, Student> StudentsByName
    {
        get
        {
            return studentsByName;
        }
    }
    public string Name
    {
        get { return this.name;}
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(this.Name),
                    ExceptionMessages.NullOrEmptyValue);
            }

            name = value;
        }
    }
    public int Number { get; set; }

    public void EnrollStudent(Student student)
    {
        if (this.studentsByName.ContainsKey(student.UserName))
        {
            throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.Name));
            return;
        }

        this.studentsByName.Add(student.UserName, student);
    }
}
