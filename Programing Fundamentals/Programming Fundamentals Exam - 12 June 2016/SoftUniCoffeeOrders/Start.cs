

namespace SoftUniCoffeeOrders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Order
    {
        public decimal CapsulePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime Date { get; set; }
        public long CapsuleCount { get; set; }
    }

    public class Start
    {
        static void Main()
        {
            long ordersCount = long.Parse(Console.ReadLine());
            List<Order> orders = ReadOrders(ordersCount);
            PrintResult(orders);
        }

        private static void PrintResult(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"The price for the coffee is: ${order.DiscountPrice:f2}");
            }
            Console.WriteLine($"Total: ${orders.Select(x=>x.DiscountPrice).Sum():f2}");
        }

        private static List<Order> ReadOrders(long ordersCount)
        {
            List<Order> orders = new List<Order>();

            for (int i = 0; i < ordersCount; i++)
            {
                decimal capsulePrice = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsuleCount = long.Parse(Console.ReadLine());
                long daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                decimal discountPrice = (daysInMonth * capsuleCount) * capsulePrice;

                Order order = new Order()
                {
                    CapsulePrice = capsulePrice,
                    Date = date,
                    CapsuleCount = capsuleCount,
                    DiscountPrice = discountPrice
                };

                orders.Add(order);
            }
            return orders;
        }
    }
}
