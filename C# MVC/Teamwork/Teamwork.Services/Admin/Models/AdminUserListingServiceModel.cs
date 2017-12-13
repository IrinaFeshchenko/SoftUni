using System.Collections.Generic;
using Teamwork.Common.Mapping;
using Teamwork.Data.Models;

namespace Teamwork.Services.Admin.Models
{
    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
    }
}
