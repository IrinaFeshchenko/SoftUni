namespace _3.Sales_Database
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        public StoreLocation()
        {
        }

        public StoreLocation(string locationName)
        {
            SalesInStore = new HashSet<Sale>();
            this.LocationName = locationName;
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<Sale> SalesInStore { get; set; }
    }
}
