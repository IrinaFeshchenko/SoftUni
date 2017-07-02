using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Google
{
    public class Person
    {
        public Person(string name)
        {
            Pokemons = new List<Pokemon>();
            Parents = new List<Parent>();
            Children = new List<Child>();
            this.Name = name;
        }

        public string Name { get; set; }
        public Car Car { get; set; }
        public Company company { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }
    }
}
