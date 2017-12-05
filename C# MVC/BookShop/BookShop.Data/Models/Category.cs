using System.ComponentModel.DataAnnotations;
using static BookShop.Data.DataConstants;

namespace BookShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public int AutrhorId { get; set; }

        public Author Author { get; set; }
    }
}
