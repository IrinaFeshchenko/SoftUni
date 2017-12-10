using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Teamwork.Services.Teachers.Models;
using Teamwork.Web.Data;

namespace Teamwork.Services.Teachers
{
    public class TeachersProjectService : ITeachersProjectService
    {
        private readonly TeamworkDbContext db;

        public TeachersProjectService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TeachersProjectServiceModel> GetProjects(string id)
        {
            var projects = db
                .Projects.Where(p => p.Creator.Id == id)
                .ProjectTo<TeachersProjectServiceModel>()
                .ToList();

            return projects;
        }
    }
}
