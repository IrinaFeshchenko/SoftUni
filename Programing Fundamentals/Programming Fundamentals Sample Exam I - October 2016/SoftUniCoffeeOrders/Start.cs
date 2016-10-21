namespace SoftUniCoffeeOrders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            int orders = int.Parse(Console.ReadLine());

            decimal totalPrice = 0;
            for (int i = 0; i < orders; i++)
            {
                decimal capsulePrice = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                var price = (daysInMonth * capsulesCount) * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                totalPrice += price;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
