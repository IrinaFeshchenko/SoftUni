using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Car_Salesman
{
    public class Engine
    {
        public Engine()
        {
        }

        public Engine(string model, string power, string displacement, string efficiency)
        {
            Model = model;
            this.power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }

        public string power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
