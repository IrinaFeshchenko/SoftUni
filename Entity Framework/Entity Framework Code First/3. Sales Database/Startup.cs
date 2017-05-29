namespace _3.Sales_Database
{
    using System;

    class Startup
    {
        static void Main()
        {
            SalesContext context = new SalesContext();
            var s = context.Products;

            foreach (var item in s)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
