using System;
using System.Collections.Generic;
using Teamwork.Services.Teacher.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Teachers.Models.Courses
{
    public class TeacherCoursesListingViewModel
    {
        public IEnumerable<TeacherCourseDto> TeacherCourses { get; set; }

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
