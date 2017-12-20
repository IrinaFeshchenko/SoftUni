using System.Collections.Generic;
using Teamwork.Common.Mapping;
using Teamwork.Data.Models;

namespace Teamwork.Services.Teacher.Models
{
    public class TeacherStudentsDto : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> StudentTeacherCourses { get; set; }
    }
}
