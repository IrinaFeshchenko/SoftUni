using System.ComponentModel.DataAnnotations;
using static Teamwork.Common.GlobalConstants;


namespace Teamwork.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Surname { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [MaxLength(StudentNumberMaxLength)]
        public string StudentNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
