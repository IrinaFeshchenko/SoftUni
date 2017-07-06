namespace _05_Pizza_Calories
{
    using System;

    public class Program
    {
        static void Main()
        {
            var data = Console.ReadLine().Split();
            var pizza = new Pizza();
            bool doughrow = false;
            bool pizzarow = false;
            bool toppingrow = false;

            if (data[0] == "Pizza")
            {
                pizzarow = true;
                pizza = ReadPizzaInfo(data);
                data = Console.ReadLine().Split();
            }

            if (data[0] == "Dough")
            {
                doughrow = true;
                pizza.Testo = ReadDoughInfo(data);
                data = Console.ReadLine().Split();
            }

            while (true)
            {
                if (data[0] == "END") break;

                if (data[0] == "Topping")
                {
                    toppingrow = true;
                    pizza.AddTopping(ReadToppingsInfo(data));
                }

                data = Console.ReadLine().Split();
            }

            if (pizzarow)
            {
                if (!string.IsNullOrEmpty(pizza.PizzaName))
                {
                    Console.WriteLine($"{pizza.PizzaName} – {pizza.GetTotalCalories():f2} Calories.");
                }
            }
            else if (doughrow)
            {
                Console.WriteLine($"{pizza.Testo.CalculateCalories():f2}");
                if (toppingrow)
                {
                    Console.WriteLine($"{pizza.GetToppingsCalories():f2}");
                }
            }
        }

        private static Topping ReadToppingsInfo(string[] data)
        {
            string toppingName = data[1];
            double toppingWeight = double.Parse(data[2]);

            try
            {
                var topping = new Topping(toppingName, toppingWeight);
                return topping;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
            return null;
        }

        private static Dough ReadDoughInfo(string[] data)
        {
            string keyWord = data[0];
            string flourType = data[1];
            string bakeTech = data[2];
            double weight = double.Parse(data[3]);

            try
            {
                var testo = new Dough(flourType, bakeTech, weight);
                return testo;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
            return null;
        }

        private static Pizza ReadPizzaInfo(string[] data)
        {
            string pizzaName = data[1];
            int numberOfToppings = int.Parse(data[2]);

            try
            {
                var pizza = new Pizza(pizzaName);
                pizza.NumberOfToppings = numberOfToppings;
                return pizza;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
            return null;
        }
    }
}
