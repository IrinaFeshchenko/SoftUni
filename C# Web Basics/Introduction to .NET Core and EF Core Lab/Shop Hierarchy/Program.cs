namespace Shop_Hierarchy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (ShopDbContext context = new ShopDbContext())
            {
                ClearDatabase(context);
                FillSalesmen(context);
                SaveItems(context);
                ReadCommands(context);
                //PrintSalesmanWithCustomersCount(context);
                //PrintCustomersWithOrdersAndRevewCount(context);
                //PrintCustomerOrdersAndReviews(context);
                //PrintCustomerData(context);
                PrintCustomerOrdersWithMoreThanOneItem(context);
            }
        }

        private static void PrintCustomerOrdersWithMoreThanOneItem(ShopDbContext context)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = context.Orders.Count(o => o.CustomerId == customerId && o.ItemOrder.Count > 1);

            Console.WriteLine($"Orders : {customerData}");
        }

        private static void PrintCustomerData(ShopDbContext context)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = context.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {customerData.Name}");
            Console.WriteLine($"Orders count: {customerData.Orders}");
            Console.WriteLine($"Reviews count: {customerData.Reviews}");
            Console.WriteLine($"Salesman: {customerData.Salesman}");
        }

        private static void PrintCustomerOrdersAndReviews(ShopDbContext context)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = context.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Orders = c.Orders.Select(o => new
                    {
                        o.Id,
                        Items = o.ItemOrder.Count
                    })
                     .OrderBy(o => o.Id),
                    Reviews = c.Reviews.Count
                })
                .FirstOrDefault();

            foreach (var order in customerData.Orders)
            {
                Console.WriteLine($"order: {order.Id}: {order.Items} items");
            }

            Console.WriteLine($"reviews: {customerData.Reviews}");
        }

        private static void SaveItems(ShopDbContext context)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                decimal price = decimal.Parse(parts[1]);

                context.Add(new Item()
                {
                    Name = name,
                    Price = price
                });

                context.SaveChanges();
            }
        }

        private static void PrintCustomersWithOrdersAndRevewCount(ShopDbContext context)
        {
            var customerData = context
                .Customers
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
            var parts = arguments.Split(';');
            int customerId = int.Parse(parts[0]);
            int itemId = int.Parse(parts[1]);

            context.Add(new Review() { CustomerId = customerId, ItemId = itemId });

            context.SaveChanges();
        }

        private static void SaveOrder(ShopDbContext context, string arguments)
        {
            var parts = arguments.Split(';');
            var customerId = int.Parse(parts[0]);

            var order = new Order { CustomerId = customerId };

            for (int i = 1; i < parts.Length; i++)
            {
                order.ItemOrder.Add(new ItemOrder
                {
                    ItemId = int.Parse(parts[i])
                });
            }

            context.Add(order);

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
