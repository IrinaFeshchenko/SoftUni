using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Data.DataConstants;

namespace Teamwork.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectNameMinLength)]
        [MinLength(ProjectNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LateSubmisionDate { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public List<StudentProject> StudentProjects { get; set; } = new List<StudentProject>();

        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}
