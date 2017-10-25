namespace MyCoolWebServer.ByTheCakeApplication.Services
{
    using System.Collections.Generic;
    using MyCoolWebServer.ByTheCakeApplication.Data.Models;
    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Orders;

    public interface IOrderService
    {
        IEnumerable<OrderListingViewModel> All(int userId);

        bool Exists(int id);

        DetailsViewModel Details(int orderId);
    }
}
