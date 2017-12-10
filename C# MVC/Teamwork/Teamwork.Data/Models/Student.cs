using System.ComponentModel.DataAnnotations;

namespace Teamwork.Data.Models
{
    public class Student
    {
        [Required]
        public string StudentNumber { get; set; }

        [Key]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
