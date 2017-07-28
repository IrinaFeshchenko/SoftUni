namespace Ferrari_
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string driversName = Console.ReadLine();

            var ferrari = new Ferrari(driversName);

            Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.UseGasPedal()}/{ferrari.Driver}");

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
