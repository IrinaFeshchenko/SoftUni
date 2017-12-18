using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Teamwork.Common.Mapping;
using Teamwork.Data.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Services.Teacher.Models
{
    public class TeacherCourseCreateDto
    {
        [Required]
        [MaxLength(GenericNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}