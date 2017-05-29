namespace _1.Code_First_Student_System.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public enum ResourceType
    {
        video,
        presentation,
        document,
        other
    }

    public class Resource
    {
        public Resource()
        {
            Licenses = new HashSet<License>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
