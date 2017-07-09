using System;

namespace Mordor_s_Cruelty_Plan.Models
{
    public abstract class Food
    {
        private int happinessPoints { get; set; }

        public Food(int happinessPoints)
        {
            this.happinessPoints = happinessPoints;
        }

        internal int GetHappinessPoints()
        {
            return this.happinessPoints;
        }
    }
}
