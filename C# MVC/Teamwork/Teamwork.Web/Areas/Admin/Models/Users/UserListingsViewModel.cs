using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Teamwork.Services.Admin.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Admin.Models.Users
{
    public class UserListingsViewModel
    {
        public string SearchTerm { get; set; }

        public int TotalUsers { get; set; }

        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalUsers / AdminUsersPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
