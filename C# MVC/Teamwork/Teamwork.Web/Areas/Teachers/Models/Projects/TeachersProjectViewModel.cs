using System;

namespace Teamwork.Web.Areas.Teachers.Models.Projects
{
    public class TeachersProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
