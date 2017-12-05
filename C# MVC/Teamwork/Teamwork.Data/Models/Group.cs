using System;

namespace Teamwork.Data.Models
{
    public class Group
    {
        public int Id { get; set; }

        public User Creator { get; set; }

        public string Introduction { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LateSubmisionDate { get; set; }


    }
}
