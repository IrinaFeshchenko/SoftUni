using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Teamwork.Services.Teacher.Models;
using Teamwork.Data;

namespace Teamwork.Services.Teacher.Implementations
{
    public class TeacherProjectsService : ITeacherProjectsService
    {
        private readonly TeamworkDbContext db;

        public TeacherProjectsService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TeacherProjectsServiceModel> GetProjects(string id)
        {
            var projects = db
                .Projects.Where(p => p.Creator.UserId == id)
                .ProjectTo<TeacherProjectsServiceModel>()
                .ToList();

            return projects;
        }
    }
}
