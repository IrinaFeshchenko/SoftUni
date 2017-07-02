using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Family_Tree
{
    public class Person
    {
        public Person()
        {
            Parents = new List<Record>();
            Children = new List<Record>();
        }

        public Person(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            Parents = new List<Record>();
            Children = new List<Record>();
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
        public List<Record> Parents{ get; set; }
        public List<Record> Children { get; set; }

        public void AddPrent(Record parent)
        {
            if (!Parents.Any(r=>r.Equals(parent)))
            {
                Parents.Add(parent); 
            }
        }

        public void AddChild(Record child)
        {
            if (!Children.Any(r=>r.Equals(child)))
            {
                Children.Add(child);
            }
        }
    }
}
