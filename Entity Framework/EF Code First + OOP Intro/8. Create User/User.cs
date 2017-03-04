namespace _8.Create_User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30,MinimumLength =4)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+<>?]).{6,50})")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+[.-_]*[A-Za-z0-9]+@\w+[.]+\w+$")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(1024*1024)]
        public byte[] Picture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int? Age { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
