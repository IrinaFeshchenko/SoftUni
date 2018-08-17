using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Data.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime replyDate { get; set; }

        [Required]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
