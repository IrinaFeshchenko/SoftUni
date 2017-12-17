using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamwork.Data.Models
{
    public class Student
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public string StudentNumber { get; set; }

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public List<StudentProject> StudentProjects { get; set; } = new List<StudentProject>();

        public List<Assessment> AssessmentsGiven { get; set; } = new List<Assessment>();

        public List<Assessment> AssessmentsReceived { get; set; } = new List<Assessment>();
    }
}
