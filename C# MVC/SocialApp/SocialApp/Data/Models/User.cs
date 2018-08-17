using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Data.Models
{
    public class User: IdentityUser
    {
        public string Avatar { get; set; }

        [Required]
        public string NickName { get; set; }

        public List<Topic> Topics { get; set; }

        public List<Reply> Replies { get; set; }
    }
}
