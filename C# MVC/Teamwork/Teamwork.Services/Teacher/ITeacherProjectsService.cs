using System.Collections.Generic;
using Teamwork.Services.Teacher.Models;

namespace Teamwork.Services.Teacher
{
    public interface ITeacherProjectsService
    {
        IEnumerable<TeacherProjectsServiceModel> GetProjects(string UserId);
    }
}
