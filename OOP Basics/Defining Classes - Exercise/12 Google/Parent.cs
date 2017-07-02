using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Google
{
    public class Parent
    {
        public Parent(string name, string birthday)
        {
            Name = name;
            this.birthday = birthday;
        }

        public string Name { get; set; }
        public string birthday { get; set; }
    }
}
