namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Linq;
    using Data;
    using Infrastructure;
    using MyCoolWebServer.ByTheCakeApplication.Services;
    using MyCoolWebServer.Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using ViewModels;

    public class ShoppingController : BaseController
    {
        private readonly IProductService products;
        private readonly IUserService users;
        private readonly IShoppingService shopping;

        public ShoppingController()
        {
            this.products = new ProductService();
            this.users = new UserService();
            this.shopping = new ShoppingService();
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            if (!this.products.Exists(id))
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            shoppingCart.ProductIds.Add(id);

            var redirectUrl = "/search";

            const string SearchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(SearchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{SearchTermKey}={req.UrlParameters[SearchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.ProductIds.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var productsInCart = this.products.FindProductsInCart(shoppingCart.ProductIds).ToList();

                var items = productsInCart
                    .Select(i => $"<div>{i.Name} - ${i.Price:F2}</div><br />");

                var totalPrice = productsInCart
                    .Sum(p => p.Price);
                
                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            var productIds = shoppingCart.ProductIds;
            if (!productIds.Any())
            {
                return new RedirectResponse("/");
            }

            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);
            var userId = this.users.GetUserId(username);

            if (userId == null)
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            this.shopping.CreateOrder(userId.Value, productIds);

            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).ProductIds.Clear();

            return this.FileViewResponse(@"shopping\finish-order");
        }
    }
}
