namespace BookShopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }

    public class Book
    {
        public Book()
        {
            Categories = new HashSet<Category>();
            RelatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Desctiption { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}
