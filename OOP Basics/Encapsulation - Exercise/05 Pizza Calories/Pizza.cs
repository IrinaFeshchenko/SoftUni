namespace _05_Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string pizzaName;
        private Dough testo;
        private List<Topping> toppingList;
        private int numberOfToppings;

        public Pizza()
        {
            this.toppingList = new List<Topping>();
        }
        public Pizza(string pizzaName)
        {
            this.PizzaName = pizzaName;
            this.toppingList = new List<Topping>();
        }

        public string PizzaName
        {
            get
            {
                return this.pizzaName;
            }
            set
            {
                if (value.Length < 15 && String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.pizzaName = value;
            }
        }

        public Dough Testo
        {
            get => testo;
            set
            {
                this.testo = value;
            }
        }

        public int NumberOfToppings
        {
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.numberOfToppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppingList.Add(topping);
        }

        public double GetToppingsCalories()
        {
            double totalCalories = 0;

            if (toppingList != null)
            {
                foreach (var toping in toppingList)
                {
                    totalCalories += toping.CalculateCalories();
                }
            }

            return totalCalories;
        }

        public double GetTotalCalories()
        {
            double totalCalories=0;

            if (testo!=null)
            {
                totalCalories += testo.CalculateCalories();
            }

            if (toppingList!=null)
            {
                foreach (var toping in toppingList)
                {
                    totalCalories += toping.CalculateCalories();
                }
            }

            return totalCalories;
        }
    }
}
