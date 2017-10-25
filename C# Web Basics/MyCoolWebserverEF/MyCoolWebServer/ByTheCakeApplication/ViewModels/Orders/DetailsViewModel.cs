namespace MyCoolWebServer.ByTheCakeApplication.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;

    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Products;

    public class DetailsViewModel
    {
        public int Id { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
