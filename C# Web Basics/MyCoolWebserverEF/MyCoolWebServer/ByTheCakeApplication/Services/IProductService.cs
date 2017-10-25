namespace MyCoolWebServer.ByTheCakeApplication.Services
{
    using System.Collections.Generic;

    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Products;

    public interface IProductService
    {
        void Create(string name, decimal price, string imageUrl);

        IEnumerable<ProductListingViewModel> All(string searchTerm = null);

        ProductDetailsViewModel FindById(int id);

        bool Exists(int id);

        IEnumerable<ProductInCartViewModel> FindProductsInCart(IEnumerable<int> ids);
    }
}
