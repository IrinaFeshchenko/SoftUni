using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_Hierarchy
{
    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
