namespace _3.Sales_Database
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
        }

        public Product(string name, double quantity, decimal price)
        {
            SalesOfProduct = new HashSet<Sale>();
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public ICollection<Sale> SalesOfProduct { get; set; }
    }
}
