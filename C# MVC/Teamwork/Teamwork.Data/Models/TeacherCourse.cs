using System.ComponentModel.DataAnnotations;

namespace Teamwork.Data.Models
{
    public class TeacherCourse
    {
        [Required]
        public string TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
