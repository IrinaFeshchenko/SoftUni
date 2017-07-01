using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Raw_Data
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            Age = age;
        }

        public double pressure { get; set; }
        public int Age { get; set; }
    }
}
