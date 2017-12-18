using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamwork.Data.Models
{
    public class Teacher
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public List<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}