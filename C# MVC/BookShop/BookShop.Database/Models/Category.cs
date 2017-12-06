using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BookShop.Database.DataConstants;

namespace BookShop.Database.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public List<CategoryBooks> CategoryBooks { get; set; } = new List<CategoryBooks>();
    }
}
