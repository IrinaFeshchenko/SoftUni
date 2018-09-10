using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User: IdentityUser
    {
        public string Avatar { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string NickName { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public List<Topic> Topics { get; set; }

        public List<Reply> Replies { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<Contact> Friends { get; set; }
    }
}
