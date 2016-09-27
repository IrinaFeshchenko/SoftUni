

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    public class SalesReport
    {
        static void Main()
        {
            int z = 100;
            Console.WriteLine("{0:e}",z);
            int n = int.Parse(Console.ReadLine());

            Sale[] sales = new Sale[n];

            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }

            var towns = sales.Select(x => x.Town).Distinct().OrderBy(x=>x);

            foreach (var town in towns)
            {
                var sum = sales.Where(x=>x.Town == town).Select(x=>x.Price*x.Quantity).Aggregate((a,b)=>a+b);
                Console.WriteLine("{0} -> {1:f2}",town,sum);
            }
        }

        private static Sale ReadSale()
        {
            string[] args = Console.ReadLine().Split();
            Sale sale= new Sale();
            sale.Town = args[0];
            sale.Product = args[1];
            sale.Price = decimal.Parse(args[2]);
            sale.Quantity = decimal.Parse(args[3]);

            return sale;
        }
    }
}
