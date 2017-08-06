using System;
using System.Collections.Generic;
using System.Linq;

[AttributeUsage(AttributeTargets.Class)]
public class Book:Attribute
{
    public Book(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers.ToList();
    }

    public string Author { get; set; }

    public int Revision { get; set; }

    public string Description { get; set; }

    public List<string> Reviewers { get; set; }
}
