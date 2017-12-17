using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Surname { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }
    }
}
