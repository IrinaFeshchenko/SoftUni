namespace _7.Add_Default_Age
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int? Customer_Id { get; set; }

        public int? Product_Id { get; set; }

        public int? StoreLocation_Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        public virtual StoreLocation StoreLocation { get; set; }
    }
}
