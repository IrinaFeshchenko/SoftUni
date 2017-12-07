using System;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Data.DataConstants;

namespace Teamwork.Data.Models
{
    public class Assessment
    {
        public int Id { get; set; }

        [Required]
        [Range(AssessmentGradeMinValue, AssessmentGradeMaxValue)]
        public int Grade { get; set; }

        [Required]
        [MinLength(AssessmentCommentMinLength)]
        public string Comments { get; set; }

        public DateTime AssessmentDate { get; set; }

        public int FromStudentId { get; set; }

        public User FromStudent { get; set; }

        public int ForStudentId { get; set; }

        public User ForStudent { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
