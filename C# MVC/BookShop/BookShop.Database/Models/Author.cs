using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BookShop.Database.DataConstants;

namespace BookShop.Database.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthornameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthornameMaxLength)]
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
