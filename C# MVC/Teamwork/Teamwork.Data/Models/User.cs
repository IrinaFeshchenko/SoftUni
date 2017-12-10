using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Data.DataConstants;

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

        public List<Assessment> AssesmentsGiven { get; set; } = new List<Assessment>();

        public List<Assessment> AssesmentsReceived { get; set; } = new List<Assessment>();

        public List<StudentProject> StudentProjects { get; set; } = new List<StudentProject>();

        public List<Project> CreatedProjects { get; set; } = new List<Project>();
    }
}
