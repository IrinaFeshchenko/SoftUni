using System;
using System.ComponentModel.DataAnnotations;
using static Teamwork.Common.GlobalConstants;

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

        [Required]
        public string FromStudentId { get; set; }

        public Student FromStudent { get; set; }

        [Required]
        public string ForStudentId { get; set; }

        public Student ForStudent { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
