using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Local_Store
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new LocalStoreDBContext();

            var product = new Product()
            {
                Name = "Cup",
                DistributorName = "Fairtrade",
                Description = "Tea Cup",
                Price = 4.50m
            };
            context.Products.Add(product);

            product = new Product()
            {
                Name = "Plate",
                DistributorName = "Fairtrade",
                Description = "Dinner Plate",
                Price = 7.80m
            };
            context.Products.Add(product);

            product = new Product()
            {
                Name = "Vase",
                DistributorName = "Homebase",
                Description = "Porcelan Vase",
                Price = 9.90m
            };
            context.Products.Add(product);

            context.SaveChanges();        
        }
    }
}
