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
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
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
                    throw new ArgumentException("Name cannot be empty");
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
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;
            this.products.Add(product);
        }

        public override string ToString()
        {
            string product = string.Join(", ",this.products);
            if (string.IsNullOrEmpty(product))
            {
                product = "Nothing bought";
            }

            string name = this.Name;
            string result = $"{name} - {product}";
            return result;
        }
    }

    public class ShoppingSpree
    {
        public static void Main()
        {
            string[] tokens = Console.ReadLine().Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            CreateEntity<Person>(tokens,persons);

            tokens = Console.ReadLine().Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            CreateEntity<Product>(tokens, products);

            string line;
            while ((line = Console.ReadLine()).Trim() != "END")
            {
                string[] param = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string personName = param[0];
                string productName = param[1];
                Person person = persons[personName];
                Product product = products[productName];

                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in persons.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static void CreateEntity<T>(string[] token,Dictionary<string,T> collection)
        {
            foreach (var item in token)
            {
                string[] p = item.Split('=');
                string name = p[0];
                decimal money = decimal.Parse(p[1]);

                try
                {
                    T newEntity = (T)Activator.CreateInstance(typeof(T), new Object[] { name, money });
                    collection.Add(name, newEntity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
