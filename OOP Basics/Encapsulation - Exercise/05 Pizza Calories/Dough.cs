namespace _05_Pizza_Calories
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double CalculateCalories()
        {
            return Calculation();
        }

        private double Calculation()
        {
            //2 Калории на грам по дефоулт
            string flourType = this.flourType;
            double weight = this.weight;
            string bakingTechnique = this.bakingTechnique;
            double calories = 2 * weight;

            switch (flourType.ToLower())
            {
                case "white": calories *= 1.5; break;
                case "wholegrain": calories *= 1.0; break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy": calories *= 0.9; break;
                case "chewy": calories *= 1.1; break;
                case "homemade": calories *= 1.0; break;
            }

            return calories;
        }
    }
}
