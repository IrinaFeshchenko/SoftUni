namespace _10_Car_Salesman
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
            string noData = "n/a";
            Dictionary<string,Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var engine = new Engine();

                if (args.Count()==2)
                {
                    engine = new Engine(args[0],args[1], noData, noData);
                }
                else if (args.Count() == 3)
                {
                    if (int.TryParse(args[2],out int displacement))
                    {
                        engine = new Engine(args[0], args[1], args[2], noData);
                    }
                    else
                    {
                        engine = new Engine(args[0], args[1],noData,args[2]);
                    }
                }
                else if (args.Count() == 4)
                {
                    if (int.TryParse(args[2], out int displacement))
                    {
                        engine = new Engine(args[0], args[1], args[2], args[3]);
                    }
                    else
                    {
                        engine = new Engine(args[0], args[1], args[3], args[2]);
                    }
                }

                engines.Add(args[0],engine);
            }



            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var car = new Car();


                if (args.Count() == 2)
                {
                    car = new Car(args[0],engines[args[1]] , noData, noData);
                }
                else if (args.Count() == 3)
                {
                    if (int.TryParse(args[2], out int displacement))
                    {
                        car = new Car(args[0], engines[args[1]], args[2], noData);
                    }
                    else
                    {
                        car = new Car(args[0], engines[args[1]], noData, args[2]);
                    }
                }
                else if (args.Count() == 4)
                {
                    if (int.TryParse(args[2], out int displacement))
                    {
                        car = new Car(args[0], engines[args[1]], args[2], args[3]);
                    }
                    else
                    {
                        car = new Car(args[0], engines[args[1]] , args[3], args[2]);
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
