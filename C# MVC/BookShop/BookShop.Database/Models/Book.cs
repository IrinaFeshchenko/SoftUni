using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BookShop.Database.DataConstants;

namespace BookShop.Database.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }

        public System.DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public Author Autor { get; set; }

        public List<CategoryBooks> CategoryBooks { get; set; } = new List<CategoryBooks>();
    }
}
