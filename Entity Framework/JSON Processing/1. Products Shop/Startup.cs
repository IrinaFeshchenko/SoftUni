
using _1.Products_Shop.Models;

namespace _1.Products_Shop
{
    class Startup
    {
        static void Main()
        {
            var context = new ProductsShopDBContext();
            context.Database.Initialize(true);
        }
    }
}
