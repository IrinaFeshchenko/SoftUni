namespace _08_Raw_Data
{
    using System.Collections.Generic;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            tires = new List<Tire>()
            {
                tire1,
                tire2,
                tire3,
                tire4
            };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire Tire1 { get; set; }
        public List<Tire> tires { get; set; }

    }
}
