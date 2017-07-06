namespace _05_Pizza_Calories
{
    using System;

    public class Topping
    {
        private string toppingName;
        private double toppingWeight;

        public Topping(string toppingName, double toppingWeight)
        {
            this.ToppingName = toppingName;
            this.ToppingWeight = toppingWeight;
        }

        private string ToppingName
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));
                }
                this.toppingName = value;
            }
        }

        private double ToppingWeight
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", this.toppingName));
                }
                this.toppingWeight = value;
            }
        }

        public double CalculateCalories()
        {
            return Calculation();
        }

        private double Calculation()
        {
            string toppingName = this.toppingName;
            double weight = this.toppingWeight;

            double calories = 2 * weight; //2 Калории на грам по дехфолт

            switch (toppingName.ToLower())
            {
                case "meat": calories *= 1.2; break;
                case "veggies": calories *= 0.8; break;
                case "cheese": calories *= 1.1; break;
                case "sauce": calories *= 0.9; break;
            }

            return calories;
        }
    }
}
