using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Google
{
    public class Child
    {
        public Child(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
