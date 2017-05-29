namespace _3.Sales_Database
{
    using System;
    using System.Data.Entity;

    public class MyDbInitializer : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            Product car = new Product("Car", 8, 2000);
            Product motorcycle = new Product("Motorcycle", 10, 1000);
            Product truck = new Product("Truck", 5, 5000);
            Product airplane = new Product("Airplane", 18, 23000);
            Product ship = new Product("Ship", 4, 56000);

            context.Products.Add(car);
            context.Products.Add(motorcycle);
            context.Products.Add(truck);
            context.Products.Add(airplane);
            context.Products.Add(ship);

            Customer jim = new Customer("Jim", "Jim@yahoo.com", "2h32kh32kh32k");
            Customer jon = new Customer("Jon", "jon@gmail.com", "45l6j4l5j6l4");
            Customer pit = new Customer("Pit", "pit@hotmail.com", "jl45l6jl4k5l6j");
            Customer nick = new Customer("Nick", "nick@gmail.com", "36oiu456ouo456");
            Customer bill = new Customer("Bill", "bill@yahoo.com", "1cty2y34y2f4y234");

            context.Customers.Add(jim);
            context.Customers.Add(jon);
            context.Customers.Add(pit);
            context.Customers.Add(nick);
            context.Customers.Add(bill);

            StoreLocation losAngeles = new StoreLocation("Los Angeles");
            StoreLocation sanFrancisco = new StoreLocation("San Francisco");
            StoreLocation newYork = new StoreLocation("New York");
            StoreLocation london = new StoreLocation("London");
            StoreLocation manchester = new StoreLocation("Manchester");

            context.StoreLocations.Add(losAngeles);
            context.StoreLocations.Add(sanFrancisco);
            context.StoreLocations.Add(newYork);
            context.StoreLocations.Add(london);
            context.StoreLocations.Add(manchester);

            Sale carSale = new Sale(car, jim, losAngeles, DateTime.Now);
            Sale motorcycleSale = new Sale(motorcycle, jon, sanFrancisco, DateTime.Now);
            Sale truckSale = new Sale(truck, pit, newYork, DateTime.Now);
            Sale airplaneSale = new Sale(airplane, nick, london, DateTime.Now);
            Sale shipSale = new Sale(ship, bill, manchester, DateTime.Now);

            context.Sales.Add(carSale);
            context.Sales.Add(motorcycleSale);
            context.Sales.Add(truckSale);
            context.Sales.Add(airplaneSale);
            context.Sales.Add(shipSale);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
