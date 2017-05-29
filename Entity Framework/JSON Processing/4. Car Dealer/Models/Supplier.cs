namespace _4.Car_Dealer.Models
{
    using System.Collections.Generic;

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
