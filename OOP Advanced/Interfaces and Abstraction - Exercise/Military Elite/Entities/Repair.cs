using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military_Elite
{
    public class Repair: IRepair
    {
        public Repair(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public string Name { get; }

        public int Hours { get; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.Hours}";
        }
    }
}