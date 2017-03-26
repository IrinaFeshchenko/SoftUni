
namespace _1.Products_Shop
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new ProductsShopDBContext();
            context.Database.Initialize(true);
        }
    }
}
