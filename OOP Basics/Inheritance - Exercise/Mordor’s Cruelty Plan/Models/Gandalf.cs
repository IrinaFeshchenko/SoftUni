
namespace Mordor_s_Cruelty_Plan.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Gandalf
    {
        private List<Food> foodsEaten;

        public Gandalf()
        {
            foodsEaten = new List<Food>();
        }

        public void Eat(Food food)
        {
            this.foodsEaten.Add(food);
        }

        public int GetHappinessPoints()
        {
            return foodsEaten.Sum(f => f.GetHappinessPoints());
        }
    }
}
