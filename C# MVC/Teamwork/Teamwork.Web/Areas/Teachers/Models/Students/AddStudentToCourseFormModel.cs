using System.ComponentModel.DataAnnotations;

namespace Teamwork.Web.Areas.Teachers.Models.Students
{
    public class AddStudentToCourseFormModel
    {
        [Required]
        public string StudentId { get; set; }

        [Required]
        public string Course { get; set; }
    }
}
