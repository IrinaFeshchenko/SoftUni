namespace Mordor_s_Cruelty_Plan
{
    using Mordor_s_Cruelty_Plan.Factories;
    using Mordor_s_Cruelty_Plan.Models;
    using System;

    public class Startup
    {
        static void Main()
        {
            var foodFactory = new FoodFactory();
            var moodFactory = new MoodFactory();

            var gandalf = new Gandalf();

            string[] inputFood = Console.ReadLine().Split(new[] { ' ','\t','\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var food in inputFood)
            {
                Food foodEaten = foodFactory.GetFood(food);
                gandalf.Eat(foodEaten);
            }

            int totalHappinessPoints = gandalf.GetHappinessPoints();
            Mood currentMood = moodFactory.GetMood(totalHappinessPoints);

            Console.WriteLine(totalHappinessPoints);
            Console.WriteLine(currentMood);
        }
    }
}
