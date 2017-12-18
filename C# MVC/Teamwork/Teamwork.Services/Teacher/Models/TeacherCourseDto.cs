using System;
using System.ComponentModel.DataAnnotations;
using Teamwork.Common.Mapping;
using Teamwork.Data.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Services.Teacher.Models
{
    public class TeacherCourseDto : IMapFrom<Course>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GenericNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
