namespace Shop_Hierarchy
{
    using System;

    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (ShopDbContext context = new ShopDbContext())
            {
                ClearDatabase(context);
                FillSalesmen(context);
                ReadCommands(context);
                //PrintSalesmanWithCustomersCount(context);
                PrintCustomersWithOrdersAndRevewCount(context);
            }
        }

        private static void PrintCustomersWithOrdersAndRevewCount(ShopDbContext context)
        {
            var customerData = context
                .Customer
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenByDescending(c => c.Reviews)
                .ToList();

            foreach (var customer in customerData)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine($"Orders: {customer.Orders}");
                Console.WriteLine($"Revews: {customer.Reviews}");
            }
        }

        private static void PrintSalesmanWithCustomersCount(ShopDbContext context)
        {
            var salesmenData = context
               .Salesman
                .Select(s => new
                {
                    s.Name,
                    Customers = s.Customers.Count
                })
                .OrderByDescending(s => s.Customers)
                .ThenBy(s => s.Name)
                .ToList();


            foreach (var salesman in salesmenData)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.Customers} customers");
            }
        }

        private static void ReadCommands(ShopDbContext context)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string arguments = parts[1];

                switch (command)
                {
                    case "register":
                        Register(context, arguments);
                        break;
                    case "order":
                        SaveOrder(context, arguments);
                        break;
                    case "review":
                        SaveReview(context, arguments);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SaveReview(ShopDbContext context, string arguments)
        {
            int customerId = int.Parse(arguments);

            context.Add(new Review() { CustomerId = customerId });

            context.SaveChanges();
        }

        private static void SaveOrder(ShopDbContext context, string arguments)
        {
            int customerId = int.Parse(arguments);

            context.Add(new Order { CustomerId = customerId });

            context.SaveChanges();
        }

        private static void Register(ShopDbContext context, string input)
        {
            string[] parts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0];
            int salesmanId = int.Parse(parts[1]);

            context.Add(new Customer
            {
                Name = name,
                SalesmanId = salesmanId
            });

            context.SaveChanges();
        }

        private static void ClearDatabase(ShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void InsertCustomerData()
        {

        }

        private static void FillSalesmen(ShopDbContext context)
        {
            string[] salesmansNames = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var salesmanName in salesmansNames)
            {
                context.Salesman.Add(new Salesman()
                {
                    Name = salesmanName
                });
            }

            context.SaveChanges();
        }
    }
}
