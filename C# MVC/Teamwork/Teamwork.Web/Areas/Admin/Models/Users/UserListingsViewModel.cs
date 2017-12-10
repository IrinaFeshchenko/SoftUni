using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Teamwork.Services.Admin.Models;

namespace Teamwork.Web.Areas.Admin.Models.Users
{
    public class UserListingsViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
