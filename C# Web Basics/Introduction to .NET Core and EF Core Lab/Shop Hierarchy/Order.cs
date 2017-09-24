namespace Shop_Hierarchy
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ItemOrder> ItemOrder { get; set; } = new List<ItemOrder>();
    }
}
