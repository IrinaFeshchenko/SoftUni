
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
            ImportSales();
        }

        private static void ImportSales()
        {

            var objects = new List<Sale>();

            var context = new CarsDBContext();

            double[] discounts = {1,0.95,0.9,0.85,0.8,0.7,0.6,0.5};

            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            int discountCount = discounts.Length;

            int num = 0;
            foreach (var car in context.Cars.ToList())
            {
                int customer = ((num + 7) % customersCount) + 1;
                double discount = discounts[num % discountCount];

                var sale = new Sale()
                {
                    CarId = car.Id,
                    CustomerId = customer,
                    Discount = discount
                };

                objects.Add(sale);
                num++;
            }

            context.Sales.AddRange(objects);

            context.SaveChanges();
        }

        private static void ImportSuppliers()
        {
            var json = File.ReadAllText("..\\..\\jsons\\suppliers.json");

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
            var json = File.ReadAllText("..\\..\\jsons\\cars.json");

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
