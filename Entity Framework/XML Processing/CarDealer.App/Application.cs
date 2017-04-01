namespace CarDealer.App
{
    using System;

    using Data;
    using Models;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.Initialize(true);
        }
    }
}
