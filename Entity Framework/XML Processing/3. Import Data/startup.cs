
namespace _3.Import_Data
{
    using ProductsShop.Data;
    using ProductsShop.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        static void Main()
        {
            ImportUsers();
            //ImportProducts();
            //ImportCategories();
        }

        private static void ImportCategories()
        {
            throw new NotImplementedException();
        }

        private static void ImportProducts()
        {
            throw new NotImplementedException();
        }

        private static void ImportUsers()
        {
            var context = new ProductShopContext();
            XDocument xml = XDocument.Load("../../xmls/users.xml");

            List<User> users = xml.Root.Elements().Select(u=>new User()
            {
                FirstName = u.Attribute("first-name").Value,
                LastName = u.Attribute("last-name").Value,
                Age = int.Parse(u.Attribute("Age").Value)
            }).ToList();

            context.Users.AddRange(users);
        }
    }
}
