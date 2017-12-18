using System.Collections.Generic;
using System.Threading.Tasks;
using Teamwork.Services.Admin.Models;

namespace Teamwork.Services.Admin
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync(string searchTerm = "", int page = 1);

        Task<int> TotalAsync(string searchTerm = "");

        Task<bool> CreateTeacherProfile(string id);

        bool TeacherProfileExists(string id);

        Data.Models.Teacher GetTeacherProfile(string id);
    }
}
