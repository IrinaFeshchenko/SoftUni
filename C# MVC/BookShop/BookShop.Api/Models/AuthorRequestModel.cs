using System.ComponentModel.DataAnnotations;
using static BookShop.Database.DataConstants;

namespace BookShop.Api.Models
{
    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(AuthornameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthornameMaxLength)]
        public string LastName { get; set; }
    }
}
