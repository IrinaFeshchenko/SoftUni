namespace _2.Import_Products_Shop_data
{
    using _1.Products_Shop;
    using _1.Products_Shop.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            ImportUsers();
            ImportProducts();
            ImportCategories();
        }

        private static void ImportUsers()
        {
            var usersJson = File.ReadAllText("..\\..\\jsons\\users.json");

            var users = JsonConvert.DeserializeObject<List<User>>(usersJson);

            var context = new ProductsShopDBContext();

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        private static void ImportProducts()
        {
            var producsJson = File.ReadAllText("..\\..\\jsons\\products.json");

            var products = JsonConvert.DeserializeObject<List<Product>>(producsJson);

            var context = new ProductsShopDBContext();

            int num = 0;
            int usersCount = context.Users.Count();
            foreach (var p in products)
            {
                p.SellerId = (num % usersCount) + 1;

                if (num % 3 != 0)
                {
                    p.BuyerId = (num * 2 % usersCount) + 1;
                }
                num++;
            }

            context.Products.AddRange(products);

            context.SaveChanges();
        }

        private static void ImportCategories()
        {
            var categoriesJson = File.ReadAllText("..\\..\\jsons\\categories.json");

            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            var context = new ProductsShopDBContext();

            int num = 0;
            var products = context.Products.ToList();

            foreach (var p in products)
            {
                categories[num++ % categories.Count].Products.Add(p);
            }

            context.Categories.AddRange(categories);

            context.SaveChanges();
        }
    }
}
