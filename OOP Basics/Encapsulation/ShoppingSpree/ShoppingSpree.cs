

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException();
                }

                name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }

            private set
            {
                cost = value;
            }
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> prooducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            prooducts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException();
                }

                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }

            set
            {
                if (value <=0)
                {
                    throw new ArgumentException();
                }
                money = value;
            }
        }

        public void Add(Product product)
        {
            this.prooducts.Add(product);
        }
    }

    public class ShoppingSpree
    {
        public static void Main()
        {
            string[] param = Console.ReadLine().Trim().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            foreach (var person in param)
            {
                string[] p = person.Split('=');
                persons.Add(new Person(p[0],decimal.Parse(p[1])));
            }

            param = Console.ReadLine().Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            foreach (var product in param)
            {
                string[] p = product.Split('=');
                products.Add(new Product(p[0], decimal.Parse(p[1])));
            }

            string command;
            while ((command = Console.ReadLine()).Trim() != "END")
            {
                string[] pr = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = pr[0];
                string product = pr[1];

                if (persons.Select(p => (p.Name == name)))
                {

                }
            }
        }
    }
}
