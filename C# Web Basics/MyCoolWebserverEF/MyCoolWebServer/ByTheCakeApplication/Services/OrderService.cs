namespace MyCoolWebServer.ByTheCakeApplication.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCoolWebServer.ByTheCakeApplication.Data;
    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Orders;
    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Products;

    public class OrderService : IOrderService
    {
        public IEnumerable<OrderListingViewModel> All(int userId)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var listing = db.Orders
                    .Where(o => o.UserId == userId)
                    .Select(o => new OrderListingViewModel
                    {
                            Id = o.Id,
                            CreatedOn = o.CreationDate,
                            Sum = o.Products.Select(p => p.Product.Price).Sum()
                    })
                    .ToList();

                return listing;
            }
        }

        public bool Exists(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Orders.Any(o => o.Id == id);
            }
        }

        public DetailsViewModel Details(int orderId)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var details = db.Orders 
                    .Where(o => o.Id == orderId)
                    .Select(o => new DetailsViewModel
                    {
                        Id = o.Id,
                        Products = o.Products.Select(p => new ProductViewModel
                        {
                            Id = p.ProductId,
                            Name = p.Product.Name,
                            Price = p.Product.Price
                        }).ToList(),
                        CreatedOn = o.CreationDate
                    })
                    .FirstOrDefault();

                return details;
            }
        }
    }
}
