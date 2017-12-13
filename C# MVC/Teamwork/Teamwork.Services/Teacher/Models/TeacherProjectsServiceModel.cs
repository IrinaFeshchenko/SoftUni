using System;
using Teamwork.Common.Mapping;
using Teamwork.Data.Models;

namespace Teamwork.Services.Teacher.Models
{
    public class TeacherProjectsServiceModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Creator { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LateSubmisionDate { get; set; }
    }
}
