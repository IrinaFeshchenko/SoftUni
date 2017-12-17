using System.ComponentModel.DataAnnotations;

namespace Teamwork.Data.Models
{
    public class StudentProject
    {
        [Required]
        public string StudentId { get; set; }

        public Student Student { get; set; }

        public int ProjectId { get; set; }
        
        public Project Project { get; set; }
    }
}
