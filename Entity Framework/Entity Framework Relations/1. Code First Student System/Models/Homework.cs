using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.Code_First_Student_System.Models
{
    public enum ContentType
    {
        application,
        pdf,
        zip
    }

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
