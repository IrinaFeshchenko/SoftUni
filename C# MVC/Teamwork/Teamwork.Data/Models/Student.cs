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
    }
}
