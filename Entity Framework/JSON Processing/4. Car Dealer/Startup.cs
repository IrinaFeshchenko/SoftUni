namespace _4.Car_Dealer
{
    class Startup
    {
        static void Main()
        {
            var context = new CarsDBContext();
            context.Database.Initialize(true);
        }
    }
}
