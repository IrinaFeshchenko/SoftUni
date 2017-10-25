namespace MyCoolWebServer.ByTheCakeApplication.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MyCoolWebServer.ByTheCakeApplication.Data;
    using MyCoolWebServer.ByTheCakeApplication.Data.Models;
    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Products;

    public class ProductService : IProductService
    {
        public void Create(string name, decimal price, string imageUrl)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var product = new Product { Name = name, Price = price, ImageUrl = imageUrl };

                db.Add(product);
                db.SaveChanges();
            }
        }

        public IEnumerable<ProductListingViewModel> All(string searchTerm = null)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var products = db.Products.AsQueryable();

                if (searchTerm != null)
                {
                    products = products.Where(p => p.Name.ToLower().Contains(searchTerm));
                }

                return products
                    .Select(pr => new ProductListingViewModel
                    {
                        Id = pr.Id,
                        Name = pr.Name,
                        Price = pr.Price
                    })
                    .ToList();
            }
        }

        public ProductDetailsViewModel FindById(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Products
                    .Where(p => p.Id == id)
                    .Select(p => new ProductDetailsViewModel
                    {
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl
                    })
                    .FirstOrDefault();
            }
        }

        public bool Exists(int id)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Products.Any(p => p.Id == id);
            }
        }

        public IEnumerable<ProductInCartViewModel> FindProductsInCart(IEnumerable<int> ids)
        {
            using (var db = new ByTheCakeDbContext())
            {
                return db.Products
                    .Where(p => ids.Contains(p.Id))
                    .Select(p => new ProductInCartViewModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList();
            }
        }
    }
}
