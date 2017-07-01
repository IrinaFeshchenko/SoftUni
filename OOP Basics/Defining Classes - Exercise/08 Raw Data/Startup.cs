namespace _08_Raw_Data
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
            int n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = args[0];
                int engineSpeed = int.Parse(args[1]);
                int enginePower = int.Parse(args[2]);

                int cargoWeight = int.Parse(args[3]);
                string cargoType = args[4];

                double tire1Pressure = double.Parse(args[5]);
                int tire1Age = int.Parse(args[6]);
                double tire2Pressure = double.Parse(args[5]);
                int tire2Age = int.Parse(args[6]);
                double tire3Pressure = double.Parse(args[5]);
                int tire3Age = int.Parse(args[6]);
                double tire4Pressure = double.Parse(args[5]);
                int tire4Age = int.Parse(args[6]);

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tire1 = new Tire(tire1Pressure, tire1Age);
                var tire2 = new Tire(tire2Pressure, tire2Age);
                var tire3 = new Tire(tire3Pressure, tire3Age);
                var tire4 = new Tire(tire4Pressure, tire4Age);

                var car = new Car(model, engine, cargo, tire1, tire2, tire3, tire4);
                cars.Add(car);
            }

            string printCommand = Console.ReadLine();

            var result = new List<Car>();

            if (printCommand == "fragile")
            {
                result = cars.Where(c => c.Cargo.Type == "fragile" &&
                                         c.tires.Any(t => t.pressure < 1))
                                         .ToList();


            }
            else if (printCommand == "flamable")
            {
                result = cars.Where(c => c.Cargo.Type == "flamable" &&
                         c.Engine.Power>250)
                         .ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
