using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Admin.Models;

namespace Teamwork.Services.Admin
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}
