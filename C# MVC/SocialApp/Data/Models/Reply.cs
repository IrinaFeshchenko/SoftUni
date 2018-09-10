using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime ReplyDate { get; set; }

        [Required]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
