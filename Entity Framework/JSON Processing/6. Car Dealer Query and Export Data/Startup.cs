
namespace _6.Car_Dealer_Query_and_Export_Data
{
    using _4.Car_Dealer;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            OrderedCustomers();
            CarsFromMakeToyota();
            LocalSuppliers();
            CarsWithTheirListOfParts();
            TotalSalesByCustomer();
            SalesWithAppliedDiscount();
        }

        private static void SalesWithAppliedDiscount()
        {
            var context = new CarsDBContext();
            var query = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    s.Discount,
                    price = s.Car.Parts.Sum(p=>p.Price)
                })
                .AsEnumerable()
                .Select(s=> new
                {
                    s.car,
                    s.customerName,
                    s.Discount,
                    s.price,
                    pricewithDiscount = s.price * (decimal)s.Discount
                });

            var json = JsonConvert.SerializeObject(query, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\sales-discounts.json", json);
        }

        private static void TotalSalesByCustomer()
        {
            var context = new CarsDBContext();
            decimal youngDriverDiscount = 0.95m;
            var query = context.Customers.Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Select(s => new { price = s.Car.Parts.Sum(p => p.Price),s.Discount}),
                    c.IsYoungDriver
                })
                .AsEnumerable()
                .Select(c=> new
                {
                    c.fullName,
                    c.boughtCars,
                    spentMoney = (c.spentMoney.Sum(s=>s.price*(decimal)s.Discount)) * (c.IsYoungDriver? youngDriverDiscount : 1)
                });

            var json = JsonConvert.SerializeObject(query, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\customers-total-sales.json", json);
        }

        private static void CarsWithTheirListOfParts()
        {
            var context = new CarsDBContext();

            var query = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,                 
                    },
                    parts = c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });

            var json = JsonConvert.SerializeObject(query,Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\cars-and-parts.json", json);
        }

        private static void LocalSuppliers()
        {
            var context = new CarsDBContext();

            var query = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                });

            var json = JsonConvert.SerializeObject(query, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\local-suppliers.json", json);
        }

        private static void CarsFromMakeToyota()
        {
            var context = new CarsDBContext();

            var query = context.Cars.Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);

            var json = JsonConvert.SerializeObject(query, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\toyota-cars.json", json);
        }

        private static void OrderedCustomers()
        {
            var context = new CarsDBContext();

            var query = context.Customers.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver);

            var json = JsonConvert.SerializeObject(query, Formatting.Indented);

            File.WriteAllText("..\\..\\Jsons\\ordered-customers.json", json);
        }
    }
}
