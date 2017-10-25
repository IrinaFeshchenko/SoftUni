namespace MyCoolWebServer.ByTheCakeApplication.ViewModels.Orders
{
    using System;

    public class OrderListingViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Sum { get; set; }
    }
}
