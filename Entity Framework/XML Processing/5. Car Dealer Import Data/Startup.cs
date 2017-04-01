
namespace _5.Car_Dealer_Import_Data
{
    using CarDealer.Data;
    using CarDealer.Models;
    using System.Linq;
    using System.Xml.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            ImportSuppliers();
            ImportParts();
            ImportCars();
            ImportCustomers();
            ImportSales();
        }

        private static void ImportSales()
        {
            var context = new CarDealerContext();
            decimal[] discount = new decimal[] {1,0.95m,0.90m,0.85m,0.8m,0.7m,0.6m,0.5m };
            var customersCount = context.Customers.Count();
            var carsCount = context.Cars.Count();
            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = rnd.Next(1,carsCount+1),
                    CustomerId = rnd.Next(1,customersCount+1),
                    Discount = discount[rnd.Next(0,discount.Length)]
                };

                context.Sales.Add(sale);
            }

            context.SaveChanges();
        }

        private static void ImportCustomers()
        {
            var context = new CarDealerContext();
            XDocument customersXml = XDocument.Load("../../xmls/customers.xml");
            XElement customerRoot = customersXml.Element("customers");

            foreach (var c in customerRoot.Elements())
            {
                Customer customer = new Customer()
                {
                    Name = c.Attribute("name")?.Value,
                    BirthDate = DateTime.Parse(c.Element("birth-date")?.Value),
                    IsYoungDriver = bool.Parse(c.Element("is-young-driver")?.Value)
                };

                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }

        private static void ImportCars()
        {
            var context = new CarDealerContext();
            XDocument carsXml = XDocument.Load("../../xmls/cars.xml");
            XElement carsRoot = carsXml.Element("cars");

            int num = 19;
            int partsCount = context.Parts.Count();

            foreach (var c in carsRoot.Elements())
            {
                Car car = new Car()
                {
                    Make = c.Element("make")?.Value,
                    Model = c.Element("model")?.Value,
                    TravelledDistance = long.Parse(c.Element("travelled-distance")?.Value)
                };

                for (int i = 0; i < 10+(num%21); i++)
                {
                    car.Parts.Add(context.Parts.Find((num++%partsCount)+1));
                }

                context.Cars.Add(car);
            }

            context.SaveChanges();
        }

        private static void ImportParts()
        {
            var context = new CarDealerContext();
            XDocument partsXml = XDocument.Load("../../xmls/parts.xml");
            XElement partsRoot = partsXml.Element("parts");

            int num = 17;
            int suppliersCount = context.Suppliers.Count();

            foreach (var p in partsRoot.Elements())
            {
                Part part = new Part()
                {
                    Name = p.Attribute("name")?.Value,
                    Price = decimal.Parse(p.Attribute("price")?.Value),
                    Quantity = int.Parse(p.Attribute("quantity")?.Value)
                };
                part.SupplierId = (num++ % suppliersCount) + 1;
                context.Parts.Add(part);
            }

            context.SaveChanges();
        }

        private static void ImportSuppliers()
        {
            var context = new CarDealerContext();
            XDocument suppliersXml = XDocument.Load("../../xmls/suppliers.xml");
            XElement suppliersRoot = suppliersXml.Element("suppliers");

            foreach (var s in suppliersRoot.Elements())
            {
                Supplier supplier = new Supplier()
                {
                    Name = s.Attribute("name")?.Value,
                    IsImporter = bool.Parse(s.Attribute("is-importer")?.Value)
                };

                context.Suppliers.Add(supplier);
            }

            context.SaveChanges();
        }
    }
}
