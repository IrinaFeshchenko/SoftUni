using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Teamwork.Services.Teacher.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Teachers.Models.Students
{
    public class TeacherStudentsViewModel
    {
        public IEnumerable<TeacherStudentsDto> Students { get; set; }

        public IEnumerable<SelectListItem> Courses { get; set; }

        public string SearchTerm { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalItems / TeacherCoursesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
