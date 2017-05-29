namespace _3.Sales_Database
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
        }

        public Customer(string name, string email, string credidCardNumber)
        {
            SalesForCustomer = new HashSet<Sale>();
            this.Name = name;
            this.Email = email;
            this.CreditCardNumber = credidCardNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> SalesForCustomer { get; set; }
    }
}
