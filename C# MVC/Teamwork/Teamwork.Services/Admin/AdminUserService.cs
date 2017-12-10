using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Admin.Models;
using Teamwork.Web.Data;

namespace Teamwork.Services.Admin
{
    public class AdminUserService : IAdminUserService
    {
        private readonly TeamworkDbContext db;

        public AdminUserService(TeamworkDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
                .Users
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();
    }
}
