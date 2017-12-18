using System.ComponentModel.DataAnnotations;

namespace Teamwork.Data.Models
{
    public class StudentCourse
    {
        [Required]
        public string StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
