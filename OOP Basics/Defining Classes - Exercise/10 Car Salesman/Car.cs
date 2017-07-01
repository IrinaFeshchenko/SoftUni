using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Car_Salesman
{
    public class Car
    {
        public Car()
        {
        }

        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            this.weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string weight { get; set; }
        public string Color { get; set; }
    }
}
