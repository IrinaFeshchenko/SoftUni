
namespace _3.Query_and_Export_Data
{
    using _1.Products_Shop;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            // ProductsInRange();
            //SuccessfullySoldProducts();
            //CategoriesByProductsCount();
            UsersAndProducts();
        }

        private static void UsersAndProducts()
        {
            var context = new ProductsShopDBContext();

            var usersProducts = context.Users
                .Where(u => u.ProductsSell.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSell.Where(p => p.Buyer != null).Count())
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = u.ProductsSell.Where(p=>p.Buyer!=null)
                        .Select(p=> new
                        {
                            p.Name,
                            p.Price
                        })
                })
                .ToList();

            var usersProductsJson = JsonConvert.SerializeObject(new { usersCount = usersProducts.Count, users = usersProducts }, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\users-and-products.json", usersProductsJson);
        }

        private static void CategoriesByProductsCount()
        {
            var context = new ProductsShopDBContext();

            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRevenue = c.Products.Sum(p => p.Price)
                });

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\categories-by-products.json", categoriesJson);
        }

        private static void SuccessfullySoldProducts()
        {
            var context = new ProductsShopDBContext();

            var soldProducts = context.Users.Where(u => u.ProductsSell.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSell.Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        p.Buyer.FirstName,
                        p.Buyer.LastName
                    })
                });

            var soldProductsJson = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\users-sold-products.json", soldProductsJson);
        }

        private static void ProductsInRange()
        {
            var context = new ProductsShopDBContext();

            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new { p.Name, p.Price, FullName = p.Seller.FirstName ?? "" + " " + p.Seller.LastName })
                .ToList();

            var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\products-in-range.json", productsJson);
        }
    }
}
