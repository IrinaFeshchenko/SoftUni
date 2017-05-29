
namespace _4.Car_Dealer.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
            Parts = new HashSet<Part>();
        }
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }

        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; }
    }
}
