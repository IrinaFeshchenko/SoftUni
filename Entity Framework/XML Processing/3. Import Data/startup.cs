
namespace _3.Import_Data
{
    using ProductsShop.Data;
    using ProductsShop.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        static void Main()
        {
            ImportUsers();
            ImportProducts();
            ImportCategories();
        }

        private static void ImportCategories()
        {
            var context = new ProductShopContext();

            XDocument categoriesXml = XDocument.Load("../../xmls/categories.xml");

            var categories = categoriesXml.Root.Elements()
                .Select(c=> new Category()
                {
                    Name = c.Element("name")?.Value
                })
                .ToList();

            int num = 17;
            int categoriesCount = context.Categories.Count();
            foreach (var p in context.Products)
            {
                categories[num++ % categories.Count].Products.Add(p);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts()
        {
            var context = new ProductShopContext();

            XDocument productsXml = XDocument.Load("../../xmls/products.xml");

            var products = productsXml.Root.Elements();

            int num = 1;
            int usersCount = context.Users.Count();
            foreach (var p in products)
            {
                Product product = new Product()
                {
                    Name = p.Element("name")?.Value,
                    Price = decimal.Parse(p.Element("price")?.Value),
                };
                product.SelledId = context.Users.Find(((num + 17) % usersCount) +1).Id;

                if (num % 3 != 0)
                {
                    product.BuyerId = (num % usersCount) +1;
                }
                num++;
                context.Products.Add(product);
            }
            context.SaveChanges();
        }

        private static void ImportUsers()
        {
            var context = new ProductShopContext();
            XDocument usersXml = XDocument.Load("../../xmls/users.xml");

            List<User> users = usersXml.Root.Elements().Select(u => new User()
            {
                FirstName = u.Attribute("first-name")?.Value,
                LastName = u.Attribute("last-name")?.Value,
                Age = int.Parse(u.Attribute("age")?.Value)
            }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
