namespace _4.Products_Migration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new SalesContext();
            var pr = context.Products;

            foreach (var p in pr)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
