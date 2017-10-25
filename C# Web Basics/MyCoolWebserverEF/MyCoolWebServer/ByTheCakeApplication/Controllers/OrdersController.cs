namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Linq;
    using MyCoolWebServer.ByTheCakeApplication.Services;
    using MyCoolWebServer.Infrastructure;
    using MyCoolWebServer.Server.Http;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;

    public class OrdersController : BaseController
    {
        private readonly IOrderService orders;

        private readonly IUserService users;

        public OrdersController()
        {
            this.orders = new OrderService();
            this.users = new UserService();
        }

        public IHttpResponse ShowOrders(IHttpRequest req)
        {
            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);
            var userId = this.users.GetUserId(username);

            if (userId == null)
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            var listing = this.orders
                .All(userId.Value)
                .Select(o => $@"<tr><td><a href=""\order\{o.Id}"">{o.Id}</a></td><td>{o.CreatedOn.ToShortDateString()}</td><td>${o.Sum:F2}</td></tr>");

            if (listing.Any())
            {
                var ordersTable = string.Join(Environment.NewLine, listing);
                this.ViewData["ordersListing"] = ordersTable;
            }
            else
            {
                this.ViewData["ordersListing"] = "No Orders";
            }


            return this.FileViewResponse(@"\orders\orderslisting");
        }

        public IHttpResponse Details(IHttpRequest req)
        {
            var orderId = int.Parse(req.UrlParameters["id"]);

            if (!this.orders.Exists(orderId))
            {
                return new NotFoundResponse();
            }

            var order = this.orders.Details(orderId);

            if (order == null)
            {
                throw new InvalidOperationException($"Order {orderId} not found");
            }



            var listing = order
                .Products
                .Select(p => $@"<tr><td><a href=""\cakes\{p.Id}"">{p.Name}</a></td><td>${p.Price:F2}</td></tr>)");

            var detailsTable = string.Join(Environment.NewLine, listing);

            this.ViewData["orderId"] = order.Id.ToString();
            this.ViewData["productsTable"] = detailsTable;
            this.ViewData["createdOn"] = order.CreatedOn.ToShortDateString();

            return this.FileViewResponse(@"\orders\details");
        }
    }
}
