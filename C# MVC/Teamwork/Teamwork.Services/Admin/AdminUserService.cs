using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Admin.Models;
using Teamwork.Web.Data;
using System.Linq;
using static Teamwork.Services.ServiceConstants;

namespace Teamwork.Services.Admin
{
    public class AdminUserService : IAdminUserService
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

        public async Task<int> TotalAsync()
            => await this.db.Users.CountAsync();
    }
}
