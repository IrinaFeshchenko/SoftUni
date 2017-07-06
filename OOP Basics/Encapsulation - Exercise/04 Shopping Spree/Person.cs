using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(money)} cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuyProduct (Product product)
        {
            if (this.Money<product.Price)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.bag.Add(product);
            this.Money -= product.Price;
        }
    }
}
