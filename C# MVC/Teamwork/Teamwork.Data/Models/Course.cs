using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenericNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

        [Required]
        public List<TeacherCourse> TeachersCourses { get; set; } = new List<TeacherCourse>();

        [Required]
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
