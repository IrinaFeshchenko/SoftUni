namespace Many_to_Many_Relation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();
    }
}
