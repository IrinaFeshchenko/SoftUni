using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Car_Dealer.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Parts = new HashSet<Part>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
