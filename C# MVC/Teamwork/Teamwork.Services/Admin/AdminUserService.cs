using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Admin.Models;
using Teamwork.Data.Models;
using System.Linq;
using Teamwork.Data;
using static Teamwork.Common.GlobalConstants;


namespace Teamwork.Services.Admin
{
    public class AdminUserService : IAdminUserService, IPagination
    {
        private readonly TeamworkDbContext db;

        public AdminUserService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync(string searchTerm = "", int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await Task.Run(() =>
                db.Users
                .Where(u => !db.Students.Any(s => s.UserId == u.Id))
                .Where(u => u.Email.Contains(searchTerm))
                            .Select(user => new
                            {
                                Id = user.Id,
                                Email = user.Email,
                                UserRoles = db.UserRoles
                                             .Where(ur => ur.UserId == user.Id)
                                             .Join(db.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                                             .ToList()
                            })
                            .OrderBy(u => u.Email)
                            .Skip((page - 1) * AdminUsersPageSize)
                            .Take(AdminUsersPageSize)
                            .ProjectTo<AdminUserListingServiceModel>()
                            .ToList()
                );
            }
            else
            {
                return await Task.Run(() =>
                db.Users
                .Where(u => !db.Students.Any(s => s.UserId == u.Id))
                            .Select(user => new
                            {
                                Id = user.Id,
                                Email = user.Email,
                                UserRoles = db.UserRoles
                                             .Where(ur => ur.UserId == user.Id)
                                             .Join(db.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                                             .ToList()
                            })
                            .OrderBy(u => u.Email)
                            .Skip((page - 1) * AdminUsersPageSize)
                            .Take(AdminUsersPageSize)
                            .ProjectTo<AdminUserListingServiceModel>()
                            .ToList()
                );
            }
        }

        public async Task<int> TotalAsync(string searchTerm = "")
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await this.db.Users
                    .Where(u => !db.Students.Any(s => s.UserId == u.Id))
                    .Where(u => u.Email.Contains(searchTerm)).CountAsync();
            }
            else
            {
                return await this.db.Users
                    .Where(u => !db.Students.Any(s => s.UserId == u.Id))
                    .CountAsync();
            }
        }

        public async Task<bool> CreateTeacherProfile(string id)
        {
            var userAccount = db.Users.Find(id);
            if (userAccount==null)
            {
                return false;
            }

            if (TeacherProfileExists(id))
            {
                return false;
            }

            db.Teachers.Add(new Data.Models.Teacher {UserId = id });
            var result = await db.SaveChangesAsync();
            if (result<=0)
            {
                return false;
            }

            return true;
        }

        public Data.Models.Teacher GetTeacherProfile(string id)
        {
            return db.Teachers.Find(id);
        }

        public bool TeacherProfileExists(string id)
        {
            return db.Teachers.Any(t => t.UserId == id);
        }
    }
}
