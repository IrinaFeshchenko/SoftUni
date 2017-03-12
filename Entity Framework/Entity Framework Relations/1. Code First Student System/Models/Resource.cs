namespace _1.Code_First_Student_System.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum ResourceType
    {
        video,
        presentation,
        document,
        other
    }

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }
    }
}
