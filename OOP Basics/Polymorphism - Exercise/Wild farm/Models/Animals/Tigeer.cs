
namespace Wild_farm.Models.Animals
{
    using System;

    public class Tigeer : Felime
    {
        public Tigeer(string name, string type, double weight, string livingRegion)
            : base(name, type, weight, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!\n{this.ToString()}");
            }
            base.EatFood(food);
        }
    }
}
