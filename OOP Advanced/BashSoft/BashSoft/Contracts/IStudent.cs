namespace BashSoft.Contracts
{
    using System;
    using System.Collections.Generic;

    using BashSoft.Models;

    public interface IStudent:IComparable<IStudent>

    {
    string Username { get; }

    void EnrollInCourse(ICourse course);

    void SetMarkOnCourse(string courseName, params int[] scores);

    IReadOnlyDictionary<string, double> MarksByCourseName { get; }
    }
}
