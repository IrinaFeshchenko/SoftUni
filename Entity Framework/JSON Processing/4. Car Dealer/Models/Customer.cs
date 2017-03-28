
namespace _4.Car_Dealer.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
