namespace _07_Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            IDictionary<string,Car> cars = InputCars(n);

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "End") break;

                string carModel = args[1];
                double distanceTraveled = double.Parse(args[2]);

                if (!cars[carModel].Travel(distanceTraveled))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars.Select(x=>x.Value))
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }

        private static IDictionary<string,Car> InputCars(int n)
        {
            IDictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = args[0];
                double fuelAmmount = double.Parse(args[1]);
                double consumption = double.Parse(args[2]);
                double distancetraveled = 0;

                Car car = new Car(model, fuelAmmount, consumption, distancetraveled);
                cars.Add(model,car);
            }

            return cars;
        }
    }
}
