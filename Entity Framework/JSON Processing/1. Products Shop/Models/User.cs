
namespace _1.Products_Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            Friends = new HashSet<User>();
            Users = new HashSet<User>();
            ProductsBuy = new HashSet<Product>();
            ProductsSell = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBuy { get; set; }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSell { get; set; }
    }
}
