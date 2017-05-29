
namespace _6.Car_Dealer_Query_and_Export_Data
{
    using CarDealer.Data;
    using System.Linq;
    using System.Xml.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            Cars();
            CarsFromMakeFerrari();
            LocalSuppliers();
            CarsWithTheirListOfParts();
            TotalSalesByCustomer();
            SalesWithAppliedDiscount();
        }

        private static void SalesWithAppliedDiscount()
        {
            var context = new CarDealerContext();

            var sales = context.Sales.Select(s => new
            {
                s.Car,
                s.Customer.Name,
                Price = s.Car.Parts.Sum(p=>p.Price),
                s.Discount,
                PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) * s.Discount
            }).ToList();

            XDocument salesXml = new XDocument();
            XElement salesRoot = new XElement("sales");
            salesXml.Add(salesRoot);

            foreach (var s in sales)
            {
                XElement sale = new XElement("sale");
                XElement car = new XElement("car");
                car.Add(new XAttribute("travelled-distance",s.Car.TravelledDistance),new XAttribute("model",s.Car.Model), new XAttribute("make", s.Car.Make));
                sale.Add(car);
                sale.Add(new XElement("customer-name",s.Name));
                sale.Add(new XElement("discount", s.Discount));
                sale.Add(new XElement("price", s.Price));
                sale.Add(new XElement("price-with-discount", s.PriceWithDiscount));
                salesRoot.Add(sale);
            }

            salesXml.Save("../../export/sales-discounts.xml");
        }

        private static void TotalSalesByCustomer()
        {
            var context = new CarDealerContext();

            var customers = context.Customers.Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    c.Name,
                    BoughtCarsCount = c.Sales.Count,
                    TotalSpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price) * s.Discount)
                })
                .OrderByDescending(c => c.TotalSpentMoney)
                .ThenByDescending(c => c.BoughtCarsCount)
                .ToList();

            XDocument customersXml = new XDocument();
            XElement customersRoot = new XElement("customers");
            customersXml.Add(customersRoot);

            foreach (var c in customers)
            {
                XElement customer = new XElement("customer");
                customer.Add(new XAttribute("spent-money", c.TotalSpentMoney),
                             new XAttribute("bought-cars", c.BoughtCarsCount),
                             new XAttribute("full-name", c.Name));
                customersRoot.Add(customer);
            }

            customersXml.Save("../../export/customers-total-sales.xml");
        }

        private static void CarsWithTheirListOfParts()
        {
            var context = new CarDealerContext();

            var cars = context.Cars.Select(c => new
            {
                c.Make,
                c.Model,
                c.TravelledDistance,
                Parts = c.Parts.Select(p => new
                {
                    PartName = p.Name,
                    p.Price
                })
            })
                .ToList();

            XDocument carsXml = new XDocument();
            XElement carsRoot = new XElement("cars");
            carsXml.Add(carsRoot);

            foreach (var c in cars)
            {
                XElement car = new XElement("car");
                car.Add(new XAttribute("travelled-distance", c.TravelledDistance),
                        new XAttribute("model", c.Model),
                        new XAttribute("make", c.Make));
                XElement parts = new XElement("parts");
                car.Add(parts);

                foreach (var p in c.Parts)
                {
                    XElement part = new XElement("part");
                    part.Add(new XAttribute("price", p.Price), new XAttribute("name", p.PartName));
                    parts.Add(part);
                }

                carsRoot.Add(car);
            }

            carsXml.Save("../../export/cars-and-parts.xml");
        }

        private static void LocalSuppliers()
        {
            var context = new CarDealerContext();

            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    partsCount = s.Parts.Count()
                })
                .ToList();

            XDocument carsXml = new XDocument();
            XElement carsRoot = new XElement("suppliers");
            carsXml.Add(carsRoot);

            foreach (var s in suppliers)
            {
                XElement supplier = new XElement("supplier");
                supplier.Add(new XAttribute("parts-count", s.partsCount),
                             new XAttribute("name", s.Name),
                             new XAttribute("id", s.Id));
                carsRoot.Add(supplier);
            }

            carsXml.Save("../../export/local-suppliers.xml");
        }

        private static void CarsFromMakeFerrari()
        {
            var context = new CarDealerContext();

            var cars = context.Cars.Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            XDocument carsXml = new XDocument();
            XElement carsRoot = new XElement("cars");
            carsXml.Add(carsRoot);

            foreach (var c in cars)
            {
                XElement car = new XElement("car");
                car.Add(new XAttribute("travelled-distance", c.TravelledDistance),
                        new XAttribute("model", c.Model),
                        new XAttribute("id", c.Id));
                carsRoot.Add(car);
            }

            carsXml.Save("../../export/ferrari-cars.xml");
        }

        private static void Cars()
        {
            var context = new CarDealerContext();

            var cars = context.Cars.Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToList();

            XDocument carsXml = new XDocument();
            XElement carsRoot = new XElement("cars");
            carsXml.Add(carsRoot);

            foreach (var c in cars)
            {
                XElement car = new XElement("car");
                car.Add(new XElement("make", c.Make));
                car.Add(new XElement("model", c.Model));
                car.Add(new XElement("travelled-distance", c.TravelledDistance));
                carsRoot.Add(car);
            }

            carsXml.Save("../../export/cars.xml");
        }
    }
}
