using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Car_Dealer.Models
{
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

        public int TraveledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
