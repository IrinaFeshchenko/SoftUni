
namespace _5.Car_Dealer_Import_Data
{
    using _4.Car_Dealer;
    using _4.Car_Dealer.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            ImportSuppliers();
            ImportParts();
            ImportCars();
            ImportCustomers();
        }

        private static void ImportSuppliers()
        {
            var json = File.ReadAllText("..\\..\\jsons\\supplier.json");

            var objects = JsonConvert.DeserializeObject<List<Supplier>>(json);

            var context = new CarsDBContext();

            context.Suppliers.AddRange(objects);

            context.SaveChanges();
        }

        private static void ImportParts()
        {
            var json = File.ReadAllText("..\\..\\jsons\\parts.json");

            var objects = JsonConvert.DeserializeObject<List<Part>>(json);

            var context = new CarsDBContext();

            int count = context.Suppliers.Count();
            int num = 0;
            foreach (var p in objects)
            {
                p.SupplierId = num % count + 1;
                num++;
            }

            context.Parts.AddRange(objects);

            context.SaveChanges();
        }

        private static void ImportCustomers()
        {
            var json = File.ReadAllText("..\\..\\jsons\\customers.json");

            var objects = JsonConvert.DeserializeObject<List<Customer>>(json);

            var context = new CarsDBContext();

            context.Customers.AddRange(objects);

            context.SaveChanges();
        }

        private static void ImportCars()
        {
            var json = File.ReadAllText("..\\..\\jsons\\users.json");

            var objects = JsonConvert.DeserializeObject<List<Car>>(json);

            var context = new CarsDBContext();

            int count = context.Parts.Count();
            int partsCount = 10;
            int num = 0;
            foreach (var c in objects)
            {
                for (int i = 0; i < partsCount; i++)
                {
                    c.Parts.Add(context.Parts.Find(num%count+1));
                }

                num++;
                partsCount++;
                if (partsCount == 21)
                {
                    partsCount = 10;
                }
            }

            context.Cars.AddRange(objects);

            context.SaveChanges();
        }
    }
}
