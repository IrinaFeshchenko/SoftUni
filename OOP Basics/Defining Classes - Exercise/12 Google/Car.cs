using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Google
{
    public class Car
    {
        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public string Model { get; set; }
        public int Speed { get; set; }
    }
}
