using BashSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student
{
    //•userName
    private string userName;
    //•	enrolledCourses
    private Dictionary<string, Course> enrolledCourses;
    //•	marksByCourseName
    private Dictionary<string, double> marksByCourseName;

    public Student(string name)
    {
        this.UserName = name;
        this.enrolledCourses = new Dictionary<string, Course>();
        this.marksByCourseName = new Dictionary<string, double>();
    }

    public IReadOnlyDictionary<string, Course> EnrolledCourses
    {
        get
        {
            return enrolledCourses;
        }
    }

    public IReadOnlyDictionary<string, double> MarksByCourseName
    {
        get
        {
            return marksByCourseName;
        }
    }

    public string UserName
    {
        get { return userName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(this.userName),
                    ExceptionMessages.NullOrEmptyValue);
            }

            userName = value;
        }
    }

    public void EnrollInCourse(Course course)
    {
        if (this.enrolledCourses.ContainsKey(course.Name))
        { 
            throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,this.userName, course.Name));
        }

        this.enrolledCourses.Add(course.Name, course);
    }

    public void SetMarkOnCourse(string courseName, params int[] scores)
    {
        if (!this.enrolledCourses.ContainsKey(courseName))
        {
            throw new ArgumentException(ExceptionMessages.NotEnrolledInCourse);
        }

        if (scores.Length > Course.NumberOfTasksOnExam)
        {
            throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
        }

        this.marksByCourseName.Add(courseName, CalculateMark(scores));
    }

    private double CalculateMark(int[] scores)
    {
        double percentageOfSolvedExams = scores.Sum() /
            (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
        double mark = percentageOfSolvedExams * 4 + 2;
        return mark;
    }
}
