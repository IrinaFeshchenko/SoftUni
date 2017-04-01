
namespace _4.Query_and_Export_Data
{
    using ProductsShop.Data;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        static void Main()
        {
            ProductsInRange();
            SoldProducts();
            CategoriesByProductsCount();
            UsersAndProducts();
        }

        private static void UsersAndProducts()
        {
            var context = new ProductShopContext();

            var usersQuery = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderByDescending(u => u.ProductsSold.Where(p => p.BuyerId != null).Count())
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                                .Where(p => p.BuyerId != null)
                                .Select(p => new
                                {
                                    p.Name,
                                    p.Price
                                })
                })
                .ToList();

            XDocument usersXml = new XDocument();
            XElement usersRootXml = new XElement("users");
            usersRootXml.Add(new XAttribute("count", usersQuery.Count));
            usersXml.Add(usersRootXml);

            foreach (var u in usersQuery)
            {
                XElement user = new XElement("user");
                if (u.Age != null&&u.Age!=0) { user.Add(new XAttribute("age", u.Age.ToString())); }
                if (u.LastName != null) { user.Add(new XAttribute("last-name", u.LastName)); }
                if (u.FirstName != null) { user.Add(new XAttribute("first-name", u.FirstName)); }

                XElement soldProducts = new XElement("sold-products");
                user.Add(soldProducts);
                soldProducts.Add(new XAttribute("count", u.SoldProducts.Count()));

                foreach (var p in u.SoldProducts)
                {
                    XElement product = new XElement("product");
                    product.Add(new XAttribute("price", p.Price));
                    if (p.Name != null) { product.Add(new XAttribute("name", p.Name)); }
                    soldProducts.Add(product);
                }

                usersRootXml.Add(user);
            }

            usersXml.Save("../../xmls/users-and-products.xml");
        }

        private static void CategoriesByProductsCount()
        {
            var context = new ProductShopContext();

            var categoriesQuery = context.Categories
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    c.Name,
                    ProductsCount = c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalRevenue = c.Products.Sum(p => p.Price)
                })
                .ToList();

            XDocument categoriesXml = new XDocument();
            XElement categoriesRoot = new XElement("categories");
            categoriesXml.Add(categoriesRoot);

            foreach (var c in categoriesQuery)
            {
                XElement category = new XElement("category");
                category.Add(new XAttribute("name", c.Name));
                category.Add(new XElement("products-count", c.ProductsCount));
                category.Add(new XElement("average-price", c.AveragePrice));
                category.Add(new XElement("total-revenue", c.TotalRevenue));

                categoriesRoot.Add(category);
            }

            categoriesXml.Save("../../xmls/categories-by-products.xml");
        }

        private static void SoldProducts()
        {
            var context = new ProductShopContext();

            var usersQuery = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new { p.Name, p.Price })
                })
                .ToList();

            XDocument usersXml = new XDocument();
            XElement usersRootXml = new XElement("users");
            usersXml.Add(usersRootXml);

            foreach (var u in usersQuery)
            {
                XElement user = new XElement("user");
                user.Add(new XAttribute("last-name", u.LastName ?? ""), new XAttribute("first-name", u.FirstName ?? ""));
                var soldProducts = new XElement("sold-products");
                user.Add(soldProducts);

                foreach (var p in u.SoldProducts)
                {
                    var product = new XElement("product");
                    product.Add(new XElement("name", p.Name));
                    product.Add(new XElement("price", p.Price));
                    soldProducts.Add(product);
                }

                usersRootXml.Add(user);
            }

            usersXml.Save("../../xmls/users-sold-products.xml");
        }

        private static void ProductsInRange()
        {
            var context = new ProductShopContext();
            var productsQuery = context.Products.Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    buyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToList();

            XDocument productsXml = new XDocument();
            XElement productsXmlRoot = new XElement("products");
            productsXml.Add(productsXmlRoot);

            foreach (var p in productsQuery)
            {
                XElement product = new XElement("product");

                XAttribute name = new XAttribute("name", p.Name);

                XAttribute price = new XAttribute("price", p.Price);

                XAttribute buyer = new XAttribute("buyer", p.buyerFullName);

                product.Add(new[] { buyer, price, name });

                productsXmlRoot.Add(product);
            }

            productsXml.Save("../../xmls/products-in-range.xml");
        }
    }
}
