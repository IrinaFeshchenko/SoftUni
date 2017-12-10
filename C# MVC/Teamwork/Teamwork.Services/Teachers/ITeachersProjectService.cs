using System.Collections.Generic;
using Teamwork.Services.Teachers.Models;

namespace Teamwork.Services.Teachers
{
    public interface ITeachersProjectService
    {
        IEnumerable<TeachersProjectServiceModel> GetProjects(string id);
    }
}
